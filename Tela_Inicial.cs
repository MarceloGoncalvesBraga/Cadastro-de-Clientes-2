using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastro_de_Clientes.Modelo;
using Cadastro_de_Clientes.Banco;
using System.IO;

// Sql Server CE
using System.Data.SqlServerCe;

// SQLite
using System.Data.SQLite;

// MySQL
using MySql.Data.MySqlClient;

namespace Cadastro_de_Clientes
{

    public partial class Tela_Principal : Form
    {
        List<Clientes> clientes;
        //private DataGridView dataGridView1 = new DataGridView();
        private Int32 oldRowIndex = 0;
        private const Int32 CUSTOM_CONTENT_HEIGHT = 30;
        public Tela_Principal()
        {
            InitializeComponent();
            CreateTable();
            Conectar();
            Listar();
            Dat();

        }
        //      DialogResult res = MessageBox.Show("Aceite os Termos", "Termos",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

        private void Tela_Principal_Load(object sender, EventArgs e)
        {

            this.Visible = false;
            Tela_Login tela_login = new Tela_Login();
            tela_login.ShowDialog();


            if (Tela_Login.Cancelar)
            {
                //Application.Exit();
                return;
            }

        }
        public void Dat()
        {
            // Set a cell padding to provide space for the top of the focus
            // rectangle and for the content that spans multiple columns.
            Padding newPadding = new Padding(10, 10, 10, CUSTOM_CONTENT_HEIGHT);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;

            // Set the selection background color to transparent so
            // the cell won't paint over the custom selection background.
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor =
                Color.Transparent;

            // Set the row height to accommodate the content that
            // spans multiple columns.
            this.dataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;

            // Set the column header names.
            this.dataGridView1.ColumnCount = 4;
            this.dataGridView1.Columns[0].Name = "Nome";
            //   this.dataGridView1.Columns[0].SortMode =
            //     DataGridViewColumnSortMode.NotSortable;
            this.dataGridView1.Columns[1].Name = "Email";


        }


        private void CreateTable()
        {

            #region SQLite

            string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + baseDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConection);

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand();
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE Clientes ( id INT NOT NULL PRIMARY KEY , nome NVARCHAR(50), email NVARCHAR(50))";
                comando.ExecuteNonQuery();

                label2.Text = "Tabela Criada";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }

            #endregion

        }
        private void Conectar()
        {
            #region SQL Server CE
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource = " + baseDados + "; Password = '1234'";

            SqlCeEngine db = new SqlCeEngine(strConection);

            if (!File.Exists(baseDados))
            {
                db.CreateDatabase();
            }

            db.Dispose();

            SqlCeConnection conexao = new SqlCeConnection(strConection);
            //conexao.ConnectionString = strConection;

            try
            {
                conexao.Open();
                label2.Text = "Conexão Estavel";
            }
            catch (Exception ex)
            {
                label2.Text = "Erro ao Conectar";
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            #endregion
        }
        private void Listar()
        {
            label3.Text = "Listando Dados";


            #region SQLite
            //string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            //string strConection = @"Data Source = " + baseDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(@"Data Source = " + Application.StartupPath + @"\db\DBSQLite.db" + "; Version = 3");

            try
            {
                string query = "SELECT * FROM Clientes";

                //if (txtNome.Text != "")
                //{
                //    query = "SELECT * FROM pessoas WHERE nome LIKE '" + txtNome.Text + "'";
                //}

                DataTable dados = new DataTable();

                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, new SQLiteConnection(@"Data Source = " + Application.StartupPath + @"\db\DBSQLite.db" + "; Version = 3"));

                conexao.Open();

                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    dataGridView1.Rows.Add(linha.ItemArray);
                    Padding newPadding = new Padding(100, 100, 100, 60);
                    this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;

                }




            }
            catch (Exception ex)
            {
                dataGridView1.Rows.Clear();
                label3.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }

            #endregion
        }



        private void pesquisar_Click(object sender, EventArgs e)
        {
            label1.Text = "ok";

        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            Tela_de_Cadastro tela_cadastro = new Tela_de_Cadastro();
            tela_cadastro.ShowDialog();
            //Clientes cliente = new Clientes();

            //cliente.Nome = "Marcelo";
            //cliente.Cpf = "12110093781";
            //cliente.Email = "marcelogbc(@gmail.com";
            //cliente.Data_Nascimento = "19/05/1988";
            //cliente.Celular = "9919878109";
            //cliente.Cep = "266000-000";
            //cliente.Cidade = "paracambi";
            //cliente.Bairro = "Jardim Nova era";
            //cliente.Logradouro = "Rua shirley costa";
            //cliente.Complemento = "casa";
            //cliente.Referencia = "Subida do careca";

            label1.Text = "Cadastrado Com Sucesso";
        }
        //private void Listar()
        //{
        //    lista.Items.Clear();

        //    foreach (Clientes p in clientes)
        //    {
        //        lista.Items.Add(p.Nome);
        //        lista.Items.Add(p.Data_Nascimento);
        //    }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
