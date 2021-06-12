// libs
using System;


namespace utils
{
    // main class for server
    class Utils
    {
        // methods

        // method for create menu
        public static string Menu(string[] items)
        {
            // while main loop
            bool exit = false;
            int result = -1;
            while (!exit)
            {
                // show menu
                Console.Clear();
                Console.WriteLine("Press ESC to exit");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1} > {items[i]}");
                }

                // User action
                ConsoleKeyInfo userAction = Console.ReadKey(true);

                // process user input

                // errors
                try
                {
                    // if exit
                    if (userAction.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    // process digit
                    else if (int.Parse(userAction.KeyChar.ToString()) > 0 && int.Parse(userAction.KeyChar.ToString()) <= items.Length)
                    {
                        result = int.Parse(userAction.KeyChar.ToString()) - 1;
                        break;
                    }
                }

                // print error
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Incorect input");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            return result != -1 ? items[result] : "Exit";
        }
    }
}