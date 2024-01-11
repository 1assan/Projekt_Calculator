using System;

public class Squareroot
{
    public static double CalculateSquareroot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Kan inte kalkylera roten ur med ett negativt tal.");
        }

        return Math.Sqrt(number);
    }
}
