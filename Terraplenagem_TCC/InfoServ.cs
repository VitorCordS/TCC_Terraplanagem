using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terraplenagem_TCC
{
    public partial class InfoServ : Form
    {
        private int? idServ;
        public InfoServ()
        {
            InitializeComponent();
            //ConfigurarGridIServ();
        }

        public InfoServ(int ServID) : this()
        {
            this.idServ = ServID;
            CarregarDadosServico(ServID);
            CarregarDadosCliente(ServID);
            CarregarDadosEqui(ServID);
            lblTitulo.Text = "Serviço #" + ServID;
        }

        private void CarregarDadosServico(int id)
        {
            using (SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT data_servico,status_servico,forma_pagamento_servico,valor_servico FROM Ordem_de_Servico WHERE pk_id_servico = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                DateTime dataServico = reader.GetDateTime(0);
                                string statusServico = reader.GetString(1);
                                string formaPagamento = reader.GetString(2);
                                decimal valorServico = reader.GetDecimal(3);

                                lblData.Text = dataServico.ToString("dd/MM/yyyy");
                                lblStatus.Text = statusServico;
                                lblPag.Text = formaPagamento;
                                lblValTotal.Text = "R$ " + valorServico.ToString();
                            }
                        }
                    }
                }
                catch (Exception erro)
                {
                    RJMessageBox.Show("Erro ao carregar os dados do Serviço: " + erro.Message);
                }
            }
        }

        private void CarregarDadosCliente(int id)
        {
            using (SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                con.Open();
                string queryGetClienteId = "SELECT fk_id_cliente FROM Ordem_de_Servico WHERE pk_id_servico = @id";
                int idCliente;

                using (SqlCommand getClienteIdCommand = new SqlCommand(queryGetClienteId, con))
                {
                    getClienteIdCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    idCliente = (int)getClienteIdCommand.ExecuteScalar();
                }

                try
                {
                    string sql = "SELECT nome_cliente, documento_cliente, tel_cliente, endereco_cliente FROM Cliente WHERE pk_id_cliente = @idcliente";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@idcliente", SqlDbType.Int).Value = idCliente;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string docCliente = null;
                                decimal telCliente = 0;
                                string enderecoCliente;
                                string nomeCliente = reader.GetString(0);
                                if (!reader.IsDBNull(1))
                                {
                                    docCliente = reader.GetString(1);
                                }
                                if (!reader.IsDBNull(2))
                                {
                                    telCliente = reader.GetDecimal(2);
                                }
                                
                                lblCliente.Text = nomeCliente;
                                lblDoc.Text = docCliente;
                                lblTel.Text = telCliente.ToString();
                                /* lblRua.Text = Rua;
                                 lblNum.Text = numCasa;
                                 lblBairro.Text = bairro;
                                 lblCidade.Text = cidade;
                                 lblUF.Text = uf;
                                 lblCep.Text = cep;*/
                            }
                        }
                    }
                }
                catch (SqlException erro)
                {
                    RJMessageBox.Show("Erro ao carregar os dados do Cliente: " + erro.Message);
                }
            }
        }



        private void CarregarDadosEqui(int id)
        {
            using (SqlConnection con = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                con.Open();

                try
                {
                    string sql = @"
        SELECT e.nome_equipamento, e.tipo_equipamento, a.quant_aluguel, a.valor_equipamento_aluguel 
        FROM Aluguel a
        INNER JOIN Equipamento e ON a.fk_id_equipamento = e.pk_id_equipamento
        WHERE a.fk_id_ordemServico = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Cria o DataTable para armazenar os dados
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Equipamento", typeof(string));
                            dt.Columns.Add("Tipo", typeof(string));
                            dt.Columns.Add("Quantidade", typeof(decimal));
                            dt.Columns.Add("Valor", typeof(decimal));

                            // Adiciona os dados retornados no DataTable
                            while (reader.Read())
                            {
                                dt.Rows.Add(
                                    reader["nome_equipamento"].ToString().Replace("(Hora)", "")
                                       .Replace("(Diária)", "")
                                       .Replace("(Empreita)", "")
                                       .Replace("(Metros)", "").Trim(),
                                    reader["tipo_equipamento"].ToString(),
                                    (decimal)reader["quant_aluguel"],
                                    (decimal)reader["valor_equipamento_aluguel"]
                                );
                            }

                            // Define o DataSource da GridView como o DataTable
                            gridIServ.DataSource = dt;

                        }
                    }
                }
                catch (SqlException erro)
                {
                    RJMessageBox.Show("Erro ao carregar os dados dos equipamentos: " + erro.Message);
                }
            }
        }

        private void btnInfvoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOcamenti_Click(object sender, EventArgs e)
        {
            string nomeOrcamento = lblCliente.Text;
            var nome = nomeOrcamento;

            if (!string.IsNullOrWhiteSpace(nomeOrcamento))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Salvar PDF";
                    saveFileDialog.FileName = $"Orcamento_{nomeOrcamento}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveFileDialog.FileName;
                        DownloadPdfFromDatabaseByName(nomeOrcamento, savePath);
                    }
                }
            }
            else
            {
                RJMessageBox.Show("Por favor, insira o nome do orçamento.");
            }
        }
            byte[] fileData;
            private void DownloadPdfFromDatabaseByName(string nome, string savePath)
            {
                using (SqlConnection conn = new SqlConnection(@"data source=localhost;initial catalog=SISTEMA_TERRA;trusted_connection=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Arquivo_Orcamentos FROM Orcamentos WHERE Nome_Orcamentos = @Nome", conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", "Orcamento_" + nome);
                    fileData = cmd.ExecuteScalar() as byte[];
                }
            }

            if (fileData != null)
            {
                File.WriteAllBytes(savePath, fileData);
                RJMessageBox.Show("PDF baixado com sucesso!");
            }
            else
            {
                RJMessageBox.Show("Arquivo não encontrado.");
            }

        }
    }
}
