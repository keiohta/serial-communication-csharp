namespace SerialCommunication_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.portselectComboBox = new System.Windows.Forms.ComboBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.baudselectComboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.LogSaveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.checkBox_write_1hz = new System.Windows.Forms.CheckBox();
            this.timer_1hz = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(230, 34);
            this.openButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(87, 29);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Connect";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(162, 71);
            this.writeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(87, 29);
            this.writeButton.TabIndex = 1;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // portselectComboBox
            // 
            this.portselectComboBox.FormattingEnabled = true;
            this.portselectComboBox.Location = new System.Drawing.Point(18, 38);
            this.portselectComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portselectComboBox.Name = "portselectComboBox";
            this.portselectComboBox.Size = new System.Drawing.Size(89, 23);
            this.portselectComboBox.TabIndex = 2;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(18, 75);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(37, 23);
            this.messageTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "SerialPort";
            // 
            // baudselectComboBox
            // 
            this.baudselectComboBox.FormattingEnabled = true;
            this.baudselectComboBox.Location = new System.Drawing.Point(117, 38);
            this.baudselectComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baudselectComboBox.Name = "baudselectComboBox";
            this.baudselectComboBox.Size = new System.Drawing.Size(107, 23);
            this.baudselectComboBox.TabIndex = 6;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived_1);
            // 
            // LogSaveButton
            // 
            this.LogSaveButton.Location = new System.Drawing.Point(255, 71);
            this.LogSaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogSaveButton.Name = "LogSaveButton";
            this.LogSaveButton.Size = new System.Drawing.Size(155, 29);
            this.LogSaveButton.TabIndex = 7;
            this.LogSaveButton.Text = "ログ取得開始";
            this.LogSaveButton.UseVisualStyleBackColor = true;
            this.LogSaveButton.Click += new System.EventHandler(this.LogSaveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(323, 34);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 29);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(17, 108);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(393, 122);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.Text = "";
            this.logTextBox.VScroll += new System.EventHandler(this.logTextBox_VScroll);
            // 
            // checkBox_write_1hz
            // 
            this.checkBox_write_1hz.AutoSize = true;
            this.checkBox_write_1hz.Location = new System.Drawing.Point(74, 77);
            this.checkBox_write_1hz.Name = "checkBox_write_1hz";
            this.checkBox_write_1hz.Size = new System.Drawing.Size(82, 19);
            this.checkBox_write_1hz.TabIndex = 9;
            this.checkBox_write_1hz.Text = "write 1Hz";
            this.checkBox_write_1hz.UseVisualStyleBackColor = true;
            // 
            // timer_1hz
            // 
            this.timer_1hz.Interval = 1000;
            this.timer_1hz.Tick += new System.EventHandler(this.timer_1hz_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 242);
            this.Controls.Add(this.checkBox_write_1hz);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.LogSaveButton);
            this.Controls.Add(this.baudselectComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.portselectComboBox);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.openButton);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "SerialCommunication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.ComboBox portselectComboBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox baudselectComboBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button LogSaveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.CheckBox checkBox_write_1hz;
        private System.Windows.Forms.Timer timer_1hz;
    }
}

