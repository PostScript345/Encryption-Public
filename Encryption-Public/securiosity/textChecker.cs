using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace securiosity
{
    class textChecker
    {
        public static bool checker(string file)
        {
            string sub = "";

            try
            {
                sub = file.Substring(file.Length - 4);
            }

            catch (ArgumentOutOfRangeException)
            {
                Program.center();
            }

            if (sub == ".txt")
            {
                try
                {
                    File.ReadAllLines(file);
                    return (true);
                }

                catch (FileNotFoundException)
                {
                    return (false);
                }

                catch (OverflowException)
                {
                    return (false);
                }
            }

            else
            {
                return (false);
            }
        }
    }
}
