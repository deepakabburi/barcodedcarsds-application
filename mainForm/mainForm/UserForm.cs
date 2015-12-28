using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace mainForm
{
    public partial class UserForm : Form
    {
        SqlCeConnection cn = new SqlCeConnection("Data Source=Database1.sdf");
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader dr;

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
                }

        private void button1_Click(object sender, EventArgs e)
        {
            UserForm.ActiveForm.Hide();
            Admin ad = new Admin();
            ad.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            cmd.CommandText = "SELECT *FROM usertable WHERE id='"+textBox1.Text+"'AND pass='"+textBox2.Text+"'";
            dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    UserForm.ActiveForm.Hide();
                    IDForm idformd = new IDForm();
                    idformd.Show();

                }
                else
                {
                    MessageBox.Show("user name or password incorrect");
                }
               // cmd.Clone();
            cn.Close();
        }  

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
