using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace exercise_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox_Timing.Visible = false;
        }

        private void button1_test1_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_URL.Text = File.ReadAllText(@"C:\Users\boysa\Documents\Visual Studio 2012\Projects\exercise_7\Test1.txt");
        }

        private void button2_test2_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_URL.Text = File.ReadAllText(@"C:\Users\boysa\Documents\Visual Studio 2012\Projects\exercise_7\Test2.txt");
        }

        private void button3_test3_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_URL.Text = File.ReadAllText(@"C:\Users\boysa\Documents\Visual Studio 2012\Projects\exercise_7\Test3.txt");
        }

        private void button4_test4_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_URL.Text = File.ReadAllText(@"C:\Users\boysa\Documents\Visual Studio 2012\Projects\exercise_7\Test4.txt");
        }

        private void button5_test5_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_URL.Text = File.ReadAllText(@"C:\Users\boysa\Documents\Visual Studio 2012\Projects\exercise_7\Test5.txt");
        }

        private void button_SendRequest_Click(object sender, EventArgs e)
        {
            Stopwatch myWatch = new Stopwatch();
            String url_address = textBox_URL.Text;

            if (textBox_URL.Text == "")
            {
                MessageBox.Show("Моля изберете файл от Тест1 до Тест5.", "Текстовата кутия съдържаща URL адреса е празна !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButton1_GetRequest.Checked)
                {
                    pictureBox_Timing.Visible = true;

                    HTTP_Request request = new HTTP_Request(url_address, HTTP_Methods_ENUM.GET);

                    myWatch.Start();

                    richTextBox_HTML.Text = request.HTMLcontent;
                    textBox_Headers.Text = request.HEADcontent;

                    myWatch.Stop();
                    label_timeCount.Text = myWatch.Elapsed.ToString();
                    pictureBox_Timing.Visible = false;
                }
                else
                {
                    richTextBox_HTML.Text = "";

                    pictureBox_Timing.Visible = true;
                    HTTP_Request request = new HTTP_Request(url_address, HTTP_Methods_ENUM.HEAD);

                    myWatch.Start();

                    textBox_Headers.Text = request.HEADcontent;

                    myWatch.Stop();
                    label_timeCount.Text = myWatch.Elapsed.ToString();
                    pictureBox_Timing.Visible = false;

                }
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_URL.Clear();
            textBox_Headers.Clear();
            richTextBox_HTML.Clear();
            label_timeCount.Text = "0";
            pictureBox_Timing.Visible = false;
        }
    }
}
