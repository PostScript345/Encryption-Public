using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace securiosity
{
    class scrambler
    {
        public static void scramble(List<string> files)
        {
            List<Dictionary<char, char>> keys = new List<Dictionary<char, char>>();
            StreamWriter sw = new StreamWriter(files[1] + "/order.txt");
            Random keyUsed = new Random();

            try
            {
                for (int i = 0; i < Directory.GetFiles(files[1]).Count(); i++)
                {
                    //File.ReadLines(errorChecker.check(files[1] + "/" + i + ".txt"));
                }
            }

            catch (ArgumentNullException)
            {
                Program.center();
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The specified directory (" + files[1] + ") was not found");
                Program.center();
            }

            for (int i = 0; i < Directory.GetFiles(files[1]).Count() - 1; i++)
            {
                keys.Add(new Dictionary<char, char>());

                for (int x = 0; x < File.ReadLines(files[1] + "/" + i + ".txt").Count(); x++)
                {
                    string[] ary;
                    char char2;
                    char char1;

                    ary = File.ReadAllLines(Convert.ToString(files[1] + "/" + i + ".txt")).Skip(x).Take(1).First().Split('=');

                    char1 = Convert.ToChar(ary[0]);
                    char2 = Convert.ToChar(ary[1]);
                    keys[i].Add(char1, char2);
                }
            }

            try
            {
                for (int x = 0; x < Convert.ToInt32(files[2]); x++)
                {
                    int key;
                    string[] lines = new string[File.ReadAllLines(files[0]).Count()];

                    for (int i = 0; i < File.ReadAllLines(files[0]).Count(); i++)
                    {
                        // fix this character issue

                        string line = File.ReadLines(files[0]).Skip(i).Take(1).First();
                        char[] letters = line.ToCharArray();

                        for (int z = 0; z < letters.Length; z++)
                        {
                            try
                            {
                                key = keyUsed.Next(0, keys.Count());
                                letters[z] = keys[key][letters[z]];
                                lines[i] = lines[i] + letters[z];
                                sw.WriteLine(key);
                            }

                            catch (KeyNotFoundException)
                            {
                                lines[i] = lines[i] + letters[z];
                                continue;
                            }
                        }

                        File.WriteAllLines(files[0], lines);
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified file (" + files[0] + ") was not found");
                sw.Close();
                Program.center();
            }

            catch (OverflowException)
            {
                Console.WriteLine("The file (" + files[0] + ") was too large and could not be encrypted");
                sw.Close();
                Program.center();
            }
        }
    }
}
