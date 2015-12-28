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
    public partial class IDForm : Form
    {
        SqlCeConnection cn = new SqlCeConnection("Data Source=Database1.sdf");
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader dr;

        public IDForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void IDForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            textBox1.Focus();
            cmd.Connection = cn;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm us = new UserForm();
            us.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                cn.Open();
                cmd.CommandText = "SELECT *FROM baldata WHERE id='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    
                    Purchase ps = new Purchase();
                    
                    ps.b = textBox1.Text.ToString();
                    ps.label6.Text = dr[2].ToString();
                    ps.label7.Text = dr[1].ToString();
                    ps.label5.Text = dr[1].ToString();
               //     cmd.Clone();
                    cn.Close();
                    this.Close();
                    ps.Show();

                }
                else
                {
                 //   cmd.Clone();
                    cn.Close();
                    MessageBox.Show("Invalid id ::");
                    textBox1.Text = "";

                }



            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cn.Open();
                cmd.CommandText = "SELECT *FROM baldata WHERE id='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    //dr.Read();
                    MessageBox.Show("Already ID exists :: ");
                   // cmd.Clone();
                    cn.Close();
                    textBox1.Text = "";
                }
                else
                {
                    //cmd.Clone();
                    cn.Close();
                    cn.Open();
                    float c = 0;
                    float d = 0;
                    cmd.CommandText = "Insert into baldata (id,bal,last) values ('" + textBox1.Text + "','" + c + "','" + d + "')";
                    cmd.ExecuteNonQuery();
                   // cmd.Clone();
                    cn.Close();
                    MessageBox.Show("Inserted new ID");


                    
                    AmountAdd ama = new AmountAdd();
                    
                    ama.a = textBox1.Text.ToString();
                    this.Close();
                    ama.Show();

                }
            }
            else
            {
                MessageBox.Show("scan id"); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cn.Open();
                cmd.CommandText = "SELECT *FROM baldata WHERE id='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //cmd.Clone();
                    cn.Close();
                    
                    AmountAdd ama = new AmountAdd();
                    
                    ama.a = textBox1.Text;
                    MessageBox.Show(ama.a);
                    this.Close();
                    ama.Show();



                }
                else
                {
                    MessageBox.Show("no id found");
                    //cmd.Clone();
                    cn.Close();
                }
            }
        }
    }
}
