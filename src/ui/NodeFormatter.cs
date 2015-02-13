using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace outliner.ui
{
    public interface Formatter
    {
        void initNode(TreeNode node);
        void draw(Rectangle rect, Graphics g, Font font, Boolean selected);
        Boolean needExpand();
    }

    //==========================
    //
    //
    public class NormalFormatter : Formatter
    {
        private Color _background_color = Color.White;
        private String _label = "";

        public NormalFormatter(Color color, String text)
        {
            _background_color = color;
            _label = text.Trim();
        }

        public NormalFormatter(String text)
        {
            _label = text.Trim();
        }

        private Boolean _expand = false;
        virtual public Boolean needExpand()
        {
            return _expand;
        }

        public NormalFormatter(String text, bool expand)
        {
            _label = text.Trim();
            _expand = expand;
        }

        virtual public void initNode(TreeNode node)
        {
            if (_expand == false)
            {
                node.Collapse();
            }
            else
            {
                node.Expand();
            }
        }

        public void draw(Rectangle rect, Graphics g, Font font, Boolean selected)
        {
            SizeF s = g.MeasureString(_label, font);
            g.FillRectangle(new SolidBrush(_background_color),
                             rect.Left,
                             rect.Top,
                             s.Width,
                             s.Height);

            Color label_color = Color.Black;
            g.DrawString(_label,
                            font,
                            new SolidBrush(label_color),
                            rect.Left,
                            rect.Top);
        }
    }

    public class PathHighlightFormatter : NormalFormatter
    {
        public PathHighlightFormatter(String text)
            : base(Color.Wheat, text)
        {
        }

        override public void initNode(TreeNode node)
        {
            node.Expand();
        }

        override public Boolean needExpand()
        {
            return true;
        }
    }

    public class NodeHighlightFormatter : Formatter
    {
        private Color _background_color = Color.Yellow;
        private String[] _label = { };

        public NodeHighlightFormatter(String text, String matcher)
        {
            _label = Regex.Split(text, matcher, RegexOptions.IgnoreCase);
        }

        public void initNode(TreeNode node)
        {
            node.Expand();
        }

        public Boolean needExpand()
        {
            return true;
        }

        public void draw(Rectangle rect, Graphics g, Font font, Boolean selected)
        {
            float start_pos = rect.Left;
            for (int i = 0; i < _label.Length; i++)
            {
                start_pos = DrawNormalText(_label[i], start_pos, rect.Top, font, g);
                i++;

                if (i <= _label.Length - 1)
                {
                    start_pos = DrawHightlightText(_label[i], start_pos, rect.Top, font, g);
                }
            }
        }

        private float DrawNormalText(string name, float x_pos, float y_pos, Font font, Graphics g)
        {
            return DrawText(name, x_pos, y_pos, font, Color.Black, g);
        }

        private float DrawHightlightText(string name, float x_pos, float y_pos, Font font, Graphics g)
        {
            return DrawText(name, x_pos, y_pos, new Font(font, FontStyle.Bold), Color.Red, g);
        }

        private float DrawText(string name, float x_pos, float y_pos, Font font, Color color, Graphics g)
        {
            SizeF s = g.MeasureString(name, font);
            g.FillRectangle(
                    new SolidBrush(_background_color),
                    x_pos,
                    y_pos,
                    s.Width,
                    s.Height
                );

            g.DrawString(name,
                        font,
                        new SolidBrush(color),
                        x_pos,
                        y_pos);

            return x_pos + s.Width;
        }
    }
}
