using System;

public class MergeSortAlgorithm
{
    
    public static void MergeSort(int[] A, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2; 

            MergeSort(A, left, mid);        
            MergeSort(A, mid + 1, right);   

            Merge(A, left, mid, right);     
        }
    }

   
    private static void Merge(int[] A, int left, int mid, int right)
    {
       
        int n1 = mid - left + 1;
        int n2 = right - mid;

        
        int[] L = new int[n1];
        int[] R = new int[n2];

       
        for (int i = 0; i < n1; i++)
        {
            L[i] = A[left + i];
        }
        for (int j = 0; j < n2; j++)
        {
            R[j] = A[mid + 1 + j];
        }

      
        int p = 0;    
        int q = 0;    
        int k = left; 

        while (p < n1 && q < n2)
        {
            if (L[p] <= R[q])
            {
                A[k] = L[p];
                p++;
            }
            else
            {
                A[k] = R[q];
                q++;
            }
            k++;
        }

        
        while (p < n1)
        {
            A[k] = L[p];
            p++;
            k++;
        }

       
        while (q < n2)
        {
            A[k] = R[q];
            q++;
            k++;
        }
    }

    
    public static void Main(string[] args)
    {
        int[] A = { 12, 11, 13, 5, 6, 7 };
        int n = A.Length;

        Console.WriteLine("Mang ban dau:");
        PrintArray(A);

        MergeSort(A, 0, n - 1);

        Console.WriteLine("\nMang sau khi sap xep Merge Sort:");
        PrintArray(A);
    }

    
    private static void PrintArray(int[] A)
    {
        foreach (var item in A)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
