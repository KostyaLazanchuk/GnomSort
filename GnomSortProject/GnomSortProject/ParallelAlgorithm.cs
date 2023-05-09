using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnomSortProject
{
    public class ParallelAlgorithm
    {
        private int maxValue;
        private int[] arr;

        public ParallelAlgorithm(int maxValue, int[] arr)
        {
            this.maxValue = maxValue;
            this.arr = arr;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Sort(int[] arr)
        {
            int i = 1, j = 2;
            while (i < arr.Length)
            {
                if (arr[i - 1] <= arr[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(arr, i - 1, i);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }

        public void SortParallel(int[] arr, int numThreads)
        {
            int blockSize = arr.Length / numThreads;

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numThreads; i++)
            {
                int start = i * blockSize;
                int end = (i == numThreads - 1) ? arr.Length : (i + 1) * blockSize;
                Task task = Task.Factory.StartNew(() => Sort(arr, start, end));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            for (int i = 1; i < numThreads; i++)
            {
                Merge(arr, 0, i * blockSize, (i + 1) * blockSize);
            }

            Merge(arr, 0, blockSize, arr.Length);
        }

        private static void Sort(int[] arr, int start, int end)
        {
            int i = start + 1, j = start + 2;
            while (i < end)
            {
                if (arr[i - 1] <= arr[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(arr, i - 1, i);
                    i--;
                    if (i == start)
                    {
                        i = j;
                        j++;
                    }
                }
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] temp = new int[end - start];
            int i = start, j = mid, k = 0;

            while (i < mid && j < end)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }

            while (i < mid)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }

            while (j < end)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            for (i = 0; i < k; i++)
            {
                arr[start + i] = temp[i];
            }
        }

    }
}
