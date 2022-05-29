using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var arr = GetRandomArray(10, 1, 50);
            Console.WriteLine("Вхідні дані: {0}", string.Join(", ", arr));
            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", BasicCountingSort(arr, 50)));
            Console.ReadLine();
        }
        
        static int[] BasicCountingSort(int[] array, int k)
        {
            var count = new int[k + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            } 

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }

            return array;
           
        }
        
        static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
        {
            var random = new Random();
            var randomArray = new int[arraySize];
            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }

            return randomArray;
        }
    }
}
