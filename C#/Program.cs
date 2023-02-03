using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using Interval = System.ValueTuple<int, int>;

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

    public class SnailSolution
    {
        enum Direction
        {
            right,
            down,
            left,
            up
        }

        public static int[] Snail(int[][] array)
        {
            int len = array.Count();
            List<int[]> indexs = new List<int[]>();
            Direction d = Direction.right;
            List<int> result = new List<int>();
            int x = 0;
            int y = 0;
            if (array.Length == 0 || array[0].Length == 0)
            {
                return result.ToArray();
            }
            void add()
            {
                indexs.Add(new int[] { x, y });
                result.Add(array[x][y]);
            }

            void moveRight()
            {
                add();
                y++;
            }

            void moveDown()
            {
                add();
                x++;
            }

            void moveLeft()
            {
                add();
                y--;
            }

            void moveUp()
            {
                add();
                x--;
            }

            while (result.Count() < len * len)
            {
                switch (d)
                {
                    case Direction.right:
                        if (indexs.Where(e => e.SequenceEqual(new int[] { x, y + 1 })).Count() != 0 || y + 1 >= len)
                        {
                            d = Direction.down;
                            moveDown();
                        }
                        else
                        {
                            moveRight();
                        }
                        break;
                    case Direction.down:
                        if (indexs.Where(e => e.SequenceEqual(new int[] { x + 1, y })).Count() != 0 || x + 1 >= len)
                        {
                            d = Direction.left;
                            moveLeft();
                        }
                        else
                        {
                            moveDown();
                        }
                        break;
                    case Direction.left:
                        if (indexs.Where(e => e.SequenceEqual(new int[] { x, y - 1 })).Count() != 0 || y - 1 < 0)
                        {
                            d = Direction.up;
                            moveUp();
                        }
                        else
                        {
                            moveLeft();
                        }
                        break;
                    case Direction.up:
                        if (indexs.Where(e => e.SequenceEqual(new int[] { x - 1, y })).Count() != 0 || x - 1 < 0)
                        {
                            d = Direction.right;
                            moveRight();
                        }
                        else
                        {
                            moveUp();
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", result));
            return result.ToArray();
        }
    }

    public class Pattern16
    {
        public static string Pattern(int n)
        {
            if (n < 1)
            {
                return "";
            }
            List<string> layers = new List<string>();
            for (int i = n; i > 0; i--)
            {
                layers.Add(String.Join("", Enumerable.Range(i + 1, n - i).Select(e => e % 10 + "").Reverse().ToList()) + String.Join("", Enumerable.Range(1, i).Select(e => i % 10 + "").ToList()));
            }
            return String.Join("\n", layers);
        }
    }

    public static long CountZeroes(int n)
    {
        return n <= 0 ? 0 : Enumerable.Range(1, n).Select(e => (e - 1) * ((long)(9 * Math.Pow(10, e - 2)))).Sum();
    }

    // public class ItemCounter<T>
    // {
    //     private readonly Dictionary<T, int> _itemCounts = new Dictionary<T, int>();

    //     public int DistinctItems
    //     {
    //         get { return _itemCounts.Count(); }
    //     }

    //     public int GetCount(T item)
    //     {
    //         if (item == null)
    //         {
    //             throw new ArgumentNullException();
    //         }
    //         if (!HasItem(item))
    //         {
    //             throw new InvalidOperationException();
    //         }
    //         return _itemCounts.GetValueOrDefault(item);
    //     }

    //     public bool HasItem(T item)
    //     {
    //         return _itemCounts.ContainsKey(item);
    //     }


    //     public ItemCounter(T[] items)
    //     {
    //         if (items == null)
    //         {
    //             throw new ArgumentNullException();
    //         }
    //         foreach (var item in items.ToHashSet())
    //         {
    //             _itemCounts.Add(item, items.Where(e => e!.Equals(item)).Count());
    //         }
    //     }
    // }

    public static string[] WordsToHex(string words)
    {
        string[] wordsArr = words.Split(" ").Select(e => e.PadRight(3)).ToArray();
        string[] result = new string[wordsArr.Length];
        for (int i = 0; i < wordsArr.Length; i++)
        {
            result[i] = "#" + String.Join("", wordsArr[i].Substring(0, 3).Select(e => e == ' ' ? "00" : Convert.ToHexString(new byte[] { ((byte)e) })).ToArray()).ToLower();
        }
        return result;
    }

    public static string ZeroFill(int number, int size)
    {
        return Math.Abs(number).ToString().PadLeft(size, '0');
    }

    public static int MatrixElementsSum(int[][] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.Count(); i++)
        {
            for (int j = 0; j < matrix[i].Count(); j++)
            {
                if (matrix[i][j] != 0 && matrix[i - 1 >= 0 ? i - 1 : i][j] != 0)
                {
                    sum += matrix[i][j];
                }
                else
                {
                    if (i + 1 < matrix.Count())
                    {
                        matrix[i + 1][j] = 0;
                    }
                }
            }
        }
        return sum;
    }


    public class WeightSort
    {
        public static string orderWeight(string strng)
        {
            if (strng == "")
            {
                return strng;
            }
            long[] weightArr = strng.Split(" ").Select(e => ((long)Int64.Parse(e))).ToArray();
            var pair = new List<Tuple<long, long>>();
            LinkedList<long> result = new LinkedList<long>();
            foreach (var item in weightArr)
            {
                pair.Add(new Tuple<long, long>(item, item.ToString().Select(e => ((long)Int64.Parse(e.ToString()))).Sum()));
            }
            while (pair.Count() > 0)
            {
                long value = pair.MinBy(p => p.Item2)!.Item2!;
                var filtered = pair.Where(p => p.Item2 == value).ToList();
                long minValue = filtered.MinBy(e => e.Item1.ToString())!.Item1;
                result.AddLast(minValue);
                pair.RemoveAt(pair.IndexOf(new Tuple<long, long>(minValue, value)));

            }
            return String.Join(" ", result);
        }
    }

    public class DirReduction
    {
        private static void dirCheck(LinkedList<string> list, string dir, string dirToCheck)
        {
            if (!list.Last().Equals(dirToCheck))
            {
                list.AddLast(dir);
            }
            else
            {
                list.RemoveLast();
            }
        }
        public static string[] dirReduc(String[] arr)
        {
            var result = new LinkedList<string>();
            foreach (var item in arr)
            {
                if (result.Count() != 0)
                {
                    switch (item)
                    {
                        case "EAST":
                            dirCheck(result, item, "WEST");
                            break;
                        case "WEST":
                            dirCheck(result, item, "EAST");
                            break;
                        case "NORTH":
                            dirCheck(result, item, "SOUTH");
                            break;
                        case "SOUTH":
                            dirCheck(result, item, "NORTH");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    result.AddLast(item);
                }
            }
            return result.ToArray();
        }
    }


    public class PiApprox
    {
        public static System.Collections.ArrayList iterPi(double epsilon)
        {
            int count = 0;
            double myPI = 0d;
            double tmpForMyPI = 0d;
            while (Math.Abs(Math.PI - myPI) >= epsilon)
            {
                tmpForMyPI += (1d / (++count * 2 - 1)) * (count % 2 == 0 ? -1 : 1);
                myPI = tmpForMyPI * 4;
            }
            return new System.Collections.ArrayList() { count, Math.Round(tmpForMyPI * 4, 10) };
        }
    }

    public static string Cipher26(string message)
    {
        int sum = 0;
        int code;
        int value;
        string result = "";
        for (int i = 0; i < message.Length; i++)
        {
            code = (int)message[i] - 97;
            value = (26 * (sum / 26 + 1) - sum + code) % 26;
            result += (char)(value + 97);
            sum += (value % 26);
        }
        return result;
    }

    public static string Factorial(int n)
    {
        List<int> res = new List<int>() { 1 };
        for (int x = 2; x <= n; x++)
        {
            int carry = 0;
            for (int i = 0; i < res.Count(); i++)
            {
                int prod = res[i] * x + carry;
                res[i] = prod % 10;
                carry = prod / 10;
            }
            while (carry != 0)
            {
                res.Add(carry % 10);
                carry = carry / 10;
            }
        }
        res.Reverse();
        return String.Join("", res);
    }

    public class VolTank
    {
        public static int TankVol(int h, int d, int vt)
        {
            double r = d / 2d;
            double len = vt / (r * r * Math.PI);
            double degree = Math.Acos((h >= r ? h - r : r - h) / r) * (180d / Math.PI) * 2d;
            double radian = (degree * (Math.PI)) / 180;
            return (int)((r * r * Math.PI * ((h <= r ? degree : 360 - degree) / 360) - (h <= r ? 1 : -1) * r * r * Math.Sin(radian) / 2) * len);
        }
    }
    public static int SearchArray(object[][] arrayToSearch, object[] query)
    {
        if (arrayToSearch.Where(a => a is not Array).Count() != 0) throw new Exception();
        if (arrayToSearch.Where(a => a.Length != 2).Count() != 0) throw new Exception();
        if (query.Length != 2) throw new Exception();
        for (int i = 0; i < arrayToSearch.Count(); i++)
        {
            if (arrayToSearch[i].SequenceEqual(query)) return i;
        }
        return -1;
    }

    public static int[] MoveZeroes(int[] arr)
    {
        return arr.Where(e => e != 0).Concat(Enumerable.Repeat(0, arr.Where(e => e == 0).Count())).ToArray();
    }


    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

    public static List<int> TreeByLevels(Node node)
    {
        List<int> result = new List<int>() { };
        if (node == null) return result;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        while (queue.Count != 0)
        {
            Node tempNode = queue.Dequeue();
            result.Add(tempNode.Value);
            if (tempNode.Left != null) queue.Enqueue(tempNode.Left);
            if (tempNode.Right != null) queue.Enqueue(tempNode.Right);
        }
        return result;
    }


    public class User
    {
        public int rank;
        public int progress;
        public User()
        {
            this.rank = Rank[0];
            this.progress = 0;
        }
        List<int> Rank = new List<int>() { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };
        public void incProgress(int actRank)
        {
            if (!Rank.Contains(actRank)) throw new ArgumentException();
            int diff = Rank.IndexOf(actRank) - Rank.IndexOf(rank);
            switch (diff)
            {
                case <= -2:
                    break;
                case -1:
                    progress++;
                    break;
                case 0:
                    progress += 3;
                    break;
                case >= 1:
                    progress += 10 * diff * diff;
                    break;
            }
            rank = Rank[Rank.IndexOf(rank) + progress / 100];
            progress = rank == 8 ? 0 : progress % 100;
        }
    }

    public static void Main()
    {
        User user = new User();
        Console.WriteLine(user.rank); // => -8
        Console.WriteLine(user.progress); // => 0
        user.incProgress(-7);
        Console.WriteLine(user.progress); // => 10
        user.incProgress(-5); // will add 90 progress
        Console.WriteLine(user.progress); // => 0 // progress is now zero
        Console.WriteLine(user.rank); // => -7 // rank was upgraded to -7
        user.incProgress(-8);
        Console.WriteLine(user.progress);
    }
}