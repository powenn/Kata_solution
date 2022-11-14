import codecs
from functools import reduce
import hashlib
import math
import re
from math import factorial


def index(array, n):
    return -1 if len(array) <= n or n < 0 else pow(array[n], n)


def remove_every_other(my_list):
    index = 0
    new_list = []
    for item in my_list:
        if index % 2 == 0:
            new_list.append(my_list[index])
        index += 1
    return new_list


def remove_smallest(numbers):
    if len(numbers) == 1:
        return []
    index = 0
    for i in range(0, len(numbers)):
        if numbers[i] == min(numbers):
            index = i
            break
    return numbers[:index]+numbers[index+1:]


def check_exam(arr1, arr2):
    score = 0
    for i in range(0, len(arr1)):
        if arr1[i] == arr2[i]:
            score += 4
        elif arr1[i] != arr2[i] and arr2[i] != "":
            score -= 1
    return 0 if score < 0 else score


def remove_duplicate_words(s):
    set_of_s = set(s.split(" "))
    arr = []
    for word in s.split(" "):
        if set(filter(lambda x: x == word, set_of_s)):
            arr.append(word)
            set_of_s.remove(word)
    return " ".join(arr)


def power_of_two(x):
    if x <= 0:
        return False
    value = 1
    while value < x:
        value *= 2
    return True if x == 1 else value == x


def words_to_marks(s):
    arr = list(map(lambda x: ord(x)-96, list(s)))
    return sum(arr)


def narcissistic(value):
    return value == sum(list(map(lambda x: pow(int(x), len(str(value))), [num for num in str(value)])))


def encode(st):
    dir = {"a": "1", "e": "2", "i": "3", "o": "4", "u": "5"}
    return "".join(list(map(lambda x: dir[x] if x in dir else x, [c for c in st])))


def decode(st):
    dir = {"1": "a", "2": "e", "3": "i", "4": "o", "5": "u"}
    return "".join(list(map(lambda x: dir[x] if x in dir else str(x), [c for c in st])))


def nth_fib(n):
    fib = [0, 1]
    while len(fib) < n:
        fib.append(fib[len(fib)-2]+fib[len(fib)-1])
    return fib[n-1]


def dig_pow(n):
    sum = 0
    for i in range(0, len(str(n))):
        sum += pow(int(str(n)[i]), i+1)
    return sum


def sum_dig_pow(a, b):
    return list(filter(lambda x: dig_pow(x) == x, [i for i in range(a, b+1)]))


def data_reverse(data):
    data_arr = list(
        map(lambda x: data[x:x+8], [i for i in range(0, len(data), 8)]))
    return [item for sublist in list(reversed(data_arr)) for item in sublist]


def get_length_of_missing_array(array_of_arrays):
    value_arr = list(
        sorted((map(lambda x: len(x), [arr for arr in array_of_arrays]))))
    return list(set([i for i in range(value_arr[0], value_arr[len(value_arr)-1])])-set(value_arr))[0]


def up_array(arr):
    if list(filter(lambda x: x < 0 or x >= 10, arr)) != [] or arr == []: return None
    num = int("".join(list(map(lambda x: str(x), arr))))
    return list(map(lambda x: int(x), [num for num in str(num+1)]))


def sum_digits(n):
    return n if len(str(n)) == 1 else sum(list(map(lambda x: int(x), [i for i in str(n)])))


def compute_sum(n):
    arr = list(map(lambda x: sum_digits(x), [i for i in range(1, n+1)]))
    return sum(arr)


def mineLocation(field):
    return [int([item for sublist in field for item in sublist].index(1)/pow(len([item for sublist in field for item in sublist]), 0.5)), int([item for sublist in field for item in sublist].index(1) % pow(len([item for sublist in field for item in sublist]), 0.5))]


def letter_count(s):
    dir = {}
    for char in sorted(s):
        if char not in dir:
            dir[char] = 1
        else:
            dir[char] += 1
    return s


def string_transformer(s):
    result = []
    for word in list(reversed(s.split(" "))):
        result.append("" if word == "" else "".join(
            list(map(lambda x: x.upper() if x.islower() else x.lower(), word))))
    return " ".join(result)


def grabscrab(word, possible_words):
    return list(filter(lambda x: all([char in word for char in x]), possible_words))


def format_words(words):
    if words == [] or words == None or words == [""]:
        return ""
    words_len = len(list(filter(lambda x: x != "", words)))
    if words_len == 1:
        return list(filter(lambda x: x != "", words))[0]
    return ", ".join(list(filter(lambda x: x != "", words))[:words_len-1])+" and "+list(filter(lambda x: x != "", words))[words_len-1]


def binary_to_string(binary):
    arr = list(map(lambda x: chr(
        int(binary[x:x+8], 2)), [i for i in range(0, len(binary), 8)]))
    return "".join(arr)


def christmas_tree(height):
    arr = list(map(lambda x: " "*(height-x)+"*"*(x*2-1)+" " *
               (height-x), [i for i in range(1, height+1)]))
    return "\n".join(arr)


def collatz(n):
    arr = [n]
    while arr[len(arr)-1] != 1:
        arr.append(int(arr[len(arr)-1]/2) if arr[len(arr)-1] %
                   2 == 0 else int(arr[len(arr)-1]*3+1))
    return "->".join(list(map(lambda x: str(x), arr)))


def odd_row(n):
    first_num = int(
        ((pow(n, 3)) - sum(list(map(lambda x: x*2, [i for i in range(1, n)]))))/n)
    return list(map(lambda x: first_num+(x*2), [i for i in range(0, n)]))


def simple_transposition(text):
    arr1 = []
    arr2 = []
    for i in range(0, len(text)):
        if i % 2 == 0:
            arr1.append(text[i])
        else:
            arr2.append(text[i])

    return "".join(arr1)+"".join(arr2)


def divisible_count(x, y, k):
    return list(map(lambda x: x % k == 0, [i for i in range(x, y+1)])).count(True)


def area_value(n):
    arr = list(map(lambda x: (x, int(n/x)),
               list(filter(lambda x: n % x == 0, [i for i in range(1, n+1)]))))
    area = 0
    for i in range(0, len(arr)-1):
        area += (arr[i+1][1]+arr[i][1])*(arr[i+1][0]-arr[i][0]) / 2
    return int(area)


def ip_to_int32(ip):
    value = "".join(
        list(map(lambda x: bin(int(x))[2:].zfill(8), ip.split("."))))
    return int(value, 2)


def fibonacci(n):
    if n <= 0:
        return []
    arr = [0, 1]
    while len(arr) < n:
        arr.append(arr[len(arr)-2]+arr[len(arr)-1])
    return arr[:n]


def f(n, m):
    return int(m*(m-1)/2)*int(n/m) + int((n % m+1)*(n % m)/2)


def arr(n=None):
    return [i for i in range(0, n)] if n is not None else []


def count_squares(n):
    return (n*n+n)*(2*n+1)//6


def str_to_hash(st):
    dir = {}
    if st == "":
        return dir
    for pair in st.split(", "):
        dir[pair.split("=")[0]] = int(pair.split("=")[1])
    return dir


def powers_of_two(n):
    return list(map(lambda x: pow(2, x), [i for i in range(0, n+1)]))


def max_pizza(cuts):
    return int((cuts+1)*cuts/2)+1 if cuts >= 0 else -1


def string_breakers(n, st):
    return "\n".join([st.replace(" ", "")[i:i+n] for i in range(0, len(st.replace(" ", "")), n)])


def ascii_value_check(st):
    return bin(ord(st))[2:].count("1") < bin(ord(st))[2:].count("0")


def more_zeros(s):
    return list(dict.fromkeys(list(filter(lambda x: ascii_value_check(x), s))))


def rotate(data, n):
    return data[n-1:]+data[:n-1]


def minimum_sum(values, n):
    return sum(sorted(values)[:n]) if len(values) > n else sum(sorted(values)[:len(values)])


def maximum_sum(values, n):
    return sum(sorted(values)[len(values)-n:]) if len(values) > n else sum(sorted(values))


def factorial_of(n):
    return reduce(lambda a, b: a*b, [i for i in range(1, n+1)])


def choose(n, k):
    if n == k:
        return 1
    if k > n:
        return 0
    return reduce(lambda a, b: a*b, [i for i in range(n-k+1, n+1)]) // factorial_of(k)


def prime_factors(n):
    arr = []
    while n > 1:
        for i in range(2, n+1):
            if n % i == 0:
                n //= i
                arr.append(i)
                break
    return arr


def number_format(n):
    return f'{n:,}'


def array_diff(a, b):
    return list(filter(lambda x: x != None, map(lambda x: x if x not in b else None, a)))


def solve(arr):
    return reduce(lambda a, b: a*b, list(map(lambda x: len(set(x)), [sublist for sublist in arr])))


def sqrt_approximation(number):
    i = 1
    while i*i < number:
        i += 1
    return i if i*i == number else [i-1, i]


def gimme(input_array):
    return input_array.index(sorted(input_array)[1])


class FileMaster():
    def __init__(self, filepath):
        self.filepath = filepath

    def extension(self):
        return self.filepath.split("/")[-1].split(".")[1]

    def filename(self):
        return self.filepath.split("/")[-1].split(".")[0]

    def dirpath(self):
        return "/".join(self.filepath.split("/")[:len(self.filepath.split("/"))-1])+"/"


def ip_to_num(ip):
    value = "".join(
        list(map(lambda x: bin(int(x))[2:].zfill(8), ip.split("."))))
    return int(value, 2)


def num_to_ip(num):
    arr = list(map(lambda x: str(int(bin(num)[2:].zfill(32)[
               x:x+8], 2)), [i for i in range(0, len(bin(num)[2:].zfill(32)), 8)]))
    return ".".join(arr)


def high(x):
    return x.split(" ")[list(map(lambda m:sum(list(map(lambda n:ord(n)-96, [char for char in m]))), x.split(" "))).index(max(list(map(lambda m:sum(list(map(lambda n:ord(n)-96, [char for char in m]))), x.split(" ")))))]


def sequence_sum(begin_number, end_number, step):
    return sum([i for i in range(begin_number, end_number+1, step)])


def sum_fibs(n):
    if n <= 0:
        return []
    arr = [0, 1]
    while len(arr) <= n:
        arr.append(arr[len(arr)-2]+arr[len(arr)-1])
    return sum(num for num in arr if not num % 2)


def oddity(n):
    return "even" if len([i for i in range(1, n+1) if n % i == 0]) % 2 == 0 else "odd"


def dont_give_me_five(start, end):
    print([i for i in range(start, end+1) if str(i).count("5") == 0])
    return len([i for i in range(start, end+1) if str(i).count("5") == 0])


def zip_with(fn, a1, a2):
    return list(map(lambda x: fn(a1[x], a2[x]), range(0, min(len(a1), len(a2)))))


def hollow_triangle(n):
    arr = list(map(lambda x: "_"*(n-x)+"#"+"_" *
               (2*(x-1)-1)+"#"+"_"*(n-x), range(2, n)))
    arr.insert(0, "_"*(n-1)+"#"+"_"*(n-1))
    arr.append("#"*(2*n-1))
    print("\n".join(arr))
    return arr


def to_sha256(s):
    return hashlib.sha256(s.encode()).hexdigest()


def alphanumeric(password):
    return password != "" and len(list(filter(lambda x: not x.isnumeric() and not x.isalpha(), [char for char in password]))) == 0


def commas(num):
    num = f'{num:.3f}'
    return f'{float(num):,}' if f'{float(num):,}'[-1] != "0" else f'{float(num):,}'[:-2]


def unique_in_order(iterable):
    result = []
    prev = None
    for char in iterable[:]:
        if char != prev:
            result.append(char)
            prev = char
    return result


def nbr_of_laps(x, y):
    return (math.lcm(x, y)//x, math.lcm(x, y)//y)


def number_of_routes(m, n):
    return choose(m+n, n)


def is_pangram(s):
    for i in range(1, 27):
        if chr(i+96) not in s.lower():
            return False
    return True


def order(sentence):
    if sentence == "":
        return ""
    arr = sentence.split(" ")
    dir = {}
    for item in arr:
        index = [i for i in item if i.isnumeric()][0]
        dir[index] = item
    return " ".join(list(map(lambda x: dir[str(x)], [i for i in range(1, len(dir)+1)])))


# def solution(*args):
#     return len(list(args)) != len(set(args)) if args is not None else False


def get_w(height):
    if height < 2:
        return []
    result = ["*"+" "*(2*(height-1)-1)+"*"+" "*(2*(height-1)-1)+"*"]
    for i in range(1, height-1):
        result.append(" "*i+"*"+" "*(2*(height-i-1)-1)+"*"+" " *
                      (2*i-1)+"*"+" "*(2*(height-i-1)-1)+"*"+" "*i)
    result.append(" "*(height-1)+"*"+" "*(2*(height-1)-1)+"*"+" "*(height-1))
    return result


def delete_nth(order, max_e):
    result = []
    for i in order:
        if result.count(i) < max_e:
            result.append(i)
    return result


def Xbonacci(signature, n):
    if n <= len(signature):
        return signature[:n]
    for i in range(0, n-len(signature)):
        signature.append(sum(signature[i:i+len(signature)]))
    return signature


def twos_difference(lst):
    result = []
    for num in sorted(lst):
        if lst.count(num+2) > 0:
            result.append((num, num+2))
    return result


def f(n):
    return 1 if n == 0 else (n - m(f(n - 1)))


def m(n):
    return 0 if n == 0 else (n - f(m(n - 1)))


def move_zeros(lst):
    return list([i for i in lst if i != 0])+[0 for _ in range(0, lst.count(0))]


def word_to_char_count_dir(word):
    word_dir = {}
    for char in set(word[0:]):
        word_dir[char] = word.count(char)
    return word_dir


def anagrams(word, words):
    return list(filter(lambda x: word_to_char_count_dir(x) == word_to_char_count_dir(word), words))


def beeramid(bonus, price):
    if bonus <= 0:
        return 0
    index = 1
    total = 0
    while total <= bonus:
        total += price*int(pow(index, 2))
        index += 1
    return index-2


# def solution(array_a, array_b):
#     return sum(list(map(lambda x: pow(abs(array_a[x]-array_b[x]), 2), (i for i in range(0, len(array_a)))))) / len(array_a)


def valid_ISBN10(isbn):
    if len([i for i in isbn[:8] if i.isnumeric() == False]) > 0 or len(isbn) != 10:
        return False
    total = 0
    for i in range(1, 10):
        total += int(isbn[i-1])*i
    if isbn[-1] == "X":
        total += 100
    if isbn[-1].isnumeric() == True:
        total += int(isbn[-1])*10
    print(total)
    return total % 11 == 0


def lcm(*args):
    return reduce(lambda a, b: math.lcm(a, b), list(args)) if args != () else 1


def count_nines(n):
    return sum(list(map(lambda x: str(x).count("9"), (range(0, n+1)))))


def ipv4_to_binary(ipv4_addr: str) -> str:
    return '.'.join(list(map(lambda x: bin(int(x))[2:].zfill(8), ipv4_addr.split("."))))


def dot(n, m):
    line = "+---+"+(n-1)*"---+"
    dot = "| o |"+(n-1)*" o |"
    result = []
    for i in range(0, m):
        result.append(line)
        result.append(dot)
    result.append(line)
    return "\n".join(result)


def count_odd_pentaFib(n):
    arr = [0, 1, 1, 2, 4]
    while len(arr) <= n:
        arr.append(sum(arr[len(arr)-5:]))
    return len(set(list(filter(lambda x: x % 2 != 0, arr)))) if n != 0 else 0


def max_sum(arr, ranges):
    return max(list(map(lambda x: sum(arr[x[0]:x[1]+1]), ranges)))


def get_participants(handshakes):
    num = int(math.sqrt(handshakes*2))
    while (num*(num+1)) < handshakes*2:
        num += 1
    return num+1 if num != 0 else 0


def mormons(starting_number, reach, target):
    count = 0
    while starting_number < target:
        starting_number *= (reach+1)
        count += 1
    return count


def compute_depth(n):
    count = 1
    check_set = set()
    while len(check_set) != len(set([0, 1, 2, 3, 4, 5, 6, 7, 8, 9])):
        list(map(lambda x: check_set.add(x), list(str(count*n))))
        count += 1
    return count-1


def only_duplicates(string):
    return "".join(list(filter(lambda x: string.count(x) > 1, list(string))))


def factorsRange(n, m):
    dir = {}
    for i in range(n, m+1):
        if len([n for n in range(2, i) if i % n == 0]) != 0:
            dir[i] = [n for n in range(2, i) if i % n == 0]
        else:
            dir[i] = ["None"]
    return dir


def find_e(s):
    if s is None:
        return None
    if s == "":
        return ""
    return str(s.upper().count("E")) if s.upper().count("E") > 0 else "There is no \"e\"."


def group_by_commas(n):
    return f"{n:,}"


def pascals_triangle(n):
    arr = []
    for i in range(n):
        for j in range(i+1):
            arr.append(factorial(i)//(factorial(j)*factorial(i-j)))
    return arr


def fib(n):
    a, b = 0, 1
    for _ in range(n-1):
        a, b = b, a+b
    return a


def getROT13char(c):
    if c.islower():
        return chr(ord(c)+13) if ord(c)+13 <= 122 else chr(ord(c)-13)
    else:
        return chr(ord(c)+13) if ord(c)+13 <= 90 else chr(ord(c)-13)


def rot13(message):
    return "".join(list(map(lambda x: getROT13char(x) if x.isalpha() else x, message)))


def solution(number):
    return sum(list(filter(lambda x: x % 3 == 0 or x % 5 == 0, range(3, number))))


def find_it(seq):
    return list(set(filter(lambda x: seq.count(x) % 2 != 0, seq)))[0]


def nearest_sq(n):
    return int(math.pow(int(math.sqrt(n))+1, 2)) if math.sqrt(n) - int(math.sqrt(n)) >= 0.5 else int(math.pow(int(math.sqrt(n)), 2))


def digital_root(n):
    while len(str(n)) > 1:
        n = sum(list(map(lambda x: int(x), str(n))))
    return n


def count_smileys(arr):
    return len(list(filter(lambda x: x in [":)", ":D", ";-D", ":~)", ";~D", ":-)", ":-D", ":~D", ";D"], arr)))


def to_weird_case(words):
    words_list = words.split(" ")
    result_list = []
    for word in words_list:
        result = ""
        for i in range(len(word)):
            result += word[i].upper() if i % 2 == 0 else word[i].lower()
        result_list.append(result)
    return " ".join(result_list)


def highest_rank(arr):
    num_dict = dict()
    result = 0
    for num in set(arr):
        num_dict[num] = arr.count(num)
    for num in num_dict.keys():
        if num_dict[num] == max(num_dict.values()):
            if num > result:
                result = num
    return result


def prefill(n, v=None):
    try:
        return [v for _ in range(int(n))]
    except:
        print(f"{n} is invalid")


def derive(coefficient, exponent):
    return f"{coefficient*exponent}x^{exponent-1}"


def decipher_this(string):
    string_list = []
    for s in string.split(" "):
        result = ""
        letters = list(filter(lambda y: y.isalpha(), s))
        if len(letters) > 1:
            letters[0], letters[len(
                letters)-1] = letters[len(letters)-1], letters[0]
        letters_part = "".join(list(filter(lambda y: y.isalpha(), letters)))
        result += chr(int("".join(list(filter(lambda y: y.isnumeric(), s)))))+letters_part
        string_list.append(result)
    return " ".join(string_list)


def is_int_array(arr):
    if arr == None:
        return False
    if arr == "":
        return False
    if len(arr) == 0:
        return True
    for item in arr:
        print(item)
        if item == None:
            return False
        if type(item) is float and int(item) != item:
            return False
        if type(item) is str:
            return False
    return True


def first_non_repeating_letter(string):
    for s in string:
        if string.count(s.lower())+string.count(s.upper()) == 1 if s.isalpha() else string.count(s) == 1:
            return s
    return ""


def generate_hashtag(s):
    if s == "":
        return False
    s_list = list(map(lambda t: t.capitalize(),
                  filter(lambda x: x != "", s.split(" "))))
    return "#"+"".join(s_list) if len("".join(s_list)) < 140 else False


def is_prime(n):
    if n == 1:
        return False
    i = 2
    while i*i <= n:
        if n % i == 0:
            return False
        i += 1
    return True


def prime(n):
    return [i for i in range(2, n+1) if is_prime(i) == True]


def luck_check(string):
    str_list = list(string)
    if len(list(filter(lambda x: x.isalpha(), string))) > 0: raise ("")
    if len(string) % 2 != 0:
        str_list.remove(str_list[int((len(string)-1)/2)])
    try:
        return sum(list(map(lambda x: int(x), str_list[:int((len(str_list)+1)/2)]))) == sum(list(map(lambda x: int(x), str_list[int((len(str_list)+1)/2):])))
    except:
        raise ("")


def variance(numbers):
    mean = sum(numbers)/len(numbers)
    return sum(list(map(lambda x: math.pow(x-mean, 2), numbers)))/len(numbers)


def convert_fracts(lst):
    if lst == []:
        return []
    lcm = reduce(lambda x, y: math.lcm(x, y), list(map(lambda x: x[1], lst)))
    return list(map(lambda x: [int(lcm/x[1])*x[0], lcm], lst))


def greatest_product(n):
    return max(list(map(lambda x: reduce(lambda a, b: a*b, list(map(lambda y: int(y), n[x:x+5]))), range(len(n)-4))))


def all_squared_pairs(n):
    result = []
    for a in range(0, int(n**0.5)+1):
        b = (n-a**2)**0.5
        if int(b) == b:
            if result.count([b, a]) == 0:
                result.append([a, b])
            else:
                break
    return result


def hex_to_base64(hex: str) -> str:
    return codecs.encode(codecs.decode(hex, 'hex'), 'base64').decode().replace("\n", "")


def is_mac_48_address(address):
    pattern = "^(?:[0-9A-Fa-f]{2}[:-]){5}(?:[0-9A-Fa-f]{2})$"
    return re.match(pattern, address) != None


def factors(n: int) -> list[int]:
    result = []
    i = 1
    while i*i <= n:
        if n % i == 0:
            result.append(i)
            if n//i != i:
                result.append(n//i)
        i += 1
    return result


def oddity(n):
    return "odd" if len(factors(n)) % 2 != 0 else "even"


def find_longest(arr):
    for num in arr:
        if len(str(num)) == max(list(map(lambda x: len(str(x)), arr))):
            return num


def reverse_alternate(s):
    s_list = list(filter(lambda x: x, s.split(" ")))
    return " ".join(list(map(lambda x: s_list[x] if x % 2 == 0 else "".join(list(reversed(s_list[x]))), range(len(s_list)))))


def main():
    print()


if __name__ == "__main__":
    main()
