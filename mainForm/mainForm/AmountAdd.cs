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
    public partial class AmountAdd : Form
    {
        SqlCeConnection cn = new SqlCeConnection("Data Source=Database1.sdf");
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader dr;
        int k;
        public AmountAdd()
        {
            InitializeComponent();
        }

        private void AmountAdd_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show(a);
            cmd.Connection = cn;
           
            cn.Open();
            cmd.CommandText = "SELECT *FROM baldata WHERE id='" + a + "'";
            dr = cmd.ExecuteReader();
            dr.Read();
            k=Convert.ToInt32(dr[1].ToString());
            MessageBox.Show(k.ToString());
            //cmd.Clone();
            cn.Close();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                
                             
                cn.Open();
                cmd.CommandText = "update baldata set id='" + a + "',bal='" +( k+Convert.ToInt32(textBox1.Text)) + "' where id = '" + a + "'";
                cmd.ExecuteNonQuery();
              //  cmd.Clone();
                cn.Close();
                cn.Open();
                cmd.CommandText = "SELECT *FROM baldata WHERE id='" + a + "'";
                dr = cmd.ExecuteReader();
                dr.Read();
                Purchase pr = new Purchase();
                pr.b = a;
                pr.label6.Text = dr[2].ToString();
                pr.label7.Text = dr[1].ToString();
            pr.label5.Text = dr[1].ToString(); ;
                //cmd.Clone();
                cn.Close();
                this.Close();
                pr.Show();
               
            }
            else
            {
                MessageBox.Show("enter amount");
                textBox1.Text = "";
            }
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            IDForm idd = new IDForm();
            idd.Show();
        }

    }
}
