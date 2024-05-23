using System;
using System.ComponentModel.DataAnnotations;
using AISD3.BinTree;
using AISD3.Depth_First_Search;
using AISD3.MST;

namespace AISD3;

class Program
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Вставляем элементы
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(45);
        tree.Insert(35);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);
        tree.Insert(25);
        

        Console.WriteLine("Дерево в прямом порядке (Preorder traversal):");
        tree.Preorder();
        Console.WriteLine();
        tree.Delete(25);
        tree.Preorder();
        Console.WriteLine();

        // Поиск элементов
        Console.WriteLine("Поиск элемента 20:");
        TreeNode result = tree.Search(20);
        if (result != null)
            Console.WriteLine("Элемент найден");
        else
            Console.WriteLine("Элемент не найден");
            
        Console.WriteLine("Поиск элемента 90:");
        result = tree.Search(90);
        if (result != null)
            Console.WriteLine("Элемент найден");
        else
            Console.WriteLine("Элемент не найден");
        Console.WriteLine();





        GraphDFS graph = new GraphDFS(6);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 4);
        graph.AddEdge(3, 5);
        // полуенная матрица смежности
        //    0  1  2  3  4  5  // Номера вершин
        // 0  0  1  1  0  0  0
        // 1  1  0  0  1  1  0
        // 2  1  0  0  0  1  0
        // 3  0  1  0  0  1  1
        // 4  0  1  1  1  0  0
        // 5  0  0  0  1  0  0

        Console.WriteLine("Обход в глубину начиная с вершины 0:");
        graph.DFS(0);
        Console.WriteLine();
        Console.WriteLine();







        // Пример графа в виде списка смежности
        Dictionary<int, List<(int, int)>> graphMST = new Dictionary<int, List<(int, int)>>()
        {                                                         // Полученные списки смежности: 
            {0, new List<(int, int)>{(1, 2), (2, 4)}},            // Вершина 0: (1, 2), (2, 4)
            {1, new List<(int, int)>{(0, 2), (2, 1), (3, 3)}},    // Вершина 1: (0, 2), (2, 1), (3, 3)
            {2, new List<(int, int)>{(0, 4), (1, 1), (3, 5)}},    // Вершина 2: (0, 4), (1, 1), (3, 5)
            {3, new List<(int, int)>{(1, 3), (2, 5), (4,2)}},     // Вершина 3:SSSSS (1, 3), (2, 5), (4, 2)
            {4, new List<(int, int)>{(3,2)}}                      // Вершина 4: (3, 2)

           
        };

        // Находим минимальное остовное дерево
        List<(int, int, int)> mst = PrimMST.FindMST(graphMST);
        // Выводим результат
        Console.WriteLine("Минимальное остовное дерево:");
        foreach ((int fromVertex, int toVertex, int cost) in mst)
        {
            Console.WriteLine($"Ребро: {fromVertex} - {toVertex}, Вес: {cost}");
        }
    }
}