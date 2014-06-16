using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using outliner;

namespace outlinerTest
{
    [TestClass]
    public class TestScopeDefinition
    {
        [TestMethod]
        public void ScopeDefinition()
        {
            check("{", 0, 1);
            check("{}",0, 0);
            check("{}{",0, 1);
            check("{}}",-1, 0);
            check("{{",0, 2);
            check("{{{",0, 3);
            check("{{}",0, 1);

            check("}",-1, 0);
            check("}{",-1, 1);
            check("}{{",-1, 2);
            check("}{}",-1, 0);
            check("}}",-2, 0);
            check("}}{",-2, 1);
            check("}}}",-3, 0);
        }

        private void check(string lineContent, int expectedCurrentIndent, int expectedNextIndent) {
            checkResult(getDefinitionMatchResult(lineContent),
                         expectedCurrentIndent,
                         expectedNextIndent,
                         lineContent );
        }

        private ScopeMatchResult getDefinitionMatchResult(string inputLineContent) {
            ScopeDefinition scope = new ScopeDefinition();
            return scope.getIndent(inputLineContent);
        }

        private void checkResult( ScopeMatchResult result, int expectedCurrentIndent, int expectedNextIndent, string message)
        {
            Assert.AreEqual(result.nextLineIndent, expectedNextIndent, message + " IndenetResult.nextLineIndent");
            Assert.AreEqual(result.currentLineIndent, expectedCurrentIndent, message + " IndenetResult.currentLineIndent");
        }
    }
}
