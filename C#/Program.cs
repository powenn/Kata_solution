using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

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

    public static int MinPermutation(int n)
    {
        bool postive = n > 0;
        int[] arr = Math.Abs(n).ToString().Select(e => int.Parse(e.ToString())).ToArray();
        Array.Sort(arr);
        int index = 0;
        while (arr[0] == 0 && n != 0)
        {
            index++;
            int temp = arr[0];
            arr[0] = arr[index];
            arr[index] = temp;
        }
        return int.Parse(String.Concat(arr.Select(e => e.ToString()))) * (postive ? 1 : -1);
    }


    public static string RemoveParentheses(string s)
    {
        List<string> parenthesesArr = new List<string>();
        string result = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s.ElementAt(i).Equals('('))
            {
                parenthesesArr.Add("(");
            }
            if (s.ElementAt(i).Equals(')'))
            {
                parenthesesArr.Remove("(");
                continue;
            }
            if (parenthesesArr.Count() == 0)
            {
                result += s[i];
            }
            Console.WriteLine(parenthesesArr.Count());
        }
        return result;
    }
    public static string ParseIPv6(string iPv6)
    {
        string separator = iPv6[4].ToString();
        return String.Concat(iPv6.Split(separator).Select(e => e.Select(f => int.Parse(f.ToString(), System.Globalization.NumberStyles.HexNumber)).Sum().ToString()).ToList());
    }

    public static int[] SortArray(int[] array)
    {
        List<int> evenList = new List<int>();
        List<int> indexList = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 != 0)
            {
                evenList.Add(array[i]);
                indexList.Add(i);
            }
        }
        evenList.Sort();
        for (int i = 0; i < indexList.Count(); i++)
        {
            array[indexList[i]] = evenList[i];
        }
        return array;
    }


    public static string GreekL33t(string str)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>(){
            {"A","α"},{"B","β"},{"D","δ"},{"E","ε"},
            {"I","ι"},{"K","κ"},{"N","η"},{"O","θ"},
            {"P","ρ"},{"R","π"},{"T","τ"},{"U","μ"},
            {"V","υ"},{"W","ω"},{"X","χ"},{"Y","γ"},
        };
        return String.Concat(str.ToUpper().Select(e => dict.ContainsKey(e.ToString()) ? dict[e.ToString()] : e.ToString().ToLower()));
    }

    public static string TitleCase(string title, string minorWords = "")
    {
        List<string> titleList = title.Split(" ").ToList().Select(e => e.ToLower()).ToList();
        List<string> minorList = (minorWords == "" || minorWords == null) ? new List<string>() : minorWords.Split(" ").ToList().Select(e => e.ToLower()).ToList();
        for (int i = 0; i < titleList.Count(); i++)
        {
            if (i == 0)
            {
                titleList[i] = toCapitalize(titleList[i]);
            }
            if (i != 0 && !minorList.Contains(titleList[i]))
            {
                titleList[i] = toCapitalize(titleList[i]);
            }
        }
        return String.Join(" ", titleList);
    }

    public static string toCapitalize(string s)
    {
        return s.Length <= 1 ? s.ToUpper() : s.ElementAt(0).ToString().ToUpper() + s.Substring(1).ToLower();
    }

    public static bool IsAlt(string word)
    {
        bool firstCharIsVowel = "aeiou".Contains(word.ElementAt(0));
        if (firstCharIsVowel)
        {
            for (int i = 1; i < word.Length; i++)
            {
                if (i % 2 != 0 && "aeiou".Contains(word.ElementAt(i)))
                {
                    return false;
                }
                if (i % 2 == 0 && !"aeiou".Contains(word.ElementAt(i)))
                {
                    return false;
                }
            }
        }
        else
        {
            for (int i = 1; i < word.Length; i++)
            {
                if (i % 2 != 0 && !"aeiou".Contains(word.ElementAt(i)))
                {
                    return false;
                }
                if (i % 2 == 0 && "aeiou".Contains(word.ElementAt(i)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static List<char> Remember(string str)
    {
        HashSet<char> charSet = new HashSet<char>();
        List<char> result = new List<char>();
        foreach (char c in str)
        {
            if (!charSet.Contains(c))
            {
                charSet.Add(c);
                continue;
            }
            if (charSet.Contains(c) && !result.Contains(c))
            {
                result.Add(c);
            }
        }
        return result;
    }

    public static int SquareDigitsSequence(int a0)
    {
        List<int> numList = new List<int>() { a0 };
        while (true)
        {
            if (numList.Last() == 1)
            {
                numList.Add(1);
                break;
            }
            int newNum = numList.Last().ToString().Select(e => int.Parse(e.ToString()) * int.Parse(e.ToString())).Sum();
            numList.Add(newNum);
            if (newNum == a0) break;
        }
        return numList.Count();
    }
    public static int pointsNumber(int radius)
    {
        int count = 0;
        for (int i = -radius; i <= radius; i++)
        {
            for (int j = -radius; j <= radius; j++)
            {
                if (i * i + j * j <= radius * radius)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public static int Score(int[] dice)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int sum = 0;
        foreach (int i in dice.ToHashSet())
        {
            dict.Add(i, dice.Where(e => e == i).Count());
        }
        foreach (int key in dict.Keys)
        {
            switch (key)
            {
                case 1:
                    sum += dict[key] >= 3 ? 1000 + (dict[key] - 3) * 100 : dict[key] * 100;
                    break;
                case 2:
                    sum += dict[key] >= 3 ? 200 : 0;
                    break;
                case 3:
                    sum += dict[key] >= 3 ? 300 : 0;
                    break;
                case 4:
                    sum += dict[key] >= 3 ? 400 : 0;
                    break;
                case 5:
                    sum += dict[key] >= 3 ? 500 + (dict[key] - 3) * 50 : dict[key] * 50;
                    break;
                case 6:
                    sum += dict[key] >= 3 ? 600 : 0;
                    break;
                default:
                    break;
            }
        }
        return sum;
    }

    public static string Shortcut(string input)
    {
        return String.Join("", input.Select(e => "aeiouAEIOU".Contains(e) ? "" : e.ToString()));
    }

    public static int[,] MatrixMultiplication(int[,] a, int[,] b)
    {
        int size = (int)Math.Sqrt(a.Length);
        int[,] result = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    class Sudoku
    {
        int rowSize;
        int columnSize;
        int[][] arr = new int[][] { };

        public Sudoku(int[][] sudokuData)
        {
            this.rowSize = sudokuData.Select(e => e.Length).Max();
            this.columnSize = sudokuData.Count();
            this.arr = new int[columnSize][];
            for (int i = 0; i < columnSize; i++)
            {
                arr[i] = sudokuData[i];
            }
        }

        private bool littleSquaresIsValid(int x, int y, int pad)
        {
            List<int> list = new List<int>();
            for (int i = x; i < x + pad; i++)
            {
                for (int j = y; j < y + pad; j++)
                {
                    list.Add(arr[i][j]);
                }
            }
            return list.ToHashSet().SetEquals(Enumerable.Range(1, rowSize).ToHashSet());
        }

        public bool IsValid()
        {
            int pad;
            if (columnSize != rowSize)
            {
                return false;
            }
            else
            {
                pad = (int)Math.Sqrt(columnSize);
            }
            for (int i = 0; i < columnSize; i++)
            {
                if (arr[i].Length != rowSize)
                {
                    return false;
                }
                if (!arr[i].ToHashSet().SetEquals(Enumerable.Range(1, rowSize).ToHashSet()))
                {
                    return false;
                }
                if (!Enumerable.Range(0, rowSize).Select(e => arr[e][i]).ToHashSet().SetEquals(Enumerable.Range(1, rowSize).ToHashSet()))
                {
                    return false;
                }
            }
            for (int i = 0; i < rowSize; i += pad)
            {
                for (int j = 0; j < rowSize; j += pad)
                {
                    if (!littleSquaresIsValid(i, j, pad))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public class Sudoku2
    {
        public static bool ValidateSolution(int[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!board[i].ToHashSet().SetEquals(Enumerable.Range(1, 9).ToHashSet()))
                {
                    return false;
                }
                if (!Enumerable.Range(0, 9).Select(e => board[e][i]).ToHashSet().SetEquals(Enumerable.Range(1, 9).ToHashSet()))
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    List<int> list = new List<int>();
                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            list.Add(board[k][l]);
                        }
                    }
                    if (!list.ToHashSet().SetEquals(Enumerable.Range(1, 9).ToHashSet()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public static void Main()
    {
        Console.WriteLine();
    }
}