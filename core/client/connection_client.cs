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
            try {
                await stream.WriteAsync(Encoding.UTF8.GetBytes(command));
            }
            catch {
                
            }
        }

        // method for get packege
        public async void Get(bool isWorking)
        {
            // varaibles
            int readBytes;
            byte[] buffer = new byte[1024 * 4];
            string command = "";

            // load data from user
            try {
                Console.Clear();
                while (true)
                {
                    readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                    command += Encoding.UTF8.GetString(buffer,0,readBytes);
                    Console.WriteLine(command);
                }
            }
            catch {
                Console.WriteLine("Disconnected");
                isWorking = false;
            }
        }
    }
}