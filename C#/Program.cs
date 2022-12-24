using System;
using System.Linq;
using System.Collections.Generic;

public class Program
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
    public static string SortGiftCode(string code)
    {
        char[] arr = code.ToCharArray();
        Array.Sort(arr);
        return new String(arr);
    }
    public static int[] VowelIndices(string word)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < word.Length; i++)
        {
            if ("aeiouyAEIOUY".Contains(word[i]))
            {
                list.Add(i + 1);
            }
        }
        return list.ToArray();
    }

    public static string RepeatStr(int n, string s)
    {
        return string.Concat(Enumerable.Repeat(s, n));
    }
    public static int SumNoDuplicates(int[] arr)
    {
        List<int> list = arr.Where(i => arr.Where(j => j == i).Count() == 1).ToList();
        return list.Sum();
    }
    public static int Solution(int value)
    {
        return value < 0 ? 0 : Enumerable.Range(0, value).ToList().Where(e => e % 3 == 0 || e % 5 == 0).Sum();
    }
    public static int DigitalRoot(long n)
    {
        while (n.ToString().Length > 1)
        {
            n = n.ToString().Select(e => int.Parse(e.ToString())).Sum();
        }
        return (int)n;
    }

    public static string Assemble(string[] copies)
    {
        string[] result = new string[] { };
        for (int i = 0; i < copies.Count(); i++)
        {
            for (int j = 0; j < copies[i].Length; j++)
            {
                if (i == 0)
                {
                    result = copies[i].ToCharArray().Select(e => e.ToString()).ToArray();
                }
                if (result[j].Equals("*") && !copies[i].ElementAt(j).ToString().Equals("*"))
                {
                    result[j] = copies[i].ElementAt(j).ToString();
                }
            }
        }
        return String.Concat(result).Replace("*", "#");
    }
    public static void Main()
    {
        Console.WriteLine(Assemble(new string[] { "*ashtag ** *", "h*sht*g *> *", "has*tag -* *" })); // "hashtag -> #"
    }
}