using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace securiosity
{
    class errorChecker
    {
        public static string check (string file)
        {
            Dictionary<char, char> key = new Dictionary<char, char>();
            int counter = 0;

            try
            {
                for (int i = 0; i < File.ReadLines(file).Count(); i++)
                {
                    string[] ary;
                    char char2;
                    char char1;

                    if (File.ReadAllLines(file).Skip(i).Take(1).First().Length != 3)
                    {
                        counter = i;
                        throw new OverflowException();
                    }

                    ary = File.ReadAllLines(file).Skip(i).Take(1).First().Split('=');

                    ////fix index== case

                    //if (ary.Length == 1)
                    //{
                    //    ary[1] = "=";
                    //}

                    char1 = Convert.ToChar(ary[0]);
                    char2 = Convert.ToChar(ary[1]);
                    key.Add(char1, char2);
                }

                return (file);
            }

            catch (FormatException)
            {
                Console.WriteLine("Key should only contain character to character pairs");
                return (null);
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The file (" + file + ") was not found");
                return (null);
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Key file (" + file + ") contained duplicates");
                return (null);
            }

            catch (OverflowException)
            {
                if (counter != 0)
                {
                    Console.WriteLine("Line " + counter + " in file (" + file + ") was too long");
                    Console.WriteLine("Line length should only be of 3 characters incloding spaces");
                    return (null);
                }

                else
                {
                    Console.WriteLine("The file (" + file + ") contained too many lines");
                    return (null);
                }
            }
        }
    }
}
