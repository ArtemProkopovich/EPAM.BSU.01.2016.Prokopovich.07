using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4_BinarySearch
{
    [TestFixture]
    class Search_Test
    {

        private List<int> testList = new List<int>() {1, 2, 3, 4, 5, 7, 8, 9, 10, 11};
        [Test]
        [TestCase(5,Result =4)]
        [TestCase(1, Result = 0)]
        [TestCase(11, Result = 9)]
        [TestCase(13, Result = null)]
        [TestCase(0, Result = null)]
        [TestCase(6, Result = null)]
        public int? BinarySearch_Test(int num)
        {
            int? r1 = testList.CustomBinarySearch(num, (Comparison<int>)null);
            return r1;
        }
    }
}
