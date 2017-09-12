using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace securiosity
{
    class sender
    {
        public static List<string> information = new List<string>();

        public static void sendValues(string destination)
        {
            sender send = new sender();

            if (destination == "scrambler")
            {
                if (information.Count == 3)
                {
                    scrambler.scramble(information);
                }

                else
                {
                    Program.center();
                }
            }

            if (destination == "decipher")
            {
                if (information.Count == 3)
                {
                    decipher.decrypt(information);
                }

                else
                {
                    Program.center();
                }
            }
        }
    }
}
