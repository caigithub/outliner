namespace outliner
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._key = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._filter_input = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._tree_view = new outliner.Tree();
            this.SuspendLayout();
            // 
            // _key
            // 
            this._key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._key.Location = new System.Drawing.Point(43, 43);
            this._key.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._key.Name = "_key";
            this._key.Size = new System.Drawing.Size(938, 20);
            this._key.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(35, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 10);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // _filter_input
            // 
            this._filter_input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._filter_input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._filter_input.ForeColor = System.Drawing.SystemColors.ControlText;
            this._filter_input.Location = new System.Drawing.Point(987, 42);
            this._filter_input.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._filter_input.Name = "_filter_input";
            this._filter_input.Size = new System.Drawing.Size(79, 21);
            this._filter_input.TabIndex = 4;
            this._filter_input.Text = "Filte";
            this._filter_input.UseVisualStyleBackColor = true;
            this._filter_input.Click += new System.EventHandler(this.filter_click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(43, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(1023, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "<click to select a file>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.file_name_Click);
            // 
            // _tree_view
            // 
            this._tree_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tree_view.Location = new System.Drawing.Point(43, 110);
            this._tree_view.Name = "_tree_view";
            this._tree_view.Size = new System.Drawing.Size(1023, 482);
            this._tree_view.TabIndex = 2;
            // 
            // Form1
            // 
            this.AcceptButton = this._filter_input;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 619);
            this.Controls.Add(this._tree_view);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._filter_input);
            this.Controls.Add(this._key);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tree _tree_view;
        private System.Windows.Forms.TextBox _key;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _filter_input;
        private System.Windows.Forms.Button button2;
    }
}

