using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
    public class FixedSizeQueue<T> : Queue<T>
    {
        public FixedSizeQueue(int size)
        {
            _max_size = size;
        }

        private int _max_size = 3;
        private int getMaxSize()
        {
            return _max_size;
        }

        public new void Enqueue(T tb)
        {
            base.Enqueue(tb);

            if (this.Count > getMaxSize())
            {
                this.Dequeue();
            }
        }

        //==================

        public void test()
        {
            Tester.info(this.GetType());

            FixedSizeQueue<Content> testObject = new FixedSizeQueue<Content>(3);
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());
            testObject.Enqueue(new Content());

            Tester.check(3, testObject.Count, "current size = 3");

            testObject.Dequeue();
            Tester.check(2, testObject.Count, "current size = 2");
        }
    }
}
