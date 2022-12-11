using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Connection
    {
        public int Porta { get; set; }
        public IPAddress IpAddress { get; set; }
        public IPEndPoint LocalEndPoint { get; set; }
        public Socket Listener { get; set; }
        public Socket Client { get; set; }
        public List<string> FileDisponibili { get; set; }
        public Connection()
        {
            Porta = 2000;
            IpAddress = IPAddress.Parse("127.0.0.1");
            LocalEndPoint = new IPEndPoint(IpAddress, Porta);
            Listener = new Socket(IpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            FileDisponibili = new List<string>();
        }
        public void Connect()
        {
            FillList();
            Listener.Bind(LocalEndPoint);
            Listener.Listen(10);
            Console.WriteLine("Listen");
            Client = Listener.Accept();
            Console.WriteLine("connect");
            byte[] buffer = new byte[1024 * 500];
            while (Client.Connected)
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Attesa dati");
                    int n = Client.Receive(buffer);
                    switch (Convert.ToChar(buffer[0]))
                    {
                        case 'f':
                            {
                                ReciveFile(n, buffer);
                                Console.WriteLine("File ricevuto");
                                break;
                            }
                        case 'd':
                            {
                                DeleteFile(buffer, n);
                                Console.WriteLine("File cancellato");
                                break;
                            }
                        case 'r':
                            {
                                SendFile(buffer, n);
                                Console.WriteLine("File inviato");
                                break;
                            }
                        case 'c':
                            {
                                CopyFile(n, buffer);
                                Console.WriteLine("File copiato");
                                break;
                            }
                        case 'n':
                            {

                                RenameFile(n, buffer);
                                Console.WriteLine("File rinominato");
                                break;
                            }
                        case 'l':
                            {

                                SendList();
                                Console.WriteLine("Lista inviata");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Nessun comando eseguito");
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("Disconesso");
                    break;
                }

            }
            Client.Close();

        }
        public void ReciveFile(int recivedBufferL, byte[] buffer)
        {
            //ricezione
            Array.Resize(ref buffer, recivedBufferL);
            int fileNL = BitConverter.ToInt32(buffer, 1);//primo byte per il protocollo
            string fileName = Encoding.ASCII.GetString(buffer, 5, fileNL); //1-5 lunghezza nome file i primi 4 byte dicono quanto lungo e il nome del file
            fileName = "File\\" + fileName;
            //salvataggio
            BinaryWriter binaryWriter = new(File.Open(fileName, FileMode.Create));
            binaryWriter.Write(buffer, (5 + fileNL), (recivedBufferL - fileNL - 5));//
            binaryWriter.Close();
            FillList();
        }
        public void SendFile(byte[] buffer, int bufferL)
        {
            List<byte> dataL = new();
            byte[] data = new byte[bufferL];
            Array.Copy(buffer, 0, data, 0, bufferL);
            string nome = Encoding.ASCII.GetString(data, 1, data.Length - 1);
            string percorso = "File\\" + nome;
            byte[] fileNameByte = Encoding.ASCII.GetBytes(nome);
            byte[] fileNL = BitConverter.GetBytes(fileNameByte.Length);
            byte[] fileData = File.ReadAllBytes(percorso);
            dataL.AddRange(fileNL);
            dataL.AddRange(fileNameByte);
            dataL.AddRange(fileData);
            Client.Send(dataL.ToArray());
        }
        public void FillList()
        {
            List<string> st = Directory.GetFiles("File").ToList();
            List<string> rt = new();
            foreach (string s in st)
            {
                rt.Add(s.Split('\\').Last());
            }
            FileDisponibili = rt;
        }

        public void SendList()
        {
            List<byte> result = new();
            if (FileDisponibili.Count <= 0)
            {
                byte[] r = Encoding.ASCII.GetBytes("NessunFile");
                byte[] rl = BitConverter.GetBytes(r.Length);
                result.AddRange(rl);
                result.AddRange(r);
                Client.Send(result.ToArray());
                return;
            }

            foreach (string st in FileDisponibili)
            {
                byte[] std = Encoding.ASCII.GetBytes(st);
                byte[] stl = BitConverter.GetBytes(std.Length);
                result.AddRange(stl);
                result.AddRange(std);
            }
            Client.Send(result.ToArray());
        }

        public void DeleteFile(byte[] buffer, int recivedBufferL)
        {
            Array.Resize(ref buffer, recivedBufferL);
            string fileName = Encoding.ASCII.GetString(buffer, 1, buffer.Length - 1);
            File.Delete("File\\" + fileName); //Questo elimina il file
            FillList(); //Riempio La Lista
        }

        public void DeleteFile(string fileName)
        {
            File.Delete("File\\" + fileName); //Questo elimina il file
            FillList(); //Riempio La Lista
        }


        public void RenameFile(int recivedBufferL, byte[] buffer)
        {
            Array.Resize(ref buffer, recivedBufferL);
            int fileNL = BitConverter.ToInt32(buffer, 1);
            string fileName = Encoding.ASCII.GetString(buffer, 5, fileNL);
            string newFileName = Encoding.ASCII.GetString(buffer, (5 + fileNL), (buffer.Length - 5 - fileNL));
            if (newFileName.Length == 0)
            {
                
                newFileName = "Senza nome" + fileName.Substring(fileName.IndexOf('.'));
            }
            else
            {
                newFileName += fileName.Substring(fileName.IndexOf('.'));
            }
            File.Move("File\\" + fileName, "File\\" + newFileName);
            this.DeleteFile(fileName);
            FillList();
        }

        public void CopyFile(int recivedBufferL, byte[] buffer)
        {
            Array.Resize(ref buffer, recivedBufferL);
            string fileName = Encoding.ASCII.GetString(buffer, 1, buffer.Length - 1);
            File.Copy("File\\" + fileName, "File\\" + "(1)" + fileName, true);
            FillList();
        }
    }

}
