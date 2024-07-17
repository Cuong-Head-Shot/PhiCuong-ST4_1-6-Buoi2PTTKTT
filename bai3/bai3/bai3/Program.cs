using System;
using System.Numerics;

public class LargeIntegerMultiplication
{
    public static BigInteger KaratsubaMultiply(BigInteger X, BigInteger Y)
    {
        // Chuyển X và Y về dương để tính toán
        BigInteger sign = BigInteger.One;
        if (X.Sign < 0)
        {
            X = BigInteger.Abs(X);
            sign = -sign;
        }
        if (Y.Sign < 0)
        {
            Y = BigInteger.Abs(Y);
            sign = -sign;
        }

        // Nếu X hoặc Y là số 0, trả về 0 ngay
        if (X.IsZero || Y.IsZero)
            return BigInteger.Zero;

        // Đếm số chữ số của X và Y
        int n = Math.Max(X.ToString().Length, Y.ToString().Length);
        if (n <= 2)
        {
            // Trường hợp cơ sở khi số chữ số là nhỏ, có thể sử dụng phép nhân truyền thống
            return X * Y * sign;
        }

        // Tính n/2
        int halfN = (n + 1) / 2;

        // Chia X và Y thành A, B, C, D
        BigInteger A = X / BigInteger.Pow(10, halfN);
        BigInteger B = X % BigInteger.Pow(10, halfN);
        BigInteger C = Y / BigInteger.Pow(10, halfN);
        BigInteger D = Y % BigInteger.Pow(10, halfN);

        // Tính các phép nhân theo thuật toán Karatsuba
        BigInteger AC = KaratsubaMultiply(A, C);
        BigInteger BD = KaratsubaMultiply(B, D);
        BigInteger AplusB_times_CplusD = KaratsubaMultiply(A + B, C + D);

        // Tính toán kết quả chính
        BigInteger result = AC * BigInteger.Pow(10, 2 * halfN) +
                             (AplusB_times_CplusD - AC - BD) * BigInteger.Pow(10, halfN) +
                             BD;

        return result * sign;
    }

    public static void Main(string[] args)
    {
        // Khởi tạo hai số nguyên lớn X và Y
        BigInteger X = BigInteger.Parse("1234");
        BigInteger Y = BigInteger.Parse("98763446");

        // Gọi hàm nhân hai số nguyên lớn bằng thuật toán Karatsuba
        BigInteger result = KaratsubaMultiply(X, Y);

        // In kết quả
        Console.WriteLine("Ket qua cua " + X + " * " + Y + " la: " + result);
    }
}
