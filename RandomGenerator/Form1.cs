using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = System.Environment.CurrentDirectory;
            folderBrowserDialog1.SelectedPath = System.Environment.CurrentDirectory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random R = new Random();
            var sequence = Enumerable.Range(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value - numericUpDown1.Value + 1)).OrderBy(n => n * n * (new Random()).Next()).Take(Convert.ToInt32(numericUpDown3.Value));
            StreamWriter writerandom = new StreamWriter(folderBrowserDialog1.SelectedPath + "/output.txt");
            List<int> check = new List<int>();
            foreach (var current in sequence)
            {
                writerandom.WriteLine(current);
                if (!check.Contains(current))
                {
                    check.Add(current);
                }
                else
                {
                    MessageBox.Show("重複");
                }
            }
            

            writerandom.Close();
            MessageBox.Show("完成");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = numericUpDown1.Value + numericUpDown3.Value - 1;
        }
    }
}
