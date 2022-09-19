//
//  main.swift
//  SwiftPractice
//
//  Created by 蕭博文 on 2022/5/10.
//

import Foundation

func validBraces(_ string:String) -> Bool {
    print(string)
    let bracesArr = Array(string)
    var tmpArr = Array<String>()
    for brace in bracesArr {
        switch brace {
        case "(","[","{" :
            tmpArr.append(brace.description)
        case ")","]","}" :
            tmpArr.append(brace.description)
        default:
            break
        }
    }
    print(tmpArr)
    return tmpArr.isEmpty
}

func howMuch(_ m: Int, _ n: Int) -> [(String, String, String)] {
    var M,B,C : Int
    var result:[(String,String,String)] = []
    for num in min(m, n)...max(m, n) {
        if (num-2)%7 == 0 && (num-1)%9 == 0 {
            M = num
            B = (M-2)/7
            C = (M-1)/9
            result.append(("M: \(M)", "B: \(B)", "C: \(C)"))
        }
    }
    return result
}

func factors(of n: Int) -> [Int] {
    precondition(n > 0, "n must be positive")
    let sqrtn = Int(Double(n).squareRoot())
    var factors: [Int] = []
    factors.reserveCapacity(2 * sqrtn)
    for i in 1...sqrtn {
        if n % i == 0 {
            factors.append(i)
        }
    }
    var j = factors.count - 1
    if factors[j] * factors[j] == n {
        j -= 1
    }
    while j >= 0 {
        factors.append(n / factors[j])
        j -= 1
    }
    return factors
}

func solequa(_ n: Int) -> [(Int, Int)] {
    var x,y:Int
    var answer:[(Int,Int)] = []
    var factor_arr:[Int] = []
    factor_arr = factors(of: n)
    for _ in 1...factor_arr.count/2 {
        x=(factor_arr.first!+factor_arr.last!);y=(factor_arr.last!-factor_arr.first!)
        if x%2 == 0 && y%4 == 0 {
            answer.append((x/2,y/4))
        }
        factor_arr.removeFirst()
        factor_arr.removeLast()
    }
    if factor_arr.count == 1 {
        answer.append((factor_arr[0],0))
    }
    return answer
}

func sumFracts(_ l: [(Int, Int)]) -> (Int, Int)? {
    if l.isEmpty {return nil }
    var numerator:Int = l[0].0 ,denominator:Int = l[0].1
    var max_common_factor = 1
    if l.count != 1 {
        for i in 1..<l.count {
            numerator = (numerator*l[i].1+l[i].0*denominator)
            denominator*=l[i].1
        }
        for num in 2...min(numerator, denominator) {
            if numerator%num == 0 && denominator%num == 0{
                max_common_factor = num
            }
        }
    }
    return (numerator/max_common_factor,denominator/max_common_factor)
}


func listSquared(_ m: Int, _ n: Int) -> [(Int, Int)] {
    var result:[(Int,Int)] = []
    var sum_of_divisors:Double
    for num in m...n {
        sum_of_divisors = Double(factors(of: num).map({$0*$0}).reduce(0, +))
        if sqrt(sum_of_divisors) == Double(Int(sqrt(sum_of_divisors))) {
            result.append((num,Int(sum_of_divisors)))
        }
    }
    return result
}

func get_kprime_num(of num:Int) -> Int {
    var n = num
    var count = 0
    while n > 1 {
        for i in 2...n {
            if n%i == 0 {
                count+=1
                n/=i
                break
            }
        }
    }
    return count
}

func kprimesStep(_ k: Int, _ step: Int, _ m: Int, _ n: Int) -> [(Int, Int)]? {
    let list:[Int] = Array(m...n).filter({get_kprime_num(of: $0)==k})
    var result:[(Int,Int)] = []
    for num in list {
        if list.contains(where: {$0 == num+step}) {
            result.append((num,num+step))
        }
    }
    return result.isEmpty ? nil : result
}

func get_kprime_num_list(of num:Int) -> [Int] {
    var n = num
    var result:[Int] = []
    while n > 1 {
        for i in 2...n {
            if n%i == 0 {
                result.append(i)
                n/=i
                break
            }
        }
    }
    return result
}


func decomp(_ m: Int) -> String {
    var dir:[Int:Int] = [:]
    var result:[String] = []
    for i in 2...m {
        get_kprime_num_list(of: i).forEach({n in
            if dir[n] == nil {
                dir[n] = 1
            } else {dir[n]=dir[n]!+1}
        })
    }
    for pair in dir.sorted(by: {$0.key < $1.key}) {
        if pair.value >= 2 {
            result.append("\(pair.key)^\(pair.value)")
        } else {
            result.append("\(pair.key)")
        }
    }
    return result.joined(separator: " * ")
}

func beggars(_ values: [Int], _ n: Int) -> [Int] {
    var result:[Int] = []
    var tmp:Int = 0
    var index:Int
    for i in 0..<n {
        index = i
        tmp = 0
        while true {
            if index <= values.count-1 {
                tmp+=values[index]
                index+=n
            } else {break}
        }
        result.append(tmp)
    }
    return result
}

func race(_ v1: Int, _ v2: Int, _ g: Int) -> [Int]? {
    if v1>=v2 {return nil}
    let total_seconds:Int = g*3600 / (v2-v1)
    var h=0,m=0,s=0
    s = total_seconds % 60
    m = ((total_seconds-s)/60)%60
    h = (total_seconds-s)/(60*60)
    return [h,m,s]
}

func rank(_ st: String, _ we: [Int], _ n: Int) -> String {
    if st.isEmpty {return "No participants"}
    if n > st.split(separator: ",").count {return "Not enough participants"}
    let name_list = st.split(separator: ",")
    var value_list:[Int] = []
    var value_dir:[String:Int] = [:]
    name_list.forEach({name in
        value_list.append(name.count+name.map({Int(Character($0.lowercased()).asciiValue!-96)}).reduce(0, +))
    })
    for i in 0..<value_list.count {
        value_list[i]*=we[i]
        value_dir[String(name_list[i])] = value_list[i]
    }
    return value_dir.sorted(by: {$0.value == $1.value ? $0.key < $1.key : $0.value > $1.value})[n-1].key
}

func productFib(_ prod : UInt64) -> (UInt64,UInt64,Bool) {
    var arr:[UInt64] = [0,1]
    var index = 0
    var answer:(UInt64,UInt64,Bool) = (0,0,false)
    while arr.reduce(0, +) < prod {
        arr.append(arr[index]+arr[index+1])
        index+=1
        if arr[index]*arr[index+1] == prod {
            answer.0 = arr[index]
            answer.1 = arr[index+1]
            answer.2 = true
            break
        } else if arr[index]*arr[index+1] > prod {
            answer.0 = arr[index]
            answer.1 = arr[index+1]
            break
        }
    }
    return answer
}

func thirt(_ n: Int) -> Int {
    var tmp:Int = 0 , result:Int = n
    var divisions_list:[Int] = [1,10,9,12,3,4,1]
    while divisions_list.count < result.description.count {
        divisions_list+=divisions_list[1...]
    }
    var n_list = String(result).map({$0.wholeNumberValue!}) ; n_list = n_list.reversed()
    while result.description.count > 2 {
        tmp = 0
        for i in 0..<n_list.count {
            tmp+=divisions_list[i]*n_list[i]
        }
        result = tmp
        n_list = String(result).map({$0.wholeNumberValue!}) ; n_list = n_list.reversed()
    }
    return result
}


func get_minimal_fraction(fraction:(Int,Int)) -> (Int,Int) {
    var new_fraction = fraction
    var can_continue:Bool = true
    while can_continue {
        for i in 2...min(new_fraction.0, new_fraction.1)+1 {
            if new_fraction.0%i == 0 && new_fraction.1%i == 0 {
                new_fraction.0/=i;new_fraction.1/=i
                break
            } else {can_continue = false}
        }
    }
    return (new_fraction.0,new_fraction.1)
}

func convertFracts(_ l: [(Int, Int)]) -> [(Int, Int)] {
    var dir:[Int:Int] = [:]
    var LCM:Decimal = 1
    let fract_kprime_list:[[Int]] = l.map({get_kprime_num_list(of: $0.1)})
    var result:[(Int,Int)] = []
    fract_kprime_list.flatMap({$0}).forEach({num in
        if dir[num] == nil {dir[num] = 1}
    })
    for num in dir.keys {
        fract_kprime_list.forEach({arr in
            if arr.filter({$0 == num}).count > dir[num]! {dir[num] = arr.filter({$0 == num}).count}
        })
    }
    dir.forEach({pair in
        LCM *= pow(Decimal(pair.key), pair.value)
    })
    l.forEach({fract in
        result.append((fract.0 * (Int(LCM.description)!/fract.1),Int(LCM.description)!))
    })
    print(dir)
    return result
}


class Solution {
    static func twosum(numbers: [Double], target: Double) -> [Int] {
        let filtered_list = numbers.map({$0}).filter({numbers.contains(target-$0)})
        return [numbers.firstIndex(of: filtered_list.first!)!,numbers.lastIndex(of: filtered_list.last!)!]
    }
}

func swap(_ s: String, n: Int) -> String {
    var s_arr = s.compactMap({$0})
    var bin_arr = Array(String(n,radix: 2))
    var index = 0
    while bin_arr.count < s.filter({$0.isLetter}).count {bin_arr+=bin_arr}
    s_arr.forEach({char in
        if char.isLetter {
            if bin_arr[index] == "1" {
                s_arr[index] = char.isLowercase ? Character(char.uppercased()) : Character(char.lowercased())
            } else {
                s_arr[index] = Character(char.description)
            }
        } else {
            s_arr[index] = Character(char.description)
            bin_arr.insert("x", at: index-1)
        }
        index+=1
    })
    return String(s_arr)
}

//print(swap("Hello world!", n: 11)) // "heLLO wORLd!"
//print(swap("gOOd MOrniNg", n: 7864)) // "GooD MorNIng"

func longestRepetition(_ s: String) -> [String: Int]{
    if s.isEmpty {return ["":0]}
    let set_of_s = Set(s.compactMap({$0}))
    var dir:[String:Int] = [:]
    var result:[String:Int] = [:]
    set_of_s.forEach({char in
        dir[char.description] = s.compactMap({$0}).filter({$0==char}).count
    })
    let sorted_dir = dir.sorted(by: {$0.value>$1.value})
    if dir.filter({$0.value == dir.max(by: {$0.value<$1.value})?.value}).count >= 2 {
        for char in s {
            if dir[char.description] == dir.max(by: {$0.value<$1.value})?.value {
                result = [char.description:dir[char.description]!]
                break
            }
        }
    } else {
        result = [sorted_dir[0].key:sorted_dir[0].value]
    }
    return result
}

func euclideanDistanceBetween(_ point1: [Double], and point2: [Double]) -> Double {
    var result:Double = 0
    for i in 0..<point1.count {
        result+=pow(point1[i].distance(to: point2[i]), 2)
    }
    return Double(round(100 * pow(result, 0.5)) / 100)
}

func minimumPerimeter(_ area: Int64) -> Int64 {
    let factor_list:[Int] = factors(of: Int(area))
    var result:Int64 = 0
    if factor_list.count % 2 == 0 {
        result = Int64(factor_list[(factor_list.count)/2]+factor_list[((factor_list.count)/2)-1])*2
    } else {
        result = Int64(factor_list[(factor_list.count-1)/2]*4)
    }
    return result
}


func countArare(_ n: Int) -> String {
    var result:[String] = []
    for _ in 1...n/2 {result.append("adak")}
    n%2 == 0 ? nil : result.append("anane")
    return result.joined(separator: " ")
}

func foldArray(_ arr: [Int], times: Int) -> [Int] {
    var result:[Int] = arr
    var fold_arr:[Int] = arr
    var arr_count:Int
    for _ in 0..<times {
        arr_count = result.count
        if arr_count == 1 {break}
        if arr_count % 2 == 0 {
            fold_arr = result[arr_count/2...arr_count-1].reversed()
            for i in 0..<fold_arr.count {
                result[i] = result[i]+fold_arr[i]
            }
            result.removeSubrange(arr_count/2...arr_count-1)
        } else {
            fold_arr = result[(arr_count+1)/2...arr_count-1].reversed()
            for i in 0..<fold_arr.count {
                result[i] = result[i]+fold_arr[i]
            }
            result.removeSubrange((arr_count+1)/2...arr_count-1)
        }
    }
    return result
}

func whatCentury(_ year: String) -> String {
    let cen = Int(year)!%100 == 0 ? Int(year)!/100 : (Int(year)!/100)+1
    var end:String = "th"
    switch cen.description.last! {
    case "1" :
        end = "st"
    case "2" :
        end = "nd"
    case "3" :
        end = "rd"
    default :
        break
    }
    return cen.description+end
}

func numPrimoral( _ number: UInt ) -> UInt {
    var num_list:[UInt] = []
    var index:UInt = 2
    while num_list.count < number {
        if factors(of: Int(index)).count == 2 {
            num_list.append(index)
        }
        index+=1
    }
    print(num_list)
    return num_list.reduce(1, *)
}

func findMissingLetter(_ chArr: [Character]) -> Character {
    let ch_code_arr = chArr.map({$0.asciiValue!})
    var answer:Character = Character(" ")
    for i in ch_code_arr.min()!...ch_code_arr.max()! {
        if !ch_code_arr.contains(where: {$0 == i}) {
            answer = Character(UnicodeScalar(i))
            break
        } else {
            answer = Character(UnicodeScalar(i+1))
        }
    }
    return answer
}

func expandedForm(_ num: Int) -> String {
    let num_to_arr = Array(num.description)
    var result:[String] = []
    for i in 0..<num_to_arr.count {
        if num_to_arr[i] != "0" {
            result.append(String(repeating: "\(num_to_arr[i])", count: 1)+String(repeating: "0", count: num_to_arr.count-i-1))
        }
    }
    return result.joined(separator: " + ")
}

func find_missing(l:[Int]) -> Int {
    let spacing = (l.max()!-l.min()!)/l.count
    let array = Array(stride(from: l.min()!, through: l.max()!, by: spacing))
    let difference = Set(array).symmetricDifference(Set(l))
    return difference.first!
}

func perimeter(_ n: UInt64) -> UInt64 {
    var arr:[UInt64] = [1,1]
    while arr.count < n+1 {
        arr.append(arr[arr.count-1]+arr[arr.count-2])
    }
    return 4*(arr.reduce(0, +))
}

//extension Int {
//    func isPrime() -> Bool {
//        return self > 0 ? factors(of: self).count == 2 : false
//    }
//}

func getPrimes(from start: Int, to end: Int) -> [Int] {
    var arr:[Int] = []
    let new_start = start > 0 ? start : 1
    let new_end = end > 0 ? end : 1
    for i in Array(min(new_start, new_end)...max(new_start, new_end)) {
        if factors(of: i).count == 2 {
            arr.append(i)
        }
    }
    return arr
}

