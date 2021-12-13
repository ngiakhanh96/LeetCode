# LeetCode - C# Solution

Techniques:

Array: Prefix Sum, Range Addition (Prefix Sum with input (0,0,0,0)), Prefix XOR, Boundary Swap (Dutch Flag), Sliding Window as special case of Two Pointers, Partition, Merge 2 sorted arrays, 
*Use temp for swapping results in significant better performance compared to swap in-place
*Partition: Lomuto (Boundary Swap) maintains original order, Hoare not maintain original order.
    Use for find Kth or K largest/smallest - can also make use of binary heap(priority queue)
*Counting sort: Use when valueRange <= n:
    Sort or find the value with max frequency in array,
    Find how many Numbers Are Smaller Than the Current Number (Leetcode 1365)
*Merge sort: Use to find any number a[i], a[r] (i < r) when a[i], a[r] statisfy a condition
*Merge sort and heap sort can be used on LinkedList while quicksort can't
*Counting sort: Use element as index in the second array, value as the frequency
*Bucket sort: Use frequency(or array.size() * val) as index in the second array, value as the dynamic list (or linked-list) of elements
*Two pointers same direction template: see _485, _674, _845
*Two pointers opposite direction template: see _15
*1/-1 First occurence: see _525, _1124

Bit Manipulation: n &= (n - 1), Subset a bitmask from 0 to 2^n - 1, Get Bit, Clear Bit, ~ for flip, & for get/clear, | for get/set | ^ for get/set/clear/flip
*XOR: 
    x^y^x = y, number of subsets with XOR result containing ith bit set will be half of subsets (see _1863)
    x^0 = x
    x^x = 0
    x^y = y^x
    (x^y)^z =  x^(y^z)

LinkedList: Floyd Algorithm, Reverse, Merge/Heap Sort

CircularQueue

Deque: Use doubly linked-list. Find max in a sliding window

Queue: Find sum/product in a sliding window

Stack: Deal with invalid ({) or remove duplicated characters, Evaluate Reverse Polish Notation (2,3,+)

Binary Heap(Priority Queue): 
*Use to get 2 smallest(largest) values, update or combine them then add back to the heap
*Use to find K smallest(largest) in a stream
*Use 2 heaps (max and min) to track the median value (see _295)

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
*Dijkstra algorithm: Use to find shortest path in a non negative weight map. See reverse Dijkstra in _1514

Binary Search Tree: Not balanced, unique values, In order traversal gives increasing sequence and In order traversal reversed gives decreasing sequence

Union Find: Use to combine things which share common patterns into one group with runtime nearly O(1). For more info https://docs.google.com/presentation/d/1_j8xIydyYzjB_M9J4qGC-YYYvzRrRDW2UUMhTy8Rl6g/edit#slide=id.gfc60fc96f0_0_310

MinimumSpanningTree: a sorted version of UnionFind. Used to find the minimum cost to connect all the vertices in the graph

LeftToRightMinimaTree: Use to find (left/right) nearest position that contains a smaller/bigger value in an array. Runtime O(n). Proof: https://hoangdinhquang.me/on-lrm-trees-lemma-application/

Trie: Use to find the prefix words from the set of given words. May combine with Dfs, Dictionary, Min/Max Heap

Dynamic Programming (DP): Can be realized by 2 approaches: Bottom-up and Top-down with memoization (cache)
*If f[i] only relies on f[i - 1], then maybe don't need cache for both bottom-up and top-down approach
More general case: see _650. f[i] only relies on f[i - j] (j < i and j satisfies a given condition), then don't need cache for top-down but need stack for bottom-up to calculate up
*If f[i] relies on many i - 1, i - 2, ...(finite), then maybe need cache(with constant size) for top-down approach
*If f[i] relies on all i - 1, i - 2, ..., 0, then maybe need cache even for bottom-up and top-down approach
