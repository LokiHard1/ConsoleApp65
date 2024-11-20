using System;

////задание 1
//class Program
//{
//    static void Main(string[] args)
//    {
//        int[][] arrays = {
//            new int[] { 34, 7, 23, 32, 5, 62, 89, 12, 48, 90, 26, 57, 39, 73, 2, 45, 79, 28, 63, 55, 76, 44, 67, 36, 13, 88, 84, 68, 38, 1, 72, 70, 27, 18, 30, 8, 29, 60, 9, 19, 71, 15, 10, 25, 49, 3, 4, 86, 16, 20 },
//            new int[] { 99, 2, 6, 8, 3, 1, 4, 5, 7, 10, 12, 15, 11, 13, 14, 20, 17, 18, 99, 22, 30, 29, 28, 26, 25, 24, 23, 21, 100, 32, 35, 38, 36, 39, 40, 45, 44, 43, 42, 41, 50, 48, 49, 55, 58, 60, 65, 66, 68, 69 },
//            new int[] { 7, 5, 3, 2, 9, 8, 6, 1, 4, 10, 13, 12, 15, 14, 11, 30, 29, 28, 27, 20, 19, 18, 17, 16, 25, 24, 23, 22, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 55, 54, 53, 52, 51, 99, 98, 99, 100, 200, 300 }
//        };

//        foreach (var array in arrays)
//        {
//            int bubbleIterations = BubbleSort(array.Clone() as int[]);
//            Console.WriteLine($"Количество итераций сортировки пузырьком: {bubbleIterations}");

//            int quickIterations = QuickSort(array.Clone() as int[], 0, array.Length - 1);
//            Console.WriteLine($"Количество итераций быстрой сортировки: {quickIterations}");
//        }
//    }

//    static int BubbleSort(int[] arr)
//    {
//        int n = arr.Length;
//        int iterations = 0;
//        for (int i = 0; i < n - 1; i++)
//        {
//            for (int j = 0; j < n - i - 1; j++)
//            {
//                iterations++;
//                if (arr[j] > arr[j + 1])
//                {
//                    int temp = arr[j];
//                    arr[j] = arr[j + 1];
//                    arr[j + 1] = temp;
//                }
//            }
//        }
//        return iterations;
//    }

//    static int QuickSort(int[] arr, int left, int right)
//    {
//        int iterations = 0;
//        if (left < right)
//        {
//            int pivot = Partition(arr, left, right);
//            iterations += QuickSort(arr, left, pivot - 1);
//            iterations += QuickSort(arr, pivot + 1, right);
//        }
//        return iterations + 1; 
//    }

//    static int Partition(int[] arr, int left, int right)
//    {
//        int pivot = arr[right];
//        int i = (left - 1);
//        for (int j = left; j < right; j++)
//        {
//            if (arr[j] <= pivot)
//            {
//                i++;
//                int temp = arr[i];
//                arr[i] = arr[j];
//                arr[j] = temp;
//            }
//        }
//        int temp1 = arr[i + 1];
//        arr[i + 1] = arr[right];
//        arr[right] = temp1;
//        return i + 1;
//    }
//}


//задание 2
class Program
{
    static void Main(string[] args)
    {
        int[][] arrays = {
            new int[] { 34, 7, 23, 32, 5, 62, 89, 12, 48, 90, 26, 57, 39, 73, 2, 45, 79, 28, 63, 55, 76, 44, 67, 36, 13, 88, 84, 68, 38, 1, 72, 70, 27, 18, 30, 8, 29, 60, 9, 19, 71, 15, 10, 25, 49, 3, 4, 86, 16, 20 },
            new int[] { 99, 2, 6, 8, 3, 1, 4, 5, 7, 10, 12, 15, 11, 13, 14, 20, 17, 18, 99, 22, 30, 29, 28, 26, 25, 24, 23, 21, 100, 32, 35, 38, 36, 39, 40, 45, 44, 43, 42, 41, 50, 48, 49, 55, 58, 60, 65, 66, 68, 69 },
            new int[] { 7, 5, 3, 2, 9, 8, 6, 1, 4, 10, 13, 12, 15, 14, 11, 30, 29, 28, 27, 20, 19, 18, 17, 16, 25, 24, 23, 22, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 55, 54, 53, 52, 51, 99, 98, 99, 100, 200, 300 }
        };

        foreach (var array in arrays)
        {
            int insertionIterations = InsertionSort(array.Clone() as int[]);
            Console.WriteLine($"Количество итераций сортировки вставками: {insertionIterations}");

            int shellIterations = ShellSort(array.Clone() as int[]);
            Console.WriteLine($"Количество итераций сортировки Шелла: {shellIterations}");
        }
    }

    static int InsertionSort(int[] arr)
    {
        int n = arr.Length;
        int iterations = 0;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                iterations++;
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
            iterations++; 
        }
        return iterations;
    }

    static int ShellSort(int[] arr)
    {
        int n = arr.Length;
        int gap = n / 2;
        int iterations = 0;

        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = arr[i];
                int j = i;

                while (j >= gap && arr[j - gap] > temp)
                {
                    iterations++;
                    arr[j] = arr[j - gap];
                    j -= gap;
                }
                arr[j] = temp;
                iterations++; 
            }
            gap /= 2;
        }
        return iterations;
    }
}