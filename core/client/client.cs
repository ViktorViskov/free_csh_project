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
        bool isWorking = true;


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
            try
            {
                Controll();
            }
            catch
            {
                Console.WriteLine("Disconnected");
            }
        }

        // methods

        // method for controll (exit) server
        private void Controll()
        {
            // start listen
            connection.Get(isWorking);

            while (isWorking)
            {
                connection.Send(Console.ReadLine());
            }

        }
    }
}