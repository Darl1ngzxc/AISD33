using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD3.BinTree;

public class TreeNode
{
    public int key;
    public TreeNode left, right;

    public TreeNode(int item)
    {
        key = item;
        left = right = null;
    }
}
