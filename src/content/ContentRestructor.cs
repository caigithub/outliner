using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace outliner
{
    public interface ContentHandler
    {
        void handleSelectContent(Content content, TextFilter f);
        void handleContextContent(Content content, TextFilter f);
        void handleFilteredContent(Content content, TextFilter f);
        void handleSelectNodeParent(Content content, TextFilter f);
    }

    public class ContentRestructor
    {
        class EmptyContentHandler : ContentHandler
        {
            public void handleSelectContent(Content content, TextFilter f) { }
            public void handleContextContent(Content content, TextFilter f) { }
            public void handleSelectNodeParent(Content content, TextFilter f) { }
            public void handleFilteredContent(Content content, TextFilter f) { }
        }

        private TextFilter _filter = new TextFilter();

        public TextFilter filter
        {
            set
            {
                if (_filter != null)
                {
                    _filter = value;
                }
                else
                {
                    _filter = new TextFilter();
                }
            }

            get                                                           
            {
                return _filter;
            }
        }

        private ContentHandler h = new EmptyContentHandler();
        public ContentHandler handler
        {
            set
            {
                if (value == null)
                {
                    h = new EmptyContentHandler();
                }
                else
                {
                    h = value;
                }
            }
        }

        private int _contextSize = 3;
        public int contextSize
        {
            get {
                return _contextSize;
            }

            set {
                _contextSize = value;
            }
        }

        private bool _enableContextConstrain = true;
        public bool enableContextConstrain
        {
            get {
                return _enableContextConstrain;
            }

            set {
                _enableContextConstrain = value;
            }
        }

        public bool restrcutre(Content n, Content output)
        {
            if (n == null || output == null)
            {
                return true;
            }

            bool found_in_child = false;
            if (enableContextConstrain == true)
            {
                found_in_child = handleChildrenWithContextConstrain(n, output);
            }
            else {
                found_in_child = handleChildrenWithAllContext(n, output);
            }

            return handleCurrentNode(n, output, found_in_child);
        }

        private bool handleCurrentNode(Content n, Content output , bool found_in_child ) {
            n.shadowCopyTo(output);
            
            if (_filter == null || _filter.isMatch(n.Name))
            {
                h.handleSelectContent(output, _filter);
                return true;
            }

            if (found_in_child == true)
            {
                h.handleSelectNodeParent(output, _filter);
                return true;
            }

            h.handleContextContent(output, _filter);
            return false;
        }

        private bool handleChildrenWithAllContext(Content n, Content output) {
            bool found_in_child = false;

            foreach (Content c in n.Chidren)
            {
                Content new_c = new Content();
                if (restrcutre(c, new_c) == true)
                {
                    found_in_child = true;
                }
                
                output.addChild(new_c);
            }

            return found_in_child;
        }

        private Content generateFilteIndication() {
            Content new_content = new Content();
            new_content.Name = ".....";
            h.handleFilteredContent(new_content, _filter);
            return new_content;
        }

        private bool handleChildrenWithContextConstrain(Content n, Content output)
        {
            bool found_in_child = false;

            FixedSizeQueue<Content> previouseContextContent = new FixedSizeQueue<Content>(contextSize);
            int postConextContentCount = 0;
            int filteredContentCount = 0;

            foreach (Content c in n.Chidren)
            {
                Content new_c = new Content();

                if (restrcutre(c, new_c) == true)
                {
                    if (filteredContentCount > 0) {
                        output.addChild(generateFilteIndication());
                        filteredContentCount = 0;
                    }

                    while (previouseContextContent.Count > 0)
                    {
                        output.addChild(previouseContextContent.Dequeue());
                    }
                    output.addChild(new_c);

                    postConextContentCount = contextSize;

                    found_in_child = true;
                }
                else
                {
                    if (postConextContentCount > 0)
                    {
                        output.addChild(new_c);
                        postConextContentCount--;
                    }
                    else
                    {
                        if (previouseContextContent.Enqueue(new_c) != null)
                        {
                            filteredContentCount++;
                        }
                    }
                }
            }

            if (filteredContentCount > 0 || previouseContextContent.Count > 0)
            {
                previouseContextContent.Clear();
                output.addChild(generateFilteIndication());
                filteredContentCount = 0;
            }
            return found_in_child;
        }

        //====================================
    
        public void info()
        {
            if (_filter == null)
            {
                System.Diagnostics.Debug.WriteLine("== filter : null");
            }
            else
            {
                _filter.info();
            }
        }
    }
}
