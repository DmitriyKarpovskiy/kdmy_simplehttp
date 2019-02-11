using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace kdmy_http
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new TcpClient("www.google.com", 80))
            {
                using (var stream = client.GetStream())
                using (var writer = new StreamWriter(stream))
                using (var reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;
                    // Send request headers
                    writer.WriteLine("GET / HTTP/1.0\n\n");
                    writer.WriteLine("Host: www.google.com:80");
                    writer.WriteLine("Connection: close");
                    writer.WriteLine();
                    writer.WriteLine();

                    // Read the response from server
                    Console.WriteLine(reader.ReadToEnd());
                    Console.ReadKey();
                }
            }
        }
    }
}
