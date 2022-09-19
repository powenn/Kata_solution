import "dart:core";

List<int> maps(List<int> arr) => arr.map((e) => e *= 2).toList();

bool valid_spacing(String text) {
  print(text.split(" "));
  return !text.split(" ").contains("") || text.isEmpty;
}

int add(int num1, int num2) {
  List<String> num1_to_list = num1.toString().split(""),
      num2_to_list = num2.toString().split("");
  List<String> result_list = [];
  while (num1_to_list.length != num2_to_list.length) {
    if (num1_to_list.length < num2_to_list.length) {
      num1_to_list.insert(0, "0");
    } else {
      num2_to_list.insert(0, "0");
    }
  }
  for (int i = 0; i < num1_to_list.length; i++) {
    result_list.add(
        (int.parse(num1_to_list[i]) + int.parse(num2_to_list[i])).toString());
  }
  return int.parse(result_list.join());
}

// int solve(String s) {
//   List<String> num_list = [];
//   s = s.replaceAll(new RegExp(r'[^0-9]'), " ");
//   num_list = s.split(" ")..retainWhere((element) => element.isNotEmpty);
//   num_list.sort((a, b) => int.parse(a).compareTo(int.parse(b)));
//   return int.parse(num_list.last);
// }

int getCount(String inputStr) {
  int count = 0;
  List<String> v_list = ["a", "e", "i", "o", "u"];
  inputStr.split("").forEach((element) {
    if (v_list.contains(element)) {
      count++;
    }
  });
  return count;
}

int save(List<int> sizes, int hd) {
  int total = 0, index = 0;
  for (var num in sizes) {
    total += num;
    index++;
    if (total == hd) {
      break;
    } else if (total > hd) {
      index--;
      break;
    }
  }
  return index;
}

List<List<String>> partlist(List<String> arr) {
  List<List<String>> result = [];
  for (int i = 1; i < arr.length; i++) {
    result.add([arr.sublist(0, i).join(" "), arr.sublist(i).join(" ")]);
  }
  return result;
}

int minSum(arr) {
  int sum = 0;
  List<int> new_arr = arr;
  print(new_arr..sort());
  for (int i = 0; i < new_arr.length / 2; i++) {
    sum += new_arr[i] * new_arr[new_arr.length - i - 1];
  }
  return sum;
}

class SequenceSum {
  static String showSequence(int n) {
    String answer = "";
    List<int> n_list = [];
    if (n < 0) {
      answer = "${n}<0";
    } else if (n == 0) {
      answer = "0=0";
    } else {
      n_list = List.generate(n + 1, (int index) => index);
      answer = "${n_list.join("+")} = ${n_list.reduce((a, b) => a + b)}";
    }
    return answer;
  }
}

int adjacentElementsProduct(array) {
  List<int> input = array;
  int answer = input[0] * input[1];
  for (int i = 1; i < input.length - 1; i++) {
    if (input[i] * input[i + 1] > answer) {
      answer = input[i] * input[i + 1];
    }
  }
  return answer;
}

int maxProduct(arr, size) {
  List<int> new_arr = List.from(arr)..sort();
  return new_arr
      .sublist(new_arr.length - int.parse(size.toString()))
      .reduce((a, b) => a * b);
}

// List<int> solve(List<String> arr) {
//   List<int> result = [];
//   int count = 0;
//   arr = arr.map((e) => e.toLowerCase()).toList();
//   arr.forEach((element) {
//     count = 0;
//     for (int i = 0; i < element.length; i++) {
//       if (element[i] == String.fromCharCode(i + 97)) {
//         count++;
//       }
//     }
//     result.add(count);
//   });
//   return result;
// }

int maxTriSum(nums) {
  List<int> nums_list = List.from(nums)..sort();
  print(nums_list);
  print(nums_list.sublist(nums_list.length - 3).reduce((a, b) => a + b));
  return nums_list.sublist(nums_list.length - 3).reduce((a, b) => a + b);
}

List solve(arr) {
  List<int> num_arr = List.from(arr);
  print(num_arr);
  for (int i = 0; i < num_arr.length; i++) {}
  return [];
}

int solution(int n) {
  List<int> result = [];
  if (n > 0) {
    for (int i = 0; i < n; i++) {
      if (i % 3 == 0 || i % 5 == 0) {
        result.add(i);
      }
    }
    return result.reduce((a, b) => a + b);
  }
  return 0;
}

String addLetters(List<String> letters) {
  if (letters.isEmpty) {
    return "z";
  }
  int value =
      letters.map((e) => e.codeUnits.first - 96).reduce((a, b) => a + b);
  print(value);
  if (value % 26 == 0) {
    return "z";
  }
  return value > 26
      ? String.fromCharCode(value % 26 + 96)
      : String.fromCharCode(value + 96);
}

void main(List<String> args) {
  print(addLetters(['a', 'b', 'c']));
  print(addLetters(['z']));
}
