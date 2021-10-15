using ConsoleApp1.Array;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]
            {
                7, -5, 5, -8, -6, 6, -4, 7, -8, -7
            };
            new _974().SubarraysDivByK(arr, 7);
            var list = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum % 7 == 0)
                    {
                        list.Add(arr[i..(j + 1)]);
                    }
                }
            }
            Console.WriteLine('s');
        }
    }
}
