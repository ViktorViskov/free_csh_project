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
            Status(); 

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
                try
                {
                    // accept client and get stream
                    client = await listener.AcceptTcpClientAsync();
                    stream = client.GetStream();

                    // load packages and exec commang from user
                    Exec();

                }

                // print error
                catch
                {
                    Console.WriteLine("Disconnected");
                }
            }
        }


        // status
        private void Status()
        {
            Console.WriteLine($"Server address {ipAddr.ToString()}:{port}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
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
                byte[] errors;
                byte[] output;

                // load data from user
                readBytes = stream.Read(buffer, 0, buffer.Length);

                // converting command
                command = Encoding.UTF8.GetString(buffer);

                // exec commang and send back
                ProcessStartInfo process = new ProcessStartInfo { FileName = "CMD.exe", Arguments = $"/C {command}", RedirectStandardOutput = true, RedirectStandardInput = true, RedirectStandardError = true};
                Process task = Process.Start(process);

                // get prompt output
                output = Encoding.UTF8.GetBytes(task.StandardOutput.ReadToEnd());
                errors = Encoding.UTF8.GetBytes(task.StandardError.ReadToEnd());

                // send back to client
                if (output.Length != 0)
                {
                    stream.Write(output,0,output.Length);
                }
                else
                {
                    stream.Write(errors,0,errors.Length);
                }
            }
        }
    }
}