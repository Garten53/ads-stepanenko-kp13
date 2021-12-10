using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp128
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 12, m = 12;
            int[,] matrix = new int[n, m];
            Random rnd = new Random();

            for (int n1 = 0; n1 < n; n1++)
            {
                for (int m1 = 0; m1 < m; m1++)
                {
                    matrix[n1, m1] = rnd.Next(-100, 200);
                    if (main_axis(n1, m1))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (second_axis(n1, m1, n))
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{matrix[n1, m1]}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            
            List<Point> main_ax = new List<Point>();
            List<Point> second_ax = new List<Point>();
            List<int> main_ax_val = new List<int>();
            List<int> second_ax_val = new List<int>();

            Console.WriteLine();
            for (int n1 = 0; n1 < n && n1 < m; n1++)
            {
                if (main_axis(n1, n1) && second_axis(n1, n1, n))
                    continue;
                Console.Write($"{matrix[n1, n1]}\t");
                main_ax.Add(new Point(n1, n1));
                main_ax_val.Add(matrix[n1, n1]);
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int n1 = 0; n1 < n && n1 < m; n1++)
            {
                if (main_axis(n1, n1) && second_axis(n1, n1, n))
                    continue;
                Console.Write($"{matrix[n - n1 - 1, n1]}\t");
                second_ax.Add(new Point(n - n1 - 1, n1));
                second_ax_val.Add(matrix[n - n1 - 1, n1]);
            }
            Console.WriteLine();
            Console.WriteLine();

            int[] main_ax_val_sort = ShakerSort(main_ax_val.ToArray(), false);
            int[] second_ax_val_sort = ShakerSort(second_ax_val.ToArray(), true);

            for (int i = 0; i < main_ax_val_sort.Length; i++)
            {
                matrix[main_ax[i].X, main_ax[i].Y] = main_ax_val_sort[i];
                matrix[second_ax[i].X, second_ax[i].Y] = second_ax_val_sort[i];
            }

            show_matrix(matrix);
            Console.ReadLine();

        }

        static void show_matrix(int[,] matrix)
        {
            for (int n1 = 0; n1 < matrix.GetLength(0); n1++)
            {
                for (int m1 = 0; m1 < matrix.GetLength(1); m1++)
                {
                    if (main_axis(n1, m1))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (second_axis(n1, m1, matrix.GetLength(0)))
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{matrix[n1, m1]}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        static bool main_axis(int n1, int m1)
        {
            return n1 == m1;
        }
        static bool second_axis(int n1, int m1, int n)
        {
            return m1 == n - n1 - 1;
        }

        //метод обміну елементів
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static bool NeedSwap(int e1, int e2, bool reverse)
        {
            if (e1 > e2 && !reverse)
                return true;
            if (e1 < e2 && reverse)
                return true;
            return false;
        }

        //сортування змішуванням
        static int[] ShakerSort(int[] array, bool reverse)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //прохід зліва направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (NeedSwap(array[j], array[j + 1], reverse))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //прохід справа наліво
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (NeedSwap(array[j - 1], array[j], reverse))
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //якщо обмінів не було
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
    }
}
