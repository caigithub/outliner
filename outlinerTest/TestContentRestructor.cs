using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using outliner;

namespace outlinerTest
{
    [TestClass]
    public class TestContentRestructor
    {
        [TestMethod]
        public void ContentRestructorSingleSelect()
        {
            checkContextResult("aa", 2, 1);

            for (int i = 0; i < 5; i++)
            {
                if (i != 1)
                {
                    checkContextResult("_" + i.ToString(), 2, 5 + i);
                    checkContextResult("_" + (SampleData.contentChildrenCount() - 1 - i).ToString(), 2, 5 + i);
                }
            }
        }

        [TestMethod]
        public void ContentRestructorMultiSelect()
        {
            //0 ...
            //1 cc
            //2 xx
            //3 cc
            //4 ...
            //5 
            //6 cc
            //7 xx
            //8 cc
            //9 ...
            checkContextResult("_2 _7", 2, 9, 1);

            //0 ...
            //1 cc
            //2 xx
            //3 cc
            //4 xx
            //5 cc
            //6 ...
            //7 
            //8 
            //9 
            checkContextResult("_2 _4", 2, 7, 1);

            //0 ...
            //1 cc
            //2 xx
            //3 cc
            //4 ...
            //5 ...
            //6 cc
            //7 xx
            //8 cc
            //9 xx
            //10 cc
            //11 ...
            //12
            //13
            checkContextResult("_2 _4", 2, 7, 1);
        }

        //[TestMethod]
        //public void ContentRestructorNoContext()
        //{
        //0 
        //1 ...
        //2 xx
        //3 ...
        //4 
        //5 
        //6 
        //7 
        //8 
        //9 
        //checkContextResult("_2", 2, 3, 0);

        //0 
        //1 ...
        //2 xx
        //3 ...
        //4 
        //5 
        //6 
        //7 xx
        //8 ...
        //9 
        //checkContextResult("_2 _7", 2, 5, 0);
        //}

        [TestMethod]
        public void ContentRestructorAllContext()
        {
            checkNoContextResult("aa", 2, SampleData.contentChildrenCount());
            checkNoContextResult("_8", 2, SampleData.contentChildrenCount());
        }

        private void checkContextResult(string filterString,
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber,
                                            int contextSize = 3)
        {
            checkResultContent(getContent(SampleData.contentTree(), contextSize, filterString),
                                expected_childerNumber,
                                expected_chidlrenChildrenNumber,
                                "filter " + filterString);
        }

        private void checkNoContextResult(string filterString,
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber)
        {
            checkResultContent(getContent(SampleData.contentTree(), filterString),
                                expected_childerNumber,
                                expected_chidlrenChildrenNumber,
                                "filter " + filterString);
        }

        private Content getContent(Content input, int contextSize, string filterString)
        {
            ContentRestructor restructor = new ContentRestructor();
            restructor.enableContextConstrain = true;
            restructor.contextSize = contextSize;
            restructor.filter = new TextFilter(filterString);

            Content output = new Content();
            restructor.restrcutre(input, output);

            return output;
        }

        private Content getContent(Content input, string filterString)
        {
            ContentRestructor restructor = new ContentRestructor();
            restructor.enableContextConstrain = false;
            restructor.filter = new TextFilter(filterString);

            Content output = new Content();
            restructor.restrcutre(input, output);

            return output;
        }

        private void checkResultContent(Content output,
                                            int expected_childerNumber,
                                            int expected_chidlrenChildrenNumber,
                                            string description)
        {
            output.info();
            Assert.AreEqual(expected_childerNumber, output.Chidren.Count, "children number, " + description);
            Assert.AreEqual(expected_chidlrenChildrenNumber, output.Chidren[0].Chidren.Count, "children children number, " + description);
        }
    }
}
