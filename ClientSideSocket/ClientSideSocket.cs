﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ClientSideSocket
{
    class ClientSideSocket
    {
        private string serverName;
        private int port;

        public ClientSideSocket(string serverName, int port)
        {
            this.serverName = serverName;
            this.port = port;
        }

        internal void Run()
        {
            Console.WriteLine(GetConnectionInfo());
            TcpClient server = new TcpClient(serverName, port);
            NetworkStream stream = server.GetStream();

            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("Hello server");
            writer.Flush();

            StreamReader reader = new StreamReader(stream);
            string serverText = reader.ReadLine();
            Console.WriteLine(serverText);

            Console.WriteLine("Shutting down connection...");
            writer.Close();
            reader.Close();
            stream.Close();
            server.Close();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private string GetConnectionInfo()
        {
            string connectionInfo = "This client is connected to " + serverName + " at port " + port + ".";
            return connectionInfo;
        }
    }
}
