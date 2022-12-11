using System;
using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (!Directory.Exists("File"))
            {
                Directory.CreateDirectory("File");
            }
            Connection c = new();
            c.Connect();
        }

    }
}
