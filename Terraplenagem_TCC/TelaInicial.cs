using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terraplenagem_TCC
{
    public partial class TelaInicial : Form
    {
        TelaClientes clientes;
        TelaServicos servicos;
        TelaEquipamentos equipamentos;
        TelaConfiguracoes configuracoes;
        TelaArquivados arquivados;
        AddCliente addCliente;
        AddEquipamentos addequi;
        AddServicos addServ;
        Logo logo;
        

        bool sidebarExpanded = true;
        bool clienteCollapsed = true;
        bool equipametoCollapsed = true;
        bool serviçoCollapsed = true;
        public TelaInicial()
        {
            InitializeComponent();
            Funcoes.Mexeratela(guna2Panel1);
            Funcoes.AbrirTela(ref logo, this);

        }


        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            
        }

        private void sidebarTimer_tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    sidebarTimer.Stop();

                    pnlEquip.Width = sidebar.Width;
                    pnlCliente.Width = sidebar.Width;
                    pnlServiço.Width = sidebar.Width;
                    panel4.Width = sidebar.Width;
                    panel5.Width = sidebar.Width;
                    panel5.Size = new Size(235, 52);
                    Maquinaimg.Size = new Size(38, 38);
                    pbSistematerra.Visible = false;
       

                }//fim segundo if
            }//fim primeiro if
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    sidebarTimer.Stop();

                    pnlEquip.Width = sidebar.Width;
                    pnlCliente.Width = sidebar.Width;
                    pnlServiço.Width = sidebar.Width;
                    panel4.Width = sidebar.Width;
                    panel5.Width = sidebar.Width;
                    panel5.Size = new Size(235, 97);
                    Maquinaimg.Size = new Size(80, 80);
                    pbSistematerra.Visible = true;
     
                }
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
                Funcoes.AbrirTela(ref clientes, this);
                ClienteTimer.Start();
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirTela(ref servicos, this);
            ServTimer.Start();
        }


        private void btnEquipamentos_Click(object sender, EventArgs e)
        {
                Funcoes.AbrirTela(ref equipamentos, this);
                EquipTimer.Start();          
        }


        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirTela(ref configuracoes, this);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel5_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirTela(ref logo, this);

        }

        private void Maquinaimg_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirTela(ref logo, this);
        }

        private void pbSistematerra_Click(object sender, EventArgs e)
        {
            Funcoes.AbrirTela(ref logo, this);
        }


        private void ClienteTimer_Tick(object sender, EventArgs e)
        {
            if (clienteCollapsed)
            {
                pnlCliente.Height += 10;
                if (pnlCliente.Height == pnlCliente.MaximumSize.Height)
                {
                    clienteCollapsed = false;
                    ClienteTimer.Stop();

                }
            }else
            {
                pnlCliente.Height -= 10;
                if (pnlCliente.Height == pnlCliente.MinimumSize.Height)
                {
                    clienteCollapsed = true;
                    ClienteTimer.Stop();
                }

            }

        }

        private void btnAddcli_Click(object sender, EventArgs e)
        {
            if (clientes == null)
            {
                clientes = new TelaClientes();
                clientes.MdiParent = this;
                clientes.Dock = DockStyle.Fill;
                clientes.Show();
            }
            Funcoes.AbrirTela(ref addCliente, this);
        }
        
        private void btnArquivs_Click(object sender, EventArgs e)
        {
            if (clientes == null)
            {
                clientes = new TelaClientes();
                clientes.MdiParent = this;
                clientes.Dock = DockStyle.Fill;
                clientes.Show();
            }
            Funcoes.AbrirTela(ref arquivados, this);
        }

        private void EquipTimer_Tick(object sender, EventArgs e)
        {

            if (equipametoCollapsed)
            {
                pnlEquip.Height += 10;
                if (pnlEquip.Height == pnlEquip.MaximumSize.Height)
                {
                    equipametoCollapsed = false;
                    EquipTimer.Stop();
                }
            }
            else
            {
                pnlEquip.Height -= 10;
                if (pnlEquip.Height == pnlEquip.MinimumSize.Height)
                {
                    equipametoCollapsed = true;
                    EquipTimer.Stop();
                }
            }
        }

        private void ServTimer_Tick(object sender, EventArgs e)
        {
            if (serviçoCollapsed)
            {
                pnlServiço.Height += 10;
                if (pnlServiço.Height == pnlServiço.MaximumSize.Height)
                {
                    serviçoCollapsed = false;
                    ServTimer.Stop();
                }
            }
            else
            {
                pnlServiço.Height -= 10;
                if (pnlServiço.Height == pnlServiço.MinimumSize.Height)
                {
                    serviçoCollapsed = true;
                    ServTimer.Stop();
                }
            }
        }

        private void addEquipa_Click(object sender, EventArgs e)
        {
            if (equipamentos == null)
            {
                equipamentos = new TelaEquipamentos();
                equipamentos.MdiParent = this;
                equipamentos.Dock = DockStyle.Fill;
                equipamentos.Show();
            }
        Funcoes.AbrirTela(ref addequi, this);
        }

        private void btnAddServ_Click(object sender, EventArgs e)
        {
            if (servicos == null)
            {
                servicos = new TelaServicos();
                servicos.MdiParent = this;
                servicos.Dock = DockStyle.Fill;
                servicos.Show();
            }
        Funcoes.AbrirTela(ref addServ, this);
        }
    }//fim da classe
}
