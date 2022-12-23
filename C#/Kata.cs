using System;
using System.Linq;
public static class Kata
{
    public static int multiply(int a, int b)
    {
        return a * b;
    }
    public static bool IsLeapYear(int year)
    {
        return DateTime.IsLeapYear(year);
    }
    public static string EvenOrOdd(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
    public static int GetVowelCount(string str)
    {
        return str.ToCharArray().Where((e) => e == 'a' || e == 'e' || e == 'i' || e == 'o' || e == 'u').Count();
    }
    public static int MaxDiff(int[] lst)
    {
        return lst.Count() != 0 ? lst.Max() - lst.Min() : 0;
    }
    public static int SquareDigits(int n)
    {
        string result = "";
        for (int i = 0; i < Convert.ToString(n).Length; i++)
        {
            result += Math.Pow(Convert.ToInt64(Convert.ToInt64(Convert.ToString(n)[i].ToString())), 2);
        }
        return ((int)Convert.ToInt64(result));
    }
    public static string NumberToString(int num)
    {
        return num.ToString();
    }
    public static string Solution(string str)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new String(arr);
    }
    public static void Main()
    {
        Console.WriteLine(Solution("world"));
    }
}