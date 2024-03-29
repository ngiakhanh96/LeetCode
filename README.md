# LeetCode - C# Solutions
## Table of Contents (WIP)
* [Array](#array)
* [Partition](#partition)
* [Counting sort](#counting-sort)
* [Merge sort/Heap sort](#merge-or-heap-sort)
* [Bucket sort](#bucket-sort)
* [Two pointers](#two-pointers)
* [1 or -1 First occurence](#one-or-minus-one-first-occurence)
* [Bit Manipulation](#bit-manipulation)
* [Binary Search](#binary-search)
* [Dijkstra](#dijkstra)
* [Binary Search Tree](#binary-search-tree)
* [Union Find](#binary-search-tree)
* [Minimum Spanning Tree](#left-to-right-minima-tree)
* [Left To Right Minima Tree](#left-to-right-minima-tree)
* [Trie](#trie)
* [Dynamic Programming](#dynamic-programming)
* [Database](#database)
## Techniques:

### Array:
* Prefix Sum, Range Addition (Prefix Sum with input (0,0,0,0)), Prefix XOR, Boundary Swap (Dutch Flag), Sliding Window as special case of Two Pointers, Partition, Merge 2 sorted arrays, 
* Use temp for swapping results in significant better performance compared to swap in-place

### Partition:
* Lomuto (Boundary Swap) maintains original order, Hoare not maintain original order.
* Used for find Kth or K largest/smallest - can also make use of binary heap(priority queue)

### Counting sort:
* Used when valueRange <= n:
* Sort or find the value with max frequency in array,
* Find how many Numbers Are Smaller Than the Current Number (see _1365)
* Use element as index in the second array, value as the frequency

### Merge or Heap sort:
* Used to find any number a[i], a[r] (i < r) when a[i], a[r] statisfy a condition
* Merge sort and heap sort can be used on LinkedList while quicksort can't

### Bucket sort:
* Use frequency(or array.size() * val) as index in the second array, value as the dynamic list (or linked-list) of elements

### Two pointers:
* Same direction template: see _485, _674, _845
* Opposite direction template: see _15, _259
* Matrix: see _240
* Sliding window: When given an array to find longest (count number) of something with at most K something
	```csharp
	var res = 0;
	if (fruits.Length == 0)
	{
		return res;
	}
	var (l, r) = (0, 0);
	// Initialize tracker
	var charDict = new Dictionary<int, int>();
	UpdateTracker(fruits, r);
	while (r < fruits.Length && l < fruits.Length)
	{
		if (charDict.Count <= k)
		{
			res = Math.Max(res, r - l + 1);
			// or res += r - l + 1;
			r++;
			if (r < fruits.Length)
			{
				UpdateTracker(fruits, r);
			}
		}
		else
		{
			UpdateTracker2(fruits, l);
			l++;
		}
	}
	return res;
	```


### One or minus one First occurence:
* See _525, _1124

### Bit Manipulation:
* turn off the right most bit: n & (n - 1),
* check if power of 2: n & (n - 1) == 0
* get_bit(x, position): (x >> position) & 1,
* set_bit(x, position): x | (1<<position),
* flip_bit(x, position): x ^ (1<<position),
* clear_bit(x, position): x & ~(1<<position), 
* ~ for flip => flip all bits, 
* & for get/clear => get/clear, 
* | for get/set => set, 
* ^ for get/set/flip/clear => flip single bit,
* See https://drive.google.com/file/d/1jdIyIEwzXEmis0tj5hjrOspXpaYzI2P3/view?usp=sharing
* Subset a bitmask from 0 to 2^n - 1
* XOR: 
	* x^y^x = y, number of subsets with XOR result containing ith bit set will be half of subsets (see _1863)
	* x^0 = x
	* x^x = 0
	* x^y = y^x (see raw markdown)
	* (x^y)^z =  x^(y^z) (see raw markdown)

### LinkedList: 
* Floyd Algorithm, Reverse, Merge/Heap Sort

### CircularQueue:
* See _622

### Deque: 
* Use doubly linked-list. Find max in a sliding window

### Queue: 
* Find sum/product in a sliding window

### Stack: 
* Deal with invalid ({) or remove duplicated characters, Evaluate Reverse Polish Notation (2,3,+)

### Binary Heap (Priority Queue): 
* Used to get 2 smallest(largest) values, update or combine them then add back to the heap
* Used to find K smallest(largest) in a stream
* Use 2 heaps (max and min) to track the median value (see _295)

### Binary Tree: 
* Use Prefix Sum, DFS (O(V + E)), BFS(O(V + E)), Dynamic Programming

### [DFS](https://www.evernote.com/shard/s601/sh/2c10dcd2-2b7d-fb51-deed-4b6bff378ea0/fa5a97ade555ec93d5293299ae6e3b69):
* Used to find connected graph. Can combine with DP. 
* Use bool[,] instead of HashSet<(int x, int y)>.
* Only use struct/primitive value for HashSet.
* For distance with nodes only or edges only: See _104 vs _543
* Dynamic Programming: 1. Choose optimal structure, 2. Avoid overlapping Subproblems (using cache/memoization)
* Fibonacci: O(2^n)

### BFS:
* Used to find the shortest path, deal with level in tree. 
* Use bool[,] instead of HashSet<(int x, int y)>.
* Only use struct/primitive value for HashSet and Queue.
* Try to calculate on the dequeuing node/value rather than its children


### [Binary Search](https://www.evernote.com/shard/s601/sh/51bb4614-ef6b-b3b4-3eac-14e357413141/08dc2a9e498e3e4276edae0866ee01a7):
* Can use with sorted list, rotated sorted list, binary search tree
* Can use for problems which have the only way to solve is to bruteforce
* Can use for finding max of min, min of max
* Notice:
	* Be careful for the overflow issue when calculating middle = low + (high - low) / 2
	* +1 or -1 for low/high is to avoid infinite loop which happens when high == low + 1 AND high == low
		* If while loop checks the case high == low then it is a MUST to assign low = middle + 1, high = middle - 1
		* Otherwise, if while loop of omit the case high == low, then it is only required either low or high to be + 1/ - 1 - depends on how to calculate the middle
		* For comparing with surrounding (see _852):
		* If it is min, max problem or something we know the answer must be there, then while(low < high) (when low == high, it's the answer. Can break the loop and return) and then next loop, one of low/high would be assigned to middle, 
		* the other has to be assigned like this: For low = middle + 1, or high = middle - 1; 
		* If in case low = middle + 1 when (arr[middle] < arr[middle + 1]), or high = middle,*    
		* then middle = low + (high - low) / 2 AND high runs from max - 1  (since high depends on middle, so middle has to be rounded down)
		* If in case low = middle,*   or high = middle - 1 when (arr[middle] < arr[middle - 1]), 
		* then middle = low + (high - low + 1) / 2 AND low runs from min + 1 (since low depends on middle, so middle has to be rounded up)
		* Finally return low or high

		* For comparing with fixed condition or with high/low (see _33):
		* If it is a search problem or something we don't know the answer is there or not, then while(low <= high),
		* low = middle + 1, high = middle - 1, middle = low + (high - low) / 2 or low + (high - low + 1) / 2
		* If it is min, max problem or something we know the answer must be there, then while(low < high) (when low == high, it's the answer. Can break the loop and return) and one of low/high would be assigned to middle, 
		* the other has to be assigned like this: For low = middle + 1, or high = middle - 1; 
		* If in case low = middle + 1, or high = middle,*  then middle = low + (high - low) / 2*  - Compare middle to high (since high depends on middle, so middle has to be rounded down)
		* If in case low = middle,*  or high = middle - 1, then middle = low + (high - low + 1) / 2 - Compare middle to low (since low depends on middle, so middle has to be rounded up)
		* Finally return low or high
		* For finding max/min[1] of min/max[2]: Need to identify correct values [1] and [2]
		* Graph: Return max/min[1] of something which is min/max[2] of something else (see _1102):
			```csharp
			var low = ...
			var high = ...

			while(low < high) {
				//for find max[1]
				var middle = low + (high - low + 1)/2;

				//for find min[1]
				middle = low + (high - low)/2;

				if (CanBfs(middle, grid, grid[0][0]))
				{
					//for find max[1]
					low = middle;
					//for find min[1]
					low = middle - 1;
				}
				else
				{
					//for find max[1]
					high = middle - 1;
					//for find min[1]
					high = middle;
				}
			}

			return low;
			```
		* Not graph: Return max/min[1] of something which is min/max[3] of something else ([3] is optional) with constraints min/max[2]:
			```csharp
			var low = ...
			var high = ...

			while(low < high) {
				//for find max[1]
				middle = low + (high - low + 1)/2;

				//for find min[1]
				middle = low + (high - low)/2;

				total = 0;

				//only required if [3] is not provided
				temp = 0;
				foreach (var item in givenArray) {
				//do something which increases total (temp also) using item and middle
				//if [3] is not provided, then apply the operation on all elements in the array (see _1283)
				//otherwise, need to perform if check for temp variable (see _1011 and _1231), like this
				//for min[3]
				//if (temp >= middle)
				//for max[3]
				//if (temp <= middle)
    			}

				//for find max[1], then must be min[2]
				if (total >= middle)
				{
    				low = middle;
				}
				else
				{
					//for find max[1]
					high = middle - 1;
				}

				//for find min[1], then must be max[2]
				if (total <= middle)
				{
    				high = middle;
				}
				else
				{
    				low = middle + 1;
				}
			}

			return low;
			```


### Dijkstra: 
* Used to find shortest path in a non negative weight map. See reverse Dijkstra in _1514

### Binary Search Tree: 
* Balanced, unique values, In order traversal gives increasing sequence and In order traversal reversed gives decreasing sequence

### Union Find: 
* Used to combine things which share common patterns into one group with runtime nearly O(1). For more info https://docs.google.com/presentation/d/1_j8xIydyYzjB_M9J4qGC-YYYvzRrRDW2UUMhTy8Rl6g/edit#slide=id.gfc60fc96f0_0_310

### Minimum Spanning Tree: 
* A sorted version of UnionFind. Used to find the minimum cost to connect all the vertices in the graph

### Left To Right Minima Tree: 
* Used to find (left/right) nearest position that contains a smaller/bigger value in an array. Runtime O(n). Proof: https://hoangdinhquang.me/on-lrm-trees-lemma-application/

### Trie: 
* Used to find the prefix words from the set of given words. May combine with Dfs, Dictionary, Min/Max Heap

### Dynamic Programming: 
* Can be realized by 2 approaches: Bottom-up and Top-down with memoization (cache)
* If f[i] only relies on f[i - 1], then maybe don't need cache for both bottom-up and top-down approach
More general case: see _650. f[i] only relies on f[i - j] (j < i and j satisfies a given condition), then don't need cache for top-down but need stack for bottom-up to calculate up
* If f[i] relies on many i - 1, i - 2, ...(finite), then maybe need cache(with constant size) for top-down approach
* If f[i] relies on all i - 1, i - 2, ..., 0, then maybe need cache even for bottom-up and top-down approach
* Classical problems:
	* Normal: 
	* N-th Fibonacci
	* Min/Max Cost Climbing Steps
	* House Robber series
	* 2-keys-keyboard (see _650)
	* Longest increasing subsequence (LIS)
	* Multi-dimensional
	* Longest common subsequence (LCS)
	* Others
	* Matrix
	* Palindrome
	* Coin change
	* Longest Palindromic Subsequence (see _516)
	* Longest Palindromic Substring (see _5)
	* Like DP normal climbing step. Except _518
	* Edit distance
	* Notice 
		* _72 with base case
		* MaxSumDiv
	* Super hard DP (see _1262)

### Database: 
* LRU, LFU, RandomizedSet buffer pool replacement policy (cache invalidation policy)

 