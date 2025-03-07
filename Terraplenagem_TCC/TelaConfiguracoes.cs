using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Terraplenagem_TCC
{
    public partial class TelaConfiguracoes : Form
    {
        public TelaConfiguracoes()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var senha = txtNewsenha.Text;
            string senhadesCriptografada = CriptografarSenha(txtOldsenha.Text);
            string senhaCriptografada = GerarHashSHA256(txtNewsenha.Text);

            if (senha.Length < 8 || !Regex.IsMatch(senha, @"\d"))
            {
                RJMessageBox.Show("A senha deve ter no mínimo 8 caracteres e conter pelo menos 1 número.",
                                  "Erro - Ícone de Stop",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);
                txtNewsenha.BorderColor = System.Drawing.Color.Red;
                return;

            }
            for (int i = 0; i <= senha.Length - 3; i++)
            {
                // Converte caracteres em números
                int num1 = senha[i] - '0';
                int num2 = senha[i + 1] - '0';
                int num3 = senha[i + 2] - '0';

                // Verifica se formam uma sequência
                if (num2 == num1 + 1 && num3 == num2 + 1)
                {
                    RJMessageBox.Show("A senha não pode conter sequências numéricas.",
                                      "Erro - Ícone de Stop",
                                      MessageBoxButtons.RetryCancel,
                                      MessageBoxIcon.Error);
                    return;
                }
            }


                if (txtNewsenhaC.Text != txtNewsenha.Text)
            {
                RJMessageBox.Show("As senhas são diferentes.",
                                  "Error-Stop Icon",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);
                return;
            }
            

            using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Conecte WHERE nome_user = @login";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@login", txtNewnome.Text);

                    int userCount = (int)checkCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        RJMessageBox.Show("O login já está em uso. Por favor, escolha um login diferente.",
                                          "Error-Stop Icon",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        return;
                    }         
                    if (string.IsNullOrEmpty(txtNewsenha.Text))      
                    {
                        RJMessageBox.Show("A nova senha não foi fornecida. Por favor, insira uma nova senha válida.",
                                          "Error-Stop Icon",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(txtOldsenha.Text))
                    {
                        RJMessageBox.Show("O e-mail não foi fornecido para a troca de senha. Por favor, insira um e-mail válido.",
                                          "Error-Stop Icon",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        return;
                    }
                    


                }

                // Crie a consulta de atualização condicionalmente
                string updateQuery = "UPDATE Conecte SET senha_user = @newsenha";

                // Se o nome não for nulo ou vazio, adicione a parte de atualização do nome
                if (!string.IsNullOrWhiteSpace(txtNewnome.Text))
                {
                    updateQuery += ", nome_user = @name";
                }

                updateQuery += " WHERE email_user = @oldsenha";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                {
                    updateCommand.Parameters.AddWithValue("@oldsenha", txtOldsenha.Text);
                    updateCommand.Parameters.AddWithValue("@newsenha", senhaCriptografada);

                    // Adicione o parâmetro do nome apenas se ele não for nulo
                    if (!string.IsNullOrWhiteSpace(txtNewnome.Text))
                    {
                        updateCommand.Parameters.AddWithValue("@name", txtNewnome.Text);
                    }

                    updateCommand.ExecuteNonQuery();
                }

                RJMessageBox.Show("Usuário atualizado com sucesso!", "Information Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpar os campos
                txtOldsenha.Clear();
                txtNewsenha.Clear();
                txtNewsenhaC.Clear();
                txtNewnome.Clear();

            }

        }

        private string CriptografarSenha(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }
        private string GerarHashSHA256(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void picClho1_Click(object sender, EventArgs e)
        {
            if (txtNewsenha.PasswordChar == '*')
            {
                txtNewsenha.PasswordChar = '\0';
                picClho1.Image = Terraplenagem_TCC.Properties.Resources.olho;
            }
            else
            {
                txtNewsenha.PasswordChar = '*';
                picClho1.Image = Terraplenagem_TCC.Properties.Resources.olho__1_;
            }
        }

        private void picClho2_Click(object sender, EventArgs e)
        {
            if (txtNewsenhaC.PasswordChar == '*')
            {
                txtNewsenhaC.PasswordChar = '\0';
                picClho2.Image = Terraplenagem_TCC.Properties.Resources.olho;
            }
            else
            {
                txtNewsenhaC.PasswordChar = '*';
                picClho2.Image = Terraplenagem_TCC.Properties.Resources.olho__1_;
            }
        }

        

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";

            // NT SERVICE\MSSQLSERVER colocar isso na pasta onde for salvar prioridades-->segurançao e cria um novo pessoa e permite tudo
            var dia = DateTime.Now.Date;
            string diaDoSistema = dia.ToString("ddMMyyyy");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            saveFileDialog.Title = "Salvar Backup";
            saveFileDialog.DefaultExt = "bak";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "relatorio_servicos_" + diaDoSistema + ".bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = saveFileDialog.FileName;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string backupQuery = $"BACKUP DATABASE [SISTEMA_TERRA] TO DISK = '{backupFilePath}'";

                        using (SqlCommand command = new SqlCommand(backupQuery, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            RJMessageBox.Show("Backup realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao realizar o backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=localhost;initial catalog=master;trusted_connection=true";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            openFileDialog.Title = "Selecionar Arquivo de Backup";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFilePath = openFileDialog.FileName;
                string databaseName = "SISTEMA_TERRA";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Colocar o banco em modo SINGLE_USER
                        using (SqlCommand command = new SqlCommand($"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Restaurar o banco de dados
                        using (SqlCommand command = new SqlCommand($@"
                    RESTORE DATABASE [{databaseName}] 
                    FROM DISK = '{backupFilePath}' 
                    WITH REPLACE;", connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Voltar o banco para modo MULTI_USER
                        using (SqlCommand command = new SqlCommand($"ALTER DATABASE [{databaseName}] SET MULTI_USER;", connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        RJMessageBox.Show("Banco restaurado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao restaurar o banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            
            TelaLogin mainForm = new TelaLogin();
            this.MdiParent.Hide();
            if (this.WindowState == FormWindowState.Maximized)
            {
                mainForm.WindowState = FormWindowState.Maximized;
            }
            mainForm.ShowDialog();
            this.MdiParent.Close();
        }
    }
}
