using System;

namespace SelectionSort
{
    class Program
    {
        // Данная реализация SelectionSort не такая как в книге. Это связанно с тем, что массивы в C# не поддерживают операцию pop.
        // Поэтому нет смысла возиться с двумя массивами и переносом значений из одного массива в другой. Для экономии памяти будем работать в одном массиве.
        static void Main(string[] args)
        {
            selectionSort(new int[]{2,4,21,5,2});
        }
        // O(n^2) - по времени
        // O(1) по памяти
        static int[] selectionSort(int[] arr)
        {
            for(int  i = 0; i < arr.Length; i++)
            {
                int smallestIndex = i;
                // Найдем индекс минимального значения в массиве.
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[smallestIndex] > arr[j]) smallestIndex = j;
                }
                // Поменяем найденный минимальный элемент с текущим элементом.
                int temp = arr[smallestIndex];
                arr[smallestIndex] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
    }
}
