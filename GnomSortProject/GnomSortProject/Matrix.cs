using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnomSortProject
{
    public class Matrix
    {
        private readonly int size;
        private readonly int value;

        public Matrix(int size, int value)
        {
            this.size = size;
            this.value = value;
        }

        public int[] CreateMatrix()
        {
            Random random = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(value);
            }
            return arr;
        }
    }
}
