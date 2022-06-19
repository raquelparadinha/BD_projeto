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
            InitializeCargoBox();

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


        private void InitializeCargoBox()
        {
            Cargo_Box.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargo_Box.Items.Add("Chefe de Loja");
            Cargo_Box.Items.Add("Responsável de Operações");
            Cargo_Box.Items.Add("Atendimento ao Cliente");
            Cargo_Box.Items.Add("Reposição");
            Cargo_Box.Items.Add("Op_Caixa");

            // Associate the event-handling method with the 
            // SelectedIndexChanged event.
            this.Cargo_Box.SelectedIndexChanged +=
                new System.EventHandler(Cargo_Box_SelectedIndexChanged);
        }


        private void Cargo_Box_SelectedIndexChanged(object sender,
        System.EventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            string selectedEmployee = (string)Cargo_Box.SelectedItem;
            //MessageBox.Show(selectedEmployee);

            if (selectedEmployee == "Chefe de Loja")
            {
                Categoria_label.Visible = false;
                Categoria_textbox.Visible = false;
                Sup_textbox.Enabled = false;
            }

            if (selectedEmployee == "Responsável de Operações")
            {
                Categoria_label.Visible = true;
                Categoria_label.Text = "Categoria";
                Categoria_textbox.Visible = true;
                Sup_textbox.Enabled = true;
            }

            if (selectedEmployee == "Atendimento ao Cliente")
            {
                Categoria_label.Visible = true;
                Categoria_label.Text = "Extensão de Telefone";
                Categoria_textbox.Visible = true;
                Sup_textbox.Enabled = true;
            }
            if (selectedEmployee == "Reposição")
            {
                Categoria_label.Visible = false;
                Categoria_textbox.Visible = false;
                Sup_textbox.Enabled = true;
            }
            if (selectedEmployee == "Op_Caixa")
            {
                Categoria_label.Visible = true;
                Categoria_label.Text = "ID da Caixa";
                Categoria_textbox.Visible = true;
                Sup_textbox.Enabled = true;
            }



        }



        //private void getStats()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Op_Caixa FROM Mercado.Op_Caixa", cn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    reader.Read();
        //    String count = reader["Op_Caixa"].ToString();
        //    Nome_textbox.Text = count;
        //    MessageBox.Show(count);
        //    reader.Close();
        //    cmd = new SqlCommand("SELECT COUNT(*) AS Atend_Cliente FROM Mercado.Atend_Cliente", cn);
        //    reader = cmd.ExecuteReader();
        //    reader.Read();
        //    count = reader["Atend_Cliente"].ToString();
        //    Nome_textbox.Text = count;
        //    MessageBox.Show(count);
        //    reader.Close();
        //    cmd = new SqlCommand("SELECT COUNT(*) AS Count FROM Mercado.Reposicao", cn);
        //    reader = cmd.ExecuteReader();
        //    reader.Read();
        //    count = reader["Count"].ToString();
        //    Nome_textbox.Text = count;
        //    MessageBox.Show(count);
        //    reader.Close();
        //}

        private void addFuncionário()
        {
            try
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
                string Inicio = Data_inicio.Value.ToString("yyyy-MM-dd");
                string Fim = Data_fim.Value.ToString("yyyy-MM-dd");

                switch (cargo)
                {

                    case "Chefe de loja":
                        command = new SqlCommand("Mercado.Adicionar_Chefe_Loja", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@Morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

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
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Categoria", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

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
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Ext_tel", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

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
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

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
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Id_caixa", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Caixa adicionad@ com sucesso");


                        break;
                }
            }
            catch
            {
                Bad_Data_Cancel();
            }
        }

        private void updateListFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterFuncionarios()", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Nome = reader["Nome"].ToString();
                funcionario.Id = reader["ID"].ToString();
                funcionario.Email = reader["Email"].ToString();
                funcionario.Telemovel = reader["Telemovel"].ToString();
                funcionario.SSN = reader["SSN"].ToString();
                funcionario.NIF = reader["NIF"].ToString();
                funcionario.Morada = reader["Morada"].ToString();
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

            
            this.Func_list.SelectedIndexChanged +=
                new System.EventHandler(Func_list_SelectedIndexChanged);
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


        private void Func_list_SelectedIndexChanged(object sender,
System.EventArgs e)
        {

            ListBox ListBox = (ListBox)sender;


            Funcionario selectedEmployee = (Funcionario)Func_list.SelectedItem;
            //MessageBox.Show(selectedEmployee);
            if (selectedEmployee != null)
            {
                if (selectedEmployee.Id_Sup == null)
                {
                    Categoria_label.Visible = false;
                    Categoria_textbox.Visible = false;

                    Sup_textbox.Enabled = false;
                    Sup_textbox.Text = "";
                    Cargo_Box.SelectedIndex = 1;

                }
                else
                {
                    //Sup_label.Visible = true;
                    //Sup_textbox.Visible = true;
                    Sup_textbox.Text = selectedEmployee.Id_Sup;
                }


                Nome_textbox.Text = selectedEmployee.Nome;
                Id_textbox.Text = selectedEmployee.Id;
                Email_textbox.Text = selectedEmployee.Email;
                tel_textbox.Text = selectedEmployee.Telemovel;
                Morada_textbox.Text = selectedEmployee.Morada;
                //Salario_textbox.Text = selectedEmployee.Salario;
                SSN_textbox.Text = selectedEmployee.SSN;
                NIF_textbox.Text = selectedEmployee.NIF;
            }
        }


        private void updateListProdutos()
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterProdutos()", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Produto produto = new Produto();
                produto.CodProd = reader["CodProd"].ToString();
                produto.Marca = reader["Marca"].ToString();
                produto.Nome = reader["Nome"].ToString();
                produto.CodSeccao = reader["CodSeccao"].ToString();
                produto.Designacao = reader["Designacao"].ToString();
                produto.Stock = reader["Stock"].ToString();
                produto.Preco = reader["Preco"].ToString();



                Func_list.Items.Add(produto);

            }
            reader.Close();
            cn.Close();
            try
            {
                this.Func_list.SelectedIndexChanged -= new EventHandler(Func_list_SelectedIndexChanged);
            }
            catch { }

            this.Func_list.SelectedIndexChanged +=
                new System.EventHandler(Prod_list_SelectedIndexChanged);
        }

        private void Prod_list_SelectedIndexChanged(object sender,System.EventArgs e)
        {

            ListBox ListBox = (ListBox)sender;


            Produto selectedProd = (Produto)Func_list.SelectedItem;
            //MessageBox.Show(selectedProd);
            if (selectedProd != null)
            {
                Nome_textbox.Text = selectedProd.Nome;
                Id_textbox.Text = selectedProd.CodProd;
                Email_textbox.Text = selectedProd.Marca;
                tel_textbox.Text = selectedProd.CodSeccao;
                Morada_textbox.Text = selectedProd.Designacao;
                Salario_textbox.Text = selectedProd.Stock;
                Sup_textbox.Text = selectedProd.Preco;
            }
        }





        private void Change_func_Click(object sender, EventArgs e)
        {
            if (Func_list.SelectedIndex != -1)
            {   

                Change_func.Enabled = false;
                Confirm_Button.Visible = true;
                NoEndDate_Button.Visible = true;
                Cancel_Button.Visible = true;
                Func_list.Enabled = false;
                Nome_textbox.Enabled = true;
                Id_textbox.Enabled = true;
                Email_textbox.Enabled = true;
                tel_textbox.Enabled = true;
                Morada_textbox.Enabled = true;
                Salario_textbox.Enabled = true;
                Sup_textbox.Enabled = true;
                SSN_textbox.Enabled = true;
                NIF_textbox.Enabled = true;
                Cargo_Box.Enabled = true;
                Data_inicio.Enabled = true;
                Data_fim.Enabled = true;
                NoEndDate_Button.Enabled = true;
            }




        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Change_func.Enabled = true;
            NoEndDate_Button.Visible = false;
            Confirm_Button.Visible=false;
            Cancel_Button.Visible = false;
            Func_list.Enabled = true;
            Nome_textbox.Enabled = false;
            Id_textbox.Enabled = false;
            Email_textbox.Enabled = false;
            tel_textbox.Enabled = false;
            Morada_textbox.Enabled = false;
            Salario_textbox.Enabled = false;
            Sup_textbox.Enabled = false;
            SSN_textbox.Enabled = false;
            NIF_textbox.Enabled = false;
            Cargo_Box.Enabled = false;
            Data_fim.Visible = true;
            Fim_Name.Visible = true;
            Data_fim.Visible = true;
            Data_inicio.Enabled = false;
            Data_fim.Enabled = false;
            NoEndDate_Button.Enabled = false;



            Nome_textbox.Text = "";
            Id_textbox.Text = "";
            Email_textbox.Text = "";
            tel_textbox.Text = "";
            Morada_textbox.Text = "";
            Salario_textbox.Text = "";
            NIF_textbox.Text = "";
            Sup_textbox.Text = "";
            SSN_textbox.Text = "";
            Cargo_Box.SelectedItem = null;
            Categoria_textbox.Text = "";
            Func_list.SelectedIndex = -1;


        }

        private void Confirm_Button_Click(object sender, EventArgs e)
        {   
            ChangeFuncionario();
        }

        private void NoEndDate_Button_Click(object sender, EventArgs e)
        {
            if (Fim_Name.Visible)
            {
                Fim_Name.Visible = false;
                Data_fim.Visible = false;
                NoEndDate_Button.Text = "Data de fim";
            }
            else
            {
                Fim_Name.Visible = true;
                Data_fim.Visible = true;
                NoEndDate_Button.Text = "Sem data de fim";
            }


        }

        private void Bad_Data_Cancel()
        {

            MessageBox.Show("Algum dado passado de forma incorreta");
            Change_func.Enabled = true;
            NoEndDate_Button.Visible = false;
            Confirm_Button.Visible = false;
            Cancel_Button.Visible = false;
            Func_list.Enabled = true;
            Nome_textbox.Enabled = false;
            Id_textbox.Enabled = false;
            Email_textbox.Enabled = false;
            tel_textbox.Enabled = false;
            Morada_textbox.Enabled = false;
            Salario_textbox.Enabled = false;
            Sup_textbox.Enabled = false;
            SSN_textbox.Enabled = false;
            NIF_textbox.Enabled = false;
            Cargo_Box.Enabled = false;
            Data_fim.Visible = true;
            Fim_Name.Visible = true;
            Data_fim.Visible = true;
            Data_inicio.Enabled = false;
            Data_fim.Enabled = false;
            NoEndDate_Button.Enabled = false;



            Nome_textbox.Text = "";
            Id_textbox.Text = "";
            Email_textbox.Text = "";
            tel_textbox.Text = "";
            Morada_textbox.Text = "";
            Salario_textbox.Text = "";
            NIF_textbox.Text = "";
            Sup_textbox.Text = "";
            SSN_textbox.Text = "";
            Cargo_Box.SelectedItem = null;
            Categoria_textbox.Text = "";
            Func_list.SelectedIndex = -1;
        }




        private void ChangeFuncionario()
        {
            try
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
                string Inicio = Data_inicio.Value.ToString("yyyy-MM-dd");
                string Fim = Data_fim.Value.ToString("yyyy-MM-dd");

                switch (cargo)
                {

                    case "Chefe de loja":
                        command = new SqlCommand("Mercado.Alterar_Chefe_de_Loja", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@Morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Gerente de loja alterad@ com sucesso");


                        break;

                    case "Responsável de Operações":
                        command = new SqlCommand("Mercado.Alterar_Resp_Op", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Categoria", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Reponsável de Operações alterad@ com sucesso");


                        break;

                    case "Atendimento ao Cliente":
                        command = new SqlCommand("Mercado.Alterar_Atend_Cliente" + cargo, cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Ext_tel", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Atendimento ao Cliente alterado@ com sucesso");


                        break;

                    case "Reposição":
                        command = new SqlCommand("Mercado.Alterar_Reposicao" + cargo, cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Reposição alterad@ com sucesso");


                        break;

                    case "Operad@r de Caixa":
                        command = new SqlCommand("Mercado.Alterar_Op_Caixa", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Id", Id));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Sup_Id", Id_superior));
                        command.Parameters.Add(new SqlParameter("@Id_caixa", categoria));
                        command.Parameters.Add(new SqlParameter("@DataInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DataFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Caixa alterad@ com sucesso");


                        break;
                }
            }
            catch
            {
                Bad_Data_Cancel();
            }
        }

        private void Produtos_Button_Click(object sender, EventArgs e)
        {
            Email_label.Text = "Marca";
            Id_label.Text = "Código do Produto";
            tele_label.Text = "Código da Secção";
            Morada_label.Text = "Designação";
            Salario_label.Text = "Stock";

            Nome_textbox.Text = "";
            Email_textbox.Text = "";
            Id_textbox.Text = "";
            tel_textbox.Text = "";
            Morada_textbox.Text = "";
            Salario_textbox.Text = "";
            Sup_textbox.Text = "";
            NIF_textbox.Text = "";
            SSN_textbox.Text = "";
            NIF_textbox.Text = "";
            Cargo_Box.SelectedIndex = -1;
            Categoria_textbox.Text = "";

            func_button.Enabled = true;
            Sup_label.Visible = false;
            Sup_textbox.Visible = false;
            SSN_label.Visible = false;
            SSN_textbox.Visible = false;
            NIF_label.Visible = false;
            NIF_textbox.Visible = false;
            Cargo_label.Visible = false;
            Cargo_Box.Visible = false;
            Categoria_label.Visible = false;
            Categoria_textbox.Visible = false;
            Inicio_label.Visible = false;
            Data_inicio.Visible = false;
            Fim_Name.Visible = false;
            Data_fim.Visible = false;
            NoEndDate_Button.Visible = false;
            Produtos_Button.Enabled = false;
            updateListProdutos();

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
