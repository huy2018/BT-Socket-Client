using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace BT_Socket_Client
{
    class Client
    {
        IPEndPoint ipcl;
        Socket client;
        public Client()
        {
            ipcl = new IPEndPoint(IPAddress.Loopback, 1234);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Ketnoi()
        {
            try
            {
                client.Connect(ipcl);
                nhan();
            }
            catch
            { System.Console.WriteLine("loi"); }
        }
        public string nhan()
        {
            string nhan = "";
            try
            {
                byte[] snhan = new byte[1024];
                int rec = client.Receive(snhan);
                nhan = Encoding.ASCII.GetString(snhan, 0, rec);
                System.Console.WriteLine(nhan);
            }
            catch
            {
                Console.WriteLine("Loi");
            }
            return nhan;
        }
        public void Gui(string s)
        {
            byte[] sgui = new byte[1024];
            sgui = Encoding.ASCII.GetBytes(s);
            client.Send(sgui);
        }
        public void CreateFIle(string pathfile, string data)
        {

            string path = pathfile;

            if (!File.Exists(path))
            {

                try

                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(data);
                    }
                    Console.WriteLine("Thanh cong");
                }
                catch
                {
                    Console.WriteLine("Loi duong dan: ");
                }
            }
            else
            {
                Console.WriteLine("file da ton tai!");
            }

            // Open the file to read from.
            //using (StreamReader sr = File.OpenText(path))
            //{
            //    string s = "";
            //    while ((s = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
        }
    }
}
