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
        private String type_func = "";
        SqlCommand command;
        private int totalItems;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verifySGBDConnection();
            InitializeCargoBox();
            InitializeCargoBox2();

            updateListFuncionarios();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER, 8101; Initial Catalog = p8g2; uid = p8g2; password = 101581194@BD");
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
            Cargo_Box.Items.Add("Operador de Caixa");

            // Associate the event-handling method with the 
            // SelectedIndexChanged event.
            this.Cargo_Box.SelectedIndexChanged +=
                new System.EventHandler(Cargo_Box_SelectedIndexChanged);
        }

        private void InitializeCargoBox2()
        {

            Cargo2_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Cargo2_ComboBox.Items.Add("Funcionário");
            Cargo2_ComboBox.Items.Add("Chefe de Loja");
            Cargo2_ComboBox.Items.Add("Responsável de Operações");
            Cargo2_ComboBox.Items.Add("Atendimento ao Cliente");
            Cargo2_ComboBox.Items.Add("Reposição");
            Cargo2_ComboBox.Items.Add("Operador de Caixa");
            Cargo2_ComboBox.SelectedIndex = 2;

            // Associate the event-handling method with the 
            // SelectedIndexChanged event.
            this.Cargo2_ComboBox.SelectedIndexChanged +=
                new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
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
                Categoria_textbox.Text = "";
                Sup_textbox.Enabled = false;
                Sup_textbox.Text = "";
            }
        }
        private void Cargo2_ComboBox_SelectedIndexChanged(object sender,
        System.EventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            string selectedEmployee = (string)Cargo2_ComboBox.SelectedItem;
            //MessageBox.Show(selectedEmployee);
            if (selectedEmployee == "Responsável de Operações" || selectedEmployee == "Atendimento ao Cliente" || selectedEmployee == "Operador de Caixa")
            {
                Categoria_textbox.Visible = true;
                Categoria_label.Visible = true;
            }
            else
            {
                Categoria_textbox.Visible = false;
                Categoria_label.Visible = false;
            }

            if (selectedEmployee == "Funcionário")
            {
                Salario_label.Visible = false;
                Salario_textbox.Visible = false;
                Sup_label.Visible = false;
                Sup_textbox.Visible = false;
                Cargo_Box.Visible = false;
                Cargo_label.Visible = false;

                Reset();
                updateListFuncionarios();
            }

            else if (selectedEmployee == "Chefe de Loja")
            {
                Salario_label.Visible = true;
                Salario_textbox.Visible = true;
                Sup_label.Visible = true;
                Sup_textbox.Visible = true;
                Cargo_Box.Visible = true;
                Cargo_label.Visible = true;
                Reset();
                updateListChefesDeLoja();
            }



            else if (selectedEmployee == "Responsável de Operações")
            {
                Salario_label.Visible = true;
                Salario_textbox.Visible = true;
                Sup_label.Visible = true;
                Sup_textbox.Visible = true;
                Cargo_Box.Visible = true;
                Cargo_label.Visible = true;
                Categoria_label.Text = "Categoria";
                Reset();
                updateListResp_op();
            }

            else if (selectedEmployee == "Atendimento ao Cliente")
            {
                Salario_label.Visible = true;
                Salario_textbox.Visible = true;
                Sup_label.Visible = true;
                Sup_textbox.Visible = true;
                Cargo_Box.Visible = true;
                Cargo_label.Visible = true;
                Categoria_label.Text = "Extensão de telefone";
                Reset();
                updateListAtend_Cliente();
            }
            else if (selectedEmployee == "Reposição")
            {
                Salario_label.Visible = true;
                Salario_textbox.Visible = true;
                Sup_label.Visible = true;
                Sup_textbox.Visible = true;
                Cargo_Box.Visible = true;
                Cargo_label.Visible = true;
                Reset();
                updateListRepo();
            }
            else if (selectedEmployee == "Operador de Caixa")
            {
                Salario_label.Visible = true;
                Salario_textbox.Visible = true;
                Sup_label.Visible = true;
                Sup_textbox.Visible = true;
                Cargo_Box.Visible = true;
                Cargo_label.Visible = true;
                Categoria_label.Text = "ID de caixa";
                Reset();
                updateListOp_Caixa();
            }



        }

        private void addFuncionário()
        {
            //try
            //{
                if (!verifySGBDConnection()) { 
                return; 
            }
                SqlDataReader data_reader = null;
                String nome = Nome_textbox.Text;
                String email = Email_textbox.Text;
                String telemovel = tel_textbox.Text;
                String morada = Morada_textbox.Text;
                String salario = Salario_textbox.Text;
                String NIF = NIF_textbox.Text;
                String SSN = SSN_textbox.Text;
                String cargo = Cargo_Box.Text;
                String categoria = Categoria_textbox.Text;
                if (Data_inicio.Value >= Data_fim.Value)
                {
                    MessageBox.Show("Data de inicio ocorre depois da de fim");
                }
                string Inicio = Data_inicio.Value.ToString("yyyy-MM-dd");
                string Fim = Data_fim.Value.ToString("yyyy-MM-dd");

                //MessageBox.Show(cargo);


                //command = new SqlCommand("Mercado.addFunc", cn);
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@Nome", nome));
                //command.Parameters.Add(new SqlParameter("@Email", email));
                //command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                //command.Parameters.Add(new SqlParameter("@Morada", morada));
                //command.Parameters.Add(new SqlParameter("@NIF", NIF));
                //command.Parameters.Add(new SqlParameter("@SSN", SSN));
                //MessageBox.Show("tentando adicionad@ com sucesso");

                //data_reader = command.ExecuteReader();
                //MessageBox.Show("Gerente de loja adicionad@ com sucesso");

                switch (cargo)
                {

                    case ("Chefe de Loja"):
                        command = new SqlCommand("Mercado.addChefe", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@Morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@DInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Gerente de loja adicionad@ com sucesso");
                        data_reader.Close(); 
                        updateListFuncionarios();
                        Reset();
                        break;

                case "Responsável de Operações":
                        command = new SqlCommand("Mercado.addResp", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Nome", nome));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                        command.Parameters.Add(new SqlParameter("@Morada", morada));
                        command.Parameters.Add(new SqlParameter("@Salario", salario));
                        command.Parameters.Add(new SqlParameter("@NIF", NIF));
                        command.Parameters.Add(new SqlParameter("@SSN", SSN));
                        command.Parameters.Add(new SqlParameter("@Categoria", categoria));
                        command.Parameters.Add(new SqlParameter("@DInicio", Inicio));
                        command.Parameters.Add(new SqlParameter("@DFim", Fim));

                        data_reader = command.ExecuteReader();
                        MessageBox.Show("Reponsável de Operações adicionad@ com sucesso");
                        data_reader.Close();
                        updateListFuncionarios();
                        Reset();
                        break;

                case "Atendimento ao Cliente":
                    command = new SqlCommand("Mercado.Adicionar_Atend_Cliente", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Nome", nome));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                    command.Parameters.Add(new SqlParameter("@Morada", morada));
                    command.Parameters.Add(new SqlParameter("@Salario", salario));
                    command.Parameters.Add(new SqlParameter("@NIF", NIF));
                    command.Parameters.Add(new SqlParameter("@SSN", SSN));
                    command.Parameters.Add(new SqlParameter("@ExtTelefone", categoria));
                    command.Parameters.Add(new SqlParameter("@DInicio", Inicio));
                    command.Parameters.Add(new SqlParameter("@DFim", Fim));

                    data_reader = command.ExecuteReader();
                    MessageBox.Show("Atendimento ao Cliente adicionad@ com sucesso");
                    data_reader.Close();
                    updateListFuncionarios();
                    Reset();
                    break;

                case "Reposição":
                    command = new SqlCommand("Mercado.addReposicao", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Nome", nome));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                    command.Parameters.Add(new SqlParameter("@Morada", morada));
                    command.Parameters.Add(new SqlParameter("@Salario", salario));
                    command.Parameters.Add(new SqlParameter("@NIF", NIF));
                    command.Parameters.Add(new SqlParameter("@SSN", SSN));
                    command.Parameters.Add(new SqlParameter("@DInicio", Inicio));
                    command.Parameters.Add(new SqlParameter("@DFim", Fim));

                    data_reader = command.ExecuteReader();
                    MessageBox.Show("Reposição adicionad@ com sucesso");
                    data_reader.Close();
                    updateListFuncionarios();
                    Reset();
                    break;

                case "Operador de Caixa":
                    command = new SqlCommand("Mercado.addOpCaixa", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Nome", nome));
                    command.Parameters.Add(new SqlParameter("@Email", email));
                    command.Parameters.Add(new SqlParameter("@Telemovel", telemovel));
                    command.Parameters.Add(new SqlParameter("@Morada", morada));
                    command.Parameters.Add(new SqlParameter("@Salario", salario));
                    command.Parameters.Add(new SqlParameter("@NIF", NIF));
                    command.Parameters.Add(new SqlParameter("@SSN", SSN));
                    command.Parameters.Add(new SqlParameter("@IDCaixa", categoria));
                    command.Parameters.Add(new SqlParameter("@DInicio", Inicio));
                    command.Parameters.Add(new SqlParameter("@DFim", Fim));

                    data_reader = command.ExecuteReader();
                    MessageBox.Show("Operador de Caixa adicionad@ com sucesso");
                    data_reader.Close();
                    updateListFuncionarios();
                    Reset();
                    break;
                default:
                    break;
            }
                //}
            //        catch
            //{
            //    Bad_Data_Cancel();
            //}
        }

        private void updateListFuncionarios()
        {   
            totalItems = 0;
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

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de funcionários:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Func_list.SelectedIndexChanged -= new EventHandler(Prod_list_SelectedIndexChanged);
            }
            catch { }
            try
            {
                this.Func_list.SelectedIndexChanged -=
                    new System.EventHandler(Func_list_SelectedIndexChanged);
            }
            catch { }

            this.Func_list.SelectedIndexChanged +=
                new System.EventHandler(Func_list_SelectedIndexChanged);
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.obterFuncionariosAtuais()", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            while (reader2.Read())
            {
                totalItems++;
            }
            total_items_Atuais_label.Text = "Total de funcionários Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();

            reader2.Close();
            cn.Close();
        }

        private void updateListChefesDeLoja()
        {
            totalItems = 0;
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterChefeLoja()", cn);
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
                funcionario.Salario = reader["Salario"].ToString();
                funcionario.DataInicio = reader["DInicio"].ToString();
                funcionario.DataFim = reader["DFim"].ToString();
                funcionario.Cargo = "Chefe de Loja";

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de Chefes de Loja:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged -=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged +=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.Chefe_Loja_atual", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {   
                totalItems++;
            }
            total_items_Atuais_label.Text = "Chefes de loja Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();
            reader2.Close();
            cn.Close();
        }

        private void updateListResp_op()
        {
            totalItems = 0;
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterRespOp()", cn);
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
                funcionario.Salario = reader["Salario"].ToString();
                funcionario.DataInicio = reader["DInicio"].ToString();
                funcionario.DataFim = reader["DFim"].ToString();
                funcionario.Id_Sup = reader["IDSup"].ToString();
                funcionario.Categoria = reader["Categoria"].ToString();
                funcionario.Cargo = "Responsável de Operações";

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de Resp Op:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged -=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }

            this.Cargo2_ComboBox.SelectedIndexChanged +=
                new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.Resp_Op_atual", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                totalItems++;
            }
            total_items_Atuais_label.Text = "Resp Op Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();

            reader2.Close();
            cn.Close();
        }

        private void updateListAtend_Cliente()
        {
            totalItems = 0;
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterAtendCliente()", cn);
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
                funcionario.Salario = reader["Salario"].ToString();
                funcionario.DataInicio = reader["DInicio"].ToString();
                funcionario.DataFim = reader["DFim"].ToString();
                funcionario.Id_Sup = reader["IDSup"].ToString();
                funcionario.Categoria = reader["ExtTelefone"].ToString();
                funcionario.Cargo = "Atendimento ao Cliente";

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de Atend Cliente:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged -=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }

            this.Cargo2_ComboBox.SelectedIndexChanged +=
                new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.Atend_Cliente_atual", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                totalItems++;
            }
            total_items_Atuais_label.Text = "Atend Cliente Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();

            reader2.Close();
            cn.Close();
        }

        private void updateListRepo()
        {
            totalItems = 0;
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterReposicao()", cn);
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
                funcionario.Salario = reader["Salario"].ToString();
                funcionario.DataInicio = reader["DInicio"].ToString();
                funcionario.DataFim = reader["DFim"].ToString();
                funcionario.Id_Sup = reader["IDSup"].ToString();
                funcionario.Cargo = "Reposição";

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de Reposição:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged -=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }

            this.Cargo2_ComboBox.SelectedIndexChanged +=
                new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.Reposicao_atual", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                totalItems++;
            }
            total_items_Atuais_label.Text = "Reposição Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();

            reader2.Close();
            cn.Close();
        }

        private void updateListOp_Caixa()
        {
            totalItems = 0;
            if (!verifySGBDConnection())
            {
                return;
            }

            Func_list.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Mercado.obterOpCaixa()", cn);
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
                funcionario.Salario = reader["Salario"].ToString();
                funcionario.DataInicio = reader["DInicio"].ToString();
                funcionario.DataFim = reader["DFim"].ToString();
                funcionario.Id_Sup = reader["IDSup"].ToString();
                funcionario.Categoria = reader["IDCaixa"].ToString();
                funcionario.Cargo = "Operador de Caixa";

                totalItems++;
                Func_list.Items.Add(funcionario);

            }
            total_items_label.Text = "Total de Op de Caixa:";
            total_items_textbox.Text = totalItems.ToString();
            reader.Close();
            cn.Close();
            totalItems = 0;
            try
            {
                this.Cargo2_ComboBox.SelectedIndexChanged -=
                    new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            }
            catch { }

            this.Cargo2_ComboBox.SelectedIndexChanged +=
                new System.EventHandler(Cargo2_ComboBox_SelectedIndexChanged);
            if (!verifySGBDConnection())
            {
                return;
            }
            SqlCommand cmd2 = new SqlCommand("select * from Mercado.Op_Caixa_atual", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                totalItems++;
            }
            total_items_Atuais_label.Text = "Opcaixa Atuais:";
            Func_atuais_textBox.Text = totalItems.ToString();

            reader2.Close();
            cn.Close();
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
                    Sup_textbox.Text = selectedEmployee.Id_Sup;
                }


                Nome_textbox.Text = selectedEmployee.Nome;
                Id_textbox.Text = selectedEmployee.Id;
                Email_textbox.Text = selectedEmployee.Email;
                tel_textbox.Text = selectedEmployee.Telemovel;
                Morada_textbox.Text = selectedEmployee.Morada;
                Salario_textbox.Text = selectedEmployee.Salario;
                SSN_textbox.Text = selectedEmployee.SSN;
                NIF_textbox.Text = selectedEmployee.NIF;
                Cargo_Box.Text = selectedEmployee.Cargo;
                Categoria_textbox.Text = selectedEmployee.Categoria;
            }
        }


        private void updateListProdutos()
        {
            totalItems = 0;
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


                totalItems++;
                Func_list.Items.Add(produto);

            }
            total_items_textbox.Text = totalItems.ToString();
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
                SSN_textbox.Text = selectedProd.Stock;
                Sup_textbox.Text = selectedProd.Preco;
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            type_func = "add";
            Change_func.Enabled = false;
            Confirm_Button.Visible = true;
            NoEndDate_Button.Visible = true;
            Cancel_Button.Visible = true;
            Func_list.Enabled = false;
            Nome_textbox.Enabled = true;
            Id_textbox.Enabled = false;
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
            Change_func.Enabled = false;
            add_button.Enabled = false;
            Apagar_button.Enabled = false;

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



        private void Change_func_Click(object sender, EventArgs e)
        {
            type_func = "change";
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
                Change_func.Enabled = false;
                add_button.Enabled = false;
                Apagar_button.Enabled = false;
            }
        }


        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void Reset()
        {
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
            Change_func.Enabled = true;
            add_button.Enabled = true;
            Apagar_button.Enabled = true;


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
            if (type_func == "change") {
                ChangeFuncionario(); 
            }
            else if (type_func == "add")
                addFuncionário();
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

            MessageBox.Show("Algum dado foi passado de forma incorreta");
            Change_func.Enabled = true;
            Confirm_Button.Enabled = true;
            Apagar_button.Enabled = true;
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

                    case "Operador de Caixa":
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

        private void Apagar_button_Click(object sender, EventArgs e)
        {
                apagar_prod();
        }

        private void apagar_prod()
        {
           // cona
        }


        private void func_button_Click(object sender, EventArgs e)
        {
            Email_label.Text = "Email";
            Id_label.Text = "ID";
            tele_label.Text = "Nº Telemovel";
            Morada_label.Text = "Morada";
            Salario_label.Text = "Salario";
            Sup_label.Text = "ID do Superior";
            SSN_label.Text = "SSN";
            NIF_label.Text = "NIF";
            Cargo_label.Text = "Cargo";
            Categoria_label.Text = "Categoria";
            total_items_label.Text = "Total de Funcionários:";
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

            total_items_Atuais_label.Visible = true;
            Func_atuais_textBox.Visible = true;
            func_button.Enabled = false;
            NIF_label.Visible = true;
            NIF_textbox.Visible = true;
            Inicio_label.Visible = true;
            Data_inicio.Visible = true;
            Fim_Name.Visible = true;
            Data_fim.Visible = true;
            NoEndDate_Button.Visible = true;
            Produtos_Button.Enabled = true;
            Apagar_button.Visible = false;
            Cargo2_ComboBox.Visible = true;
            updateListFuncionarios();
        }


        private void Produtos_Button_Click(object sender, EventArgs e)
        {
            Email_label.Text = "Marca";
            Id_label.Text = "Código do Produto";
            tele_label.Text = "Código da Secção";
            Morada_label.Text = "Designação";
            SSN_label.Text = "Stock";

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

            total_items_label.Text = "Total de Produtos:";
            total_items_Atuais_label.Visible = false;
            Func_atuais_textBox.Visible = false;
            func_button.Enabled = true;
            Sup_label.Visible = false;
            Sup_textbox.Visible = false;
            SSN_label.Visible = true;
            SSN_textbox.Visible = true;
            Salario_label.Visible = false;
            Salario_textbox.Visible = false;
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
            Apagar_button.Visible = true;
            Cargo2_ComboBox.Visible = false;
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Estatisticas_button_Click(object sender, EventArgs e)
        {
            if(Produtos_Button.Enabled == true)
            {

            }
        }
    }
}
