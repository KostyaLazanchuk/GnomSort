using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnomSortProject
{
    public class Algorithm
    {
        private int maxValue;
        private int[] arr;

        public Algorithm(int maxValue, int[] arr)
        {
            this.maxValue = maxValue;
            this.arr = arr;
        }
        static void Swap(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }
        public int[] GnomeSort(int[] arr)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < arr.Length)
            {
                if (arr[index - 1] < arr[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref arr[index - 1], ref arr[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

            return arr;
        }
    }
}
