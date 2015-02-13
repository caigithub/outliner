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

        public bool restrcutre(Content n, Content new_node)
        {
            if (n == null || new_node == null)
            {
                return true;
            }

            bool found_in_child = false;
            Content ellipsis = null;

            foreach (Content c in n.Chidren)
            {
                Content new_c = new Content();
                
                if (restrcutre(c, new_c) == true)
                {
                    new_node.addChild(new_c);
                    ellipsis = null;
                    found_in_child = true;
                }
                else
                {
                    if (ellipsis == null)
                    {
                        ellipsis = generateEllipsis();
                        new_node.addChild(ellipsis);
                    }

                    ellipsis.addChild(new_c);
                }
            }


            return handleCurrentNode(n, new_node, found_in_child );
        }

        //====================================
        private Content generateEllipsis()
        {
            Content new_content = new Content();
            new_content.Name = ".....";
            h.handleFilteredContent(new_content, _filter);
            return new_content;
        }

        private bool handleCurrentNode(Content n, Content new_node, bool found_in_child)
        {
            n.shadowCopyTo(new_node);

            if (_filter == null || _filter.isMatch(n.Name))
            {
                h.handleSelectContent(new_node, _filter);
                return true;
            }

            if (found_in_child == true)
            {
                h.handleSelectNodeParent(new_node, _filter);
                return true;
            }

            h.handleContextContent(new_node, _filter);
            return false;
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
