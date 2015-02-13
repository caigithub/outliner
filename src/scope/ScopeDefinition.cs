using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace outliner
{
    public class ScopeDefinition
    {
        private char getScopeBegin()
        {
            return '{';
        }

        private char getScopeEnd()
        {
            return '}';
        }

        public ScopeMatchResult getIndent(string s)
        {
            int indentInCount = 0;
            int indentOutCount = 0;

            foreach (char c in s.ToCharArray())
            {
                if (c == getScopeBegin())
                {
                    indentInCount++;
                }

                if (c == getScopeEnd())
                {
                    if (indentInCount > 0)
                    {
                        indentInCount--;
                    }
                    else
                    {
                        indentOutCount--;
                    }
                }
            }

            if (indentOutCount < 0)
            {
                return new ScopeMatchResult(indentOutCount + 1, indentInCount - 1);
            }
            else
            {
                return new ScopeMatchResult(indentOutCount, indentInCount);
            }
        }
    }
}
