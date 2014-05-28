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
        void handleFilteredcontent(Content content, TextFilter f);
        void handleSelectNodeParent(Content content, TextFilter f);
    }

    public class ContentRestructor
    {
        class EmptyContentHandler : ContentHandler
        {
            public void handleSelectContent(Content content, TextFilter f) { }
            public void handleFilteredcontent(Content content, TextFilter f) { }
            public void handleSelectNodeParent(Content content, TextFilter f) { }
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

        public bool restrcutre(Content n, Content output)
        {
            if (n == null || output == null)
            {
                return true;
            }

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

            output.Name = n.Name;
            if (_filter == null || _filter.isMatch(n.Name))
            {
                h.handleSelectContent(output, _filter);
                return true;
            }

            if (found_in_child == true )
            {
                h.handleSelectNodeParent(output, _filter);
                return true;
            }

            h.handleFilteredcontent(output, _filter);
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

        //====================================

        public void test()
        {
            Tester.info(this.GetType());

            simpleTest("fuc", "", 0);
            simpleTest("roo", "root", 0);

            simpleTest("aa", "root", 1);
            simpleTest("bb", "root", 1);
            simpleTest("child", "root", 2);

            simpleTest("", "root", 2);
            simpleTest(" ", "root", 2);
        }

        private void simpleTest(string filterString, string rootName, int childerNumber)
        {
            this.filter = new TextFilter(filterString);
            Content output = new Content();
            restrcutre(sample(), output);
            Tester.check(rootName, output.Name, filterString + " - root name");
            Tester.check(childerNumber, output.Chidren.Count, filterString + " - children count");
        }

        private Content sample()
        {
            Content root = new Content();
            root.Name = "root";

            Content f_child = new Content();
            f_child.Name = "aa_child";
            root.addChild(f_child);

            Content s_child = new Content();
            s_child.Name = "bb_child";
            root.addChild(s_child);

            return root;
        }
    }
}
