using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace outliner.ui
{
    class NodeConvertor
    {
        //public static void add(Node n)
        //{
        //    if (n == null)
        //    {
        //        return;
        //    }

        //    TreeNode tree_node = new TreeNode();

        //    if (map(tree_node, n) == true)
        //    {
        //        _tree_control.Nodes.Add(tree_node);
        //    }
        //}

        public static bool map( Content n , TreeNode tree_node )
        {
            if (n == null)
            {
                return false;
            }

            tree_node.Tag = n;
            if (n.getData() != null)
            {
                (n.getData() as ui.Formatter).initNode(tree_node);
            }

            foreach (Content s_n in n.Chidren)
            {
                TreeNode new_node = new TreeNode();
                if (map( s_n, new_node) == true)
                {
                    tree_node.Nodes.Add(new_node);
                }
            }

            return true;
        }
    }
}
