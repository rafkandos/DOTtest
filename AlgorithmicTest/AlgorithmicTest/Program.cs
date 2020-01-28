using System;

namespace AlgorithmicTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Solution s = new Solution();
            int[] arr = new int[5] { 2, 1, 5, 3, 6 };
            int sol = s.solution(arr);

            Console.WriteLine(sol);
        }
    }

    public class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int i, j = 0, n = A.Length;
            if (A != null && n != 0)
            {
                Array.Sort(A);
                for (j = A[0], i = 0; i < n; i++, j++)
                {
                    //if (j == A[i]) continue;
                    //else return j;
                    if (j == A[i])
                    {
                        continue;
                    }
                    else
                    {
                        return j;
                    }
                }

                //if (i == n) return (A[0] == 2) ? 1 : ++A[--n]
                if (i == n)
                {
                    return (A[0] == 2) ? 1 : ++A[--n];
                }

            }
            //else return 1;
            else
            {
                return 1;
            }

            return j;
        }
    }
}
