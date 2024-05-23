using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD3.MST;

public class PriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> _dict = new SortedDictionary<int, Queue<T>>();

    public int Count { get; private set; }

    public void Enqueue(T item, int priority)
    {
        if (!_dict.ContainsKey(priority))
            _dict[priority] = new Queue<T>();

        _dict[priority].Enqueue(item);
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty");

        var item = _dict.First();
        var queue = item.Value;
        var result = queue.Dequeue();

        if (queue.Count == 0)
            _dict.Remove(item.Key);

        Count--;
        return result;
    }
}