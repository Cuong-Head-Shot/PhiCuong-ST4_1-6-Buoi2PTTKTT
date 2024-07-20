using System;

public class BinarySearchAlgorithm
{
    public static int BinarySearch(int[] A, int n, int key)
    {
        int left = 0; 
        int right = n - 1; 

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (A[mid] == key)
            {
                return mid; 
            }
            else if (key < A[mid])
            {
                right = mid - 1; 
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1; 
    }

    public static void Main(string[] args)
    {
        int[] A = { 2, 4, 6, 8, 11, 12, 13, 14, 16, 18, 20 };
        int n = A.Length;
        int key = 10;

        int result = BinarySearch(A, n, key);

        if (result != -1)
        {
            Console.WriteLine("Phan tu đuoc tim thay tai vi tri trong mang");
        }
        else
        {
            Console.WriteLine("Khong tim thay phan tu trong mang");
        }
    }
}
