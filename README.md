# LeetCode - C# Solution

Techniques:

Array: Prefix Sum, Range Addition (Prefix Sum with input (0,0,0,0)), Prefix XOR, Boundary Swap (Dutch Flag), Sliding Window/Two Pointers, Partition, Merge 2 sorted arrays, 
*Use temp for swapping results in significant better performance compared to swap in-place
*Partition: Lomuto (Boundary Swap) maintains original order, Hoare not maintain original order.
    Use for find Kth or K largest/smallest - can also make use of binary heap(priority queue)
*Counting sort: Use when valueRange <= n:
    Sort or find the value with max frequency in array,
    Find how many Numbers Are Smaller Than the Current Number (Leetcode 1365)
*Merge sort: Use to find any number a[i], a[r] (i < r) when a[i], a[r] statisfy a condition

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

Binary Tree: Using Prefix Sum, DFS (O(V + E)), BFS(O(V + E)), Dynamic Programming
*DFS use to find connected graph, dynamic programming
*Dynamic Programming: 1. Choose optimal structure, 2. Avoid overlapping Subproblems (using cache/memoization)
*Fibonacci: O(2^n)
*BFS use to find the shortest path, deal with level in tree
*Binary Search: 
**Can use with sorted list, rotated sorted list, binary search tree
**Can use for problems which have the only way to solve is to bruteforce
**Can use for finding max of min, min of max
**Notice:
***Look for more indepth instructions at https://www.evernote.com/shard/s601/sh/51bb4614-ef6b-b3b4-3eac-14e357413141/08dc2a9e498e3e4276edae0866ee01a7
***Be careful for the overflow issue when calculating middle = middle = low + (high - low) / 2
***If it is a search problem or something we don't know the answer is there or not, then while(low <= high)
***If it is min, max problem or something we know the answer must be there, then while(low < high) and one of low/high would be assigned to middle, 
the other has to be assigned like this: For low = middle + 1, for high = middle - 1; 
**** If in case low = middle + 1, high = middle, then middle = low + (high - low) / 2
**** If in case low = middle, high = middle - 1, then middle = low + (high - low + 1) / 2

Binary Search Tree: Not balanced, unique values, In order traversal gives increasing sequence and In order traversal reversed gives decreasing sequence
