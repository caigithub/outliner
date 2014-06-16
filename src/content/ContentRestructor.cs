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
            output.Name = n.Name;
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
            bool needPreviouseFilterIndication = false;

            int postConextContentCount = 0;
            bool needPostFilterIndication = false;

            foreach (Content c in n.Chidren)
            {
                Content new_c = new Content();

                if (restrcutre(c, new_c) == true)
                {
                    if (needPreviouseFilterIndication == true) {
                        output.addChild(generateFilteIndication());
                        needPreviouseFilterIndication = false;
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

                        if (postConextContentCount == 0 ) {
                            needPostFilterIndication = true;
                        }
                    }
                    else
                    {
                        if (previouseContextContent.Enqueue(new_c) != null)
                        {
                            needPreviouseFilterIndication = true;
                        }

                        if (needPostFilterIndication == true) {
                            output.addChild(generateFilteIndication());
                            needPostFilterIndication = false;
                        }
                    }
                }
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

        //====================================
    
        public void test()
        {
            Tester.info(this.GetType());


            this.enableContextConstrain = true;
            this.contextSize = 3;
            checkQuickFilterResult("aa", 2, 0);
            checkQuickFilterResult("_0", 2, 5);
            checkQuickFilterResult("_1", 2, 6);
            checkQuickFilterResult("_2", 2, 7);
            checkQuickFilterResult("_3", 2, 8);
            checkQuickFilterResult("_4", 2, 9);
            checkQuickFilterResult("_5", 2, 8);
            checkQuickFilterResult("_6", 2, 7);
            checkQuickFilterResult("_7", 2, 6);
            checkQuickFilterResult("_8", 2, 5);

            this.enableContextConstrain = false;
            this.contextSize = 7;
            checkQuickFilterResult("aa", 2, 9); 
            checkQuickFilterResult("_8", 2, 9);
        }

        private void checkQuickFilterResult(string filterString, 
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber)
        {
            this.filter = new TextFilter(filterString);
            Content output = new Content();
            restrcutre(sample(), output);


            Tester.check(expected_childerNumber, output.Chidren.Count, filterString + " - children count");
            Tester.check(expected_chidlrenChildrenNumber, output.Chidren[0].Chidren.Count, filterString + " - children children count");
        }

        private Content sample()
        {
            // root
            //      aa
            //          aa_child_1
            //          aa_child_2
            //          ....
            //          aa_child_9
            //      bb
            //          bb_child_1
            //          bb_child_2
            //          ....
            //          bb_child_9
            
            Content root = new Content();
            root.Name = "root";

            root.addChild( sampleContents("aa", 9));
            root.addChild(sampleContents("bb", 9));

            return root;
        }

        private Content sampleContents( string name , int child_number )
        {
            Content first = new Content();
            first.Name = name;

            for (int i = 0; i < child_number;  i++)
            {
                Content new_child = new Content();
                new_child.Name = "child_" + i.ToString();
                first.addChild(new_child);
            }

            return first;
        }
        
    }
}
