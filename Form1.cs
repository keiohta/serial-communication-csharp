using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace SerialCommunication_CSharp
{
    public partial class Form1 : Form
    {
        // スレッド間処理のために用意
        private delegate void Delegate_Write(string data);
        
        DateTime now = DateTime.Now;
        // 各種フラグ
        // 1bit目 : ログ保存フラグ
        private byte saveLogFlag = 0x00;

        // ログ収集用リスト
        private List<string> saveLogList = new List<string>();
 
        public Form1()
        {
            InitializeComponent();
            setSerialComboBox();
            setBaudComboBox();
            setTimer();
            logTextBox.HideSelection = false;
        }

        /* 
         * シリアルポートを選択するComboBoxを作る.
         * 接続されているポートの名前を取得し, 表示する
         */
        private void setSerialComboBox()
        {
            foreach (var portName in SerialPort.GetPortNames())
            {
                portselectComboBox.Items.Add(portName);
            }
            if (portselectComboBox.Items.Count > 0)
            {
                portselectComboBox.SelectedIndex = 0;
                openButton.Enabled = true;
            }
            else openButton.Enabled = false;
        }

        /** 
         * ボーレートを選択するComboBoxを作る.
         * 接続されているポートの名前を取得し, 表示する
         */
        private void setBaudComboBox()
        {
            int[] baudArray = { 1200, 2400, 4800, 9600, 19200, 115200};
            for (int i = 0; i < baudArray.Length; i++)
            {
                baudselectComboBox.Items.Add(baudArray[i]);
            }
            baudselectComboBox.SelectedIndex = 3;
        }

        private void setTimer()
        {
            timer_1hz.Interval = 1000;
        }

        /**
         * openButtonが押されると実行
         * 接続の分岐をする
         */
        private void openButton_Click(object sender, EventArgs e)
        {
            if(openButton.Text == "Connect")
            {
                serialPortOpen();
                openButton.Text = "Disconnect";
            }
            else
            {
                serialPortClose();
                openButton.Text = "Connect";
            }
        }

        /** 
         * 接続を開始する
         */
        private void serialPortOpen()
        {
            string portName = portselectComboBox.SelectedItem.ToString();
            serialPort1.BaudRate = Convert.ToInt32(baudselectComboBox.SelectedItem.ToString());
            serialPort1.PortName = portName;
            serialPort1.Open();
            serialPort1.DataBits = 8;
            writeButton.Enabled = true;
        }

        /**
         * 接続を終了する
         */
        private void serialPortClose()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                writeButton.Enabled = false;
            }
        }

        /**
         * writeButtonが押されると実行される
         * serialPort1に送信される
         */
        private void writeButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (writeButton.Text == "STOP")
                {
                    timer_1hz.Stop();
                }
                else
                {
                    if (checkBox_write_1hz.Checked)
                        timer_1hz.Start();
                    else
                    {
                        String text = messageTextBox.Text;
                        serialPort1.Write(text);
                        /// messageTextBoxをクリア
                        messageTextBox.Text = "";
                    }
                    writeButton.Text = "Write";
                }
            }
        }

        /** 
         * logTextBoxに受信内容を書き込む
         */
        private void write(string data)
        {
            if (data != null)
            {
                logTextBox.AppendText(data);
            }
        }

        /**
         * ウィンドウが閉じられる際に実行される
         */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // シリアル通信していた場合は、閉じてから終了する
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        /**
         * serialPort1でデータを受信すると実行される
         * スレッドが異なるのでInvokeを使う 
         */
        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            // 受信した文字列
            string data = this.serialPort1.ReadExisting();

            // ログ保存用リストに追加
            if ((saveLogFlag & 0x01) == 0x01)
            {
                saveLogList.Add(DateTime.Now.ToString("yyyyMMdd HHmmss.ffff\t"));
                saveLogList.Add(data);
                saveLogList.Add("\r\n");
            }
            
            // 異なるスレッドのテキストボックスに書き込む
            Invoke(new Delegate_Write(write), new Object[] { data });
        }

        private void LogSaveButton_Click(object sender, EventArgs e)
        {
            if((saveLogFlag & 0x01) == 0x00)
            {
                saveLogFlag = 0x01;
                LogSaveButton.Text = "ログ取得終了";
            }
            else if((saveLogFlag & 0x01) == 0x01)
            {
                LogSaveButton.Text = "ログ取得開始";

                //SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog sfd = new SaveFileDialog();

                //はじめのファイル名を指定する
                sfd.FileName = now.ToString("yyyyMMdd_HHmmss") + ".log";
                
                //はじめに表示されるフォルダを指定する
                sfd.InitialDirectory = @"C:\";
          
                //[ファイルの種類]ではじめに
                //「すべてのファイル」が選択されているようにする
                sfd.FilterIndex = 1;
                //タイトルを設定する
                sfd.Title = "保存先のファイルを選択してください";
                
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.RestoreDirectory = true;

                //既に存在するファイル名を指定したとき警告する
                sfd.OverwritePrompt = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("UTF-8"));
                    foreach (string tmp in saveLogList)
                    {
                        writer.Write(tmp);
                    }
                    writer.Close();
                    saveLogList.Clear();
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
        }

        /**
         * スクロール位置制御の実験 20140513
         */
        private void logTextBox_VScroll(object sender, EventArgs e)
        {
            writeButton.Text = "hoge";
            this.AutoScrollPosition =
                new Point(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y -100);
        }

        private void timer_1hz_Tick(object sender, EventArgs e)
        {
            String text = messageTextBox.Text;
            serialPort1.Write(text);
        }
    }
}
