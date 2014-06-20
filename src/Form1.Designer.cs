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
            this._enableContext = new System.Windows.Forms.CheckBox();
            this._contextSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this._tree_view = new outliner.Tree();
            this._expandLevel2 = new System.Windows.Forms.Button();
            this._expandLevel3 = new System.Windows.Forms.Button();
            this._expandAll = new System.Windows.Forms.Button();
            this._expandLevel4 = new System.Windows.Forms.Button();
            this._expandLevel5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._contextSize)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(35, 72);
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
            this._filter_input.Size = new System.Drawing.Size(79, 24);
            this._filter_input.TabIndex = 4;
            this._filter_input.Text = "Filte";
            this._filter_input.UseVisualStyleBackColor = true;
            this._filter_input.Click += new System.EventHandler(this.filter_click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // _enableContext
            // 
            this._enableContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._enableContext.AutoSize = true;
            this._enableContext.Checked = true;
            this._enableContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this._enableContext.Location = new System.Drawing.Point(848, 91);
            this._enableContext.Name = "_enableContext";
            this._enableContext.Size = new System.Drawing.Size(54, 17);
            this._enableContext.TabIndex = 12;
            this._enableContext.Text = "Filte : ";
            this._enableContext.UseVisualStyleBackColor = true;
            this._enableContext.CheckedChanged += new System.EventHandler(this._enableContext_CheckedChanged);
            // 
            // _contextSize
            // 
            this._contextSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._contextSize.Location = new System.Drawing.Point(910, 89);
            this._contextSize.Name = "_contextSize";
            this._contextSize.Size = new System.Drawing.Size(43, 20);
            this._contextSize.TabIndex = 13;
            this._contextSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Lines Context";
            // 
            // _tree_view
            // 
            this._tree_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tree_view.Location = new System.Drawing.Point(43, 130);
            this._tree_view.Name = "_tree_view";
            this._tree_view.Size = new System.Drawing.Size(989, 460);
            this._tree_view.TabIndex = 2;
            // 
            // _expandLevel2
            // 
            this._expandLevel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandLevel2.Location = new System.Drawing.Point(1040, 130);
            this._expandLevel2.Name = "_expandLevel2";
            this._expandLevel2.Size = new System.Drawing.Size(30, 23);
            this._expandLevel2.TabIndex = 15;
            this._expandLevel2.Text = "2";
            this._expandLevel2.UseVisualStyleBackColor = true;
            this._expandLevel2.Click += new System.EventHandler(this._expandLevel2_Click);
            // 
            // _expandLevel3
            // 
            this._expandLevel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandLevel3.Location = new System.Drawing.Point(1040, 159);
            this._expandLevel3.Name = "_expandLevel3";
            this._expandLevel3.Size = new System.Drawing.Size(30, 23);
            this._expandLevel3.TabIndex = 16;
            this._expandLevel3.Text = "3";
            this._expandLevel3.UseVisualStyleBackColor = true;
            this._expandLevel3.Click += new System.EventHandler(this._expandLevel3_Click);
            // 
            // _expandAll
            // 
            this._expandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandAll.Location = new System.Drawing.Point(1040, 246);
            this._expandAll.Name = "_expandAll";
            this._expandAll.Size = new System.Drawing.Size(31, 23);
            this._expandAll.TabIndex = 17;
            this._expandAll.Text = "All";
            this._expandAll.UseVisualStyleBackColor = true;
            this._expandAll.Click += new System.EventHandler(this._expandAll_Click);
            // 
            // _expandLevel4
            // 
            this._expandLevel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandLevel4.Location = new System.Drawing.Point(1040, 188);
            this._expandLevel4.Name = "_expandLevel4";
            this._expandLevel4.Size = new System.Drawing.Size(30, 23);
            this._expandLevel4.TabIndex = 18;
            this._expandLevel4.Text = "4";
            this._expandLevel4.UseVisualStyleBackColor = true;
            this._expandLevel4.Click += new System.EventHandler(this._expandLevel4_Click);
            // 
            // _expandLevel5
            // 
            this._expandLevel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandLevel5.Location = new System.Drawing.Point(1040, 217);
            this._expandLevel5.Name = "_expandLevel5";
            this._expandLevel5.Size = new System.Drawing.Size(30, 23);
            this._expandLevel5.TabIndex = 19;
            this._expandLevel5.Text = "5";
            this._expandLevel5.UseVisualStyleBackColor = true;
            this._expandLevel5.Click += new System.EventHandler(this._expandLevel5_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this._filter_input;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 619);
            this.Controls.Add(this._expandLevel5);
            this.Controls.Add(this._expandLevel4);
            this.Controls.Add(this._expandAll);
            this.Controls.Add(this._expandLevel3);
            this.Controls.Add(this._expandLevel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._contextSize);
            this.Controls.Add(this._enableContext);
            this.Controls.Add(this._tree_view);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._filter_input);
            this.Controls.Add(this._key);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this._contextSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tree _tree_view;
        private System.Windows.Forms.TextBox _key;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _filter_input;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox _enableContext;
        private System.Windows.Forms.NumericUpDown _contextSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _expandLevel2;
        private System.Windows.Forms.Button _expandLevel3;
        private System.Windows.Forms.Button _expandAll;
        private System.Windows.Forms.Button _expandLevel4;
        private System.Windows.Forms.Button _expandLevel5;
    }
}

