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
    public partial class Purchase : Form
    {
        SqlCeConnection cn = new SqlCeConnection("Data Source=Database1.sdf");
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader dr;
        public Purchase()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            textBox1.Focus();
            cmd.Connection = cn;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            IDForm id = new IDForm();
            id.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if ((Convert.ToInt32(label7.Text) - Convert.ToInt32(textBox1.Text)) < 0)
                {
                    MessageBox.Show("Insufficient balance RECHARGE ::");
                    textBox1.Text = "";
                }
                else
                {
                    label5.Text = Convert.ToString(Convert.ToInt32(label7.Text) - Convert.ToInt32(textBox1.Text));
                    //MessageBox.Show("Done ::"); 
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            AmountAdd addd = new AmountAdd();
            addd.a = b;
            this.Close();
            addd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "update baldata set id='" + b + "',bal='" + label5.Text + "' Where id = '" + b + "'";
            cmd.ExecuteNonQuery();
           // cmd.Clone();
            cn.Close();
            cn.Open();
            cmd.CommandText = "update baldata set id='" + b + "',last='" + textBox1.Text+ "' Where id = '" + b + "'";
            cmd.ExecuteNonQuery();
                 
           // cmd.Clone();
            cn.Close();
            MessageBox.Show("purchased");
            cn.Open();
            cmd.CommandText = "SELECT *FROM baldata WHERE id='" + b + "'";
            dr = cmd.ExecuteReader();
            dr.Read();
            label6.Text = dr[2].ToString();
            label7.Text = dr[1].ToString();
            label5.Text = dr[1].ToString();
        }
    }
}
