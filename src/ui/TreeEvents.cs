using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
    public class TreeEvents
    {
        public delegate void ContentHandler(Content content );

        public event ContentHandler onDoubleClickNode = null;
        public void triggerOnDoubleClickNode( Content content ) {
            if (onDoubleClickNode != null) {
                onDoubleClickNode( content );
            }
        }
    }
}
