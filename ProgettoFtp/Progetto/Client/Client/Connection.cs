using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Permissions;
using System.IO;
using System.Reflection.Metadata;

namespace Client
{
    internal class Connection
    {
        public IPAddress Ip { get; set; }
        public IPEndPoint IPEndPoint { get; set; }
        public Socket Socket { get; set; }

        public string Collegament(string Ip, int Porta)
        {
            try
            {
                this.Ip = IPAddress.Parse(Ip);
                IPEndPoint = new IPEndPoint(this.Ip, Porta);
                Socket = new Socket(this.Ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Socket.Connect(IPEndPoint);
            }
            catch
            {
                return "Non connesso";
            }
            return "";
        }
        public void SendFile(string percorso,string nome)// f sta per invio file
        {

            byte[] fileNameByte = Encoding.ASCII.GetBytes(nome);
            byte[] fileNL = BitConverter.GetBytes(fileNameByte.Length);
            byte[] fileData = File.ReadAllBytes(percorso);
            byte[] clientData = new byte[5 + fileNameByte.Length + fileData.Length];
            clientData[0] = Convert.ToByte('f');
            fileNL.CopyTo(clientData, 1);
            fileNameByte.CopyTo(clientData, 5);
            fileData.CopyTo(clientData, (5 + fileNameByte.Length));
            Socket.Send(clientData,SocketFlags.None);
        }
        public void DownloadFile(string nomeFile)
        {
            byte[] fileNameByte = Encoding.ASCII.GetBytes(nomeFile);
            byte[] clientData = new byte[1 + fileNameByte.Length];
            clientData[0] = Convert.ToByte('r');
            fileNameByte.CopyTo(clientData, 1);
            Socket.Send(clientData);
            //
            byte[] buffer = new byte[1024 * 5000];
            int n = Socket.Receive(buffer);
            SaveFile(nomeFile, buffer, BitConverter.ToInt32(buffer, 0), n);

        }
        public static void SaveFile(string nome,byte[] buffer,int fileNL,int recivedBufferL)
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads\\");
            string fileName = pathDownload + nome;
            BinaryWriter binaryWriter = new(File.Open(fileName, FileMode.Create));
            binaryWriter.Write(buffer, (4 + fileNL), (recivedBufferL - fileNL - 4));
            binaryWriter.Close();
        }
        public void DeleteFile(string nameFile)
        {
            byte[] fileNameByte = Encoding.ASCII.GetBytes(nameFile);
            byte[] data = new byte[fileNameByte.Length + 1];
            data[0] = Convert.ToByte('d');
            fileNameByte.CopyTo(data, 1);
            Socket.Send(data.ToArray());
        }
        public void RenameFile(string nameFile, string newNameFile)
        {
            List<byte> data = new();
            byte[] nameFileByte = Encoding.ASCII.GetBytes(nameFile);
            byte[] fileNL = BitConverter.GetBytes(nameFileByte.Length);
            byte[] newNameFileByte = Encoding.ASCII.GetBytes(newNameFile);
            data.Add(Convert.ToByte('n'));
            data.AddRange(fileNL);
            data.AddRange(nameFileByte);
            data.AddRange(newNameFileByte);
            Socket.Send(data.ToArray());
        }
        public void CopyFile(string nameFile)
        {
            List<byte> data = new();
            data.Add(Convert.ToByte('c'));
            byte[] fileNameByte = Encoding.ASCII.GetBytes(nameFile);
            data.AddRange(fileNameByte);
            Socket.Send(data.ToArray());
        }
        public List<string> AskList()
        {
            List<string> result = new();
            byte[] data = new byte[1];
            data[0] = Convert.ToByte('l');
            Socket.Send(data);
            byte[] buffer = new byte[1024 * 500];
            int l = Socket.Receive(buffer);
            Array.Resize(ref buffer, l);
            int j = 0;
            while(j < l)
            {
                byte[] lenght = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    lenght[i] = buffer[j + i];
                }
                int le = BitConverter.ToInt32(lenght,0);
                string filename = Encoding.ASCII.GetString(buffer,j + 4, le);
                result.Add(filename);
                j += le + 4; 
            }
            return result;
        }

    }
}
