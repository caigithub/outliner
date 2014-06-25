using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using outliner.ui;

namespace outliner
{
    public partial class Tree : UserControl
    {
        public Tree()
        {
            InitializeComponent();

            _tree_control.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _tree_control.DrawNode += _tree_control_DrawNode;
        }

        public TreeEvents events = new TreeEvents();

        //===============

        void _tree_control_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Content n = (e.Node.Tag as Content);
            if (n != null)
            {
                if (n.getData() != null)
                {
                    (n.getData() as ui.Formatter).draw(e.Bounds, e.Graphics, this.Font,
                        (e.State & TreeNodeStates.Selected) != (TreeNodeStates)0);
                }
                else
                {
                    e.DrawDefault = true;
                }
            }
        }

        //===============
        public void expandAt(int level)
        {
            if (level <= 0)
            {
                _tree_control.ExpandAll();
            }
            else
            {
                expandAt(_tree_control.Nodes, level);
            }
        }

        private void expandAt(TreeNodeCollection nodes, int level)
        {
            if (nodes == null)
            {
                return;
            }

            foreach (TreeNode n in nodes)
            {
                if (level <= 0)
                {
                    n.Collapse();
                }
                else
                {
                    n.Expand();
                    expandAt(n.Nodes, level - 1);
                }
            }
        }

        public void add(Content n)
        {
            if (n == null)
            {
                return;
            }

            TreeNode tree_node = new TreeNode();

            if (NodeConvertor.map(n, tree_node) == true)
            {
                _tree_control.Nodes.Add(tree_node);
            }
        }

        public void clear()
        {
            _tree_control.Nodes.Clear();
        }

        private void _tree_control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode clickedNode = this._tree_control.GetNodeAt(e.X, e.Y);
            if (clickedNode != null)
            {
                events.triggerOnDoubleClickNode(clickedNode.Tag as Content);
            }
        }

    }
}
