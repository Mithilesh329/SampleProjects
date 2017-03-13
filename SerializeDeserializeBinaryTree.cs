using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
//Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
//For example, you may serialize the following tree

public class TreeNode 
{
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }

public class Codec {

    // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (root == null)
            {
                return strBuilder.ToString();
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();
                if (node != null)
                {
                    strBuilder.Append(node.val + ",");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    strBuilder.Append("null,");
                }
            }

            return strBuilder.ToString().Trim(',');
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            string[] parts = data.Trim().Split(',');

            int i = 0;
            TreeNode root = GetNextNode(parts, i);
            queue.Enqueue(root);
            i++;

            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();

                node.left = GetNextNode(parts, i);
                i++;
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                node.right = GetNextNode(parts, i);
                i++;
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return root;
        }

        private TreeNode GetNextNode(string[] parts, int index)
        {
            if (index >= parts.Length)
            {
                return null;
            }

            if (parts[index].Equals("null"))
            {
                return null;
            }
            else
            {
                TreeNode node = new TreeNode(Convert.ToInt32(parts[index]));
                return node;
            }
        }
}
