using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
 
    public class Content
    {
        public static Content createNode(string i_name, int line_num, object i_data = null)
        {
            Content result = new Content();
            result.Name = i_name;
            result.putData(i_data);
            result.lineNumber = line_num;
            return result;
        }

        public void addChildren(IEnumerable<Content> ns)
        {
            if (ns != null)
            {
                foreach (Content n in ns)
                {
                    addChild(n);
                }
            }
        }

        public Content addChild(Content n)
        {
            if (n == null)
            {
                return null;
            }
            else
            {
                n.Parent = this;
                _chidren.Add(n);
                return n;
            }
        }

        public Content addSibling(Content n)
        {
            if (this.Parent == null)
            {
                return null;
            }

            return this.Parent.addChild(n);
        }

        public void shadowCopyTo(Content target) {
            if (target != null) {
                target.Name = this.Name;
                target.lineNumber = this.lineNumber;
                target._data = this._data;
            }
        }
        //================= properties ==============

        private List<Content> _chidren = new List<Content>();
        public List<Content> Chidren
        {
            get
            {
                return _chidren;
            }
        }

        private Content _parent = null;
        public Content Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
            }
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        private int _line_num = 0;
        public int lineNumber {
            get {
                return _line_num;
            }

            set {
                _line_num = value;
            }                                                 
        }

        private object _data = null;
        public void putData(object data)
        {
            _data = data;
        }

        public object getData()
        {
            return _data;
        }

        public void clearData()
        {
            _data = null;
        }

        public void info( string indent = "" )
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0}[{1}] {2}", indent, this.lineNumber, this.Name));
            foreach (Content n in this.Chidren)
            {
                n.info(indent + "  ");
            }
        }
    }
}
