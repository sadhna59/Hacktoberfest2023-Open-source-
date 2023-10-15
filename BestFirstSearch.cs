using System;
using System.Collections.Generic;

using System.Collections;
// C# program to implement Best First Search using priority
// queue


class HelloWorld {
	
	public static LinkedList<Tuple<int, int>>[] graph;
	
	// Function for adding edges to graph
	public static void addedge(int x, int y, int cost)
	{
		graph[x].AddLast(new Tuple<int, int>(cost, y));
		graph[y].AddLast(new Tuple<int, int>(cost, x));
	}

	// Function for finding the minimum weight element. 
	public static Tuple<int,int> get_min(LinkedList<Tuple<int,int>> pq){
		// Assuming the maximum wt can be of 1e5. 
		Tuple<int,int> curr_min = new Tuple<int,int>(100000, 100000);
		foreach(var ele in pq){
			if(ele.Item1 == curr_min.Item1){
				if(ele.Item2 < curr_min.Item2){
					curr_min = ele;
				}
			}
			else{
				if(ele.Item1 < curr_min.Item1){
					curr_min = ele;
				}
			}
		}
		
		return curr_min;
	}
	
	// Function For Implementing Best First Search
	// Gives output path having lowest cost
	public static void best_first_search(int actual_Src, int target, int n)
	{
		int[] visited = new int[n];
		for(int i = 0; i < n; i++){
			visited[i] = 0;
		}
		
		// MIN HEAP priority queue
		LinkedList<Tuple<int, int>> pq = new LinkedList<Tuple<int,int>>();

		// sorting in pq gets done by first value of pair
		pq.AddLast(new Tuple<int, int> (0, actual_Src));
		int s = actual_Src;
		visited[s] = 1;
		while (pq.Count > 0) {
			
			Tuple<int,int> curr_min = get_min(pq);
			int x = curr_min.Item2;
			pq.Remove(curr_min);
			
			Console.Write(x + " ");
			// Displaying the path having lowest cost
			if (x == target)
				break;

			LinkedList<Tuple<int,int>> list = graph[x];
			foreach(var val in list)
			{
				if (visited[val.Item2] == 0) {
					visited[val.Item2] = 1;
					pq.AddLast(new Tuple<int,int>(val.Item1, val.Item2));
				}
			}
			
		}
	}
	
	static void Main() {
		// No. of Nodes
		int v = 14;
		graph = new LinkedList<Tuple<int, int>>[v];
		for (int i = 0; i < graph.Length; ++i){
			graph[i] = new LinkedList<Tuple<int, int>>();
		}

		// The nodes shown in above example(by alphabets) are
		// implemented using integers addedge(x,y,cost);
		addedge(0, 1, 3);
		addedge(0, 2, 6);
		addedge(0, 3, 5);
		addedge(1, 4, 9);
		addedge(1, 5, 8);
		addedge(2, 6, 12);
		addedge(2, 7, 14);
		addedge(3, 8, 7);
		addedge(8, 9, 5);
		addedge(8, 10, 6);
		addedge(9, 11, 1);
		addedge(9, 12, 10);
		addedge(9, 13, 2);

		int source = 0;
		int target = 9;

		// Function call
		best_first_search(source, target, v);
	}
}

// The code is contributed by Nidhi goel.
