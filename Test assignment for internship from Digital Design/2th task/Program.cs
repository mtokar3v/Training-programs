using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace _2th_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Console.Write("Введите путь до файла: ");
            path = Console.ReadLine();
            Dictionary<string, int> wordInfo = new Dictionary<string, int>();

            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    string text = stream.ReadToEnd();

                    //форматирование
                    if (path.EndsWith(".fb2"))
                    {
                        IFormatting[] formattings = new IFormatting[] { new DelHtml(), new DelDash() };

                        for (int i = 0; i < text.Length; i++)
                            foreach (var format in formattings)
                                format.Check(ref text, i);
                    }

                    string[] words = text.Split(new char[] { '.', '!', '?', ',', ' ', '\n', '\t', '\r', '/', '(', ')', ':', ';', '\"' });
                    foreach (var t in words)
                    {
                        string word = t.ToLower();
                        if (wordInfo.ContainsKey(word))
                            wordInfo[word]++;
                        else
                            wordInfo.Add(word, 1);
                    }

                    if (wordInfo.ContainsKey(""))
                        wordInfo.Remove("");
                }

                string name = path.Substring(path.LastIndexOf('\\'), path.LastIndexOf('.') - path.LastIndexOf('\\'));
                Console.Write("Введите путь для сохранения результатов: ");
                path = Console.ReadLine() + "\\" + name + "_word_count.txt";

                using (StreamWriter stream2 = new StreamWriter(path, false))
                {
                    IEnumerable<KeyValuePair<string, int>> sortWordsInfo = wordInfo.OrderByDescending(k => k.Value);
                    stream2.WriteLine("Слово\t-\tКоличество повторений");
                    foreach (var d in sortWordsInfo)
                        stream2.WriteLine(d.Key + "\t-\t" + d.Value);
                }
                Console.WriteLine("Готово");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}