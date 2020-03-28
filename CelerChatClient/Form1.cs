using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CelerChatClient {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }

        static Socket socketClient = null;

        private void connectButton_Click(object sender, EventArgs e) {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try {
                socketClient.Connect(new IPEndPoint(ip, 10086));
                Console.WriteLine("连接服务器成功");
            } catch {
                Console.WriteLine("连接服务器失败");
                return;
            }

            // 创建接收服务器反馈的进程
            Thread threadClient = new Thread(Recv);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        private void sendButton_Click(object sender, EventArgs e) {
            ClientSendMsg(chatContentTextBox.Text);
            // Console.WriteLine(chatContentTextBox.Text);
        }

        public void ClientSendMsg(string targetMsg) {
            // 清空chatContentTextBox
            BeginInvoke(new Action(() => {
                chatContentTextBox.Text = "";
            }));

            // 将string转换为byte
            byte[] targetMsgBuffer = Encoding.UTF8.GetBytes(targetMsg);

            // 发送消息
            socketClient.Send(targetMsgBuffer);
        }

        public void Recv() {
            // 创建内存缓冲区
            byte[] srcChatHistoryBuffer = new byte[1024 * 1024];

            while (true) {
                try {
                    int len = socketClient.Receive(srcChatHistoryBuffer);

                    // 将byte转换为string
                    string srcChatHistory = Encoding.UTF8.GetString(srcChatHistoryBuffer, 0, len);

                    // Console.WriteLine(srcChatHistory);
                    
                    // 将收到的字符串更新到chatHistoryTextBox
                    BeginInvoke(new Action(() => {
                        chatHistoryTextBox.Text = srcChatHistory;

                        // 滚动到最底部
                        chatHistoryTextBox.SelectionStart = chatHistoryTextBox.Text.Length;
                        chatHistoryTextBox.ScrollToCaret();
                    }));
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
