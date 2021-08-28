using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2th_task
{
    
    class TreeNode
    {
        public Dictionary<char, TreeNode> Childs { get; set; }
        public bool Eok { get; set; }

        public TreeNode()
        {
            Childs = new Dictionary<char, TreeNode>();
            Eok = false;
        }
    }
    class PrefixTree
    {
        private TreeNode root;
        public PrefixTree()
        {
            root = new TreeNode();
        }

        public void Add(string key)
        {
            key = key.ToLower();
            int pointer = 0;
            int length = key.Length;
            TreeNode currentNode = root;

            while (pointer != length)
            {
                if (!currentNode.Childs.ContainsKey(key[pointer]))
                    currentNode.Childs.Add(key[pointer], new TreeNode());
                currentNode = currentNode.Childs[key[pointer]];
                pointer++;
            }

            currentNode.Eok = true;
        }

        public bool Find(string key)
        {
            key = key.ToLower();
            int pointer = 0;
            int length = key.Length;
            TreeNode currentNode = root;

            while(pointer != length)
            {
                if(currentNode.Childs.ContainsKey(key[pointer]))
                    currentNode = currentNode.Childs[key[pointer]];
                else
                    return false;
                pointer++;
            }

            if (currentNode.Eok)
                return true;
            else
                return false;
        }
    }
}
