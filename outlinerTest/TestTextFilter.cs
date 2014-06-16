using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using outliner;

namespace outlinerTest
{
    [TestClass]
    public class TestTextFilter
    {
        [TestMethod]
        public void TextFilter()
        {
            string org = "Build started: Project: outliner, Configuration: Debug x86";

            string[] trueMatchesKeywrods = { "", " ", "start", "start outline", "startmm outline", "start outlinemm" };
            foreach (string r in trueMatchesKeywrods)
            {
                Assert.AreEqual( true,  getFilterResult(org, r));
            }

            string[] falseMatchesKeywords = { "startmm", "(", ")", "[", "]", "{", "}", "^", "$", "*", ".", "+", "?", "|" };
            foreach (string r in falseMatchesKeywords)
            {
                Assert.AreEqual(false, getFilterResult(org, r));
            }

            string repecialKeywords = "()[]{}^$*.+?|";
            string[] repecialMatches = { "(", ")", "[", "]", "{", "}", "^", "$", "*", ".", "+", "?", "|" };
            foreach (string r in repecialMatches)
            {
                Assert.AreEqual(true, getFilterResult(repecialKeywords, r));
            }
        }

        private Boolean getFilterResult(string org, string filter) {
            TextFilter textFilter = new TextFilter();
            textFilter.filterString = filter;
            return textFilter.isMatch(org);
        }
    }
}
