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
    public partial class TelaArquivados : Form
    {
        public TelaArquivados()
        {
            InitializeComponent();
            buscaCliente();
        }

        /* Voltar e retorna à tela Clientes */
        /*private void btnVoltarArquiv(object sender, EventArgs e) //private void btnVoltarArquiv_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/

        public void buscaCliente()
        {
            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT nome_cliente AS Nome , tel_cliente AS Telefone, endereco_cliente AS Endereço, documento_cliente AS Documento FROM Cliente
                                WHERE status_cliente = 'Arquivado'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewArquivado.DataSource = dt;

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

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada
            if (gridviewArquivado.SelectedRows.Count == 1)
            {
                // Obtém o documento do cliente selecionado
                string documentoCliente = gridviewArquivado.SelectedRows[0].Cells["Documento"].Value.ToString();

                // Confirma a exclusão
                var confirmResult = RJMessageBox.Show("Tem certeza que quer Desarquivar?",
                 "Sim-Nao Button",
                   MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
                    try
                    {
                        con.Open();
                        string sql = "UPDATE Cliente SET status_cliente = 'Ativo' WHERE documento_cliente = @documento";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@documento", documentoCliente);
                        cmd.ExecuteNonQuery();

                        // Remove a linha do DataGridView
                        gridviewArquivado.Rows.RemoveAt(gridviewArquivado.SelectedRows[0].Index);
                        var result = RJMessageBox.Show("Cliente Desarquivado com sucesso!",
                    "Information Icon",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                        TelaClientes obj = (TelaClientes)Application.OpenForms["TelaClientes"];
                        obj.buscaCliente();
                    }
                    catch (Exception erro)
                    {
                        RJMessageBox.Show("Erro ao Ativar o cliente: " + erro.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                var result = RJMessageBox.Show("Selecione um cliente para ativar.",
                "Error-Stop Icon",
                 MessageBoxButtons.RetryCancel,
                 MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridviewArquivado.SelectedRows.Count == 1)
            {
                // Obtém o documento do cliente selecionado
                string documentoCliente = gridviewArquivado.SelectedRows[0].Cells["Documento"].Value.ToString();

                // Confirma a exclusão
                var confirmResult = RJMessageBox.Show("Tem certeza que quer EXCLUIR?",
                 "Sim-Nao Button",
                   MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
                    try
                    {
                        con.Open();
                        string sql = "DELETE FROM Cliente WHERE documento_cliente = @documento";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@documento", documentoCliente);
                        cmd.ExecuteNonQuery();

                        // Remove a linha do DataGridView
                        gridviewArquivado.Rows.RemoveAt(gridviewArquivado.SelectedRows[0].Index);
                        var result = RJMessageBox.Show("Cliente Excluido com sucesso!",
                    "Information Icon",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    }
                    catch (Exception erro)
                    {
                        RJMessageBox.Show("Erro ao excluir o cliente: " + erro.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                var result = RJMessageBox.Show("Selecione um cliente para excluir.",
                "Error-Stop Icon",
                 MessageBoxButtons.RetryCancel,
                 MessageBoxIcon.Error);
            }
        }

        private void btnVoltarArquiv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridviewArquivado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
