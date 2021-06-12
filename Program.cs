using System;
using utils;
using server;
using client;

namespace freely_selected_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Message
            Console.Clear();
            Console.WriteLine("App for remote controll via console/terminal");

            // main menu
            switch (Utils.Menu(new string[] { "Client", "Server" }))
            {
                // client side
                case "Client":
                    new Client();
                    break;

                // server side
                case "Server":
                    new Server();
                    break;
            }
        }
    }
}
