using System;

namespace QuickSort
{
    // Данная реализация алгоритма быстрой сортировки сильно отличается от представленной в книге, т.к. в C# нет возможности разбить массивы на подмассивы как в python.
    // В данном случае мы будем работать всегда с одним и тем же массивом, изменяя значения в нем по ссылке.
    class Program
    {
        // Данный метод производит обмен двух значений.
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // Данный метод находит опорный элемент
        static int Partition(int[] arr, int startIndex, int endIndex)
        {
            int pivot = startIndex - 1;
            for(int i = startIndex; i < endIndex; i++)
            {
                if(arr[i] < arr[endIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot],ref arr[i]);
                }
            }
            pivot++;
            Swap(ref arr[pivot],ref arr[endIndex]);
            return pivot;
        }
        // Данный метод содержит в себе базовый случай проверку индексов, необходимую для того чтобы быстрая сортировка не выпала в StackOverflow
        static int[] QuickSort(int[] arr, int startIndex, int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return arr;
            }
            int pivot = Partition(arr,startIndex,endIndex);
            QuickSort(arr,startIndex, pivot - 1);
            QuickSort(arr,pivot + 1, endIndex);

            return arr;
        }
        
        static int[] QuickSort(int[] arr)
        {
            return QuickSort(arr, 0, arr.Length - 1);
        }

        static void Main(string[] args)
        {
            int[] a = {7,5,9,3,8};
            QuickSort(a);
        }
    }
}
