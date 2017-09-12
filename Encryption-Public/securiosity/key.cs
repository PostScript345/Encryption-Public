using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace securiosity
{
    class key
    {
        public static void randomKey(string file)
        {
            Random randint = new Random();
            StreamWriter sw = new StreamWriter("keys/" + file + ".txt");
            Dictionary<char, char> alphaDictionary = new Dictionary<char, char>();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890` ~!@#$%^&*()-_+[{]};:',<.>/?".ToCharArray();
            List<char> alphaList1 = new List<char>(alpha);
            List<char> alphaList2 = new List<char>(alpha);

            while (alphaList1.Count() > 0)
            {
                int i = randint.Next(0, alphaList1.Count);
                int x = randint.Next(0, alphaList2.Count);

                if (i != x)
                {
                    alphaDictionary[alphaList1[i]] = alphaList2[x];
                    alphaList1.RemoveAt(i);
                    alphaList2.RemoveAt(x);
                }

                if (alphaList1.Count == 1)
                {
                    alphaDictionary[alphaList1[0]] = alphaList2[0];
                    alphaList1.RemoveAt(0);
                    alphaList2.RemoveAt(0);
                }
            }

            foreach (KeyValuePair<char, char> item in alphaDictionary)
            {
                sw.WriteLine(item.Key + "=" + item.Value);
            }

            sw.Close();
        }
    }
}
