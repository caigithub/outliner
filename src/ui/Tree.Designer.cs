namespace outliner
{
    partial class Tree
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            this._tree_control = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNodeTextIncludeChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tree_control
            // 
            this._tree_control.ContextMenuStrip = this.contextMenuStrip1;
            this._tree_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tree_control.FullRowSelect = true;
            this._tree_control.Location = new System.Drawing.Point(0, 0);
            this._tree_control.Name = "_tree_control";
            treeNode1.Name = "Node5";
            treeNode1.Text = "Node5";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Node1";
            treeNode3.Name = "Node6";
            treeNode3.Text = "Node6";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Node4";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeNode6.Name = "Node3";
            treeNode6.Text = "Node3";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Node0";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Node8";
            treeNode9.Name = "Node9";
            treeNode9.Text = "Node9";
            treeNode10.Name = "Node7";
            treeNode10.Text = "Node7";
            this._tree_control.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode10});
            this._tree_control.Size = new System.Drawing.Size(150, 150);
            this._tree_control.TabIndex = 0;
            
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tree_control);
            this.Name = "Tree";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _tree_control;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyNodeTextIncludeChildrenToolStripMenuItem;
    }
}
