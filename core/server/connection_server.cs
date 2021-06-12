// libs
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

namespace server.connection
{
    // main class for server
    class Connection
    {
        // variables
        IPAddress ipAddr = IPAddress.Any;
        int port;
        IPEndPoint endPoint;
        TcpListener listener;
        TcpClient client;
        NetworkStream stream;


        // constructor
        public Connection(int port = 8182)
        {
            // vatiables
            this.port = port;

            // init interface and port
            Init();

            // print connection info
            // Status(); //TODO bug with showing status message

            // await for client
            Listen();

        }

        // methods

        // init connection
        private void Init()
        {
            endPoint = new IPEndPoint(ipAddr, port);
            listener = new TcpListener(endPoint);
            listener.Start();
        }


        // listener
        private async void Listen()
        {
            // main loop
            while (true)
            {
                // // errors ckeching
                // try
                // {
                    // accept client and get stream
                    client = await listener.AcceptTcpClientAsync();
                    stream = client.GetStream();

                    // load packages and exec commang from user
                    Exec();

                // }

                // // print error
                // catch
                // {
                //     Console.WriteLine("Connection error");
                // }
            }
        }


        // status
        private void Status()
        {
            Console.WriteLine($"Server address {ipAddr.ToString()}:{port}");
        }

        // exec user command
        private void Exec()
        {
            // variables
            bool exit = false;

            // main loop
            while (!exit)
            {
                // varaibles
                int readBytes;
                byte[] buffer = new byte[1024 * 4];
                string command;
                byte[] output;

                // load data from user
                readBytes = stream.Read(buffer, 0, buffer.Length);

                // converting command
                command = Encoding.UTF8.GetString(buffer);

                // exec commang and send back
                // ProcessStartInfo process = new ProcessStartInfo { FileName = "/home/viktor/file", Arguments = command, RedirectStandardOutput = true};
                Process process = new Process();
                process.StartInfo.FileName = "/home/viktor/file";
                process.Start();
                // output = Encoding.UTF8.GetBytes(task.StandardOutput.ReadToEnd());

                // send back to client
                // stream.Write(output,0,output.Length);
            }
        }
    }
}