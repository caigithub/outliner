using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
    public class ScopeMatchResult
    {
        public ScopeMatchResult(int current, int next)
        {
            currentLineIndent = current;
            nextLineIndent = next;
        }

        private int _currentLineIndent = 0;
        public int currentLineIndent
        {
            get
            {
                return _currentLineIndent;
            }

            set
            {
                _currentLineIndent = value;
            }
        }

        private int _nextLineIndent = 0;
        public int nextLineIndent
        {
            get
            {
                return _nextLineIndent;
            }

            set
            {
                _nextLineIndent = value;
            }
        }

    }
}
