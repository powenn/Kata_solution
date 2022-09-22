from functools import reduce
import hashlib
import math

def index(array, n):
    return -1 if len(array) <= n or n < 0 else pow(array[n],n)

def remove_every_other(my_list):
    index = 0
    new_list = []
    for item in my_list :
        if index%2 == 0 :
            new_list.append(my_list[index])
        index+=1
    return new_list

def remove_smallest(numbers):
    if len(numbers) == 1 : return []
    index = 0
    for i in range(0,len(numbers)) :
        if numbers[i] == min(numbers) :
            index = i
            break
    return numbers[:index]+numbers[index+1:]

def check_exam(arr1,arr2):
    score = 0
    for i in range(0,len(arr1)) :
        if arr1[i] == arr2[i] :
            score+=4
        elif arr1[i] != arr2[i] and arr2[i] != "" :
            score-=1
    return 0 if score < 0 else score

def remove_duplicate_words(s):
    set_of_s = set(s.split(" "))
    arr = []
    for word in s.split(" ") :
        if set(filter(lambda x:x==word,set_of_s)) :
            arr.append(word)
            set_of_s.remove(word)
    return " ".join(arr)

def power_of_two(x):
    if x <=0 : return False
    value = 1
    while value < x :
        value *= 2
    return True if x==1 else value==x

def words_to_marks(s):
    arr = list(map(lambda x:ord(x)-96,list(s)))
    return sum(arr)

def narcissistic(value):
    return value == sum(list(map(lambda x:pow(int(x),len(str(value))),[num for num in str(value)])))

def encode(st):
    dir = {"a":"1","e":"2","i":"3","o":"4","u":"5"}
    return "".join(list(map(lambda x:dir[x] if x in dir else x,[c for c in st])))
    
def decode(st):
    dir = {"1":"a","2":"e","3":"i","4":"o","5":"u"}
    return "".join(list(map(lambda x:dir[x] if x in dir else str(x),[c for c in st])))

def nth_fib(n):
    fib = [0,1]
    while len(fib) < n :
        fib.append(fib[len(fib)-2]+fib[len(fib)-1])
    return fib[n-1]

def dig_pow(n) :
    sum = 0
    for i in range(0,len(str(n))) :
        sum+=pow(int(str(n)[i]),i+1)
    return sum

def sum_dig_pow(a, b): 
    return list(filter(lambda x:dig_pow(x) == x ,[i for i in range(a,b+1)]))

def data_reverse(data):
    data_arr = list(map(lambda x:data[x:x+8],[i for i in range(0,len(data),8)]))
    return [item for sublist in list(reversed(data_arr)) for item in sublist]

def get_length_of_missing_array(array_of_arrays):
    value_arr = list(sorted((map(lambda x:len(x),[arr for arr in array_of_arrays]))))
    return list(set([i for i in range(value_arr[0],value_arr[len(value_arr)-1])])-set(value_arr))[0]

def up_array(arr):
    if list(filter(lambda x:x<0 or x>=10,arr)) != [] or arr == []: return None
    num = int("".join(list(map(lambda x:str(x),arr))))
    return list(map(lambda x:int(x),[num for num in str(num+1)]))

def sum_digits(n) :
    return n if len(str(n)) == 1 else sum(list(map(lambda x:int(x) ,[i for i in str(n)])))

def compute_sum(n):
    arr = list(map(lambda x:sum_digits(x) ,[i for i in range(1,n+1)]))
    return sum(arr)

def mineLocation(field):
    return [int([item for sublist in field for item in sublist].index(1)/pow(len([item for sublist in field for item in sublist]),0.5)),int([item for sublist in field for item in sublist].index(1)%pow(len([item for sublist in field for item in sublist]),0.5))]

def letter_count(s):
    dir = {}
    for char in sorted(s) :
        if char not in dir:
            dir[char] = 1
        else :
            dir[char] += 1
    return s

def string_transformer(s):
    result = []
    for word in list(reversed(s.split(" "))) :
        result.append("" if word == "" else "".join(list(map(lambda x:x.upper() if x.islower() else x.lower(),word))))
    return " ".join(result)

def grabscrab(word, possible_words):
    return list(filter(lambda x:all([char in word for char in x]),possible_words))

def format_words(words):
    if words == [] or words == None or words == [""] :return ""
    words_len  = len(list(filter(lambda x:x!="",words)))
    if words_len == 1 :
        return list(filter(lambda x:x!="",words))[0] 
    return ", ".join(list(filter(lambda x:x!="",words))[:words_len-1])+" and "+list(filter(lambda x:x!="",words))[words_len-1]

def binary_to_string(binary):
    arr = list(map(lambda x:chr(int(binary[x:x+8],2)),[i for i in range(0,len(binary),8)]))
    return "".join(arr)

def christmas_tree(height):
    arr = list(map(lambda x:" "*(height-x)+"*"*(x*2-1)+" "*(height-x),[i for i in range(1,height+1)]))
    return "\n".join(arr)

def collatz(n):
    arr = [n]
    while arr[len(arr)-1] != 1 :
        arr.append(int(arr[len(arr)-1]/2) if arr[len(arr)-1]%2==0 else int(arr[len(arr)-1]*3+1))
    return "->".join(list(map(lambda x:str(x),arr)))

def odd_row(n):
    first_num = int(((pow(n,3)) -sum(list(map(lambda x:x*2,[i for i in range(1,n)]))))/n)
    return list(map(lambda x:first_num+(x*2),[i for i in range(0,n)]))

def simple_transposition(text):
    arr1 = [] ; arr2 =[]
    for i in range(0,len(text)) :
        if i%2== 0 :
            arr1.append(text[i])
        else :
            arr2.append(text[i])

    return  "".join(arr1)+"".join(arr2)


def divisible_count(x,y,k):
    return list(map(lambda x:x%k==0,[i for i in range(x,y+1)])).count(True)

def area_value(n):
    arr = list(map(lambda x:(x,int(n/x)),list(filter(lambda x:n%x==0,[i for i in range(1,n+1)]))))
    area = 0
    for i in range(0,len(arr)-1) :
        area+=(arr[i+1][1]+arr[i][1])*(arr[i+1][0]-arr[i][0]) /2 
    return int(area)

def ip_to_int32(ip):
    value = "".join(list(map(lambda x:bin(int(x))[2:].zfill(8),ip.split("."))))
    return int(value, 2)


def fibonacci(n):
    if n<=0 :return []
    arr = [0,1]
    while len(arr) < n :
        arr.append(arr[len(arr)-2]+arr[len(arr)-1])
    return arr[:n]

def f(n, m):
    return int(m*(m-1)/2)*int(n/m) + int((n%m+1)*(n%m)/2)

def arr(n=None): 
    return [i for i in range(0,n)] if n is not None else []

def count_squares(n):
    return (n*n+n)*(2*n+1)//6

def str_to_hash(st): 
    dir = {}
    if st == "" :return dir
    for pair in st.split(", ") :
        dir[pair.split("=")[0]] = int(pair.split("=")[1])    
    return dir

def powers_of_two(n):
    return list(map(lambda x:pow(2,x),[i for i in range(0,n+1)]))

def max_pizza(cuts):
    return int((cuts+1)*cuts/2)+1 if cuts>=0 else -1

def string_breakers(n, st): 
    return "\n".join([st.replace(" ", "")[i:i+n] for i in range(0,len(st.replace(" ", "")),n)])

def ascii_value_check(st) :
    return bin(ord(st))[2:].count("1") < bin(ord(st))[2:].count("0")

def more_zeros(s):
    return list(dict.fromkeys(list(filter(lambda x:ascii_value_check(x),s))))

def rotate(data, n):
    return data[n-1:]+data[:n-1]


def minimum_sum(values, n):
    return sum(sorted(values)[:n]) if len(values) > n else sum(sorted(values)[:len(values)])

def maximum_sum(values, n):
    return sum(sorted(values)[len(values)-n:]) if len(values) > n else sum(sorted(values))

def factorial_of(n) :
    return reduce(lambda a,b:a*b,[i for i in range(1,n+1)])

def choose(n,k):
    if n==k:return 1
    if k>n:return 0
    return reduce(lambda a,b:a*b,[i for i in range(n-k+1,n+1)]) // factorial_of(k)

def prime_factors (n):
    arr = []
    while n>1 :
        for i in range(2,n+1) :
            if n%i == 0 :
                n//=i
                arr.append(i)
                break
    return arr

def number_format(n):
    return f'{n:,}'

def array_diff(a, b):
    return list(filter(lambda x:x!=None ,map(lambda x:x  if x not in b else None,a)))

def solve(arr):
    return reduce(lambda a,b:a*b,list(map(lambda x:len(set(x)),[sublist for sublist in arr])))

def sqrt_approximation(number):
    i = 1
    while i*i <number :
        i+=1 
    return i if i*i == number else [i-1,i]
    
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
    value = "".join(list(map(lambda x:bin(int(x))[2:].zfill(8),ip.split("."))))
    return int(value, 2)

def num_to_ip(num):
    arr = list(map(lambda x:str(int(bin(num)[2:].zfill(32)[x:x+8],2)),[i for i in range(0,len(bin(num)[2:].zfill(32)),8)]))
    return ".".join(arr)

def high(x):
    return x.split(" ")[list(map(lambda m:sum(list(map(lambda n:ord(n)-96,[char for char in m]))),x.split(" "))).index(max(list(map(lambda m:sum(list(map(lambda n:ord(n)-96,[char for char in m]))),x.split(" ")))))]

def sequence_sum(begin_number, end_number, step):
    return sum([i for i in range(begin_number,end_number+1,step)])

def sum_fibs(n):
    if n<=0 :return []
    arr = [0,1]
    while len(arr) <= n :
        arr.append(arr[len(arr)-2]+arr[len(arr)-1])
    return sum(num for num in arr if not num%2)

def oddity(n):
    return "even" if len([i for i in range(1,n+1) if n%i==0])%2==0 else "odd"

def dont_give_me_five(start, end):
    print([i for i in range(start,end+1) if str(i).count("5")==0])
    return len([i for i in range(start,end+1) if str(i).count("5")==0])

def zip_with(fn,a1,a2):
    return list(map(lambda x:fn(a1[x],a2[x]),range(0,min(len(a1),len(a2)))))

def hollow_triangle(n):
    arr = list(map(lambda x:"_"*(n-x)+"#"+"_"*(2*(x-1)-1)+"#"+"_"*(n-x),range(2,n)))
    arr.insert(0,"_"*(n-1)+"#"+"_"*(n-1))
    arr.append("#"*(2*n-1))
    print("\n".join(arr))
    return arr
    
def to_sha256(s):
    return hashlib.sha256(s.encode()).hexdigest()

def alphanumeric(password):
    return password != "" and len(list(filter(lambda x: not x.isnumeric() and not x.isalpha(),[char for char in password]))) == 0

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
    return (math.lcm(x,y)//x, math.lcm(x,y)//y)

def number_of_routes(m, n):
    return choose(m+n,n)

def is_pangram(s):
    for i in range(1,27) :
        if chr(i+96) not in s.lower() :
            return False
    return True

def order(sentence):
    if sentence == "" :return ""
    arr=sentence.split(" ")
    dir = {}
    for item in arr :
        index = [i for i in item if i.isnumeric()][0]
        dir[index] =item
    return " ".join(list(map(lambda x:dir[str(x)],[i for i in range(1,len(dir)+1)])))

def solution(*args):
    return len(list(args)) != len(set(args)) if args is not None else False

def get_w(height):
    if height < 2 : return []
    result = ["*"+" "*(2*(height-1)-1)+"*"+" "*(2*(height-1)-1)+"*"]
    for i in range(1,height-1) :
        result.append(" "*i+"*"+" "*(2*(height-i-1)-1)+"*"+" "*(2*i-1)+"*"+" "*(2*(height-i-1)-1)+"*"+" "*i)
    result.append(" "*(height-1)+"*"+" "*(2*(height-1)-1)+"*"+" "*(height-1))
    return result

def delete_nth(order,max_e):
    result = []
    for i in order :
        if result.count(i) < max_e :
            result.append(i)
    return result

def Xbonacci(signature,n):
    if n <= len(signature) : return signature[:n]
    for i in range(0,n-len(signature)) :
        signature.append(sum(signature[i:i+len(signature)]))
    return signature

def twos_difference(lst): 
    result = []
    for num in sorted(lst) :
        if lst.count(num+2) > 0 :
            result.append((num,num+2))
    return result

def f(n):
    return 1 if n == 0 else (n - m(f(n - 1)))

def m(n):
    return 0 if n == 0 else (n - f(m(n - 1)))

def move_zeros(lst):
    return list([i for i in lst if i != 0])+[0 for _ in range(0,lst.count(0))]

def word_to_char_count_dir(word):
    word_dir = {}
    for char in set(word[0:]) :
        word_dir[char] = word.count(char)
    return word_dir

def anagrams(word, words):
    return list(filter(lambda x:word_to_char_count_dir(x)==word_to_char_count_dir(word),words))

def beeramid(bonus, price):
    if bonus<=0 :return 0
    index = 1 ; total = 0
    while total <= bonus :
        total+=price*int(pow(index,2))
        index+=1
    return index-2

def solution(array_a, array_b):
    return sum(list(map(lambda x:pow(abs(array_a[x]-array_b[x]),2),(i for i in range(0,len(array_a)))))) / len(array_a)

def valid_ISBN10(isbn): 
    if len([i for i in isbn[:8] if i.isnumeric()==False])>0 or len(isbn)!=10:return False
    total = 0
    for i in range(1,10):
        total+=int(isbn[i-1])*i
    if isbn[-1] == "X" :
        total+= 100
    if isbn[-1].isnumeric() == True :
        total+=int(isbn[-1])*10
    print(total)
    return total%11==0

def lcm(*args):
    return reduce(lambda a,b:math.lcm(a,b),list(args)) if args != () else 1

def main():
    pass


if __name__ == "__main__":
    main()
