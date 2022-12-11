using System.Net.Sockets;

namespace Client
{
    public partial class Frm : Form
    {
        private Connection c;
        private string path = "";
        public Frm()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            Button(false);
            btnUpload.Enabled = false;
            btnBrose.Enabled = false;
            btnAskList.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            c = new Connection();
            if (txtIP.Text.Length <= 0 || txtDoor.Text.Length <= 0)
            {
                lblConnect.Text = "Inserire ip e porta";
                return;
            }
            string s;
            try
            {
                s = c.Collegament(txtIP.Text, (int)Convert.ToInt64(txtDoor.Text));
            }
            catch
            {
                s = "Inserire solo numeri";
            }
            if (s != "")
            {
                lblConnect.Text = s;
                return;
            }

            if (c.Socket.Connected)
            {
                lblConnect.Text = "Server Connesso";
            }

            btnAskList.Enabled = true;
            btnConnect.Enabled = false;
            txtIP.Enabled = false;
            txtDoor.Enabled = false;
        }

        private void btnBrose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)//
            {
                path = ofd.FileName;
                lblPath.Text = "File selezionato: " + path.Split('\\').ToList().Last();
            }
            btnUpload.Enabled = true;
        }

        private void btnAskList_Click(object sender, EventArgs e)
        {
            try
            {
                FillListBox();
                btnBrose.Enabled = true;
            }
            catch (SocketException)
            {
                this.Disconect();
            }
        }
        public void FillListBox()
        {
            lbxServer.Items.Clear();
            List<string> s = c.AskList();
            if (s.Contains("NessunFile"))
            {
                lbxServer.Enabled = false;
                Button(false);
            }
            else
            {
                lbxServer.Enabled = true;
                Button(true);
            }

            lbxServer.Items.AddRange(s.ToArray());
        }
        public void Disconect()
        {
            c.Socket.Close();
            lblConnect.Text = "Disconesso";
            foreach (Control o in this.Controls)
            {
                o.Enabled = false;
            }
            lblConnect.Enabled = true;
        }
        public void Button(bool enabled)
        {
            btnBrose.Enabled = enabled;
            btnDownload.Enabled = enabled;
            btnCopy.Enabled = enabled;
            btnRename.Enabled = enabled;
            btnDelete.Enabled = enabled;
            txtRename.Enabled = enabled;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxServer.SelectedItem != null)
                {
                    c.DownloadFile(lbxServer.SelectedItem.ToString());
                    lblDownload.Text = "";
                    Button(false);
                }
                else
                {
                    lblDownload.Text = "Selezionare un file";
                }
            }
            catch (SocketException)
            {
                this.Disconect();
            }
            catch (ArgumentOutOfRangeException)
            {
                lblDownload.Text = "Il file selezionato non esiste";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxServer.SelectedItem != null)
                {
                    c.DeleteFile(lbxServer.SelectedItem.ToString());
                    lblDownload.Text = "";
                    Button(false);
                }
                else
                {
                    lblDownload.Text = "Selezionare un file";
                }
            }
            catch (SocketException)
            {
                this.Disconect();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxServer.SelectedItem != null)
                {
                    c.CopyFile(lbxServer.SelectedItem.ToString());
                    lblDownload.Text = "";
                    Button(false);
                }
                else
                {
                    lblDownload.Text = "Selezionare un file";
                }
            }
            catch (SocketException)
            {
                this.Disconect();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxServer.SelectedItem != null)
                {
                    c.RenameFile(lbxServer.SelectedItem.ToString(), txtRename.Text);
                    Button(false);
                }
            }
            catch (SocketException)
            {
                this.Disconect();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpload.Enabled = false;
                List<string> s = path.Split('\\').ToList();
                if (!File.Exists(path))
                {
                    lblPath.Text = "Errore File non trovato";
                    return;
                }
                if (c.AskList().Contains(s.Last()))
                {
                    lblPath.Text = "Un file con questo nome esiste gia \n selezionare un altro file o rinominarlo";
                    return;
                }
                lblPath.Text = "";
                c.SendFile(path, s.Last());
                Button(false);
            }
            catch (SocketException)
            {
                this.Disconect();
            }
        }


    }
}