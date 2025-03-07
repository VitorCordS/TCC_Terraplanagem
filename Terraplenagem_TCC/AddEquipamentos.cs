using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Terraplenagem_TCC
{
    public partial class AddEquipamentos : Form
    {
        private int equipamentoId;
        string connectionString = @"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";
        string nomeEquipamento = string.Empty;
        string descEquipamento;

        public AddEquipamentos()
        {
            InitializeComponent();
            trocabotaoadd();
        }

        public AddEquipamentos(int id)
        {
            InitializeComponent();
            equipamentoId = id;
            CarregarDadosEquipamento();
            trocabotaoatu();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string equi = txtEqui.Text;
                string desc = txtDes.Text;


                if (string.IsNullOrEmpty(equi))
                {
                    RJMessageBox.Show("O campo Nome não pode estar vazio.",
                                      "Error-Stop Icon",
                                      MessageBoxButtons.RetryCancel,
                                      MessageBoxIcon.Error);
                    return;
                }

                if (checkDia.Checked)
                {
                    double valdia = 0;
                    if (!string.IsNullOrEmpty(txtValdia.Text))
                    {
                        if (double.TryParse(txtValdia.Text, out valdia))
                        {
                            InsertEquipamento(conn, equi + " (Diária)", desc, "Diária", valdia);
                        }
                        else
                        {
                            RJMessageBox.Show("Valor inválido para 'Diária'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (checkAlu.Checked)
                {
                    double valhora = 0;
                    if (!string.IsNullOrEmpty(txtValhora.Text))
                    {
                        if (double.TryParse(txtValhora.Text, out valhora))
                        {
                            InsertEquipamento(conn, equi + " (Hora)", desc, "Hora", valhora);
                        }
                        else
                        {
                            RJMessageBox.Show("Valor inválido para 'Hora'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (checkMet.Checked)
                {
                    double valmet = 0;
                    if (!string.IsNullOrEmpty(txtMet.Text))
                    {
                        if (double.TryParse(txtMet.Text, out valmet))
                        {
                            InsertEquipamento(conn, equi + " (Metros)", desc, "Metros", valmet);
                        }
                        else
                        {
                            RJMessageBox.Show("Valor inválido para 'Metros'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (checkViag.Checked)
                {
                    double valviag = 0;
                    if (!string.IsNullOrEmpty(txtViag.Text))
                    {
                        if (double.TryParse(txtViag.Text, out valviag))
                        {
                            InsertEquipamento(conn, equi + " (Viagens)", desc, "Viagens", valviag);
                        }
                        else
                        {
                            RJMessageBox.Show("Valor inválido para 'Viagens'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


                InsertEquipamento(conn, equi + " (Empreita)", desc, "Empreita", 0);



                RJMessageBox.Show("Equipamento salvo com sucesso!",
                                  "Information Icon",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                TelaEquipamentos obj = (TelaEquipamentos)Application.OpenForms["TelaEquipamentos"];
                obj.buscaEquip();
                this.Close();
            }
        }

        private void checkDia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDia.Checked)
            {
                txtValdia.Enabled = true;
            }
            else
            {
                txtValdia.Enabled = false;
            }
        }


        private void checkAlu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAlu.Checked)
            {
                txtValhora.Enabled = true;
            }
            else
            {
                txtValhora.Enabled = false;
            }
        }

        private void InsertEquipamento(SqlConnection conn, string nomeEquipamento, string descricaoEquipamento, string tipoEquipamento, double valorEquipamento)
        {
            string query = "INSERT INTO Equipamento(nome_equipamento, descricao_equipamento, tipo_equipamento,valor_equipamento) VALUES (@nomeEquipamento, @descricaoEquipamento, @tipoEquipamento, @valorEquipamento)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@nomeEquipamento", (object)nomeEquipamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@descricaoEquipamento", (object)descricaoEquipamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@tipoEquipamento", (object)tipoEquipamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@valorEquipamento", (object)valorEquipamento ?? DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        private void checkMet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMet.Checked)
            {
                txtMet.Enabled = true;
            }
            else
            {
                txtMet.Enabled = false;
            }
        }

        private void checkViag_CheckedChanged(object sender, EventArgs e)
        {
            if(checkViag.Checked)
            {
                txtViag.Enabled = true;
            }
            else
            {
                txtViag.Enabled = false;
            }
        }

        private void CarregarDadosEquipamento()
        {
            lblTitulo.Text = "Atualizar Equipamento";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string querydesEquip = "SELECT descricao_equipamento FROM Equipamento WHERE pk_id_equipamento = @ID";
                using (SqlCommand cmddesEquip = new SqlCommand(querydesEquip, conn))
                {
                    cmddesEquip.Parameters.AddWithValue("@ID", equipamentoId);
                    descEquipamento = cmddesEquip.ExecuteScalar()?.ToString() ?? string.Empty;
                    txtDes.Text = descEquipamento;
                }


                string queryNomeEquip = "SELECT nome_equipamento FROM Equipamento WHERE pk_id_equipamento = @ID";
                using (SqlCommand cmdNomeEquip = new SqlCommand(queryNomeEquip, conn))
                {
                    cmdNomeEquip.Parameters.AddWithValue("@ID", equipamentoId);
                    nomeEquipamento = cmdNomeEquip.ExecuteScalar()?.ToString() ?? string.Empty;
                    nomeEquipamento = nomeEquipamento
                        .Replace("(Hora)", "")
                        .Replace("(Diária)", "")
                        .Replace("(Empreita)", "")
                        .Replace("(Metros)", "")
                        .Replace("(Viagens)", "")
                        .Trim();
                    txtEqui.Text = nomeEquipamento;
                }

                // Verifica o tipo de cada equipamento e ajusta as checkboxes e TextBoxes
                string queryCheckTipos = @"
            SELECT tipo_equipamento, valor_equipamento 
            FROM Equipamento 
            WHERE nome_equipamento LIKE @Nome + '%' 
            AND tipo_equipamento IN ('Hora', 'Diária', 'Metros', 'Viagens')";

                using (SqlCommand cmdCheckTipos = new SqlCommand(queryCheckTipos, conn))
                {
                    cmdCheckTipos.Parameters.AddWithValue("@Nome", nomeEquipamento);
                    SqlDataReader reader = cmdCheckTipos.ExecuteReader();

                    while (reader.Read())
                    {
                        string tipoEquipamento = reader["tipo_equipamento"].ToString();
                        decimal valorEquipamento = (decimal)reader["valor_equipamento"];

                        switch (tipoEquipamento)
                        {
                            case "Hora":
                                checkAlu.Checked = true;
                                txtValhora.Text = valorEquipamento.ToString("F2");
                                break;

                            case "Diária":
                                checkDia.Checked = true;
                                txtValdia.Text = valorEquipamento.ToString("F2");
                                break;

                            case "Metros":
                                checkMet.Checked = true;
                                txtMet.Text = valorEquipamento.ToString("F2");
                                break;

                            case "Viagens":
                                checkViag.Checked = true;
                                txtViag.Text = valorEquipamento.ToString("F2");
                                break;
                        }
                    }
                    reader.Close();
                }
            }
        }

        private void trocabotaoatu()
        {
            btnAtualizar.Visible = true;
            
            addBtn.Visible = false;
        }

        private void trocabotaoadd()
        {
            btnAtualizar.Visible = false;
            addBtn.Visible = true;
        }

        private void txtMet_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Atualizar ou inserir registros para checkboxes ativadas
                AtualizarOuInserirRegistro("Hora", checkAlu.Checked, txtValhora.Text, nomeEquipamento, conn);
                AtualizarOuInserirRegistro("Diária", checkDia.Checked, txtValdia.Text, nomeEquipamento, conn);
                AtualizarOuInserirRegistro("Metros", checkMet.Checked, txtMet.Text, nomeEquipamento, conn);
                AtualizarOuInserirRegistro("Viagens", checkViag.Checked, txtViag.Text, nomeEquipamento, conn);
            }
            RJMessageBox.Show("Dados atualizados com sucesso!");

            TelaEquipamentos obj = (TelaEquipamentos)Application.OpenForms["TelaEquipamentos"];
            obj.buscaEquip();
            this.Close();

        }

        private void AtualizarOuInserirRegistro(string tipo, bool isChecked, string valor, string nomeEquipamento, SqlConnection conn)
        {
            if (isChecked)
            {
                string nomecerto = nomeEquipamento+" ("+tipo+")";
                string queryCheckExistente = "SELECT COUNT(*) FROM Equipamento WHERE nome_equipamento = @Nome AND tipo_equipamento = @Tipo";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheckExistente, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@Nome", nomecerto);
                    cmdCheck.Parameters.AddWithValue("@Tipo", tipo);

                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count == 0) // Se não existir, insere um novo registro
                    {
                        string queryInserir = "INSERT INTO Equipamento (nome_equipamento,descricao_equipamento, tipo_equipamento, valor_equipamento) VALUES (@Nome,@Desc, @Tipo, @Valor)";
                        using (SqlCommand cmdInserir = new SqlCommand(queryInserir, conn))
                        {
                            cmdInserir.Parameters.AddWithValue("@Nome", nomecerto);
                            cmdInserir.Parameters.AddWithValue("@Desc", descEquipamento);
                            cmdInserir.Parameters.AddWithValue("@Tipo", tipo);
                            cmdInserir.Parameters.AddWithValue("@Valor", decimal.Parse(valor));
                            cmdInserir.ExecuteNonQuery();
                        }
                    }
                    else // Se já existe, atualiza o valor
                    {
                        string queryAtualizar = "UPDATE Equipamento SET valor_equipamento = @Valor WHERE nome_equipamento = @Nome AND tipo_equipamento = @Tipo";
                        using (SqlCommand cmdAtualizar = new SqlCommand(queryAtualizar, conn))
                        {
                            cmdAtualizar.Parameters.AddWithValue("@Valor", decimal.Parse(valor));
                            cmdAtualizar.Parameters.AddWithValue("@Nome", nomecerto);
                            cmdAtualizar.Parameters.AddWithValue("@Tipo", tipo);
                            cmdAtualizar.ExecuteNonQuery();
                        }
                    }
                }
            }
            else
            {
                string nomecerto = nomeEquipamento + " (" + tipo + ")";
                string queryExcluir = "DELETE FROM Equipamento WHERE nome_equipamento = @Nome AND tipo_equipamento = @Tipo";
                using (SqlCommand cmdExcluir = new SqlCommand(queryExcluir, conn))
                {
                    cmdExcluir.Parameters.AddWithValue("@Nome", nomecerto);
                    cmdExcluir.Parameters.AddWithValue("@Tipo", tipo);
                    cmdExcluir.ExecuteNonQuery();
                }
            }
        }

        private void txtMet_Leave(object sender, EventArgs e)
        {
            txtMet.Text = Regex.Replace(txtMet.Text, "[^0-9]", "");
        }

        private void txtValdia_Leave(object sender, EventArgs e)
        {
            txtValdia.Text = Regex.Replace(txtValdia.Text, "[^0-9]", "");
        }

        private void txtValhora_Leave(object sender, EventArgs e)
        {
            txtValhora.Text = Regex.Replace(txtValhora.Text, "[^0-9]", "");
        }

        private void txtViag_Leave(object sender, EventArgs e)
        {
            txtViag.Text = Regex.Replace(txtViag.Text, "[^0-9]", "");
        }
    }
}
