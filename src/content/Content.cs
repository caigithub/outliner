using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
 
    public class Content
    {
        public static Content createNode(string i_name, object i_data = null)
        {
            Content result = new Content();
            result.Name = i_name;
            result.putData(i_data);

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
            System.Diagnostics.Trace.WriteLine( indent + this.Name);
            foreach (Content n in this.Chidren)
            {
                n.info(indent + "  ");
            }
        }
    }
}
