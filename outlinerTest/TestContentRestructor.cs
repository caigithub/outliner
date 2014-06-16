using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using outliner;

namespace outlinerTest
{
    [TestClass]
    public class TestContentRestructor
    {
        [TestMethod]
        public void ContentRestructor()
        {
            checkContextResult("aa", 2, 0);
            checkContextResult("_0", 2, 5);
            checkContextResult("_1", 2, 6);
            checkContextResult("_2", 2, 7);
            checkContextResult("_3", 2, 8);
            checkContextResult("_4", 2, 9);
            checkContextResult("_5", 2, 8);
            checkContextResult("_6", 2, 7);
            checkContextResult("_7", 2, 6);
            checkContextResult("_8", 2, 5);

            checkNoContextResult("aa", 2, 9); 
            checkNoContextResult("_8", 2, 9);
        }

        private void checkContextResult(    string filterString , 
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber)
        {
            checkResultContent(getContent( SampleData.contentTree(), 3, filterString),
                                expected_childerNumber,
                                expected_chidlrenChildrenNumber,
                                "filter " + filterString );
        }

        private void checkNoContextResult(  string filterString , 
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber)
        {
            checkResultContent(getContent( SampleData.contentTree(), filterString),
                                expected_childerNumber,
                                expected_chidlrenChildrenNumber,
                                "filter " + filterString );
        }

        private Content getContent( Content input, int contextSize, string filterString ){
            ContentRestructor restructor = new ContentRestructor() ;
            restructor.enableContextConstrain = true;
            restructor.contextSize = contextSize;
            restructor.filter = new TextFilter(filterString);

            Content output = new Content();
            restructor.restrcutre( input, output);

            return output;
        }

        private Content getContent( Content input , string filterString ){
            ContentRestructor restructor = new ContentRestructor() ;
            restructor.enableContextConstrain = false;
            restructor.filter = new TextFilter(filterString);

            Content output = new Content();
            restructor.restrcutre( input, output);

            return output;
        }

        private void checkResultContent(    Content output, 
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber ,
                                            string description ){
            Assert.AreEqual( expected_childerNumber, output.Chidren.Count , "children number, " + description );
            Assert.AreEqual( expected_chidlrenChildrenNumber, output.Chidren[0].Chidren.Count , "children children number, " + description );
        }




    }
}
