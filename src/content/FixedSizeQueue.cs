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

        public new T Enqueue(T tb)
        {
            base.Enqueue(tb);

            if (this.Count > getMaxSize())
            {
                return this.Dequeue();
            }
            else {
                return default(T);
            }
        }
    }
}
