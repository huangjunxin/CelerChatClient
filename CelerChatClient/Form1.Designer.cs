namespace CelerChatClient {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.chatHistoryTextBox = new System.Windows.Forms.TextBox();
            this.chatContentTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.localIPLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chatHistoryTextBox
            // 
            this.chatHistoryTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.chatHistoryTextBox.Font = new System.Drawing.Font("更纱黑体 SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatHistoryTextBox.Location = new System.Drawing.Point(12, 12);
            this.chatHistoryTextBox.Multiline = true;
            this.chatHistoryTextBox.Name = "chatHistoryTextBox";
            this.chatHistoryTextBox.ReadOnly = true;
            this.chatHistoryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatHistoryTextBox.Size = new System.Drawing.Size(432, 306);
            this.chatHistoryTextBox.TabIndex = 1;
            // 
            // chatContentTextBox
            // 
            this.chatContentTextBox.Font = new System.Drawing.Font("更纱黑体 SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatContentTextBox.Location = new System.Drawing.Point(13, 325);
            this.chatContentTextBox.Multiline = true;
            this.chatContentTextBox.Name = "chatContentTextBox";
            this.chatContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatContentTextBox.Size = new System.Drawing.Size(431, 89);
            this.chatContentTextBox.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(288, 420);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(369, 420);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("更纱黑体 SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(450, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(152, 422);
            this.listBox1.TabIndex = 4;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(207, 420);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // localIPLabel
            // 
            this.localIPLabel.AutoSize = true;
            this.localIPLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.localIPLabel.Location = new System.Drawing.Point(12, 425);
            this.localIPLabel.Name = "localIPLabel";
            this.localIPLabel.Size = new System.Drawing.Size(143, 12);
            this.localIPLabel.TabIndex = 6;
            this.localIPLabel.Text = "Local IP: No Connection";
            // 
            // Form1
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(614, 455);
            this.Controls.Add(this.localIPLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.chatContentTextBox);
            this.Controls.Add(this.chatHistoryTextBox);
            this.Name = "Form1";
            this.Text = "CelerChatClient  - Alpha 0.6 By Transion C. T. Studio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatHistoryTextBox;
        private System.Windows.Forms.TextBox chatContentTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label localIPLabel;
    }
}

