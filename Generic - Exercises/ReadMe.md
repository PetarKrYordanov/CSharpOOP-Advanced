## 1.
# Exercises

# : Generics

This document defines the exercises for [&quot;C# OOP Advanced&quot; course @ Software University](https://softuni.bg/trainings/2085/csharp-oop-advanced-november-2018).

Please submit your solutions (source code) of all below described problems in [Judge](https://judge.softuni.bg/Contests/248/Generics-Exercise).

1. **1.** Generic Box of String

Create a generic class **Box** that can be initialized with any type and store the value. Override **ToString()** method method and print the type and stored value in format {class full name: value}. On the first line, you will get **n** - the number of strings to read from the console. On the next **n** lines, you will get the actual strings. For each of them create a box and call its **ToString()** method to print its data on the console.

### Examples

| **Input** | **Output** |
| --- | --- |
| 2life in a boxbox in a life | System.String: life in a boxSystem.String: box in a life |

1. **2.** Generic Box of Integer

Use the description of the previous problem but now, test your generic box with Integers.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3712342 | System.Int32: 7System.Int32: 123System.Int32: 42 |

1. **3.** Generic Swap Method Strings

Create a generic method that receives a list, containing any type of data and swaps the elements at two given indexes.

As in the previous problems read **n** number of boxes of type String and add them to the list. On the next line, however you will receive a swap command consisting of two indexes. Use the method you&#39;ve created to swap the elements that correspond to the given indexes and print each element in the list.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3PeshoGoshoSwap me with Pesho0 2 | System.String: Swap me with PeshoSystem.String: GoshoSystem.String: Pesho |

1. **4.** Generic Swap Method Integers

Use the description of the previous problem but now, test your list of generic boxes with Integers.

### Examples

| **Input** | **Output** |
| --- | --- |
| 37123420 2 | System.Int32: 42System.Int32: 123System.Int32: 7 |

1. **5.** Generic Count Method Strings

Create a **method** that receives as an argument a **list of any type that can be compared** and an **element of the given type**. The method should **return the count of the elements that are greater than the value of the given element**. **Modify your Box class** to support **comparison by value** of the stored data.

On the first line, you will receive **n** - the number of elements to add to the list. On the next **n** lines, you will receive the actual elements. On the last line, you will get the value of the element to which you need to compare every element in the list.

### Examples

| **Input** | **Output** |
| --- | --- |
| 3aaaaabbaa | 2 |

1. **6.** Generic Count Method Doubles

Use the description of the previous problem but now, test your list of generic boxes with **doubles**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 37.13123.2242.787.55 | 2 |

1. **7.** Custom List

Create a generic data structure that can store **any** type that **can** be compared. Implement functions:

- **void Add(T element)**
- **T Remove(int index)**
- **bool Contains(T element)**
- **void Swap(int index1, int index2)**
- **int CountGreaterThan(T element)**
- **T Max()**
- **T Min()**

Create a command interpreter that reads commands and modifies the custom list that you have created. Set the custom list&#39;s type to string. Implement the commands:

- **Add \&lt;element\&gt;** - Adds the given element to the end of the list
- **Remove \&lt;index\&gt;** - Removes the element at the given index
- **Contains \&lt;element\&gt;** - Prints if the list contains the given element **(True or False)**
- **Swap \&lt;index\&gt; \&lt;index\&gt;** - Swaps the elements at the given indexes
- **Greater \&lt;element\&gt;** - Counts the elements that are greater than the given element and prints their count
- **Max** - Prints the maximum element in the list
- **Min** - Prints the minimum element in the list
- **Print** - Prints all of the elements in the list, each on a separate line
- **END** - stops the reading of commands

There will **not** be any **invalid** input commands.

### Examples

| **Input** | **Output** |
| --- | --- |
| Add aaAdd bbAdd ccMaxMinGreater aaSwap 0 2Contains aaPrintEND | ccaa2Trueccbbaa    |

1. **8.** Custom List Sorter

Extend the previous problem. It should have a **method**** Sort() **which can sort objects of type** CustomList **containing any type that can be compared.** Extend the command list** to support one additional command Sort:

- **Sort** - Sort the elements in the list in ascending order.

### Examples

| **Input** | **Output** |
| --- | --- |
| Add ccAdd bbAdd aaSortPrintEND | aabbcc |

1. **9.** \*Custom List Iterator

For the print command, you have probably used a **for** loop. Extend your custom list class by making it implement **IEnumerable\&lt;T\&gt;.** This should allow you to iterate your list in a foreach statement.

### Examples

| **Input** | **Output** |
| --- | --- |
| Add aaAdd bbAdd ccMaxMinGreater aaSwap 0 2PrintEND | ccaa2ccbbaa |

1. **10.** Tuple

There is something, really annoying in C#. It is called a [**Tuple**](https://msdn.microsoft.com/en-us/library/system.tuple(v=vs.110).aspx). It is a class, which may store a few objects but let&#39;s focus on the type of Tuple which contains two objects. The first one is &quot; **item1**&quot; and the second one is &quot; **item2**&quot;. It is kind of like a **KeyValuePair** except – it **simply has items,** which are **neither key nor value**. The annoyance is coming from the fact, that you have no idea what these objects are holding. The class name is telling you nothing, the methods, which it has – also. So, let&#39;s say for some reason we would like to try to implement it by ourselves.

The task: Create a class &quot; **Tuple**&quot;, which is holding two objects. Like we said, the first one, will be &quot; **item1**&quot; and the second one - &quot; **item2**&quot;. The tricky part here is to make the class hold generics. This means, that when you create a new object of class - &quot; **Tuple**&quot;, there should be a way to explicitly, specify both the items&#39; type separately.

### Input

The input consists of three lines:

- The first one is holding a person name and an address. They are separated by space(s). Your task is to collect them in the tuple and print them on the console. Format of the input:

**\&lt;first name\&gt; \&lt;last**  **name**** \&gt;\&gt; ****\&lt;**** address ****\&gt;**

- The second line holds a **name** f a personand the **amount of beer** (int) he can drink. Format:

**\&lt;**** name ****\&gt; \&lt;**** liters of beer ****\&gt;**

- The last line will hold an **Integer** and a **Double**. Format:

**\&lt;**** Integer ****\&gt; \&lt;**** Double ****\&gt;**

### Output

- Print the tuples&#39; items in format: { **item1** } -\&gt; { **item2** }

### Constraints

Use the good practices we have learned. Create the class and make it have getters and setters for its class variables. The input will be valid, no need to check it explicitly!

### Example

| **Input** | **Output** |
| --- | --- |
| Sofka Tripova StolipinovoAz 223 21.23212321 | Sofka Tripova -\&gt; StolipinovoAz -\&gt; 2
1. 23-\&gt; 21.23212321
 |

1. **11.** Threeuple

Create a Class **Threeuple**. Its name is telling us, that it will hold no longer, just a pair of objects. The task is simple, our **Threeuple** should **hold three objects**. Make it have getters and setters. You can even extend the previous class

### Input

The input consists of three lines:

- The first one is holding a name, an address and a town. Format of the input:

**\&lt;\&lt;first name\&gt; \&lt;last name\&gt;\&gt; \&lt;**** address ****\&gt; \&lt;**** town ****\&gt;**

- The second line is holding a name, beer liters, and a Boolean variable with value - **drunk** or **not**. Format:

**\&lt;**** name ****\&gt; \&lt;**** liters of beer ****\&gt; \&lt;**** drunk or not ****\&gt;**

- The last line will hold a name, a bank balance (double) and a bank name. Format:

**\&lt;**** name ****\&gt; \&lt;account**  **balance**** \&gt; \&lt; ****bank name**** \&gt;**

### Output

- Print the Threeuples&#39; objects in format: { **firstElement** } -\&gt; { **secondElement** } -\&gt; { **thirdElement** }

### Examples

| **Input** | **Output** |
| --- | --- |
| Sofka Tripova Stolipinovo PlovdivMitkoShtaigata 18 drunkSashoKompota 0.10 NkqfaBanka | Sofka Tripova -\&gt; Stolipinovo -\&gt; PlovdivMitkoShtaigata -\&gt; 18 -\&gt; TrueSashoKompota -\&gt; 0.1 -\&gt; NkqfaBanka |
| Ivan Ivanov Tepeto PlovdivMitko 18 notSasho 0.10 NGB | Ivan Ivanov -\&gt; Tepeto -\&gt; PlovdivMitko -\&gt; 18 -\&gt; FalseSasho -\&gt; 0.1 -\&gt; NGB |

### Note

You may extend your previous solution.