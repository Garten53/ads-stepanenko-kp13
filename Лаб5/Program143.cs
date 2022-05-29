using System;

namespace TestSort
{
    class Program
    {
        static int[] Array;
        static int N;
        static void Main(string[] args)
        {
            N = 10;
            Console.WriteLine("Input N: " + N.ToString());

            InitArray();
            PrintArray();
            Sorter(0, N / 2, 1);
            Sorter(N / 2, N, -1);
            PrintArray();


           

        }

        static private void InitArray()
        {
            Array = new int[N];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                Array[i] = rnd.Next(1, 100);
        }

        static private void PrintArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                Console.Write(Array[i].ToString() + " ");
            Console.WriteLine();
        }

        static private void Sorter(int iLeft, int iRight, int flag)
        {
            for (int i = 0; i < iRight - iLeft; i++)
                for (int j = iLeft; j < iRight - 1; j++)
                    if (flag * (Array[j] - Array[j + 1]) > 0)
                    {
                        int tmp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = tmp;
                    }
        }

    }
}
