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
    public partial class TelaAdmin : Form
    {
        public TelaAdmin()
        {
            InitializeComponent();
            BuscaLogins();
        }
        private void BuscaLogins()
        {
            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_user AS ID, nome_user AS Login, email_user AS [E-mail], habilitado from Conecte";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dados);
                gridviewAdm.DataSource = dt;
                // Converte a coluna existente para checkbox
                if (gridviewAdm.Columns.Contains("habilitado"))
                {
                    // Remove a coluna antiga se existir
                    gridviewAdm.Columns.Remove("habilitado");

                    // Adiciona a coluna checkbox
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "habilitado";
                    checkColumn.HeaderText = "Habilitado";
                    checkColumn.DataPropertyName = "habilitado";
                    gridviewAdm.Columns.Add(checkColumn);

                }
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

        private void gridviewAdm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridviewAdm.Columns["habilitado"].Index && e.RowIndex >= 0)
            {
                try
                {
                    // Pega o valor atual do checkbox
                    bool currentValue = (bool)gridviewAdm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Inverte o valor (se era true vira false e vice-versa)
                    bool newValue = !currentValue;

                    // Pega o ID da linha selecionada
                    int userId = Convert.ToInt32(gridviewAdm.Rows[e.RowIndex].Cells["ID"].Value);

                    using (SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
                    {
                        con.Open();
                        string updateSql = "UPDATE Conecte SET habilitado = @habilitado WHERE pk_id_user = @userId";
                        using (SqlCommand cmd = new SqlCommand(updateSql, con))
                        {
                            cmd.Parameters.AddWithValue("@habilitado", newValue ? 1 : 0);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Atualiza o valor na grid
                    gridviewAdm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = newValue;

                    // Opcional: Mostrar mensagem de sucesso
                    RJMessageBox.Show("Status atualizado com sucesso!");
                }
                catch (Exception erro)
                {
                    RJMessageBox.Show("Erro ao atualizar status: " + erro.Message);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            TelaLogin a = new TelaLogin();
            this.Hide();
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.WindowState = FormWindowState.Maximized;
            }
            a.ShowDialog();
            this.Close();
        }
    }
}
