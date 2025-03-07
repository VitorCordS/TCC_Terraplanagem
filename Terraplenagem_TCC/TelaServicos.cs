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

namespace Terraplenagem_TCC
{

    public partial class TelaServicos : Form
    {
        AddServicos addser;
        InfoServ infos;
        int quantpen;
        int quantfin;
        int quantdeve;
        int sexo;
        decimal valTotaldeve;
        decimal valTotalfat;
        public TelaServicos()
        {
            InitializeComponent();
            buscaServico();
            graficopendendte();
            SetupPieChart();
            Configurargridview();
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            PieChart2.Visible = false;
            PieChart1.Visible = false;
            rjButton2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addser = new AddServicos();
            addser.MdiParent = this.MdiParent;
            addser.Dock = DockStyle.Fill;
            addser.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rjRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            filtrofin();
        }

        private void atualizardados()
        {
            quantdeve = 0;
            valTotalfat = 0;
            valTotaldeve = 0;
            quantpen = 0;
            quantfin = 0;
            sexo = 0;
            foreach (DataGridViewRow row in gridserv.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Pendente")
                {
                    quantpen += 1;
                    decimal valordeve = Convert.ToDecimal(row.Cells["Devendo"].Value);
                    valTotaldeve += valordeve;
                }
                else if (row.Cells["Status"].Value.ToString() == "Finalizado")
                {
                    quantfin += 1;
                    decimal fatura = Convert.ToDecimal(row.Cells["Total"].Value);
                    valTotalfat += fatura;
                }
                else
                {
                    sexo += 1;
                    decimal fatura = Convert.ToDecimal(row.Cells["Pago"].Value);
                    valTotalfat += fatura;
                    decimal valordeve = Convert.ToDecimal(row.Cells["Devendo"].Value);
                    valTotaldeve += valordeve;
                }
            }
            lblFat.Text = "R$ " + valTotalfat.ToString();
            lblPen.Text = quantpen.ToString();
            lblFin.Text = quantfin.ToString();
            lblDeve.Text = "R$ " + valTotaldeve.ToString();

        }


        public void buscaServico()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT os.pk_id_servico AS ID, 
                      c.nome_cliente AS Cliente, 
                      CONVERT(VARCHAR(10), os.data_servico, 103) AS Data,  
                      os.status_servico AS Status, 
                      os.forma_pagamento_servico AS Pagamento,
                      os.valor_servico AS Total,
                      os.valor_pago as Pago,
                      os.valor_deve as Devendo
                       FROM Ordem_de_Servico os
                       JOIN Cliente c ON os.fk_id_cliente = c.pk_id_cliente";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridserv.DataSource = dt;
                quantdeve += 1;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
            atualizardados();
        }

        public void filtroanda()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT os.pk_id_servico AS ID, 
                      c.nome_cliente AS Cliente, 
                      CONVERT(VARCHAR(10), os.data_servico, 103) AS Data,  
                      os.status_servico AS Status, 
                      os.forma_pagamento_servico AS Pagamento,
                      os.valor_servico AS Total,
                      os.valor_pago as Pago,
                      os.valor_deve as Devendo
                       FROM Ordem_de_Servico os
                       JOIN Cliente c ON os.fk_id_cliente = c.pk_id_cliente WHERE os.status_servico = 'Pendente'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridserv.DataSource = dt;

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

        public void filtrodeve()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT os.pk_id_servico AS ID, 
                      c.nome_cliente AS Cliente, 
                      CONVERT(VARCHAR(10), os.data_servico, 103) AS Data,  
                      os.status_servico AS Status, 
                      os.forma_pagamento_servico AS Pagamento,
                      os.valor_servico AS Total,
                      os.valor_pago as Pago,
                      os.valor_deve as Devendo
                       FROM Ordem_de_Servico os
                       JOIN Cliente c ON os.fk_id_cliente = c.pk_id_cliente WHERE os.status_servico = 'A Pagar'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridserv.DataSource = dt;

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

        public void filtrofin()
        {

            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT os.pk_id_servico AS ID, 
                      c.nome_cliente AS Cliente, 
                      CONVERT(VARCHAR(10), os.data_servico, 103) AS Data,  
                      os.status_servico AS Status, 
                      os.forma_pagamento_servico AS Pagamento,
                      os.valor_servico AS Total,
                      os.valor_pago as Pago,
                      os.valor_deve as Devendo
                       FROM Ordem_de_Servico os
                       JOIN Cliente c ON os.fk_id_cliente = c.pk_id_cliente WHERE os.status_servico = 'Finalizado'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridserv.DataSource = dt;

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

        private void rjRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            filtroanda();
        }

        private void rjRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            filtrodeve();
        }

        private void btnLimp_Click(object sender, EventArgs e)
        {
            rjRadioButton6.Checked = false;
            rjRadioButton7.Checked = false;
            rjRadioButton8.Checked = false;
            DateTime primeiroDiaDoAno = new DateTime(DateTime.Now.Year, 1, 1);
            gtpInicio.Value = primeiroDiaDoAno;
            gtpFin.Value = primeiroDiaDoAno;

            buscaServico();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DateTime inicio = gtpInicio.Value.Date;
            DateTime finn = gtpFin.Value.Date;


            string inicioFormatado = inicio.ToString("ddMMyyyy");
            string finnFormatado = finn.ToString("ddMMyyyy");

            if (finnFormatado != inicioFormatado && inicio < finn)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (.pdf)|.pdf|All files (.)|.";
                saveFileDialog.Title = "Salvar arquivo PDF";
                saveFileDialog.FileName = "relatorio_servicos_" + inicioFormatado + "_" + finnFormatado + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;
                    GerarRelatorioPDF(saveFileDialog.FileName);
                }
            }
            else
            {
                var dia = DateTime.Now.Date;
                string diaDoSistema = dia.ToString("ddMMyyyy");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (.pdf)|.pdf|All files (.)|.";
                saveFileDialog.Title = "Salvar arquivo PDF";
                saveFileDialog.FileName = "relatorio_servicos_" + diaDoSistema + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GerarRelatorioPDF(saveFileDialog.FileName);
                }
            }

        }
        private void GerarRelatorioPDF(string caminhoArquivo)
        {
            DateTime inicio = gtpInicio.Value.Date;
            DateTime finn = gtpFin.Value.Date;
            var dia = DateTime.Now.Date;

            string diaDoSistema = dia.ToString("dd/MM/yyyy");
            string inicioFormatado = inicio.ToString("dd/MM/yyyy");
            string finnFormatado = finn.ToString("dd/MM/yyyy");
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = null;

            try
            {
                writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                if (finnFormatado != inicioFormatado && inicio < finn)
                {
                    AddHeader(doc, "Relatório de Serviços - " + inicioFormatado + " - " + finnFormatado);
                }
                else
                {
                    AddHeader(doc, "Relatório de Serviços - " + diaDoSistema);
                }
            
                PdfPTable tabela = new PdfPTable(gridserv.Columns.Count);
                tabela.WidthPercentage = 110;
                tabela.SpacingBefore = 5f;
                iTextSharp.text.Font pequeno = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (DataGridViewColumn coluna in gridserv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(coluna.HeaderText, pequeno));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 1f;
                    
                    tabela.AddCell(cell);
                }

                foreach (DataGridViewRow row in gridserv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tabela.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", pequeno)) { Padding = 5f });
                    }
                }

                doc.Add(tabela);
                RJMessageBox.Show("Relatório gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Usando o parâmetro caminhoArquivo ao invés de outputPath

            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Erro ao gerar relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
            SavePdfToDatabase(caminhoArquivo, $"Relatorio_{DateTime.Now:yyyyMMdd}");
        }
        static void AddHeader(Document doc, string title)
        {
            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15);
            Paragraph header = new Paragraph(title, headerFont);
            header.Alignment = Element.ALIGN_CENTER;
            doc.Add(header);
            doc.Add(new Paragraph(" "));

            LineSeparator line = new LineSeparator(5f, 110f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
            doc.Add(new Chunk(line));
            doc.Add(new Paragraph(" "));
        }

        private void SavePdfToDatabase(string filePath, string nome)
        {
            var dia = DateTime.Now.Date;
            string diaDoSistema = dia.ToString("dd/MM/yyyy");
            byte[] fileData = File.ReadAllBytes(filePath);

            using (SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Registros (Nome_Registros, Arquivo_Registros, Hora_Registros ) VALUES (@Nome, @Arquivo, @data)", conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Arquivo", fileData);
                    cmd.Parameters.AddWithValue("@data", diaDoSistema);
                    cmd.ExecuteNonQuery();
                }
            }
        }




        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime inicio = gtpInicio.Value.Date;
            DateTime finn = gtpFin.Value.Date;


            var inicioFormatado = inicio.ToString("ddMMyyyy");
            var finnFormatado = finn.ToString("ddMMyyyy");
            if (finnFormatado != inicioFormatado && inicio < finn)
            {
                filtrodata();
            }
            else
            {
                RJMessageBox.Show("Erro ao filtrar data", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void filtrodata()
        {
            DateTime inicio;
            DateTime finn;

            inicio = gtpInicio.Value;
            finn = gtpFin.Value;



            SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true");
            try
            {
                con.Open();
                string sql = @"SELECT os.pk_id_servico AS ID, 
                      c.nome_cliente AS Cliente, 
                      CONVERT(VARCHAR(10), os.data_servico, 103) AS Data,  
                      os.status_servico AS Status, 
                      os.forma_pagamento_servico AS Pagamento,
                      os.valor_servico AS Total,
                      os.valor_pago as Pago,
                      os.valor_deve as Devendo
                       FROM Ordem_de_Servico os
                       JOIN Cliente c ON os.fk_id_cliente = c.pk_id_cliente WHERE os.data_servico between '" + inicio + "' AND '" + finn + "'";
                SqlCommand cmd = new SqlCommand(sql, con);



                SqlDataReader dados = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dados);
                gridserv.DataSource = dt;

            }
            catch (Exception erro)
            {
                RJMessageBox.Show("Erro: " + erro.Message);
            }
            finally
            {
                con.Close();
            }
            atualizardados();

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (gridserv.SelectedRows.Count == 1)
            {
                int servID = Convert.ToInt32(gridserv.SelectedRows[0].Cells["ID"].Value);
                infos = new InfoServ(servID);
                infos.MdiParent = this.MdiParent;
                infos.Dock = DockStyle.Fill;
                infos.Show();
            }
            else
            {
                RJMessageBox.Show("Selecione um Serviço para editar.", "Error-Stop Icon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para buscar dados do cliente pelo ID
        private DataTable GetClienteData(int servID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Cliente WHERE pk_id_cliente = @Id";

            using (SqlConnection conn = new SqlConnection("data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", servID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }




        public void graficopendendte()
        {
            
            PieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Em Andamento", 
                    Values = new ChartValues<double> { Convert.ToDouble(quantpen) }, 
                    DataLabels = true 
                , Fill = new SolidColorBrush(MediaColor.FromArgb(255, 116, 45, 0))},
                new PieSeries
                {
                    Title = "Finalizados",
                    Values = new ChartValues<double> { Convert.ToDouble(quantfin) },
                    DataLabels = true,
                    Fill = new SolidColorBrush(MediaColor.FromArgb(255, 213, 127, 21))
                },
                new PieSeries
                {
                    Title = "A Pagar",
                    Values = new ChartValues<double> { Convert.ToDouble(sexo) }, 
                    DataLabels = true,
                    Fill = new SolidColorBrush(MediaColor.FromArgb(255, 247, 178, 47))
                }
               
            };
            PieChart1.LegendLocation = LegendLocation.Right;

        }
        public void SetupPieChart()
        {
            PieChart2.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "A Receber",
            Values = new ChartValues<double> { Convert.ToDouble(valTotaldeve) },
            DataLabels = true,
            Fill = new SolidColorBrush(MediaColor.FromArgb(255, 247, 178, 47)) 
        },
        new PieSeries
        {
            Title = "Faturamento",
            Values = new ChartValues<double> { Convert.ToDouble(valTotalfat) },
            DataLabels = true,
            Fill = new SolidColorBrush(MediaColor.FromArgb(255, 213, 127, 21)) 
        }
    };

            PieChart2.LegendLocation = LegendLocation.Right;
        }

    


        private void rjButton1_Click(object sender, EventArgs e)
        {


            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = true;
            PieChart2.Visible = true;
            PieChart1.Visible = true;
            rjButton2.Visible = true;
            rjButton1.Visible = false;
            lblPen.Visible = false;
            guna2HtmlLabel2.Visible = false;
            guna2ContainerControl1.Visible = false;
            lblFin.Visible = false;
            guna2HtmlLabel5.Visible = false;
            guna2PictureBox2.Visible = false;
            guna2ContainerControl2.Visible = false;
            guna2ContainerControl3.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2HtmlLabel7.Visible = false;
            lblDeve.Visible = false;
            guna2ContainerControl4.Visible = false;
            lblFat.Visible = false;
            guna2HtmlLabel9.Visible = false;
            guna2PictureBox4.Visible = false;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {


            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            PieChart2.Visible = false;
            PieChart1.Visible = false;
            rjButton1.Visible = true;
            rjButton2.Visible = false;
            lblPen.Visible = true;
            guna2HtmlLabel2.Visible = true;
            guna2ContainerControl1.Visible = true;
            lblFin.Visible = true;
            guna2HtmlLabel5.Visible = true;
            guna2PictureBox2.Visible = true;
            guna2ContainerControl2.Visible = true;
            guna2ContainerControl3.Visible = true;
            guna2PictureBox3.Visible = true;
            guna2HtmlLabel7.Visible = true;
            lblDeve.Visible = true;
            guna2ContainerControl4.Visible = true;
            lblFat.Visible = true;
            guna2HtmlLabel9.Visible = true;
            guna2PictureBox4.Visible = true;
        }

        private void gridserv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //PORRA DO CARALHO DO INFERNO FILHO DUMA PUTA
            if (e.ColumnIndex == 6)
            {
                try
                {
                    decimal novoValorPago = Convert.ToDecimal(gridserv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    int idServico = Convert.ToInt32(gridserv.Rows[e.RowIndex].Cells[0].Value);
                    decimal valorTotal = Convert.ToDecimal(gridserv.Rows[e.RowIndex].Cells[5].Value);
                    string connectionString = @"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true";
                    string query = "UPDATE Ordem_de_Servico SET valor_pago = @ValorPago";

                    if (novoValorPago == valorTotal)
                    {
                        query += ", status_servico = 'Finalizado'";
                    }

                    query += " WHERE pk_id_servico = @IdServico";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ValorPago", novoValorPago);
                            command.Parameters.AddWithValue("@IdServico", idServico);
                            command.ExecuteNonQuery();
                        }
                    }

                    buscaServico();
                    atualizardados();
                    graficopendendte();
                    SetupPieChart();
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Erro ao atualizar o valor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Configurargridview()
        {
            // Definir todas as colunas como somente leitura, exceto a do Valor Pago.
            gridserv.Columns[0].ReadOnly = true; // ID
            gridserv.Columns[1].ReadOnly = true; // Cliente
            gridserv.Columns[2].ReadOnly = true; // Data
            gridserv.Columns[3].ReadOnly = true; // Status
            gridserv.Columns[4].ReadOnly = true; // Pagamento
            gridserv.Columns[5].ReadOnly = true; // Total (Valor Total)
            gridserv.Columns[6].ReadOnly = false; // Pago (Valor Pago) - Permitido editar
            gridserv.Columns[7].ReadOnly = true; // Devendo
        }


        private void gridserv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 6) // Coluna Pago (Valor Pago)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal novoValorPago))
                {
                    e.Cancel = true;
                    RJMessageBox.Show("Por favor, insira um valor numérico válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal valorTotal = Convert.ToDecimal(gridserv.Rows[e.RowIndex].Cells[5].Value); // Valor Total

                if (novoValorPago > valorTotal)
                {
                    e.Cancel = true;
                    RJMessageBox.Show("O valor pago não pode ser maior que o valor total.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridserv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6) // Coluna Pago (Valor Pago)
            {
                string status = gridserv.Rows[e.RowIndex].Cells[3].Value?.ToString();
                if (status == "Finalizado")
                {
                    e.Cancel = true;
                    RJMessageBox.Show("Não é possível editar o valor pago de um serviço finalizado.", "Edição não permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}   
