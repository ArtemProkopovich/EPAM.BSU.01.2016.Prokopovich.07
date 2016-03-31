using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Fibonacci
{
    public static class Fibonacci
    {
        public static IEnumerable<int> Fibbonacci()
        {
            int prev = 1;
            int curr = 1;
            yield return prev;
            yield return curr;
            while (curr >= prev)
            {
                yield return curr + prev;
                int temp = curr;
                curr = curr + prev;
                prev = temp;
            }
        }

        public static IEnumerator<int> GetFibbonacci()
        {
            return Fibbonacci().GetEnumerator();
        }
    }
}
