using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD3.Depth_First_Search;

public class GraphDFS
{
    private int V; // Количество вершин
    private bool[,] adjacencyMatrix; // Матрица смежности

    public GraphDFS(int v)
    {
        V = v;
        adjacencyMatrix = new bool[V, V];
    }

    public void AddEdge(int v1, int v2)
    {
        adjacencyMatrix[v1, v2] = true;
        adjacencyMatrix[v2, v1] = true; 
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        for (int i = 0; i < V; i++)
        {
            if (adjacencyMatrix[v, i] && !visited[i])
            {
                DFSUtil(i, visited);
            }
        }
    }

    public void DFS(int startVertex)
    {
        bool[] visited = new bool[V];
        DFSUtil(startVertex, visited);
    }
}
