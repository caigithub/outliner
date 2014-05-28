﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;

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

        }

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
            ApplyFilter(_key.Text);
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
        //===========================

        private void ApplySourceFile(string file_name)
        {
            button2.Text = Path.GetFileName(file_name);
            _analyzed_content = _analyzer.analyze(File.ReadAllLines(file_name));

            refresh();
        }

        private void ApplyFilter(string keyword)
        {
            _restructor.filter = new TextFilter(_key.Text);

            refresh();
        }

        //===========================

        private Content _analyzed_content = null;
        ScopeAnazlyzer _analyzer = new ScopeAnazlyzer();

        private ContentRestructor _restructor = new ContentRestructor();

        //===========================


        private void refresh()
        {
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


    }
}
