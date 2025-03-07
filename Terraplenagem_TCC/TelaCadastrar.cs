using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace Terraplenagem_TCC
{
    public partial class TelaCadastrar : Form
    {
        public TelaCadastrar()
        {
            InitializeComponent();
            Funcoes.Mexeratela(guna2Panel1);
         
        }

        private void btnCadvoltar_Click(object sender, EventArgs e)
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

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            string login = txtlogin.Text;
            string senha = txtsenha.Text;
            string senhconf = txtsenhaC.Text;
            string email = txtemail.Text;
            bool vermeio = false;

            if (string.IsNullOrEmpty(login))
            {
                vermeio = true;
                txtlogin.BorderColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(senha))
            {
                vermeio = true;
                txtsenha.BorderColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(senhconf))
            {
                vermeio = true;
                txtsenhaC.BorderColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(email))
            {
                vermeio = true;
                txtemail.BorderColor = System.Drawing.Color.Red;
            }


            if (vermeio)
            {
                RJMessageBox.Show("Há um ou mais campos vazios.",
                                  "Error-Stop Icon",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);


            }

            if (vermeio == true)
            {
                RJMessageBox.Show("Preencha todos os campos",
                  "Error-Stop Icon",
                  MessageBoxButtons.RetryCancel,
                  MessageBoxIcon.Error);

                return;
            }

            if (!EmailValido(email))
            {
                RJMessageBox.Show("O email inserido não é válido.",
                                  "Error-Stop Icon",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);
                return;
            }
            if (senha.Length < 8 || !Regex.IsMatch(senha, @"\d"))
            {
                RJMessageBox.Show("A senha deve ter no mínimo 8 caracteres e conter pelo menos 1 número.",
                                  "Erro - Ícone de Stop",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);
                txtsenha.BorderColor = System.Drawing.Color.Red;
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
            if (senha != senhconf)
            {
                RJMessageBox.Show("As senhas são diferentes.",
                                  "Error-Stop Icon",
                                  MessageBoxButtons.RetryCancel,
                                  MessageBoxIcon.Error);
                return;
            }

            // Criptografar a senha antes de salvar no banco
            string senhaCriptografada = GerarHashSHA256(senha);

            using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();

                // Verificar se o login já existe
                string checkQuery = "SELECT COUNT(*) FROM Conecte WHERE nome_user = @login";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@login", login);

                    int userCount = (int)checkCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        RJMessageBox.Show("O login já está em uso. Por favor, escolha um login diferente.",
                                          "Error-Stop Icon",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        return;
                    }
                }
                // Verificar se o login já existe
                string checkemail = "SELECT COUNT(*) FROM Conecte WHERE email_user = @email";
                using (SqlCommand checkCommand = new SqlCommand(checkemail, conn))
                {
                    checkCommand.Parameters.AddWithValue("@email", email);
                    
                    int userCount = (int)checkCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        RJMessageBox.Show("O E-mail já está em uso. Por favor, escolha um login diferente.",
                                          "Error-Stop Icon",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        return;
                    }
                }

                // Inserir novo usuário com senha criptografada
                string insertQuery = "INSERT INTO Conecte (nome_user, senha_user, email_user,habilitado) VALUES (@login, @senha, @email,0)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                {
                    insertCommand.Parameters.AddWithValue("@login", login);
                    insertCommand.Parameters.AddWithValue("@senha", senhaCriptografada); // Senha criptografada
                    insertCommand.Parameters.AddWithValue("@email", email);

                    insertCommand.ExecuteNonQuery();
                }

                RJMessageBox.Show("Cadastrado com sucesso!",
                                  "Information Icon",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                // Limpar dados das textbox
               // txtlogin.Clear();
               // txtsenha.Clear();
                //txtsenhaC.Clear();
               // txtemail.Clear();

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

        // Método para gerar o hash SHA256 da senha
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtsenha.PasswordChar == '*')
            {
                txtsenha.PasswordChar = '\0';
                pictureBox2.Image = Terraplenagem_TCC.Properties.Resources.olho;
            }
            else
            {
                txtsenha.PasswordChar = '*';
                pictureBox2.Image = Terraplenagem_TCC.Properties.Resources.olho__1_;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtsenhaC.PasswordChar == '*')
            {
                txtsenhaC.PasswordChar = '\0';
                pictureBox1.Image = Terraplenagem_TCC.Properties.Resources.olho;
            }
            else
            {
                txtsenhaC.PasswordChar = '*';
                pictureBox1.Image = Terraplenagem_TCC.Properties.Resources.olho__1_;
            }
        }

        private bool EmailValido(string email)
        {
            // Expressão regular para validar o formato do email
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private void txtlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtlogin.BorderColor = System.Drawing.Color.Black;
        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtsenha.BorderColor = System.Drawing.Color.Black;
        }

        private void txtsenhaC_KeyPress(object sender, KeyPressEventArgs e)
        {

            txtsenhaC.BorderColor = System.Drawing.Color.Black;
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtemail.BorderColor = System.Drawing.Color.Black;
        }
    }
}
