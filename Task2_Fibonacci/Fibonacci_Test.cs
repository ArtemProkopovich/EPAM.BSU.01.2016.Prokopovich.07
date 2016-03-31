using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2_Fibonacci
{
    [TestFixture]
    class Fibonacci_Test
    {
        [Test]
        public void EnumerableTest()
        {
            int[] FArray = new int[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            int i = 0;
            foreach (int num in Fibonacci.Fibbonacci())
            {
                if (i == FArray.Length)
                    break;
                Assert.AreEqual(FArray[i], num);
                i++;
            }
            i = 0;
            IEnumerator<int> e = Fibonacci.GetFibbonacci();
            while (e.MoveNext() && i<FArray.Length)
            {
                Assert.AreEqual(FArray[i], e.Current);
                i++;
            }
        }
    }
}
