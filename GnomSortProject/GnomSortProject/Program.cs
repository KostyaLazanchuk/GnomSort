using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GnomSortProject
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int size = 1000;
            int value = 10000;
            int numThreads = 16;

            ParallelResult(size, value, numThreads);
            //StandartResult(size, value);
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("]");
        }

        static void ParallelResult(int size, int value, int numThreads)
        {

            Matrix matrix = new Matrix(size, value);
            int[] arr = matrix.CreateMatrix();

            ParallelAlgorithm algorithm = new ParallelAlgorithm(numThreads, arr);

            Console.WriteLine("Original array:");
            PrintArray(arr);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Sorting array using GnomSortParallel...");
            algorithm.SortParallel(arr, numThreads);
            stopwatch.Stop();

            Console.WriteLine("Sorted array:");
            PrintArray(arr);
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        }

        static void StandartResult(int size, int value)
        {
            Matrix matrix = new Matrix(size, value);
            int[] arr = matrix.CreateMatrix();
            int[] resultArr = new int[arr.Length];

            Algorithm algorithm = new Algorithm(value, arr);

            Console.WriteLine("Original array:");
            PrintArray(arr);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Sorting array using GnomSort...");
            resultArr = algorithm.GnomeSort(arr);
            stopwatch.Stop();
            PrintArray(resultArr);
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        }
    }
}
