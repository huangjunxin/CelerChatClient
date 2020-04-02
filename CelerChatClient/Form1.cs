using Newtonsoft.Json;
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
            // IPHostEntry host = Dns.GetHostEntry("");
            // IPAddress ip = host.AddressList[0];

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string newInfo = null;

            try {
                socketClient.Connect(new IPEndPoint(ip, 18888));

                newInfo = "Successfully connected to server.";
                connectButton.Enabled = false;

                // 获取本地IP
                string localEndPoint = socketClient.LocalEndPoint.ToString();

                // 更新当前本地IP到IP栏
                BeginInvoke(new Action(() => {
                    localIPLabel.Text = "Local IP: " + localEndPoint;
                }));

                // 将nicknameTextBox设为ReadOnly
                BeginInvoke(new Action(() => {
                    nicknameTextBox.ReadOnly = true;
                }));

                // 根据nickname与newInfo创建新消息
                MakeNewMsg("System info", newInfo);
            } catch {
                newInfo = "Failed to connect to server.";

                // 根据nickname与newInfo创建新消息
                MakeNewMsg("System info", newInfo);

                return;
            }

            // 创建发送对象，即将发送昵称给客户端
            ContactObject co = new ContactObject();
            co.nickname = nicknameTextBox.Text;

            // 将Json转换为string
            string targetObject = JsonConvert.SerializeObject(co);

            // 将string转换为byte
            byte[] targetObjectBuffer = Encoding.UTF8.GetBytes(targetObject);

            // 发送昵称给客户端
            socketClient.Send(targetObjectBuffer);

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
            if (localIPLabel.Text != "Local IP: No Connection") {
                // 清空chatContentTextBox
                BeginInvoke(new Action(() => {
                    chatContentTextBox.Text = "";
                }));

                // 根据nickname与targetMsg创建新消息
                string newMsg = MakeNewMsg(nicknameTextBox.Text, targetMsg);

                // 创建发送对象，即将发送新消息给客户端
                ContactObject co = new ContactObject();
                co.msg = targetMsg;

                // 将Json转换为string
                string targetObject = JsonConvert.SerializeObject(co);

                // 将string转换为byte
                byte[] targetObjectBuffer = Encoding.UTF8.GetBytes(targetObject);

                // 发送新消息给客户端
                socketClient.Send(targetObjectBuffer);
            } else {
                MessageBox.Show("You are not currently connected to the server. Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Recv() {
            // 创建内存缓冲区
            byte[] srcNewMsgBuffer = new byte[1024 * 1024];

            while (true) {
                try {
                    int len = socketClient.Receive(srcNewMsgBuffer);

                    // 将byte转换为string
                    string srcNewMsg = Encoding.UTF8.GetString(srcNewMsgBuffer, 0, len);

                    // 将新消息增加到chatHistory
                    string chatHistory = chatHistoryTextBox.Text;
                    chatHistory += srcNewMsg;

                    // 将增加新消息后的chatHistory更新到chatHistoryTextBox
                    BeginInvoke(new Action(() => {
                        chatHistoryTextBox.Text = chatHistory;

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

        private void nicknameTextBox_Click(object sender, EventArgs e) {
            if (nicknameTextBox.ReadOnly == false) {
                nicknameTextBox.Text = "";
            }
        }

        public string MakeNewMsg(string nickname, string msg) {
            // 获取当前时间
            string nowDateTime = DateTime.Now.ToString();

            // 即将发送的字符串拼接成一条新消息
            string newMsg = nickname + " " + nowDateTime;
            newMsg += Environment.NewLine;
            newMsg += "　" + msg;
            newMsg += Environment.NewLine;

            // 将新消息增加到chatHistory
            string chatHistory = chatHistoryTextBox.Text;
            chatHistory += newMsg;

            // 将增加新消息后的chatHistory更新到chatHistoryTextBox
            BeginInvoke(new Action(() => {
                chatHistoryTextBox.Text = chatHistory;

                // 滚动到最底部
                chatHistoryTextBox.SelectionStart = chatHistoryTextBox.Text.Length;
                chatHistoryTextBox.ScrollToCaret();
            }));

            return newMsg;
        }
    }

    class ContactObject {
        public string nickname = null;
        public string msg = null;
    }
}
