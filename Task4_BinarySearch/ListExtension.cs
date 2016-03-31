using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BinarySearch
{
    public static class ListExtension
    {

        public static int? CustomBinarySearch<T>(this IList<T> list, T element, Comparison<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException("", nameof(list));
            if (element == null)
                throw new ArgumentNullException("", nameof(element));

            Comparison<T> comparison;
            if (comparer != null)
                comparison = comparer;
            else if (element is IComparable<T>)
                comparison = (x, y) => (x as IComparable<T>).CompareTo(y);
            else
                throw new InvalidOperationException("");
            int low = 0, high = list.Count;
            while (low < high)
            {
                int mid = (low + high)/2;
                if (comparison(element, list[mid]) == 0)
                {
                    return mid;
                }
                else
                {
                    if (comparison(element, list[mid]) < 0)
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }
            return null;
        }

        public static int? CustomBinarySearch<T>(this IList<T> list, T element, IComparer<T> comparer)
        {
            return CustomBinarySearch(list, element, comparer.Compare);
        }
    }
}
