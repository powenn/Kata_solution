import java.util.*;
import java.util.stream.*;

public class Kata {
    public static Double multiply(Double a, Double b) {
        return a * b;
    }

    public static String findNeedle(Object[] haystack) {
        int answer = 0;
        for (int i = 0; i < haystack.length; i++) {
            if (haystack[i] == "needle") {
                answer = i;
            }
        }
        return "found the needle at position " + answer;
    }

    public static double find_average(int[] array) {
        double sum = 0;
        for (int i = 0; i < array.length; i++) {
            sum += array[i];
        }
        return sum / array.length;
    }

    public static String smash(String... words) {
        return String.join(" ", words);
    }

    // public static int sum(int[] numbers) {
    // Arrays.sort(numbers);
    // int sum = 0;
    // if (numbers.length == 0) {
    // return 0;
    // }
    // for (int i = 1; i < numbers.length - 1; i++) {
    // sum += numbers[i];
    // }
    // return sum;
    // }

    public static int enough(int cap, int on, int wait) {
        return on + wait - cap > 0 ? on + wait - cap : 0;
    }

    public static String hoopCount(int n) {
        return n >= 10 ? "Great, now move on to tricks" : "Keep at it until you get it";
    }

    public static String toAlternativeString(String string) {
        StringBuilder sb = new StringBuilder();
        for (Character c : string.toCharArray()) {
            if (Character.isLetter(c)) {
                if (Character.isUpperCase(c)) {
                    sb.append(Character.toLowerCase(c));
                } else {
                    sb.append(Character.toUpperCase(c));
                }
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }

    public static int oddCount(int n) {
        return n / 2;
    }

    public static String switcheroo(String x) {
        StringBuilder sb = new StringBuilder();
        for (Character c : x.toCharArray()) {
            if (c == 'a') {
                sb.append("b");
            } else if (c == 'b') {
                sb.append("a");
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }

    // public static String[] solution(String s) {
    // List<String> result = new ArrayList<String>();
    // if (s.length() % 2 != 0) {
    // s += "_";
    // }
    // for (int i = 0; i < s.length() - 1; i += 2) {
    // result.add(String.valueOf(s.toCharArray()[i]) +
    // String.valueOf(s.toCharArray()[i + 1]));
    // }
    // return result.toArray(new String[s.length() / 2]);
    // }

    public static String numberToString(int num) {
        return String.valueOf(num);
    }

    public static String solution(String str) {
        StringBuilder sb = new StringBuilder(str);
        return sb.reverse().toString();
    }

    public static int arithmetic(int a, int b, String operator) {
        int result = 0;
        switch (operator) {
            case "add":
                result = a + b;
                break;
            case "subtract":
                result = a - b;
                break;
            case "multiply":
                result = a * b;
                break;
            case "divide":
                result = a / b;
                break;
        }
        return result;
    }

    public static String disemvowel(String str) {
        return str.replaceAll("[aeiouAEIOU]", "");
    }

    public static int squareDigits(int n) {
        int[] intArray = new int[String.valueOf(n).length()];
        String result = "";
        for (int i = 0; i < String.valueOf(n).length(); i++) {
            intArray[i] = Integer.parseInt(String.valueOf(n).split("")[i]);
            result += String.valueOf(Integer.parseInt(String.valueOf(n).split("")[i])
                    * Integer.parseInt(String.valueOf(n).split("")[i]));
        }
        return Integer.parseInt(result);
    }

    public static String[] alternate(int n, String firstValue, String secondValue) {
        String[] answer = new String[n];
        for (int i = 0; i < n; i++) {
            if (i % 2 == 0) {
                answer[i] = firstValue;
            } else {
                answer[i] = secondValue;
            }
        }
        return answer;
    }

    public static Integer prevMultOfThree(int n) {
        Integer answer = 0;
        while (String.valueOf(n).length() > 0) {
            if (n % 3 == 0) {
                answer = n;
                break;
            }
            n /= 10;
        }
        return answer == 0 ? null : answer;
    }

    public static int sum(int k) {
        if (k > 0) {
            return k + sum(k - 1);
        } else {
            return 0;
        }
    }

    public static int getCount(String str) {
        int count = 0;
        List<String> arr = Arrays.asList("a", "e", "i", "o", "u");
        for (char c : str.toCharArray()) {
            if (arr.contains(String.valueOf(c))) {
                count++;
            }
        }
        return count;
    }

    public static int points(String[] games) {
        int score = 0;
        for (String str : games) {
            if (Integer.valueOf(str.split(":")[0]) > Integer.valueOf(str.split(":")[1])) {
                score += 3;
            } else if (Integer.valueOf(str.split(":")[0]) == Integer.valueOf(str.split(":")[1])) {
                score++;
            }
        }
        return score;
    }

    public static int sum(int[] arr) {
        return Arrays.stream(arr).filter(n -> n >= 0).reduce(0, (a, b) -> a + b);
    }

    public static String repeatStr(final int repeat, final String string) {
        return string.repeat(repeat);
    }

    public static String remove(String str) {
        return str.substring(1, str.length() - 1);
    }

    public static int findSmallestInt(int[] args) {
        return Arrays.stream(args).sorted().toArray()[0];
    }

    public static String reverseWords(final String original) {
        ArrayList<String> result = new ArrayList<String>();
        Arrays.stream(original.split(" ")).map(word -> {
            StringBuilder sb = new StringBuilder(word);
            return sb.reverse().toString();
        }).forEach(word -> {
            result.add(word);
        });
        return String.join(" ", result);
    }

    public static int[] multipleOfIndex(int[] array) {
        ArrayList<Integer> result = new ArrayList<Integer>();
        for (int i = 1; i < array.length; i++) {
            if (array[i] % i == 0) {
                result.add(array[i]);
            }
        }
        return result.stream().mapToInt(n -> n).toArray();
    }

    public static int arrayPlusArray(int[] arr1, int[] arr2) {
        return Arrays.stream(arr1).sum() + Arrays.stream(arr2).sum();
    }

    public static int toBinary(int n) {
        return Integer.valueOf(Integer.toBinaryString(n));
    }

    public static String integrate(int coefficient, int exponent) {
        return (coefficient / (exponent + 1) + "x^" + (exponent + 1));
    }

    public static String replaceDots(final String str) {
        return str.replace(".", "-");
    }

    public static String position(char alphabet) {
        int value = alphabet;
        return String.valueOf(value - 96);
    }

    public static String well(String[] x) {
        long count = Arrays.stream(x).filter(n -> n == "good").count();
        System.out.println(count);
        if (count >= 1 && count <= 2) {
            return "Publish!";
        } else if (count >= 2) {
            return "I smell a series!";
        } else {
            return "Fail!";
        }
    }

    public static boolean isPrime(int num) {
        if (num <= 1) {
            return false;
        }
        for (int i = 2; i <= num / i; i++) {
            if ((num % i) == 0)
                return false;
        }
        return true;
    }

    public static String highAndLow(String numbers) {
        List<Integer> num_list = Arrays.stream(numbers.split(" ")).map(x -> Integer.parseInt(x)).toList();
        return Collections.max(num_list) + " " + Collections.min(num_list);
    }

    public static String greet(String name) {
        return "Hello " + name.substring(0, 1).toUpperCase() + name.substring(1).toLowerCase() + "!";
    }

    public static int compute(int x, int y) {
        int d = 1;
        for (int i = d; i < Math.max(x, y); i++) {
            if (x % i == 0 && y % i == 0) {
                d = i;
            }
        }
        return d;
    }

    public static int sumTriangularNumbers(int n) {
        if (n <= 0) {
            return 0;
        }
        int[] arr = new int[n];
        int tmp;
        for (int i = 0; i < n; i++) {
            tmp = IntStream.rangeClosed(1, i + 1).sum();
            arr[i] = tmp;
        }
        return Arrays.stream(arr).sum();
    }

    public static String explode(String digits) {
        String result = "";
        char[] arr = digits.toCharArray();
        for (char c : arr) {
            result += String.valueOf(c).repeat(Integer.parseInt(String.valueOf(c)));
        }
        return result;
    }

    public static int halvingSum(int n) {
        int index = 1;
        int sum = 0;
        while (n / index > 0) {
            System.out.println(n / index);
            sum += n / index;
            index *= 2;
        }
        return sum;
    }

    public static int solution(int number) {
        ArrayList<Integer> result = new ArrayList<Integer>();
        for (int i = 1; i < number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                result.add(i);
            }
        }
        return result.stream().mapToInt(a -> a).sum();
    }

    public static int[] generateIntegers(int n) {
        return IntStream.rangeClosed(0, n).toArray();
    }

    public static String getMiddle(String word) {
        return word.length() % 2 == 0 ? word.substring((int) (word.length()) / 2 - 1, (int) (word.length()) / 2 + 1)
                : String.valueOf(word.charAt((int) (word.length() - 1) / 2));
    }

    public static boolean isSquare(int n) {
        return n < 0 ? false : Math.sqrt(n) - (int) Math.sqrt(n) == 0;
    }

    public static int GetSum(int a, int b) {
        return Arrays.stream(IntStream.rangeClosed(Math.min(a, b), Math.max(a, b)).toArray()).sum();
    }

    public static String pofi(int n) {
        switch (n % 4) {
            case 0:
                return String.valueOf(1);
            case 1:
                return "i";
            case 2:
                return String.valueOf(-1);
        }
        return "-i";
    }

    public static String whoLikesIt(String... names) {
        if (names.length == 0) {
            return "no one likes this";
        } else if (names.length == 1) {
            return names[0] + " likes this";
        } else if (names.length == 2) {
            return names[0] + " and " + names[1] + " like this";
        } else if (names.length == 3) {
            return names[0] + ", " + names[1] + " and " + names[2] + " like this";
        } else if (names.length >= 4) {
            return names[0] + ", " + names[1] + " and " + (names.length - 2) + " others like this";
        } else {
            return "";
        }
    }

    public static int digital_root(int n) {
        while (String.valueOf(n).length() > 1) {
            n = Arrays.stream(String.valueOf(n).split("")).mapToInt(e -> Integer.parseInt(e)).sum();
        }
        return n;
    }

    public static List<Integer> notPrimes(int a, int b) {
        int[] arr = IntStream.rangeClosed(a, b - 1).toArray();
        arr = Arrays.stream(arr)
                .filter(n -> isPrime(n) == false && String.valueOf(n).contains("1") == false
                        && String.valueOf(n).contains("4") == false && String.valueOf(n).contains("6") == false
                        && String.valueOf(n).contains("8") == false && String.valueOf(n).contains("9") == false
                        && String.valueOf(n).contains("0") == false)
                .toArray();
        return Arrays.stream(arr).boxed().toList();
    }

    public static int countBits(int n) {
        return Collections.frequency(Arrays.asList(Integer.toBinaryString(n).split("")), "1");
    }

    public static long fib(int n) {
        if (n == 0) {
            return 0;
        }
        if (n == 1 || n == 2) {
            return 1;
        }
        return fib(n - 2) + fib(n - 1);
    }

    public static String capitalize(String str) {
        if (str == null || str.isEmpty()) {
            return str;
        }
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }

    public static String createPhoneNumber(int[] numbers) {
        return String.format("(%s) %s-%s",
                String.join("", Arrays.stream(numbers).mapToObj(e -> String.valueOf(e)).toList().subList(0, 3)),
                String.join("", Arrays.stream(numbers).mapToObj(e -> String.valueOf(e)).toList().subList(3, 6)),
                String.join("", Arrays.stream(numbers).mapToObj(e -> String.valueOf(e)).toList().subList(6, 10)));
    }

    public static int findIt(int[] a) {
        Set<Integer> a_set = Arrays.stream(a).boxed().collect(Collectors.toSet());
        return a_set.stream().filter(e -> Arrays.stream(a).filter(x -> x == e).count() % 2 != 0).findFirst().get();
    }

    public static boolean isIsogram(String str) {
        return Arrays.stream(str.toLowerCase().split("")).collect(Collectors.toSet()).size() == str.length()
                || str.isEmpty();
    }

    public static int findShort(String s) {
        return Arrays.stream(s.split(" ")).mapToInt(e -> e.length()).min().getAsInt();
    }

    public static long sumMul(int n, int m) {
        if (n <= 0 || m <= 0) {
            throw new IllegalArgumentException();
        }
        return IntStream.rangeClosed(n, m - 1).filter(e -> e % n == 0).sum();
    }

    public static int countSheeps(Boolean[] arrayOfSheeps) {
        return (int) Arrays.stream(arrayOfSheeps).filter(e -> String.valueOf(e).equals("true")).count();
    }

    public static int[] digitize(long n) {
        var new_n = new ArrayList<>(
                Arrays.stream(String.valueOf(n).split("")).mapToInt(e -> Integer.parseInt(e)).boxed().toList());
        Collections.reverse(new_n);
        return new_n.stream().mapToInt(e -> (int) e).toArray();
    }

    public static int predictAge(int... ages) {
        return (int) Math.sqrt(IntStream.rangeClosed(0, 7).mapToDouble(e -> Math.pow(ages[e], 2)).sum()) / 2;
    }

    public static String makeReadable(int seconds) {
        return String.format("%02d:%02d:%02d", seconds / 60 / 60, seconds / 60 % 60, seconds % 60);
    }

    public static int sum(List<?> mixed) {
        return mixed.stream().mapToInt(e -> Integer.parseInt(String.valueOf(e))).sum();
    }

    public static String formatDuration(int seconds) {
        LinkedHashMap<String, Integer> time_map = new LinkedHashMap<>();
        time_map.put("year", seconds / 60 / 60 / 24 / 365);
        time_map.put("day", seconds / 60 / 60 / 24 % 365);
        time_map.put("hour", seconds / 60 / 60 % 24);
        time_map.put("minute", seconds / 60 % 60);
        time_map.put("second", seconds % 60);
        var time_list = time_map.entrySet().stream().filter(e -> e.getValue() > 0).toList();
        if (time_list.size() == 0) {
            return "now";
        }
        if (time_list.size() <= 1) {
            return String.format("%d %s%s", time_list.get(0).getValue(), time_list.get(0).getKey(),
                    time_list.get(0).getValue() > 1 ? "s" : "");
        } else if (time_list.size() <= 2) {
            return String.format("%d %s%s and %d %s%s", time_list.get(0).getValue(), time_list.get(0).getKey(),
                    time_list.get(0).getValue() > 1 ? "s" : "", time_list.get(1).getValue(), time_list.get(1).getKey(),
                    time_list.get(1).getValue() > 1 ? "s" : "");
        } else {
            return String.join(", ", IntStream.rangeClosed(0, time_list.size() - 2)
                    .mapToObj(e -> String.format("%d %s%s", time_list.get(e).getValue(), time_list.get(e).getKey(),
                            time_list.get(e).getValue() > 1 ? "s" : ""))
                    .toList())
                    + String.format(" and %d %s%s", time_list.get(time_list.size() - 1).getValue(),
                            time_list.get(time_list.size() - 1).getKey(),
                            time_list.get(time_list.size() - 1).getValue() > 1 ? "s" : "");
        }
    }

    public static double squareArea(double A) {
        return (int) (Math.pow(4 * A / Math.PI / 2, 2) * 100) / 100.0;
    }

    public static void main(String[] args) {
        System.out.println(squareArea(2));
    }
}
