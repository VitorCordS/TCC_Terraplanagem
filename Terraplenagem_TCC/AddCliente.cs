using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Terraplenagem_TCC
{
    public partial class AddCliente : Form
    {
        private int clienteId = -1; // Usado para edição de cliente
        string documento = "";

        // Construtor para adicionar cliente
        public AddCliente()
        {
            InitializeComponent();
        }

        // Construtor para editar cliente, recebe o ID do cliente
        public AddCliente(int idCliente)
        {
            InitializeComponent();
            this.clienteId = idCliente;
            CarregarDadosCliente(idCliente);
        }

        // Fecha a tela e retorna à tela anterior
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        // Botão que cria a conexão com o BD e salva novos dados ou edita um cliente existente
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                RJMessageBox.Show("Nome nao pode ser nulo.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();

                if (clienteId == -1) // Adicionar Cliente
                {
                    // Verificar se o documento já existe
                    string checkQuery = "SELECT COUNT(*) FROM Cliente WHERE documento_cliente = @documento";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@documento", documento);
                        int docCount = (int)checkCommand.ExecuteScalar();

                        if (docCount > 0)
                        {
                            RJMessageBox.Show("Já existe um cliente com este CPF/CNPJ.", "Error-Stop Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Inserir novo cliente
                    string insertQuery = "INSERT INTO Cliente (nome_cliente, tipo_cliente, tel_cliente, endereco_cliente, documento_cliente, status_cliente) " +
                                         "VALUES (@name, @tipo, @tel, @endereco, @documento, 'Ativo')";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                    {
                        insertCommand.Parameters.AddWithValue("@name", string.IsNullOrEmpty(txtNome.Text) ? DBNull.Value : (object)txtNome.Text);
                        if (btnradioFisica.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@tipo", "Fisica");
                        }
                        else if (btnradioJuridica.Checked)
                        {
                            insertCommand.Parameters.AddWithValue("@tipo", "Juridica");
                        }
                        else
                        {
                            insertCommand.Parameters.Add("@tipo", SqlDbType.VarChar).Value = DBNull.Value;
                        }

                        insertCommand.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(txtTel.Text) ? DBNull.Value : (object)txtTel.Text);

                        // Construindo o endereço, mas permitindo que ele seja completamente nulo
                        string endereco = $"{(string.IsNullOrEmpty(txtEndereco.Text) ? "" : txtEndereco.Text)}, " +
                                          $"{(string.IsNullOrEmpty(txtNumero.Text) ? "" : txtNumero.Text)}, " +
                                          $"{(string.IsNullOrEmpty(txtBairro.Text) ? "" : txtBairro.Text)}, " +
                                          $"{(string.IsNullOrEmpty(txtCidade.Text) ? "" : txtCidade.Text)}, " +
                                          $"{(string.IsNullOrEmpty(txtEstado.Text) ? "" : txtEstado.Text)}, " +
                                          $"{(string.IsNullOrEmpty(txtCep.Text) ? "" : txtCep.Text)}";

                        insertCommand.Parameters.AddWithValue("@endereco", string.IsNullOrEmpty(endereco.Replace(", ", "").Trim()) ? DBNull.Value : (object)endereco);
                        insertCommand.Parameters.AddWithValue("@documento", string.IsNullOrEmpty(documento) ? DBNull.Value : (object)documento);

                        insertCommand.ExecuteNonQuery();
                    }

                    RJMessageBox.Show("Cliente salvo com sucesso!", "Information Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Editar Cliente Existente
                {
                    // Atualizar cliente existente
                    string updateQuery = "UPDATE Cliente SET nome_cliente = @name, tipo_cliente = @tipo, tel_cliente = @tel, endereco_cliente = @endereco, documento_cliente = @documento " +
                                         "WHERE pk_id_cliente = @id";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@id", clienteId);
                        updateCommand.Parameters.AddWithValue("@name", string.IsNullOrEmpty(txtNome.Text) ? DBNull.Value : (object)txtNome.Text);
                        updateCommand.Parameters.AddWithValue("@tipo", btnradioFisica.Checked ? "Fisica" : "Juridica");
                        updateCommand.Parameters.AddWithValue("@tel", string.IsNullOrEmpty(txtTel.Text) ? DBNull.Value : (object)txtTel.Text);

                        string endereco = $"{txtEndereco.Text}, {txtNumero.Text}, {txtBairro.Text}, {txtCidade.Text}, {txtEstado.Text}, {txtCep.Text}";
                        updateCommand.Parameters.AddWithValue("@endereco", string.IsNullOrEmpty(endereco.Replace(", ", "").Trim()) ? DBNull.Value : (object)endereco);
                        updateCommand.Parameters.AddWithValue("@documento", string.IsNullOrEmpty(documento) ? DBNull.Value : (object)documento);

                        updateCommand.ExecuteNonQuery();
                    }

                    RJMessageBox.Show("Cliente atualizado com sucesso!", "Information Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpar formulário
                LimparFormulario();

                TelaClientes obj = (TelaClientes)Application.OpenForms["TelaClientes"];
                obj.buscaCliente();
                this.Close();
            }
        }

        // Carregar os dados do cliente para edição
        private void CarregarDadosCliente(int idCliente)
        {
            lblTitulo.Text = "Editar clientes";
            guna2Button1.Text = "Salvar";
            using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();
                string query = "SELECT * FROM Cliente WHERE pk_id_cliente = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNome.Text = reader["nome_cliente"].ToString();
                        txtDoc.Text = reader["documento_cliente"].ToString();
                        txtTel.Text = reader["tel_cliente"].ToString();
                        string[] endereco = reader["endereco_cliente"].ToString().Split(',');

                        if (endereco.Length == 6)
                        {
                            txtEndereco.Text = endereco[0].Trim();
                            txtNumero.Text = endereco[1].Trim();
                            txtBairro.Text = endereco[2].Trim();
                            txtCidade.Text = endereco[3].Trim();
                            txtEstado.Text = endereco[4].Trim();
                            txtCep.Text = endereco[5].Trim();
                        }

                        if (reader["tipo_cliente"].ToString() == "Fisica")
                            btnradioFisica.Checked = true;
                        else
                            btnradioJuridica.Checked = true;
                    }
                }
            }
        }

        // Função para limpar os campos do formulário
        private void LimparFormulario()
        {
            txtNome.Clear();
            txtDoc.Clear();
            txtEndereco.Clear();
            txtTel.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtCep.Clear();
            txtEstado.Clear();
        }

        // Validação de CPF
        private bool IsValidCPF(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        // Validação de CNPJ
       private bool IsValidCNPJ(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito); 
        }
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere digitado é um número ou tecla de controle (como backspace)
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoc_Leave(object sender, EventArgs e)
        {
            txtDoc.Text = Regex.Replace(txtDoc.Text, @"[^0-9\.\-]", "");
            string documento = txtDoc.Text.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

            if (txtDoc.Text != "")
            {
                if (documento.Length == 11)
                {
                    btnradioFisica.Checked = true;
                    // Documento é CPF
                    if (!IsValidCPF(documento))
                    {
                        RJMessageBox.Show("CPF inválido.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        txtDoc.BorderColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else if (documento.Length == 14)
                {
                    btnradioJuridica.Checked = true;
                    // Documento é CNPJ
                    if (!IsValidCNPJ(documento))
                    {
                        RJMessageBox.Show("CNPJ inválido.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        txtDoc.BorderColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    RJMessageBox.Show("Documento inválido.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    txtDoc.BorderColor = System.Drawing.Color.Red;
                    return;
                }
            }
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            txtTel.Text = Regex.Replace(txtTel.Text, "[^0-9]", "");
        }
    }
}
