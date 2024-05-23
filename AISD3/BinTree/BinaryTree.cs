using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD3.BinTree;

public class BinaryTree
{
    public TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    // Вспомогательная рекурсивная функция для вставки нового ключа в дерево
    private TreeNode InsertRec(TreeNode root, int key)
    {
        // Если дерево пустое, создаем новый узел
        if (root == null)
        {
            root = new TreeNode(key);
            return root;
        }

        // Иначе рекурсивно идем по дереву
        if (key < root.key)
            root.left = InsertRec(root.left, key);
        else if (key > root.key)
            root.right = InsertRec(root.right, key);

        // Возвращаем измененный указатель корня
        return root;
    }

    // Вспомогательная функция для вызова InsertRec()
    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    // Рекурсивная функция для поиска ключа в дереве
    private TreeNode SearchRec(TreeNode root, int key)
    {
        // Если дерево пустое или ключ находится в корне
        if (root == null || root.key == key)
            return root;

        // Если ключ меньше корня, идем влево
        if (root.key > key)
            return SearchRec(root.left, key);

        // Иначе идем вправо
        return SearchRec(root.right, key);
    }

    // Вспомогательная функция для вызова SearchRec()
    public TreeNode Search(int key)
    {
        return SearchRec(root, key);
    }

    // Рекурсивная функция для вывода содержимого дерева в прямом порядке (Preorder)
    private void PreorderRec(TreeNode root)
    {
        if (root != null)
        {
            Console.Write(root.key + " ");
            PreorderRec(root.left);
            PreorderRec(root.right);
        }
    }



    // Вспомогательная функция для вызова PreorderRec()
    public void Preorder()
    {
        PreorderRec(root);
    }

    private TreeNode DeleteRec(TreeNode root, int key)
    {
        if (root == null)
            return root;


        if (key<root.key)
            root.left = DeleteRec(root.left, key);
        else if (key > root.key)
            root.right = DeleteRec(root.right, key);
        else
        {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;


            root.key = MinValue(root.right);

            root.right = DeleteRec(root.right, root.key);
        }
        return root;
    }

    private int MinValue(TreeNode root) 
    {
        int minv = root.key;
        while (root.left != null)
        {
            minv = root.left.key;
            root = root.left;
        }
        return minv;
    }

    public void Delete(int key)
    {
        root = DeleteRec(root, key);
    }





}
