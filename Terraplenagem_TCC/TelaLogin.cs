using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using iText.Layout.Element;
using iTextSharp.text;
using LiveCharts.Wpf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Diagnostics.Metrics;
using System.Web;

namespace Terraplenagem_TCC
{
    public partial class TelaLogin : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }


        public TelaLogin()
        {
            InitializeComponent();
            Funcoes.Mexeratela(guna2Panel1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Text;

            ChecarAdm(Username, Password);

            var loginResult = ChecarLogin(Username, Password);

            if (loginResult == 1)
            {
                TelaInicial mainForm = new TelaInicial();
                this.Hide();
                if (this.WindowState == FormWindowState.Maximized)
                {
                    mainForm.WindowState = FormWindowState.Maximized;
                }
                mainForm.ShowDialog();
                this.Close();
            }
            else if (loginResult == 0)
            {
                // Código específico para o caso habilitado = 0
                RJMessageBox.Show("Usuário não habilitado!",
                    "Error-Stop Icon",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Adicione qualquer código adicional aqui
            }
            else
            {
                RJMessageBox.Show("Usuário ou senha incorretos!",
                    "Error-Stop Icon",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                txtUsername.BorderColor = System.Drawing.Color.Red;
                txtPassword.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void ChecarAdm(string username, string password)
        {
            if (username == "Admin" && password == "admin123")
            {
                TelaAdmin mainForm = new TelaAdmin();
                this.Hide();
                if (this.WindowState == FormWindowState.Maximized)
                {
                    mainForm.WindowState = FormWindowState.Maximized;
                }
                mainForm.ShowDialog();
                this.Close();
                return;
            }
        }

        private int ChecarLogin(string username, string password)
        {
            string connectionString = "data source=localhost;" +
                                      "initial catalog=SISTEMA_TERRA;" +
                                      "trusted_connection=true;";

            string senhaCriptografada = CriptografarSenha(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CASE WHEN habilitado = 1 THEN 1 ELSE 0 END AS isEnabled " +
                                   "FROM Conecte WHERE nome_user = @username AND senha_user = @password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", senhaCriptografada);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return -1; // Retorna -1 em caso de erro ou usuário não encontrado
        }

        // Função para criptografar a senha (mesma da tela de cadastro)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                pictureBox2.Image = Terraplenagem_TCC.Properties.Resources.olho;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                pictureBox2.Image = Terraplenagem_TCC.Properties.Resources.olho__1_;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            txtUsername.BorderColor = System.Drawing.Color.Black;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TelaCadastrar a = new TelaCadastrar();
            this.Hide();
            if (this.WindowState == FormWindowState.Maximized)
            {
                a.WindowState = FormWindowState.Maximized;
            }
            a.ShowDialog();
            this.Close();
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            txtPassword.BorderColor = System.Drawing.Color.Black;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = txtUsername.Text;

            // Verifica se o nome de usuário foi preenchido
            if (string.IsNullOrWhiteSpace(username))
            {
                RJMessageBox.Show("Por favor, insira o nome de usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar o email do usuário no banco de dados
            string email = BuscarEmailPorNomeUsuario(username);

            if (email != null)
            {
                // Gerar uma nova senha
                string novaSenha = GerarSenhaAleatoria();

                // Criptografar a nova senha
                string novaSenhaCriptografada = CriptografarSenha(novaSenha);

                // Atualizar a senha no banco de dados
                AtualizarSenha(username, novaSenhaCriptografada);

                // Enviar email com a nova senha
                EnviarEmail(email, novaSenha);


                RJMessageBox.Show("Uma nova senha foi enviada para o seu email.",
                                  "Senha redefinida",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
            }
            else
            {
                RJMessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuscarEmailPorNomeUsuario(string username)
        {
            string connectionString = "data source=localhost;" +
                                      "initial catalog=SISTEMA_TERRA;" +
                                      "trusted_connection=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT email_user FROM Conecte WHERE nome_user = @username";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    var resultado = cmd.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : null;
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao buscar o email: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private string GerarSenhaAleatoria(int tamanho = 8)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(caracteres, tamanho)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void AtualizarSenha(string username, string novaSenhaCriptografada)
        {
            string connectionString = "data source=localhost;" +
                                      "initial catalog=SISTEMA_TERRA;" +
                                      "trusted_connection=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Conecte SET senha_user = @novaSenha WHERE nome_user = @username";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@novaSenha", novaSenhaCriptografada);
                    cmd.Parameters.AddWithValue("@username", username);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao atualizar a senha: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EnviarEmail(string para, string novaSenha)
        {
            MailMessage mensagem = new MailMessage("sistema.terra5@gmail.com", para);
            mensagem.Subject = "Redefinição de senha";
            mensagem.IsBodyHtml = true;
            mensagem.Body = $@"
<html>
    <body style='font-family: Arial, sans-serif; color: #333; background-color: #f9f9f9; padding: 20px;'>
        <div style='max-width: 600px; margin: auto; background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);'>
            <h2 style='color: #4CAF50; text-align: center;'>Redefinição de Senha</h2>
            <p>Olá,</p>
            <p>Sua nova senha temporária é:</p>
            <p style='font-size: 18px; font-weight: bold; color: #E74C3C; background-color: #fbe9e7; padding: 10px; border: 1px solid #E74C3C; border-radius: 4px; text-align: center;'>
                {novaSenha}
            </p>
            <p>Por favor, use essa senha para acessar o sistema e altere-a assim que possível para manter sua conta segura.</p>
            <br>
            <p>Atenciosamente,</p>
            <p>Equipe do Sistema Terra</p>
            <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;'>
            <p style='font-size: 12px; color: #777; text-align: center;'>Este é um e-mail automático. Por favor, não responda.</p>
        </div>
    </body>
</html>";





            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            // Use a senha de aplicativo aqui
            client.Credentials = new NetworkCredential("sistema.terra5@gmail.com", "hxft szhb axxs gcey");

            try
            {
                client.Send(mensagem);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Erro ao enviar email: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      /*  // Posição das text box na tela de login
        private Point txtUsernamePositionNormal = new Point(59, 179);
        private Point txtUsernamePositionMaximized = new Point(59, 210);
        private Point txtPasswordPositionNormal = new Point(59, 249);
        private Point txtPasswordPositionMaximized = new Point(59, 346);

        // Evento de muãnça do estado da tela para maximized
        private void TelaLogin_SizeChanged(object sender, EventArgs e)
        {
            //Variavel para definir um novo tamanho
            float novoTamanho;
            //if que muda e posiciona os itens dentro do container
            if (this.WindowState == FormWindowState.Maximized)
            {
                ctnLogin.Size = ctnLogin.MaximumSize;
                novoTamanho = Math.Max(lblLogin.Font.Size + 20, 8);
                lblLogin.Font = new System.Drawing.Font(lblLogin.Font.FontFamily, novoTamanho, lblLogin.Font.Style);
                novoTamanho = Math.Max(lblUser.Font.Size + 20, 8);
                lblUser.Font = new System.Drawing.Font(lblUser.Font.FontFamily, novoTamanho, lblUser.Font.Style);
                novoTamanho = Math.Max(lblpasswor.Font.Size + 20, 8);
                lblpasswor.Font = new System.Drawing.Font(lblpasswor.Font.FontFamily, novoTamanho, lblpasswor.Font.Style);
                novoTamanho = Math.Max(lblfrgtpass.Font.Size + 10, 8);
                lblfrgtpass.Font = new System.Drawing.Font(lblfrgtpass.Font.FontFamily, novoTamanho, lblfrgtpass.Font.Style);
                txtUsername.Size = new Size(455, 34);
                txtUsername.Location = txtUsernamePositionMaximized;
                txtPassword.Size = new Size(455, 34);
                txtPassword.Location = txtPasswordPositionMaximized;


            }
            //esle que volta o tamanho e o posicionamento dos itens para o padrão
            else
            {
                ctnLogin.Size = ctnLogin.MinimumSize;
                lblLogin.Font = new System.Drawing.Font(lblLogin.Font.FontFamily, 28, lblLogin.Font.Style);
                lblUser.Font = new System.Drawing.Font(lblUser.Font.FontFamily, 12, lblUser.Font.Style);
                lblpasswor.Font = new System.Drawing.Font(lblpasswor.Font.FontFamily, 12, lblpasswor.Font.Style);
                lblfrgtpass.Font = new System.Drawing.Font(lblfrgtpass.Font.FontFamily, 10, lblfrgtpass.Font.Style);
                txtUsername.Size = new Size(255, 24);
                txtUsername.Location = txtUsernamePositionNormal;
                txtPassword.Size = new Size(255, 24);
                txtPassword.Location = txtPasswordPositionNormal;
            }

            CentralizarCtnLogin();
            PosicionarLblLogin();

        }
        //Centralizador do container na tela
        private void CentralizarCtnLogin()
        {
            int x = (this.ClientSize.Width - ctnLogin.Width) / 2;
            int y = (this.ClientSize.Height - ctnLogin.Height) / 2;
            ctnLogin.Location = new Point(x, y);
        }
        //Posiciona a label no meio e no topo do container
        private void PosicionarLblLogin()
        {

            int x = (ctnLogin.Width - lblLogin.Width) / 2;
            int y = 53;


            lblLogin.Location = new Point(x, y);
        }*/

    }

}