using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace outliner
{

    public class ScopeAnazlyzer
    {
        public ScopeAnazlyzer()
        {
        }

        private ScopeDefinition _handler = new ScopeDefinition();

        public Content analyze(string[] content )
        {
            System.Diagnostics.Trace.WriteLine( "=========  scope analyze ==========");


            Content result = new Content();
            result.Name = "=======================";

            Content current = result;

            ScopeMatchResult indent = new ScopeMatchResult(0, 0);

            foreach (string s in content)
            {
                string temp = s.Trim();
                

                if (temp.Length > 0)
                {
                    ScopeMatchResult newIndent = _handler.getIndent(temp);
                    indent.currentLineIndent = newIndent.currentLineIndent + indent.nextLineIndent;
                    indent.nextLineIndent = newIndent.nextLineIndent;

                    System.Diagnostics.Trace.WriteLine(String.Format("[{0:0000}] {1}", indent.currentLineIndent , temp));

                    Content new_node = Content.createNode(temp);
                    Content old_node = current;

                    if ( indent.currentLineIndent == 0)
                    {
                        current = indentKeep(current, new_node);
                    }
                    else if (indent.currentLineIndent > 0)
                    {
                        current = indentIn(current, new_node);
                    }
                    else
                    {
                        current = indentOut(current, new_node);
                    }
                    
                }
            }

            return result;
        }

        //=======================================================

        private Content indentIn(Content n, Content new_node)
        {
            if (n == null)
            {
                return null;
            }
            else
            {
                return n.addChild(new_node);
            }
        }

        private Content indentKeep(Content n, Content new_node)
        {
            if (n == null)
            {
                return null;
            }
            else
            {
                if (n.Parent == null)
                {
                    new_node.Name = "#" + new_node.Name;
                    return n.addChild(new_node);
                }
                else
                {
                    return n.addSibling(new_node);
                }
            }
        }

        private Content indentOut(Content n, Content new_node)
        {
            if (n == null)
            {
                return null;
            }
            else
            {
                if (n.Parent == null)
                {
                    new_node.Name = "##" + new_node.Name;
                    return n.addChild(new_node);
                }
                else if (n.Parent.Parent == null)
                {
                    new_node.Name = "#" + new_node.Name;
                    return n.Parent.addChild(new_node);
                }
                else
                {
                    return n.Parent.Parent.addChild(new_node);
                }
            }
        }

        private List<Content> _exclude_list = new List<Content>();

        /*
        private Node indentSiblingsToChildren(Node n, string text)
        {
            Node new_n = Node.createNode(text);
            _exclude_list.Add(new_n);

            if (n == null)
            {
                return new_n;
            }

            if (n.Parent == null)
            {
                new_n.addChild(n);
                return new_n;
            }
            else
            {
                new_n.addChildren(n.Parent.Nodes);
                n.Parent.Nodes.Clear();
                n.Parent.addChild(new_n);
                return new_n;
            }
        }
         * 
         * */
    }
}
