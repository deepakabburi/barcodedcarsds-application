using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mainForm
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "asd" && textBox2.Text == "123")
            {

                this.Close();

                CreateUser cu = new CreateUser();
                cu.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Details");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm us = new UserForm();
            us.Show();

        }
    }
}
