using System;

class Program
{
    public static int[] Merge_Sorted_Arrays(int[] A, int[] B)
    {
        int[] New_Array = new int[A.Length + B.Length];

        int i = 0, j = 0, k = 0;

        // Merge arrays A and B into mergedArray while both arrays have elements left
        while (i < A.Length && j < B.Length)
        {
            if (A[i] <= B[j])
            {
              New_Array[k++] = A[i++];
            }
            else
            {
              New_Array[k++] = B[j++];
            }
        }

        // Copy remaining elements of A, if any
        while (i < A.Length)
        {
          New_Array[k++] = A[i++];
        }

        // Copy remaining elements of B, if any
        while (j < B.Length)
        {
          New_Array[k++] = B[j++];
        }

        return New_Array;
    }

    public static void Main(string[] args)
    {
        // Input array A
        Console.WriteLine("Enter elements of the first sorted array separated by spaces:");
        string inputA = Console.ReadLine();
        int[] A = Array.ConvertAll(inputA.Split(' '), int.Parse);

        // Input array B
        Console.WriteLine("Enter elements of the second sorted array separated by spaces:");
        string inputB = Console.ReadLine();
        int[] B = Array.ConvertAll(inputB.Split(' '), int.Parse);

        // Merge arrays A and B
        int[] Merged_Array = Merge_Sorted_Arrays(A, B);

        // Print the merged array
        Console.WriteLine("\nMerged Sorted Array:");
        foreach (var num in Merged_Array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}