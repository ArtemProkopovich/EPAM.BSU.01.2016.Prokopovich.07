using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task5_Sort
{
    class SortTest
    {
        private int[] testList = new int[] {1, 2, 3, 4, 5, 7, 8, 9, 10, 11};
        private int[] testListS = new int[] {3, 5, 1, 4, 2, 11, 10, 8, 9, 7};
        [Test]
        public void BinarySearch_Test()
        {
            int[] testCopy = (int[]) testListS.Clone();
            Sorter.Sort(testCopy, (Comparison<int>) null);
            Assert.AreEqual(testCopy, testList);

            testCopy = (int[]) testListS.Clone();
            Sorter.Sort(testCopy, (x, y) => -1*x.CompareTo(y));
            Assert.AreEqual(testCopy, testList.Reverse());
        }
    }
}
