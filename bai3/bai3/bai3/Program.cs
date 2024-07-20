using System;
using System.Numerics;

public class LargeIntegerMultiplication
{
    public static BigInteger KaratsubaMultiply(BigInteger X, BigInteger Y)
    {
      
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
        if (X.IsZero || Y.IsZero)
            return BigInteger.Zero;
        int n = Math.Max(X.ToString().Length, Y.ToString().Length);
        if (n <= 2)
        {
            return X * Y * sign;
        }
        int halfN = (n + 1) / 2;
        BigInteger A = X / BigInteger.Pow(10, halfN);
        BigInteger B = X % BigInteger.Pow(10, halfN);
        BigInteger C = Y / BigInteger.Pow(10, halfN);
        BigInteger D = Y % BigInteger.Pow(10, halfN);
        BigInteger AC = KaratsubaMultiply(A, C);
        BigInteger BD = KaratsubaMultiply(B, D);
        BigInteger AplusB_times_CplusD = KaratsubaMultiply(A + B, C + D);
        BigInteger result = AC * BigInteger.Pow(10, 2 * halfN) +
                             (AplusB_times_CplusD - AC - BD) * BigInteger.Pow(10, halfN) +
                             BD;
        return result * sign;
    }
    public static void Main(string[] args)
    {
        BigInteger X = BigInteger.Parse("1234");
        BigInteger Y = BigInteger.Parse("98763446");
        BigInteger result = KaratsubaMultiply(X, Y);
        Console.WriteLine("Ket qua cua " + X + " * " + Y + " la: " + result);
    }
}
