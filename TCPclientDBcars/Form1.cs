using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPclientDBcars
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private TextBox textBox;
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient("192.168.0.100", 8081);
            stream = client.GetStream();
            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(10, 10);
            textBox.Size = new System.Drawing.Size(200, 20);
            Button sendButton = new Button();
            sendButton.Text = "Send Request";
            sendButton.Location = new System.Drawing.Point(10, 40);
            sendButton.Click += SendButton_Click;
            Controls.Add(textBox);
            Controls.Add(sendButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static void Main(string[] args)
        {
            Application.Run(new Form());
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string requestData = textBox.Text;
            byte[] data = Encoding.ASCII.GetBytes(requestData);
            stream.Write(data, 0, data.Length);
            textBox.Clear();
        }
    }
}
