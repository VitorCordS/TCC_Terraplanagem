using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terraplenagem_TCC
{
    public partial class TelaClientes : Form
    {
        AddCliente addcli;
        TelaArquivados arquivs;
        String pesquisa;
        public TelaClientes()
        {
            InitializeComponent();
            buscaCliente();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            TelaClientes clientes = null;


            if (clientes == null)
            {
                clientes = new TelaClientes();
                clientes = this;
                clientes.Dock = DockStyle.Fill;
                clientes.Show();


            }
            addcli = new AddCliente();
            addcli.MdiParent = this.MdiParent;
            addcli.Dock = DockStyle.Fill;
            addcli.Show();
        }

        public void buscaCliente()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_cliente AS ID ,nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento
                                FROM Cliente
                                WHERE status_cliente = 'Ativo'";
                                
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewCliente.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void buscaClientejuri()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_cliente AS ID ,nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento
                                FROM Cliente
                                WHERE (status_cliente IS NULL OR status_cliente <> 'Arquivado')
                                AND tipo_cliente = 'Juridica'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewCliente.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void buscaClientepessoa()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_cliente AS ID ,nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento 
                                FROM Cliente
                                WHERE (status_cliente IS NULL OR status_cliente <> 'Arquivado')
                                AND tipo_cliente = 'Fisica'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewCliente.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void buscaClientefav()
        {
            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_cliente AS ID ,nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento 
                                FROM Cliente
                                WHERE (status_cliente IS NULL OR status_cliente <> 'Arquivado')
                                AND fav_cliente = 'Favorito'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewCliente.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridviewCliente.SelectedRows.Count == 1)
            {
                // Obtém o documento do cliente selecionado
                string documentoCliente = gridviewCliente.SelectedRows[0].Cells["ID"].Value.ToString();

                // Confirma a exclusão
                var confirmResult = RJMessageBox.Show("Tem certeza que quer arquivar?",
                    "Sim-Nao Button",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string connectionString = @"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";

                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string sql = "UPDATE Cliente SET status_cliente = 'Arquivado' WHERE pk_id_cliente = @documento";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@documento", documentoCliente);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Remove a linha do DataGridView
                        gridviewCliente.Rows.RemoveAt(gridviewCliente.SelectedRows[0].Index);

                        RJMessageBox.Show("Cliente Arquivado com sucesso!",
                            "Information Icon",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception erro)
                    {
                        // Aqui você pode logar o erro
                        RJMessageBox.Show("Erro ao Arquivar o cliente: " + erro.Message);
                    }
                }
            }
            else
            {
                RJMessageBox.Show("Selecione um cliente para arquivar.",
                    "Error-Stop Icon",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
            }


        }

        private void TelaClientes_Load(object sender, EventArgs e)
        {

        }

        private void BntArquivado_Click(object sender, EventArgs e)
        {

            if (arquivs == null)
            {
                arquivs = new TelaArquivados();
                arquivs.MdiParent = this.MdiParent;
                arquivs.Dock = DockStyle.Fill;
                arquivs.Show();
            }
            else
            {
                arquivs.Activate();
            }
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void rdbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbJuridica.Checked)
            {
                buscaCliente();
            }
            else { buscaClientejuri(); }



        }

        private void rdbPessoal_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbPessoal.Checked)
            {
                buscaCliente();
            }
            else
            {
                buscaClientepessoa();
            }

        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {

            rdbJuridica.Checked = false;
            rdbPessoal.Checked = false;
            rjRadioButton1.Checked = false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            // Verifica se há uma linha selecionada no grid
            if (gridviewCliente.SelectedRows.Count == 1)
            {
                // Obtém o ID do cliente selecionado
                int clienteId = Convert.ToInt32(gridviewCliente.SelectedRows[0].Cells["ID"].Value);

                // Abre o formulário AddCliente no modo de edição, passando o ID do cliente
                AddCliente addcli = new AddCliente(clienteId);
                addcli.MdiParent = this.MdiParent;
                addcli.Dock = DockStyle.Fill;
                addcli.Show();
            }
            else
            {
                RJMessageBox.Show("Selecione um cliente para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void rjRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!rjRadioButton1.Checked)
            {
                buscaCliente();
            }
            else
            {
                buscaClientefav();
            }
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            if (gridviewCliente.SelectedRows.Count == 1)
            {
                // Obtém o documento do cliente selecionado
                string documentoCliente = gridviewCliente.SelectedRows[0].Cells["ID"].Value.ToString();

                // Confirma a exclusão
                var confirmResult = RJMessageBox.Show("Tem certeza que quer Favoritar?",
                    "Sim-Nao Button",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string connectionString = @"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";

                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string sql = "UPDATE Cliente SET fav_cliente = 'Favorito' WHERE pk_id_cliente = @documento";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@documento", documentoCliente);
                                cmd.ExecuteNonQuery();
                            }
                        }



                    }
                    catch (Exception erro)
                    {
                        // Aqui você pode logar o erro
                        RJMessageBox.Show("Erro ao Favoritar o cliente: " + erro.Message);
                    }
                }
            }
            else
            {
                RJMessageBox.Show("Selecione um cliente para favoritar.",
                    "Error-Stop Icon",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
            }

        }

        private void BuscaNomeCliente()
        {
            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_cliente AS ID ,nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento
                                FROM Cliente
                                WHERE nome_cliente LIKE @pesquisa
                                AND (status_cliente IS NULL OR status_cliente <> 'Arquivado')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pesquisa", pesquisa + "%");
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewCliente.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //pesquisa = txtSearch.Text;
            //BuscaNomeCliente();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pesquisa = txtSearch.Text;
            BuscaNomeCliente();
        }

        private void btnDesFav_Click(object sender, EventArgs e)
        {

            if (gridviewCliente.SelectedRows.Count == 1)
            {
                // Obtém o documento do cliente selecionado
                string documentoCliente = gridviewCliente.SelectedRows[0].Cells["ID"].Value.ToString();

                string connectionString = @"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Verifica se o cliente é favorito
                        string sqlCheckFav = "SELECT fav_cliente FROM Cliente WHERE pk_id_cliente = @documento";
                        using (SqlCommand cmdCheckFav = new SqlCommand(sqlCheckFav, con))
                        {
                            cmdCheckFav.Parameters.AddWithValue("@documento", documentoCliente);
                            var isFavorite = cmdCheckFav.ExecuteScalar();

                            if (isFavorite == DBNull.Value || isFavorite == null)
                            {
                                RJMessageBox.Show("Este cliente não está nos favoritos.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                return; // Sai do método se o cliente não for favorito
                            }
                        }

                        // Confirma a exclusão
                        var confirmResult = RJMessageBox.Show("Tem certeza que quer remover dos favoritos?",
                            "Sim-Nao Button",
                            MessageBoxButtons.YesNo);

                        if (confirmResult == DialogResult.Yes)
                        {
                            string sql = "UPDATE Cliente SET fav_cliente = Null WHERE pk_id_cliente = @documento";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@documento", documentoCliente);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (rjRadioButton1.Checked)
                        {
                            buscaClientefav();
                        }
                        
                    }
                }
                catch (Exception erro)
                {
                    // Aqui você pode logar o erro
                    RJMessageBox.Show("Erro ao remover dos Favoritos o cliente: " + erro.Message);
                }
            }
            else
            {
                RJMessageBox.Show("Selecione um cliente",
                "Error-Stop Icon",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
            }


        }
    }

}
