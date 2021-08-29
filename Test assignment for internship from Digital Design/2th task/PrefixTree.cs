using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2th_task
{
    
    class TreeNode
    {
        public TreeNode[] Childs;
        public bool Eok { get; set; }

        public TreeNode()
        {
            //кириллица + латиница + цифры + специальные символы 
            Childs = new TreeNode[33 + 26 + 10 + 16];
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
                int code = (int)key[pointer];
                if (code >= 'а' && code <= 'я')
                {
                    if(currentNode.Childs[code - 'а'] == null)
                        currentNode.Childs[code - 'а'] = new TreeNode();

                    currentNode = currentNode.Childs[code - 'а'];
                }
                else
                if (code >= 'a' && code <= 'z')
                {
                    if(currentNode.Childs[33 - 1 + code - 'a'] == null)
                        currentNode.Childs[33 - 1 + code - 'a'] = new TreeNode();
                    currentNode = currentNode.Childs[33 - 1 + code - 'a'];
                }
                else
                if (code >= '0' && code <= '9')
                {
                    if(currentNode.Childs[33 + 26 - 1 + code - '0'] == null)
                        currentNode.Childs[33 + 26 - 1 + code - '0'] = new TreeNode();
                    currentNode = currentNode.Childs[33 + 26 - 1 + code - '0'];
                }
                else
                if (code >= '!' && code <= '/')
                {
                    if(currentNode.Childs[33 + 26 + 10 - 1 + code - '!'] == null)
                        currentNode.Childs[33 + 26 + 10 - 1 + code - '!'] = new TreeNode();
                    currentNode = currentNode.Childs[33 + 26 + 10 - 1 + code - '!'];
                }
                else
                    throw new Exception("Некорректный символ : доступны символы латиницы и кириллицы, цифры и специальные символы");

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
                int code = (int)key[pointer];
                if (code >= 'а' && code <= 'я')
                {
                    if (currentNode.Childs[code - 'а'] != null)
                        currentNode = currentNode.Childs[code - 'а'];
                    else
                        return false;
                }
                else
                if (code >= 'a' && code <= 'z')
                {
                    if (currentNode.Childs[33 - 1 + code - 'a'] != null)
                        currentNode = currentNode.Childs[33 - 1 + code - 'a'];
                    else
                        return false;
                }
                else
                if (code >= '0' && code <= '9')
                {
                    if (currentNode.Childs[33 + 26 - 1 + code - '0'] != null)
                        currentNode = currentNode.Childs[33 + 26 - 1 + code - '0'];
                    else
                        return false;
                }
                else
                if (code >= '!' && code <= '/')
                {
                    if (currentNode.Childs[33 + 26 + 10 - 1 + code - '!'] != null)
                        currentNode = currentNode.Childs[33 + 26 + 10 - 1 + code - '!'];
                    else
                        return false;
                }
                else
                    throw new Exception("Некорректный символ : доступны символы латиницы и кириллицы, цифры и специальные символы");

                pointer++;
            }

            if (currentNode.Eok)
                return true;
            else
                return false;
        }
    }
}
