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
    public partial class TelaEquipamentos : Form
    {

        AddEquipamentos addequi;
        public TelaEquipamentos()
        {
            InitializeComponent();
            buscaEquip();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            addequi = new AddEquipamentos();
            addequi.MdiParent = this.MdiParent;
            addequi.Dock = DockStyle.Fill;
            addequi.Show();
        }
        public void buscaEquip()
        {
            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT pk_id_equipamento AS ID , nome_equipamento AS Nome, valor_equipamento AS Valor FROM Equipamento WHERE tipo_equipamento <> 'Empreita'";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                dataGridEquip.DataSource = dt;

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dataGridEquip.SelectedRows.Count == 1)
            {
                // Obtém o nome do equipamento selecionado
                string nomeequipamento = dataGridEquip.SelectedRows[0].Cells["ID"].Value.ToString();

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
                        string sql = "DELETE FROM Equipamento WHERE pk_id_equipamento = @nome";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@nome", nomeequipamento);
                        cmd.ExecuteNonQuery();

                        // Remove a linha do DataGridView
                        dataGridEquip.Rows.RemoveAt(dataGridEquip.SelectedRows[0].Index);
                        var result = RJMessageBox.Show("Equipamento excluido com sucesso!",
                    "Information Icon",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    }
                    catch (Exception erro)
                    {
                        RJMessageBox.Show("Erro ao excluir o equipamento: " + erro.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                var result = RJMessageBox.Show("Selecione um equipamento para excluir.",
                "Error-Stop Icon",
                 MessageBoxButtons.RetryCancel,
                 MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridEquip.SelectedRows.Count == 1)
            {
                int equipamentoId = Convert.ToInt32(dataGridEquip.SelectedRows[0].Cells["ID"].Value);
                addequi = new AddEquipamentos(equipamentoId); // Passa o ID do equipamento
                addequi.MdiParent = this.MdiParent;
                addequi.Dock = DockStyle.Fill;
                addequi.Show();
            }
            else
            {
                RJMessageBox.Show("Selecione um equipamento para editar.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
    }


    }

