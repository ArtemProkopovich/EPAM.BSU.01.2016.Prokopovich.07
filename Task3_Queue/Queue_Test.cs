using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3_Queue
{
    [TestFixture]
    class Queue_Test
    {
        [Test]
        public void QueueEnumerableTest()
        {
            int[] FArray = new int[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89};
            int i = 0;
            CustomQueue<int> queue = new CustomQueue<int>();
            foreach (int num in FArray)
            {
                queue.Enqueue(num);
            }
            Assert.AreEqual(queue.Count, 11);
            foreach (int num in queue)
            {
                if (i == FArray.Length)
                    break;
                Assert.AreEqual(num, FArray[i]);
                i++;
            }

            int n = queue.Dequeue();
            Assert.AreEqual(n, 1);
            n = queue.Peek();
            Assert.AreEqual(n, 1);
            n = queue.Dequeue();
            Assert.AreEqual(n, 1);
            Assert.AreEqual(queue.Count, 9);
        }
    }

}
