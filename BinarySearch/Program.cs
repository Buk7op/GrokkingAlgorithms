using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1,2,3,3,4,5,6};
            //Несмотря на то, что для бинарного поиска не требуется использования сортировки, массив по которому будет осуществляться поиск должен быть отсортирован,
            //поэтому добавляем пузырьковую сортировку перед поиском, чтобы привести массив к готовому к бинарному поиску состоянию.
            int[] sortedArray = Sort(array);   
            Console.WriteLine(BinarySearch(sortedArray,6));  
        }
        
        static int BinarySearch(int[] array, int item)
        {
            int low = 0;
            int high = array.Length - 1;
            int guess = default; 
            while(low <= high)
            {
                int mid = (low + high) / 2;
                guess = array[mid];
                if (guess == item)
                {
                    return mid;
                }
                if (guess > item)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }


        static int[] Sort(int[] arr)
        {
            int temp = default;
            for (int write = 0; write < arr.Length; write++) {
                for (int sort = 0; sort < arr.Length - 1; sort++) {
                    if (arr[sort] > arr[sort + 1]) {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
