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
            int ScopeBeginCount = 0;
            int ScopeEndCount = 0;

            foreach (char c in s.ToCharArray())
            {
                if (c == getScopeBegin())
                {
                    ScopeBeginCount++;
                }

                if (c == getScopeEnd())
                {
                    if (ScopeBeginCount > 0)
                    {
                        ScopeBeginCount--;
                    }
                    else
                    {
                        ScopeEndCount--;
                    }
                }
            }

            return new ScopeMatchResult(ScopeEndCount, ScopeBeginCount);
        }
    }
}
