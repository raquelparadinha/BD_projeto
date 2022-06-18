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
        SqlCommand command;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verifySGBDConnection();
            //getStats();
            Cargo_Box.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargo_Box.Items.Add("Chefe de Loja");
            Cargo_Box.Items.Add("Responsável de Operações");
            Cargo_Box.Items.Add("Atendimento ao Cliente");
            Cargo_Box.Items.Add("Reposição");
            Cargo_Box.Items.Add("Op_Caixa");

            updateListFuncionarios();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p8g2; uid = p8g2; password = Benfica2001!");
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
            Nome_textbox.Text = count;
            MessageBox.Show(count);
            reader.Close();
            cmd = new SqlCommand("SELECT COUNT(*) AS Atend_Cliente FROM Mercado.Atend_Cliente", cn);
            reader = cmd.ExecuteReader();
            reader.Read();
            count = reader["Atend_Cliente"].ToString();
            Nome_textbox.Text = count;
            MessageBox.Show(count);
            reader.Close();
            cmd = new SqlCommand("SELECT COUNT(*) AS Count FROM Mercado.Reposicao", cn);
            reader = cmd.ExecuteReader();
            reader.Read();
            count = reader["Count"].ToString();
            Nome_textbox.Text = count;
            MessageBox.Show(count);
            reader.Close();
        }

        private void addFuncionário()
        {
            SqlDataReader data_reader = null;
            String nome = Nome_textbox.Text;
            int Id = Int32.Parse(Id_textbox.Text);
            String email = Email_textbox.Text;
            String telemovel = tel_textbox.Text;
            String morada = Morada_textbox.Text;
            decimal salario = decimal.Parse(Salario_textbox.Text);
            String NIF = NIF_textbox.Text;
            int Id_superior = Int32.Parse(Sup_textbox.Text);
            String SSN = SSN_textbox.Text;
            String cargo = Cargo_Box.Text;
            String categoria = Categoria_textbox.Text;
            try
            {

                switch (cargo)
                {

                    case "Chefe de loja":
                        command = new SqlCommand("WineDB.Adicionar_Chefe_Loja", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Cargo", cargo));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Gerente de loja adicionad@ com sucesso");


                        break;

                    case "Responsável de Operações":
                        command = new SqlCommand("Mercado.Adicionar_Resp_Op", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Cargo", cargo));
                        command.Parameters.Add(new SqlParameter("@Categoria", categoria));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Reponsável de Operações adicionad@ com sucesso");


                        break;

                    case "Atendimento ao Cliente":
                        command = new SqlCommand("Mercado.Adicionar_Atend_Cliente" + cargo, cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Cargo", cargo));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Atendimento ao Cliente adicionad@ com sucesso");


                        break;

                    case "Reposição":
                        command = new SqlCommand("Mercado.Adicionar_Reposicao" + cargo, cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Cargo", cargo));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Reposição adicionad@ com sucesso");


                        break;

                    case "Operad@r de Caixa":
                        command = new SqlCommand("Mercado.Adicionar_Op_Caixa", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Cargo", cargo));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Caixa adicionad@ com sucesso");


                        break;
                }
            }
            catch
            {
                {

                    Nome_textbox.Text = "";
                    Id_textbox.Text = "";
                    Email_textbox.Text = "";
                    tel_textbox.Text = "";
                    Morada_textbox.Text = "";
                    Salario_textbox.Text = "";
                    NIF_textbox.Text = "";
                    Sup_textbox.Text = "";
                    SSN_textbox.Text = "";
                    Cargo_Box.Text = "";
                    Categoria_textbox.Text = "";


                    MessageBox.Show("Algum dado passado de forma incorreta");
                }
            }
        }

        private void updateListFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            //groupsVisibleFalse();
            //panelsVisibleFalse();
            Func_list.Items.Clear();
            //button8.Visible = true;
            //button7.Visible = true;
            //button9.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterFuncionarios()", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = reader["Nome"].ToString();
                funcionario.Id = reader["ID"].ToString();
                //funcionario.Email = reader["Email"].ToString();
                //funcionario.Telemovel = reader["Telemovel"].ToString();
                //funcionario.SSN = reader["SSN"].ToString();
                //funcionario.NIF = reader["NIF"].ToString();
                //funcionario.Morada = reader["Morada"].ToString();
                //funcionario.Salario = reader["Salario"].ToString();
                //funcionario.DataInicio = reader["DInicio"].ToString();
                //funcionario.DataFim = reader["DFim"].ToString();
                //if (reader["IDSup"].ToString() != null)
                //{
                //    funcionario.Id_Sup = reader["IDSup"].ToString();
                //}
                //if (reader["Categoria"].ToString() != null)
                //{
                //    funcionario.Categoria = reader["Categoria"].ToString();
                //}


                Func_list.Items.Add(funcionario);

            }
            reader.Close();
            cn.Close();
            if (Func_list.Items.Count > 0)
            {
                Func_list.SelectedIndex = 0;
            }
            //if (!verifySGBDConnection())
            //{
            //    return;
            //}
            //SqlCommand cmd2 = new SqlCommand("select * from Biblestia.obterFuncionariosAtuais('" + biblioteca.Nome + "')", cn);
            //SqlDataReader reader2 = cmd2.ExecuteReader();
            //reader2.Read();
            //String nFuncionariosAtuais = reader2["FuncionariosAtuais"].ToString();
            //double percentagemAtuais = int.Parse(nFuncionariosAtuais);
            //double total = listBox1.Items.Count;
            //double output = percentagemAtuais / total * 100;
            //textBox8.Text = listBox1.Items.Count.ToString();
            //textBox9.Text = nFuncionariosAtuais;
            //textBox10.Text = String.Format("{0:0.##}", output);
            //reader2.Close();
            //cn.Close();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
