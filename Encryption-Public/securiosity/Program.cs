using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace securiosity
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Console.Title = "Beecrpyt: Customizable Message Encryptor";
            Console.WriteLine("Type -H for command text file");
            center();
        }

        public static string navigate(string command)
        {

            bool result = textChecker.checker(command);

            if (result == true)
            {
                sender.information.Add(command);
            }

            return (command);
        }

        public static void center()
        {
            while (true)
            {
                Console.Write(">>> ");
                string command;
                string sub = "";
                string input = Console.ReadLine();

                try
                {
                    if (input.Length != 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    sub = input.Substring(0, 2);
                }

                catch (ArgumentOutOfRangeException)
                {
                    center();
                }

                sender send = new sender();

                if (sub.ToUpper() == "-S" && input.Length <= 3)
                {
                    Console.WriteLine("Choose a file you wish to encrypt: ");
                    command = navigate(filePicker.picker());
                    Console.WriteLine(command);
                    Console.WriteLine("Choose your key folder: ");
                    sender.information.Add(Console.ReadLine());
                    Console.WriteLine("Loop for: ");
                    sender.information.Add(loopChecker.checker(Console.ReadLine()));
                    sender.sendValues("scrambler");
                    sender.information.Clear();
                }

                if (sub.ToUpper() == "-K" && input.Length <= 3)
                {
                    Console.Write("Enter key file name: ");
                    key.randomKey(Console.ReadLine());
                }

                if (sub.ToUpper() == "-D" && input.Length <= 3)
                {
                    Console.WriteLine("Choose a file you wish to decrypt: ");
                    command = navigate(filePicker.picker());
                    Console.WriteLine(command);
                    Console.WriteLine("Choose your key file: ");
                    command = navigate(filePicker.picker());
                    Console.WriteLine(command);
                    Console.WriteLine("Loop for: ");
                    sender.information.Add(loopChecker.checker(Console.ReadLine()));
                    sender.sendValues("decipher");
                    sender.information.Clear();
                }

                if (sub.ToUpper() == "-H" && input.Length <= 3)
                {
                    try
                    {
                        Process process = new Process();
                        process.StartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = "help.txt"
                        };

                        process.Start();
                        process.WaitForExit();
                    }

                    catch (System.ComponentModel.Win32Exception)
                    {
                        Console.WriteLine("help.txt cannot be found");
                        Console.WriteLine("It may have been renamed or deleted");
                        center();
                    }
                }

            }
        }
    }
}
