using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf.draw;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using LiveCharts;
using PieChart1 = LiveCharts.WinForms.PieChart;
using System.Drawing;
using MediaColor = System.Windows.Media.Color;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Linq;

namespace Terraplenagem_TCC
{
    public partial class AddServicos : Form
    {
        string connectionString = "data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true;";

        public AddServicos()
        {
            InitializeComponent();
            CarregarClientes();
            ConfigurarGridEquip();
            CarregarEqui();

 
            dataServ.CustomFormat = " ";  // Formato vazio
            dataServ.Value = DateTime.Now;
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }



        private void CarregarClientes()
        {
            string query = "SELECT nome_cliente FROM Cliente ORDER BY fav_cliente DESC";// +
                                                              // "where status_cliente <> 'Arquivado'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboCliente.Items.Clear();
                    //Esse while aqui é como se fosse um foreach
                    while (reader.Read())
                    {
                        comboCliente.Items.Add(reader["nome_cliente"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    RJMessageBox.Show("Erro ao carregar clientes.",
                  "Error-Stop Icon",
                  MessageBoxButtons.RetryCancel,
                  MessageBoxIcon.Error);
                }
            }

        }

        private void CarregarEqui()
        {
            string query = "SELECT nome_equipamento FROM Equipamento";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboEqui.Items.Clear();
                    //Esse while aqui é como se fosse um foreach
                    while (reader.Read())
                    {
                        comboEqui.Items.Add(reader["nome_equipamento"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    RJMessageBox.Show("Erro ao carregar Equipamentos.",
                  "Error-Stop Icon",
                  MessageBoxButtons.RetryCancel,
                  MessageBoxIcon.Error);
                }
            }

        }


        private void addEquip_Click(object sender, EventArgs e)
        {
            string query = "SELECT valor_equipamento FROM Equipamento WHERE nome_equipamento = @nomeEquipamento";
            string valorEquipamento = "Não encontrado";
            string tipo = "Empreita";
            decimal quantidade = 1;
            if (comboEqui == null)
            {
                RJMessageBox.Show("Nenhum equipamento selecionado.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nomeEquipamento", comboEqui.Text);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        valorEquipamento = result != null ? result.ToString() : "Não encontrado";
                        connection.Close();
                    }
                }

                // Converter o valorEquipamento para decimal
                if (decimal.TryParse(valorEquipamento, out decimal valor))
                {
                    // Verificar se o nome do equipamento termina com "(Diária)" ou "(Hora)" ou "(Metros)"
                    if (comboEqui.Text.EndsWith("(Diária)") || comboEqui.Text.EndsWith("(Hora)") || comboEqui.Text.EndsWith("(Metros)") || comboEqui.Text.EndsWith("(Viagens)"))
                    {
                        // Tentar converter o texto de txtQuant para decimal
                        if (decimal.TryParse(txtQuant.Text, out quantidade))
                        {
                            // Multiplicar o valor pela quantidade
                            valor *= quantidade;
                            valorEquipamento = valor.ToString("F2"); // Formatar com 2 casas decimais
                        }
                        else
                        {
                            RJMessageBox.Show("Por favor, insira uma quantidade válida.");
                            return;
                        }
                    }
                }
                else
                {
                    RJMessageBox.Show("Valor do equipamento inválido.");
                    return;
                }

                if (comboEqui.Text.EndsWith("(Diária)"))
                {
                    tipo = "Diária";
                }
                else if (comboEqui.Text.EndsWith("(Hora)"))
                {
                    tipo = "Hora";
                }
                else if (comboEqui.Text.EndsWith("(Metros)"))
                {
                    tipo = "Metros";
                }
                else if (comboEqui.Text.EndsWith("(Viagens)"))
                {
                    tipo = "Viagens";
                }
                string nomeEquipamento = comboEqui.Text.Replace("(Hora)", "")
                                       .Replace("(Diária)", "")
                                       .Replace("(Empreita)", "")
                                       .Replace("(Metros)", "")
                                       .Replace("(Viagens)", "").Trim();

                gridequip.Rows.Add(nomeEquipamento, $"{tipo} ({quantidade})", valorEquipamento);

                AtualizarValorTotal();
                atualizarValorDevendo();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void ConfigurarGridEquip()
        {

            gridequip.Columns.Add("Column1", "Equipamentos");
            gridequip.Columns.Add("Column2", "Tipo (quantidade)");

            gridequip.Columns.Add("Column3", " Sub Valor");

            gridequip.Columns[0].ReadOnly = true;
            gridequip.Columns[1].ReadOnly = true;
        }

        private void gridequip_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarValorTotal();
            txtValor.Visible = true;
        }

        private void AtualizarValorTotal()
        {
            decimal valorTotal = 0;
            int colunaValor = 2;
            valorTotal = 0;


            foreach (DataGridViewRow row in gridequip.Rows)
            {
                if (!row.IsNewRow && row.Cells[colunaValor].Value != null)
                {
                    if (decimal.TryParse(row.Cells[colunaValor].Value.ToString(), out decimal valor))
                    {
                        valorTotal += valor;
                    }
                }
            }

            txtValor.Text = Convert.ToString(valorTotal);//$" {valorTotal:C}";
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridequip_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboEqui_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEqui.Text.EndsWith("(Diária)"))
            {
                lblQuant.Text = "Dias";
                txtQuant.Clear();
                txtQuant.Visible = true;
                lblQuant.Visible = true;
            }
            else if (comboEqui.Text.EndsWith("(Hora)"))
            {
                lblQuant.Text = "Horas";
                txtQuant.Clear();
                txtQuant.Visible = true;
                lblQuant.Visible = true;
            }
            else if (comboEqui.Text.EndsWith("(Metros)"))
            {
                lblQuant.Text = "Metros";
                txtQuant.Clear();
                txtQuant.Visible = true;
                lblQuant.Visible = true;
            }

            else if (comboEqui.Text.EndsWith("(Viagens)"))
            {
                lblQuant.Text = "Viagens";
                txtQuant.Clear();
                txtQuant.Visible = true;
                lblQuant.Visible = true;
            }
            else if (comboEqui.Text.EndsWith("(Empreita)"))
            {
                txtQuant.Clear();
                txtQuant.Visible = false;
                lblQuant.Visible = false;
            }
        }

        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (comboCliente == null && txtLocal == null && txtDataServ == null && gridequip == null && comboStatus == null && comboPag == null)
            {
                return;

            }
            if (gridequip.Rows.Count == 0)
            {
                RJMessageBox.Show("Não pode gerar serviço sem máquina!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GeneratePDF();

            using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();
                string queryGetClienteId = "SELECT pk_id_cliente FROM Cliente WHERE nome_cliente = @nomeCliente";
                int idCliente;
                int idServico;
                using (SqlCommand getClienteIdCommand = new SqlCommand(queryGetClienteId, conn))
                {
                    getClienteIdCommand.Parameters.AddWithValue("@nomeCliente", comboCliente.Text);
                    idCliente = (int)getClienteIdCommand.ExecuteScalar();
                }

                string insertQuery = "INSERT INTO Ordem_de_Servico (fk_id_cliente, data_servico, status_servico, forma_pagamento_servico,valor_servico, valor_pago) " +
                     "VALUES (@idcliente, @dataServico, @statusServico, @PagamentoServico, @valortotal,@valorpago);" +
                     "SELECT SCOPE_IDENTITY();";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                {
                    insertCommand.Parameters.AddWithValue("@idcliente", idCliente);
                    insertCommand.Parameters.AddWithValue("@dataServico", txtDataServ.Text);
                    insertCommand.Parameters.AddWithValue("@statusServico", comboStatus.Text);
                    insertCommand.Parameters.AddWithValue("@PagamentoServico", comboPag.Text);
                    insertCommand.Parameters.AddWithValue("@valorpago", Convert.ToDecimal(txtValorPag.Text));
                    insertCommand.Parameters.AddWithValue("@valortotal", Convert.ToDecimal(txtValor.Text));



                    idServico = Convert.ToInt32(insertCommand.ExecuteScalar());

                    foreach (DataGridViewRow row in gridequip.Rows)
                    {
                        string nomeEquipamento = row.Cells["Column1"].Value.ToString();
                        string column2Value = row.Cells["Column2"].Value.ToString();
                        decimal valorF = Convert.ToDecimal(row.Cells["Column3"].Value);
                        Match match = Regex.Match(column2Value, @"\((\d+)\)$");
                        int quantidades = Convert.ToInt32(match.Groups[1].Value);
                        string column2SemParenteses = System.Text.RegularExpressions.Regex.Replace(column2Value, @"\s*\(.*?\)", "");
                        string equipamentoFinal = nomeEquipamento + " (" + column2SemParenteses + ")";



                        string selectEquipamentoQuery = "SELECT pk_id_equipamento FROM Equipamento WHERE nome_equipamento = @nomeEquipamento";

                        using (SqlCommand selectEquipamentoCommand = new SqlCommand(selectEquipamentoQuery, conn))
                        {
                            selectEquipamentoCommand.Parameters.AddWithValue("@nomeEquipamento", equipamentoFinal);
                            object result = selectEquipamentoCommand.ExecuteScalar();
                            int idEquipamento = Convert.ToInt32(result);
                            string insertAlu = "INSERT INTO Aluguel (fk_id_ordemServico, fk_id_equipamento, quant_aluguel, valor_equipamento_aluguel) " +
                                                   "VALUES (@idServico, @idEquipamento, @quantServico, @valorServico)";

                            using (SqlCommand insertAluCommand = new SqlCommand(insertAlu, conn))
                            {
                                insertAluCommand.Parameters.AddWithValue("@idServico", idServico);
                                insertAluCommand.Parameters.AddWithValue("@idEquipamento", idEquipamento);
                                insertAluCommand.Parameters.AddWithValue("@quantServico", quantidades);
                                insertAluCommand.Parameters.AddWithValue("@valorServico", valorF);

                                insertAluCommand.ExecuteNonQuery();
                            }

                        }

                    }
                }

            }

            RJMessageBox.Show("Serviço adicionado com sucesso!", "Information Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TelaServicos obj = (TelaServicos)Application.OpenForms["TelaServicos"];
            obj.buscaServico();
            obj.graficopendendte();
            obj.SetupPieChart();
            this.Close();


        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarValorDevendo();
        }

        private void txtValorPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (string.IsNullOrWhiteSpace(txtValorPag.Text))
            {
                txtValorPag.Text = "0";
                txtValorPag.SelectionStart = txtValorPag.Text.Length;
                return;
            }

            if (decimal.TryParse(txtValorPag.Text, out decimal value))
            {
                if (value < 0)
                {
                    txtValorPag.Text = "0";
                    txtValorPag.SelectionStart = txtValorPag.Text.Length;
                }
                else if (txtValorPag.Text == "0" && txtValorPag.SelectionStart == 1)
                {
                    txtValorPag.SelectionStart = 0;
                    txtValorPag.SelectionLength = 1;
                }
            }
            else if (string.IsNullOrWhiteSpace(txtValorPag.Text))
            {
                txtValorPag.Text = "0";
                txtValorPag.SelectionStart = txtValorPag.Text.Length;
            }
            else
            {
                txtValorPag.Text = "0";
                txtValorPag.SelectionStart = txtValorPag.Text.Length;
            }
        }

        private void atualizarValorDevendo()
        {
            if (comboStatus.Text == "A Pagar" || comboStatus.Text == "Pendente")
            {
                txtValorPag.Clear();
                txtValorPag.Text = "0";
                lblValpag.Visible = true;
                txtValorPag.Visible = true;
            }
            else
            {
                lblValpag.Visible = false;
                txtValorPag.Visible = false;
                txtValorPag.Text = txtValor.Text;
            }
        }

        private void btnEcxl_Click(object sender, EventArgs e)
        {
            if (gridequip.SelectedRows.Count == 1)
            {
                var confirmResult = RJMessageBox.Show("Tem certeza que quer EXCLUIR?",
                 "Sim-Nao Button",
                   MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    gridequip.Rows.RemoveAt(gridequip.SelectedRows[0].Index);
                }
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void GeneratePDF()
        {
            var nome = comboCliente.Text;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configurar as propriedades do SaveFileDialog
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Salvar PDF";
                saveFileDialog.FileName = "Orcamento_" + nome + ".pdf";


                // Se o usuário selecionar um local e nome de arquivo válido
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;

                    // Definir caminho para a pasta "Public" no diretório de documentos

                    // Validação de campos obrigatórios
                    if (string.IsNullOrWhiteSpace(comboCliente.Text) ||
                        string.IsNullOrWhiteSpace(txtLocal.Text) ||
                        string.IsNullOrWhiteSpace(txtValor.Text))
                    {
                        RJMessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                        return;
                    }

                    try
                    {
                        // Salvar no caminho escolhido pelo usuário
                        using (Document docUsuario = new Document(PageSize.A4))
                        {
                            PdfWriter writerUsuario = PdfWriter.GetInstance(docUsuario, new FileStream(outputPath, FileMode.Create));
                            docUsuario.Open();

                            // Adicionar conteúdo ao PDF
                            AddTitle(docUsuario);
                            AddContactInfo(docUsuario);
                            AddOrcamentoInfo(docUsuario);
                            AddClienteInfo(docUsuario);
                            AddServiceTable(docUsuario);
                            AddTotal(docUsuario);
                            AddSignatureSpace(docUsuario);

                            docUsuario.Close();
                            writerUsuario.Close();
                        }


                        

                        RJMessageBox.Show("PDF gerado com sucesso!");

                        // Salvar no banco de dados se o CheckBox estiver marcado
                        SavePdfToDatabase(outputPath, $"Orcamento_{comboCliente.Text}");
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show($"Erro ao gerar o PDF: {ex.Message}");
                    }
                }
                else {
                string pastaPublica = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Sistematerra", "orcamentos");

                // Verifica e cria a pasta caso ela não exista
                if (!Directory.Exists(pastaPublica))
                {
                    Directory.CreateDirectory(pastaPublica);
                }

                // Caminho para o arquivo na pasta "orcamentos" (pasta secreta)
                string caminhoSecreto = Path.Combine(pastaPublica, "Orcamento_" + nome + ".pdf");
                    try
                    {
                        // Salvar no caminho escolhido pelo usuário
                        using (Document docUsuario = new Document(PageSize.A4))
                        {
                            PdfWriter writerUsuario = PdfWriter.GetInstance(docUsuario, new FileStream(caminhoSecreto, FileMode.Create));
                            docUsuario.Open();

                            // Adicionar conteúdo ao PDF
                            AddTitle(docUsuario);
                            AddContactInfo(docUsuario);
                            AddOrcamentoInfo(docUsuario);
                            AddClienteInfo(docUsuario);
                            AddServiceTable(docUsuario);
                            AddTotal(docUsuario);
                            AddSignatureSpace(docUsuario);

                            docUsuario.Close();
                            writerUsuario.Close();
                        }

                        // Salvar no caminho secreto (Pasta Pública)
                        using (Document docSecreto = new Document(PageSize.A4))
                        {
                            PdfWriter writerSecreto = PdfWriter.GetInstance(docSecreto, new FileStream(caminhoSecreto, FileMode.Create));
                            docSecreto.Open();

                            // Adicionar conteúdo ao PDF novamente para o caminho secreto
                            AddTitle(docSecreto);
                            AddContactInfo(docSecreto);
                            AddOrcamentoInfo(docSecreto);
                            AddClienteInfo(docSecreto);
                            AddServiceTable(docSecreto);
                            AddTotal(docSecreto);
                            AddSignatureSpace(docSecreto);

                            docSecreto.Close();
                            writerSecreto.Close();
                        }

                        

                        // Salvar no banco de dados se o CheckBox estiver marcado
                        SavePdfToDatabase(caminhoSecreto, $"Orcamento_{comboCliente.Text}");
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show($"Erro ao gerar o PDF: {ex.Message}");
                    }

                }

            }
        }




        // Método para salvar o PDF no banco de dados
        private void SavePdfToDatabase(string filePath, string nome)
        {
            byte[] fileData = File.ReadAllBytes(filePath);

            using (SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orcamentos (Nome_Orcamentos, Arquivo_Orcamentos) VALUES (@Nome, @Arquivo)", conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Arquivo", fileData);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void AddTitle(Document doc)
        {
            Paragraph title = new Paragraph("H S CASTRO TERRAPLENAGEM LTDA ME")
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);
        }

        private void AddContactInfo(Document doc)
        {
            Paragraph contactInfo = new Paragraph("Fones: 3893-5363 / 99764-3743\nE-mail: hscterraplenagem@yahoo.com.br\n")
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(contactInfo);
        }

        public void AddOrcamentoInfo(Document doc)
        {
            Random random = new Random();
            int num = random.Next(1000, 9999);

            Paragraph orcamentoInfo = new Paragraph($"ORÇAMENTO Nº {num}\nDATA: {DateTime.Now:dd/MM/yyyy}\n")
            {
                Alignment = Element.ALIGN_RIGHT
            };
            doc.Add(orcamentoInfo);
        }

        private void AddClienteInfo(Document doc)
        {
            var nome = comboCliente.Text;
            var loc = txtLocal.Text;
            var pag = comboPag.Text;
            var statu = comboStatus.Text;

            Paragraph clienteInfo = new Paragraph($"Cliente: {nome}\nEndereço: {loc}\n" +
                $"Pagamento: {pag}\n Status:{statu} \n  Periodo:{txtDataServ.Text}\n")
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(clienteInfo);
        }

        private void AddServiceTable(Document doc)
        {
            PdfPTable tabela = new PdfPTable(gridequip.Columns.Count)
            {
                WidthPercentage = 100,
                SpacingBefore = 5f
            };

            // Adicionar cabeçalho da tabela
            foreach (DataGridViewColumn coluna in gridequip.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(coluna.HeaderText))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 1f
                };
                tabela.AddCell(cell);
            }

            // Adicionar dados da tabela
            foreach (DataGridViewRow row in gridequip.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    tabela.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString() ?? ""))
                    {
                        Padding = 5f
                    });
                }
            }

            doc.Add(tabela);
        }

        private void AddTotal(Document doc)
        {
            Paragraph total = new Paragraph($"\nTOTAL: {txtValor.Text}\n")
            {
                Alignment = Element.ALIGN_RIGHT
            };
            doc.Add(total);
        }

        private void AddSignatureSpace(Document doc)
        {
            Paragraph assinatura = new Paragraph("\n\n\n______________________________\nAssinatura")
            {
                Alignment = Element.ALIGN_LEFT
            };
            doc.Add(assinatura);
        }

        private void AddServicos_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtém o texto atual
            // Obtém o texto atual
            string text = txtDataServ.Text;

            // Remove qualquer caractere não numérico
            text = new string(text.Where(char.IsDigit).ToArray());

            // Se o texto tiver mais de 8 caracteres, corta
            if (text.Length > 8)
            {
                text = text.Substring(0, 8);
            }

            // Formata o texto para o padrão dd/MM/yyyy
            if (text.Length >= 6)
            {
                text = text.Insert(4, "/");  // Inserir barra entre o mês e o ano
            }

            if (text.Length >= 4)
            {
                text = text.Insert(2, "/");  // Inserir barra entre o dia e o mês
            }

            // Atualiza o texto no TextBox
            txtDataServ.Text = text;

            // Verifica se o mês e o dia são válidos
            if (text.Length == 10)  // Quando a data está completa (dd/MM/yyyy)
            {
                string[] dateParts = text.Split('/');
                int day = int.Parse(dateParts[0]);
                int month = int.Parse(dateParts[1]);
                int year = int.Parse(dateParts[2]);

                // Verifica se o mês é válido (1 a 12)
                if (month < 1 || month > 12)
                {
                    RJMessageBox.Show("Mês inválido. Insira um valor entre 01 e 12.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDataServ.Clear();  // Limpa o conteúdo do TextBox
                    return;
                }

                // Verifica se o dia é válido para o mês
                if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)  // Meses com 30 dias
                {
                    RJMessageBox.Show("Este mês tem no máximo 30 dias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDataServ.Clear();  // Limpa o conteúdo do TextBox
                    return;
                }
                else if (month == 2)  // Fevereiro (considerando ano bissexto de forma simplificada)
                {
                    int daysInFebruary = DateTime.IsLeapYear(year) ? 29 : 28;
                    if (day > daysInFebruary)
                    {
                        RJMessageBox.Show($"Fevereiro tem no máximo {daysInFebruary} dias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDataServ.Clear();  // Limpa o conteúdo do TextBox
                        return;
                    }
                }
                else if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day > 31)  // Meses com 31 dias
                {
                    RJMessageBox.Show("Este mês tem no máximo 31 dias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDataServ.Clear();  // Limpa o conteúdo do TextBox
                    return;
                }
            }

            // Move o cursor para o final
            txtDataServ.SelectionStart = text.Length;
        }

        private void dataServ_ValueChanged(object sender, EventArgs e)
        {
            txtDataServ.Text = dataServ.Value.ToShortDateString();
        }

        private void txtValorPag_Leave(object sender, EventArgs e)
        {
            txtValorPag.Text = Regex.Replace(txtValorPag.Text, "[^0-9]", "");
        }
    }
}

