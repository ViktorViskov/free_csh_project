// libs
using utils;
using client.connection;
using System;


namespace client
{
    // main class for client
    class Client
    {
        // variables
        Connection connection;


        // constructor
        public Client()
        {
            // variables
            Console.Write("Ip address: ");
            string ipAddr = Console.ReadLine();
            Console.Write("Port address: ");
            int port = int.Parse(Console.ReadLine());

            // create connection
            connection = new Connection(ipAddr, port);

            // app controll
            Controll();
        }

        // methods

        // method for controll (exit) server
        private void Controll()
        {
            switch (Utils.Menu(new string[] { "Send", "World" }))
            {
                case "Send":
                connection.Send("uname -a");
                connection.Get();
                break;
            }
        }
    }
}