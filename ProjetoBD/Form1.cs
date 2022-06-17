using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoBD
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p8g2; password = PassDoMercado;");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void getStats()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Op_Caixa FROM Mercado.Op_Caixa", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            String count = reader["Op_Caixa"].ToString();
            //statAdega.Text = count;
            //MessageBox.Show(count);
            reader.Close();
            cmd = new SqlCommand("SELECT COUNT(*) AS Atend_Cliente FROM Mercado.Atende_Cliente", cn);
            reader = cmd.ExecuteReader();
            reader.Read();
            count = reader["Atend_Cliente"].ToString();
            //statArmazem.Text = count;
            //MessageBox.Show(count);
            reader.Close();
            cmd = new SqlCommand("SELECT COUNT(*) AS Count FROM Mercado.Reposicao", cn);
            reader = cmd.ExecuteReader();
            reader.Read();
            count = reader["Count"].ToString();
            //statVinho.Text = count;
            //MessageBox.Show(count);
            reader.Close();
        }



















        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
