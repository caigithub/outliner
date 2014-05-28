using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        public void Test(int current, int next , string message )
        {
            Tester.check(nextLineIndent, next, message + " IndenetResult.nextLineIndent");
            Tester.check(currentLineIndent, current, message + " IndenetResult.currentLineIndent");
        }
    }

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

        //====================================

        public void test()
        {
            Tester.info(this.GetType());

            getIndent("{").Test(0, 1 , "{");
            getIndent("{}").Test(0, 0, "{}");
            getIndent("{}{").Test(0, 1 , "{}{");
            getIndent("{}}").Test(-1, 0, "{}}");
            getIndent("{{").Test(0, 2, "{{");
            getIndent("{{{").Test(0, 3, "{{{");
            getIndent("{{}").Test(0, 1, "{{}");

            getIndent("}").Test(-1, 0, "}");
            getIndent("}{").Test(-1, 1, "}{");
            getIndent("}{{").Test(-1, 2, "}{{");
            getIndent("}{}").Test(-1, 0, "}{}");
            getIndent("}}").Test(-2, 0, "}}");
            getIndent("}}{").Test(-2, 1, "}}{");
            getIndent("}}}").Test(-3, 0, "}}}");
        }
    }
}
