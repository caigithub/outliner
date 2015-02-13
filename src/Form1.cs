using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;
using System.Threading;

namespace outliner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string file_name)
        {
            InitializeComponent();
            ApplySourceFile(file_name);
            this._tree_view.events.onDoubleClickNode += _onDoubleClickNode;
           // toggleSetting();
        }

        //===========================

        private void file_name_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\emc\\via";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ApplySourceFile(of.FileName);
            }
        }

        private void filter_click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            ApplySourceFile(files[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toggleSetting();
        }

        private void _expandLevel2_Click(object sender, EventArgs e)
        {
            _tree_view.expandAt(1);
        }

        private void _expandLevel3_Click(object sender, EventArgs e)
        {
            _tree_view.expandAt(2);
        }

        private void _expandLevel4_Click(object sender, EventArgs e)
        {
            _tree_view.expandAt(3);
        }

        private void _expandLevel5_Click(object sender, EventArgs e)
        {
            _tree_view.expandAt(4);
        }

        private void _expandAll_Click(object sender, EventArgs e)
        {
            _tree_view.expandAt(-1);
        }

        private void _onDoubleClickNode(Content c) {
            execute(_edit_command.Text, c);
        }
        //===========================

        private Content _analyzed_content = null;
        ScopeAnazlyzer _analyzer = new ScopeAnazlyzer();

        private ContentRestructor _restructor = new ContentRestructor();

        //===========================

        private void ApplySourceFile(string file_name)
        {
            button2.Text = Path.GetFileName(file_name);
            button2.Tag = file_name;

            try
            {
                _analyzed_content = _analyzer.analyze(File.ReadAllLines(file_name));
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void execute(string command, Content content) {
            string[] elements = command.Split(new char[] {' '} , StringSplitOptions.RemoveEmptyEntries);

            string exe_path = "";
            string argument = "";
            bool exe_scan_finished = false;

            foreach (string s in elements) {
                if (exe_scan_finished == false)
                {
                    exe_path = exe_path + " " + s;
                    if (File.Exists(exe_path) == true)
                    {
                        exe_scan_finished = true;
                    }
                }
                else {
                    argument = argument + " " + s;
                }
            }

            if (File.Exists(exe_path) == false) {
                MessageBox.Show( exe_path + "\r\n        does not exist");
                return;
            }

            argument = argument.Replace("$(file)", button2.Tag as string);
            argument = argument.Replace("$(line)", content.lineNumber.ToString());

            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = exe_path.Trim();
                proc.StartInfo.Arguments = argument.Trim();

                proc.Start();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            _restructor.filter = new TextFilter(_key.Text);

            Content new_content = new Content();
            if (_restructor.filter.isValid())
            {
                _restructor.handler = new ui.HightlightSelectionFormat();
            }
            else
            {
                _restructor.handler = new ui.BlankSelectionFormat();
            }

            _restructor.info();
            _restructor.restrcutre(_analyzed_content, new_content);

            new_content.info();

            _tree_view.clear();
            _tree_view.add(new_content);
        }


        private void toggleSetting()
        {
            int margin = 50;
            int offset = 1;

            if (_edit_command.Visible)
            {
                offset = margin * 1;

                _label_open_with.Visible = false;
                _edit_command.Visible = false;
            }
            else
            {
                offset = margin * -1;

                _label_open_with.Visible = true;
                _edit_command.Visible = true;
            }

            _toggle.Top = _toggle.Top + offset;
            _tree_view.Height = _tree_view.Height + offset;
        }
    }
}
