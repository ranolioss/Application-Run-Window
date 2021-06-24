using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Run
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(comboBox1.Text);
            comboBox1.Items.Remove(comboBox1.Text);
            comboBox1.Items.Add(comboBox1.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Browser";
            op.ShowDialog();
            comboBox1.Text = op.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] s = System.IO.File.ReadAllLines(Application.StartupPath+"\\applist.txt");
            for (int i = 0; i <s.Length; i++)
            {
                comboBox1.Items.Add(s[i]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] s = new string[comboBox1.Items.Count];
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                s[i] = comboBox1.Items[i].ToString();
                System.IO.File.WriteAllLines("applist.txt",s);
            }
        }
    }
}
