using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Queue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] instanceArray;

        private int count;

        private const int DefaultLength = 10; 

        public int Count => count;

        public CustomQueue()
        {
            count = 0;
            instanceArray = new T[DefaultLength];
        }

        public CustomQueue(int length)
        {
            this.count = 0;
            instanceArray = new T[length];
        }

        public void Enqueue(T item)
        {
            if (item == null)
                throw new ArgumentNullException("");
            if (count == instanceArray.Length)
            {
                ExpandArray();
            }
            instanceArray[count] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count <= 0) throw new InvalidOperationException("");
            T result = instanceArray[0];
            ShiftArray();
            count--;
            if (count < instanceArray.Length - DefaultLength)
                CompressArray();
            return result;
        }

        public T Peek()
        {
            if (count <= 0) throw new InvalidOperationException("");
            T result = instanceArray[0];
            return result;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (instanceArray[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            instanceArray = new T[DefaultLength];
            count = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = instanceArray[i];
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ExpandArray()
        {
            Array.Resize(ref instanceArray, instanceArray.Length + DefaultLength);
        }

        private void CompressArray()
        {
            Array.Resize(ref instanceArray, instanceArray.Length - DefaultLength);
        }

        private void ShiftArray()
        {
            for (int i = 1; i < count; i++)
            {
                instanceArray[i - 1] = instanceArray[i];
            }
        }

        private T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return instanceArray[index];
                else
                    throw new IndexOutOfRangeException("");
            }
        }
     
        private class CustomEnumerator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public CustomEnumerator(CustomQueue<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++currentIndex < queue.Count;
            }

            public void Reset()
            {
                throw new NotSupportedException("");
            }
        }
    }
}
