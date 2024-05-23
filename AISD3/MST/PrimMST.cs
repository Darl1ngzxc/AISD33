using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD3.MST;

public class PrimMST
{
    // Метод для поиска минимального остовного дерева
    public static List<(int, int, int)> FindMST(Dictionary<int, List<(int, int)>> graphMST)
    {
        // Множество для отслеживания посещенных вершин
        HashSet<int> visited = new HashSet<int>();
        // Список для хранения ребер остовного дерева
        List<(int, int, int)> mst = new List<(int, int, int)>();
        // Приоритетная очередь для хранения ребер
        PriorityQueue<(int, int, int)> pq = new PriorityQueue<(int, int, int)>();

        // Выбираем произвольную стартовую вершину
        int startVertex = graphMST.Keys.GetEnumerator().Current;
        // Отмечаем стартовую вершину как посещенную
        visited.Add(startVertex);
        // Добавляем все ребра, инцидентные стартовой вершине, в приоритетную очередь
        foreach ((int toVertex, int cost) in graphMST[startVertex])
        {
            pq.Enqueue((startVertex, toVertex, cost), cost);
        }

        // П00ока в очереди есть элементы
        while (pq.Count > 0)
        {
            
            (int fromVertex, int toVertex, int cost) = pq.Dequeue();
            // Если конечная вершина еще не посещена
            if (!visited.Contains(toVertex))
            {
                // Добавляем ребро в остовное дерево
                mst.Add((fromVertex, toVertex, cost));
                // Отмечаем конечную вершину как посещенную
                visited.Add(toVertex);
                // Добавляем все ребра, инцидентные новой вершине, в приоритетную очередь
                foreach ((int nextVertex, int nextCost) in graphMST[toVertex])
                {
                    if (!visited.Contains(nextVertex))
                    {
                        pq.Enqueue((toVertex, nextVertex, nextCost), nextCost);
                    }
                }
            }
        }

        return mst;
    }

    // Пример использования
    
}
