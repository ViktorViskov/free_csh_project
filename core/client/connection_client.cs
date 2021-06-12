// libs
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace client.connection
{
    // main class for server
    class Connection
    {
        // variables
        IPAddress ipAddr;
        int port;
        IPEndPoint endPoint;
        TcpClient client;
        NetworkStream stream;


        // constructor
        public Connection(string ipAddr, int port)
        {
            // vatiables
            this.ipAddr = IPAddress.Parse(ipAddr);
            this.port = port;

            // init interface and port
            Init();
        }

        // methods

        // init connection
        private void Init()
        {
            endPoint = new IPEndPoint(ipAddr, port);
            client = new TcpClient();
            client.Connect(endPoint);
            stream = client.GetStream();
        }


        // method for send package
        public async void Send(string command)
        {
            await stream.WriteAsync(Encoding.UTF8.GetBytes(command));
        }

        // method for get packege
        public void Get()
        {
            // varaibles
            int readBytes;
            byte[] buffer = new byte[1024 * 4];
            string command = string.Empty;

            // load data from user
            while ((readBytes = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                command += Encoding.UTF8.GetString(buffer);
            }

            // print command
            Console.WriteLine(command);
        }

        // exec user command
        // private void Exec()
        // {
        //     // variables
        //     bool exit = false;

        //     // main loop
        //     while (!exit)
        //     {
        //         // varaibles
        //         int readBytes;
        //         byte[] buffer = new byte[1024 * 4];
        //         string command = string.Empty;

        //         // load data from user
        //         while ((readBytes = stream.Read(buffer, 0, buffer.Length)) != 0)
        //         {
        //             command += Encoding.UTF8.GetString(buffer);
        //         }

        //         // print command
        //         Console.WriteLine(command);
        //     }
        // }
    }
}