# LeetCode - C# Solution

Techniques:

Array: Prefix Sum, Range Addition (Prefix Sum with input (0,0,0,0)), Prefix XOR, Boundary Swap (Dutch Flag), Sliding Window/Two Pointers, Partition, Merge 2 sorted arrays, 
*Use temp for swapping results in significant better performance compared to swap in-place
*Partition: Lomuto (Boundary Swap) maintains original order, Hoare not maintain original order.
Use for find Kth or K largest/smallest - can also make use of binary heap ?

Bit Manipulation: n &= (n - 1), Subset a bitmask from 0 to 2^n - 1, Get Bit, Clear Bit, ~ for flip, & for get/clear, | for get/set | ^ for get/set/clear/flip
*XOR: 
    x^y^x = y, number of subsets with XOR result containing ith bit set will be half of subsets (see _1863)
    x^0 = x
    x^x = 0
    x^y = y^x
    (x^y)^z =  x^(y^z)

LinkedList: Floyd Algorithm, Reverse, Merge Sort

CircularQueue

Deque: Find max in a sliding window

Queue: Find sum/product in a sliding window

Stack: Deal with invalid ({) or remove duplicated characters, Evaluate Reverse Polish Notation (2,3,+)

Binary Tree: Using Prefix Sum
