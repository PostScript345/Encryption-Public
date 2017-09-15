using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dictionary_list_test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<char, char>> keys = new List<Dictionary<char, char>>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToUpper() == "MAKE")
                {
                    randomKey.generate(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                }

                if (input.ToUpper() == "IMPORT")
                {
                    string folder = Console.ReadLine();
                    for (int x = 0; x < Directory.GetFiles(folder).Count(); x++)
                    {
                        keys.Add(new Dictionary<char, char>());
                        for (int i = 0; i < File.ReadLines(Convert.ToString(folder + "/" + x + ".txt")).Count(); i++)
                        {
                            string[] ary;
                            char char2;
                            char char1;

                            ary = File.ReadAllLines(Convert.ToString(folder + "/" + x + ".txt")).Skip(i).Take(1).First().Split('=');

                            char1 = Convert.ToChar(ary[0]);
                            char2 = Convert.ToChar(ary[1]);
                            keys[x].Add(char1, char2);
                        }
                    }
                }

                if (input.ToUpper() == "LIST")
                {
                    foreach (Dictionary<char, char> item in keys)
                    {
                        foreach (KeyValuePair<char, char> dicItem in item)
                        {
                            Console.WriteLine(dicItem.Key + "," + dicItem.Value);
                        }
                    }
                }
            }
        }
    }
}
