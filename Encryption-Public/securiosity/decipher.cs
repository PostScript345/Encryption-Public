using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace securiosity
{
    class decipher
    {
        public static void decrypt(List<string> files)
        {
            Dictionary<char, char> key = new Dictionary<char, char>();

            try
            {
                File.ReadLines(errorChecker.check(files[1]));
            }

            catch (ArgumentNullException)
            {
                Program.Main();
            }

            for (int i = 0; i < File.ReadLines(files[1]).Count(); i++)
            {
                string[] ary;
                ary = File.ReadAllLines(files[1]).Skip(i).Take(1).First().Split('=');
                char char1 = Convert.ToChar(ary[0]);
                char char2 = Convert.ToChar(ary[1]);
                key.Add(char2, char1);
            }

            try
            {
                for (int x = 0; x < Convert.ToInt32(files[2]); x++)
                {
                    string[] lines = new string[File.ReadAllLines(files[0]).Count()];

                    for (int i = 0; i < File.ReadAllLines(files[0]).Count(); i++)
                    {
                        char[] letters = File.ReadLines(files[0]).Skip(i).Take(1).First().ToCharArray();

                        for (int z = 0; z < letters.Length; z++)
                        {
                            try
                            {
                                letters[z] = key[letters[z]];
                                lines[i] = lines[i] + letters[z];
                            }

                            catch (KeyNotFoundException)
                            {
                                lines[i] = lines[i] + letters[z];
                                continue;
                            }
                        }
                    }

                    File.WriteAllLines(files[0], lines);
                }
            }

            catch (OverflowException)
            {
                Console.WriteLine("The file (" + files[0] + ") was too large and could not be encrypted");
                Program.Main();
            }
        }
    }
}
