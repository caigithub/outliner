using System;
using System.Collections.Generic;
using System.Text;

namespace outliner.ui
{
    public class HightlightSelectionFormat  : ContentHandler
    {
        public void handleSelectContent(Content content, TextFilter f)
        {
            content.putData( new ui.NodeHighlightFormatter(content.Name, f.filterReg) );
        }

        public void handleFilteredcontent(Content content, TextFilter f)
        {
            content.putData( new ui.NormalFormatter(content.Name));
        }

        public void handleSelectNodeParent(Content content, TextFilter f)
        {
            content.putData(new ui.PathHighlightFormatter(content.Name));
        }
    }

    public class BlankSelectionFormat : ContentHandler
    {
        public void handleSelectContent(Content content, TextFilter f)
        {
            doHandle(content);
        }

        public void handleFilteredcontent(Content content, TextFilter f)
        {
            doHandle(content);
        }

        public void handleSelectNodeParent(Content content, TextFilter f)
        {
            doHandle(content);
        }

        private void doHandle(Content content)
        {
            content.putData(new ui.NormalFormatter(content.Name, true));
        }
    }
}
