using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Interview.Challenges
{
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTree
    {
        #region Binary Tree Level Order Traversal
        // T.C.- O(N) Since iterating through all the elements
        // S.C.- O(N) In worst case queue will store all the elements
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<List<int>> response = new List<List<int>>();

            if (root == null)
                return response.ToArray();

            int h = getHeight(root);
            for (int i = 0; i <= h; i++)
            {
                response.Add(nodesAtLevel_i(root, new List<int>(), i));
            }
            return response.ToArray();
        }

        public int getHeight(TreeNode root)
        {
            if (root == null)
                return -1;

            return 1 + Math.Max(getHeight(root.left), getHeight(root.right));
        }

        public List<int> nodesAtLevel_i(TreeNode root, List<int> list, int level)
        {
            if (root == null)
                return list;

            if (level == 0)
            {
                list.Add(root.val);
                return list;
            }

            nodesAtLevel_i(root.left, list, level - 1);
            nodesAtLevel_i(root.right, list, level - 1);
            return list;
        }
        #endregion

        #region Binary Tree Zigzag Level Order Traversal

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }

            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();

            s1.Push(root);

            while (s1.Count != 0 || s2.Count != 0)
            {
                int n1 = s1.Count;
                int n2 = s2.Count;

                List<int> list = new List<int>();

                for (int i = 0; i < n1; i++)
                {
                    root = s1.Pop();
                    list.Add(root.val);

                    if (root.left != null)
                    {
                        s2.Push(root.left);
                    }

                    if (root.right != null)
                    {
                        s2.Push(root.right);
                    }
                }

                for (int i = 0; i < n2; i++)
                {
                    root = s2.Pop();
                    list.Add(root.val);

                    if (root.right != null)
                    {
                        s1.Push(root.right);
                    }

                    if (root.left != null)
                    {
                        s1.Push(root.left);
                    }
                }

                result.Add(list);
            }

            return result;
        }
        #endregion

        #region Binary Tree Level Order Traversal II
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            Stack<List<int>> s = new Stack<List<int>>();
            IList<IList<int>> res = new List<IList<int>>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                int count = q.Count;
                List<int> level = new List<int>();

                while (count > 0)
                {
                    TreeNode cur = q.Dequeue();

                    level.Add(cur.val);

                    if (cur.left != null)
                        q.Enqueue(cur.left);

                    if (cur.right != null)
                        q.Enqueue(cur.right);

                    count--;
                }

                s.Push(level);
            }

            while (s.Count > 0)
                res.Add(s.Pop());

            return res;
        }
        #endregion

        #region N-ary Tree Level Order Traversal

        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var size = queue.Count;

                var tempList = new List<int>();
                for (int s = 0; s < size; s++)
                {
                    var cur = queue.Dequeue();
                    tempList.Add(cur.val);

                    foreach (var child in cur.children)
                    {
                        queue.Enqueue(child);
                    }
                }
                result.Add(tempList);
            }
            return result;
        }
        #endregion

        #region Minimum Depth of Binary Tree
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            else if (root.left == null)
                return MinDepth(root.right) + 1;
            else if (root.right == null)
                return MinDepth(root.left) + 1;
            else
                return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
        #endregion

        #region Maximum Depth of Binary Tree
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
        #endregion

        #region Average of Levels in Binary Tree
        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null)
                return new List<double>();

            IList<double> res = new List<double>();
            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                int i = q.Count,
                    j = q.Count;
                double k = 0;

                while (i > 0)
                {
                    TreeNode n = q.Dequeue();

                    k += n.val;

                    if (n.left != null)
                        q.Enqueue(n.left);

                    if (n.right != null)
                        q.Enqueue(n.right);

                    i--;
                }

                res.Add((double)(k / j));
            }

            return res;
        }
        #endregion

        #region Cousins in Binary Tree
        private int? xHeight = null,
                 yHeight = null;
        private TreeNode xP = null,
                         yP = null;

        public bool IsCousins(TreeNode root, int x, int y)
        {
            return DFS(root, x, y, null, 0);
        }

        private bool DFS(TreeNode node, int x, int y, TreeNode p, int h)
        {
            if (node == null)
                return false;

            if (node.val == x)
            {
                if (yHeight != null)
                    return (h == yHeight) == (yP != p);
                else
                {
                    xHeight = h;
                    xP = p;
                }
            }

            if (node.val == y)
            {
                if (xHeight != null)
                    return (h == xHeight) == (xP != p);
                else
                {
                    yHeight = h;
                    yP = p;
                }
            }

            return DFS(node.left, x, y, node, h + 1) || DFS(node.right, x, y, node, h + 1);
        }
        #endregion

        #region Lowest Common Ancestor of a Binary Search Tree
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            else if (root.val >= p.val && root.val <= q.val || root.val <= p.val && root.val >= q.val)
                return root;
            else if (root.val >= p.val)
                return LowestCommonAncestor(root.left, p, q);
            else
                return LowestCommonAncestor(root.right, p, q);
        }
        #endregion

        #region Trim a Binary Search Tree
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root != null)
            {
                TreeNode left = TrimBST(root.left, low, high),
                         right = TrimBST(root.right, low, high);

                if (root.val >= low && root.val <= high)
                {
                    TreeNode node = new TreeNode();

                    node.val = root.val;
                    node.left = left;
                    node.right = right;

                    return node;
                }
                else
                    return left != null ? left : right != null ? right : null;
            }

            return null;
        }
        #endregion

        #region N-ary Tree Preorder Traversal
        private IList<int> result = new List<int>();
        public IList<int> Preorder(Node root)
        {
            if (root != null)
            {
                result.Add(root.val);
                foreach (Node n in root.children)
                    Preorder(n);
            }
            return result;
        }
        #endregion

        #region Binary Tree Preorder Traversal
        public IList<int> PreorderTraversal(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> list = new List<int>();
            stack.Push(root);
            while (stack.Count() > 0)
            {
                TreeNode current = stack.Pop();
                if (current != null)
                {
                    list.Add(current.val);
                    stack.Push(current.right);
                    stack.Push(current.left);
                }
            }

            return list;
        }
        #endregion

        #region N-ary Tree Postorder Traversal
        public IList<int> Postorder(Node root)
        {
            IList<int> result = new List<int>();
            if (root != null)
            {
                foreach (Node n in root.children)
                    Postorder(n);
                result.Add(root.val);
            }
            return result;
        }
        #endregion

        #region Balanced Binary Tree
        public bool IsBalanced(TreeNode root)
        {
            bool bal = true;
            int Dfs(TreeNode node)
            {
                if (node == null)
                    return 0;
                int l = Dfs(node.left), r = Dfs(node.right);
                if (Math.Abs(l - r) > 1)
                    bal = false;
                return Math.Max(l, r) + 1;
            }
            Dfs(root);
            return bal;
        }
        #endregion

        #region Construct Binary Tree from Inorder and Postorder Traversal
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0)
                return null;

            return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private TreeNode BuildTree(int[] inorder, int i, int j, int[] postorder, int k, int l)
        {
            if (i > j || k > l)
                return null;

            TreeNode node = new TreeNode(postorder[l]);

            if (k != l)
            {
                int m = 0;

                for (; m < inorder.Length; m++)
                    if (inorder[m] == postorder[l])
                        break;

                node.left = BuildTree(inorder, i, m - 1, postorder, k, k + m - i - 1);
                node.right = BuildTree(inorder, m + 1, j, postorder, k + m - i, l - 1);
            }

            return node;
        }
        #endregion

        #region Construct Binary Tree from Preorder and Inorder Traversal
        public TreeNode BuildTree2(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
                return null;

            return BuildTree2(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree2(int[] preorder, int i, int j, int[] inorder, int k, int l)
        {
            if (i > j || k > l)
                return null;

            TreeNode node = new TreeNode(preorder[i]);

            if (i != j)
            {
                int m = k;

                for (; m < inorder.Length; m++)
                    if (inorder[m] == preorder[i])
                        break;

                node.left = BuildTree(preorder, i + 1, i + m - k, inorder, k, m - 1);
                node.right = BuildTree(preorder, i + 1 + m - k, j, inorder, m + 1, l);
            }

            return node;
        }
        #endregion

        #region Count Good Nodes in Binary Tree
        public int GoodNodes(TreeNode root)
        {
            if (root == null) { return 0; }

            int goodNodeCount = 0;
            Traverse(root, root.val, ref goodNodeCount);
            return goodNodeCount;
        }

        private void Traverse(TreeNode node, int maxPathValue, ref int goodNodeCount)
        {
            if (node == null) { return; }

            if (maxPathValue <= node.val) { maxPathValue = node.val; goodNodeCount++; }

            Traverse(node.left, maxPathValue, ref goodNodeCount);
            Traverse(node.right, maxPathValue, ref goodNodeCount);
        }
        #endregion

        #region Maximum Depth of N-ary Tree
        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int depth = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node curr = queue.Dequeue();
                    foreach (Node node in curr.children)
                        queue.Enqueue(node);
                }
                depth++;
            }

            return depth;
        }

        #endregion

        #region Time Needed to Inform All Employees
        private int Helper(int node, IList<int>[] graph, int[] informTime)
        {
            int res = 0;

            for (int i = 0; i < graph[node].Count; i++)
            {
                res = Math.Max(res, informTime[node] + Helper(graph[node][i], graph, informTime));
            }

            return res;
        }

        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            IList<int>[] graph = new IList<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < manager.Length; i++)
            {
                if (manager[i] == -1)
                {
                    continue;
                }

                graph[manager[i]].Add(i);
            }

            return Helper(headID, graph, informTime);
        }
        #endregion

        #region Binary Tree Maximum Path Sum
        int Max = Int32.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            Helper(root);
            return Max;
        }

        private int Helper(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftMax = Helper(root.left),
                rightMax = Helper(root.right),
                currentMax = 0;

            currentMax = Math.Max(currentMax, Math.Max(leftMax + root.val, rightMax + root.val));
            Max = Math.Max(Max, leftMax + root.val + rightMax);

            return currentMax;
        }
        #endregion
    }
}