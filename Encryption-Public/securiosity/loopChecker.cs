using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace securiosity
{
    class loopChecker
    {
        public static string checker(string multiple)
        {
            try
            {
                if (Convert.ToInt32(multiple) <= 1000)
                {
                    return (multiple);
                }

                else
                {
                    return ("1");
                }
            }

            catch (FormatException)
            {
                return ("1");
            }

            catch (OverflowException)
            {
                return ("1");
            }
        }
    }
}
