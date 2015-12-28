using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data.SqlServerCe;


namespace mainForm
{
    public partial class CreateUser : Form
    {
        SqlCeConnection cn = new SqlCeConnection("Data Source=Database1.sdf");
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader dr;

        public CreateUser()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                cn.Open();
                cmd.CommandText = "SELECT *FROM usertable WHERE id='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    MessageBox.Show("Already ID exists :: ");
                    //cmd.Clone();
                    cn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    //cmd.Clone();
                    cn.Close();
                    cn.Open();
                    cmd.CommandText = "Insert into usertable (id,pass) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                     MessageBox.Show("Inserted new ID");
                   // cmd.Clone();
                    cn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            cmd.Connection = cn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm us = new UserForm();
            us.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                cn.Open();
                cmd.CommandText = "SELECT *FROM usertable WHERE id='" + textBox3.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    

                    //cmd.Clone();
                    cn.Close();
                    cn.Open();
                    cmd.CommandText = "Delete from usertable where id = '" + textBox3.Text + "'";
                    cmd.ExecuteNonQuery();
                    //cmd.Clone();
                    cn.Close();
                    MessageBox.Show("User deleted :: ");
                    textBox3.Text = "";

                }
                else
                {
                    //cmd.Clone();
                    cn.Close();
                    MessageBox.Show("Invalid User Name ::");
                    textBox3.Text = "";

                }

            }
        }
    }
}
