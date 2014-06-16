using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using outliner;

namespace outlinerTest
{
    [TestClass]
    public class TestFixedSizeQueue
    {
        [TestMethod]
        public void FixedSizeQueue()
        {
            FixedSizeQueue<Content> testObject = new FixedSizeQueue<Content>(3);

            testObject.Enqueue( SampleData.contentNode() );
            testObject.Enqueue( SampleData.contentNode() );
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            testObject.Enqueue(SampleData.contentNode());
            Assert.AreEqual(3, testObject.Count, "current size = 3");

            testObject.Dequeue();
            Assert.AreEqual(2, testObject.Count, "current size = 2");
        }
    }
}
