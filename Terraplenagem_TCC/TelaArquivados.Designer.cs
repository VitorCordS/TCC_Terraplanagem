
namespace Terraplenagem_TCC
{
    partial class TelaArquivados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.gridviewArquivado = new System.Windows.Forms.DataGridView();
            this.btnAtivar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnVoltarArquiv = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewArquivado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(178)))), ((int)(((byte)(47)))));
            this.btnExcluir.BorderRadius = 8;
            this.btnExcluir.BorderThickness = 3;
            this.btnExcluir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcluir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExcluir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcluir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExcluir.FillColor = System.Drawing.Color.Transparent;
            this.btnExcluir.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(178)))), ((int)(((byte)(47)))));
            this.btnExcluir.Location = new System.Drawing.Point(699, 595);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(117, 37);
            this.btnExcluir.TabIndex = 50;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ContainerControl1.Controls.Add(this.gridviewArquivado);
            this.guna2ContainerControl1.Location = new System.Drawing.Point(94, 119);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(845, 471);
            this.guna2ContainerControl1.TabIndex = 49;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // gridviewArquivado
            // 
            this.gridviewArquivado.AllowUserToAddRows = false;
            this.gridviewArquivado.AllowUserToDeleteRows = false;
            this.gridviewArquivado.AllowUserToResizeColumns = false;
            this.gridviewArquivado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridviewArquivado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridviewArquivado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridviewArquivado.BackgroundColor = System.Drawing.Color.White;
            this.gridviewArquivado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridviewArquivado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridviewArquivado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridviewArquivado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridviewArquivado.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridviewArquivado.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridviewArquivado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridviewArquivado.EnableHeadersVisualStyles = false;
            this.gridviewArquivado.GridColor = System.Drawing.Color.PeachPuff;
            this.gridviewArquivado.Location = new System.Drawing.Point(0, 0);
            this.gridviewArquivado.MultiSelect = false;
            this.gridviewArquivado.Name = "gridviewArquivado";
            this.gridviewArquivado.ReadOnly = true;
            this.gridviewArquivado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridviewArquivado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridviewArquivado.RowHeadersVisible = false;
            this.gridviewArquivado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewArquivado.Size = new System.Drawing.Size(845, 471);
            this.gridviewArquivado.TabIndex = 0;
            this.gridviewArquivado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewArquivado_CellContentClick);
            // 
            // btnAtivar
            // 
            this.btnAtivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivar.BackColor = System.Drawing.Color.Transparent;
            this.btnAtivar.BorderColor = System.Drawing.Color.Transparent;
            this.btnAtivar.BorderRadius = 8;
            this.btnAtivar.BorderThickness = 1;
            this.btnAtivar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAtivar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAtivar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAtivar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAtivar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(127)))), ((int)(((byte)(21)))));
            this.btnAtivar.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivar.ForeColor = System.Drawing.Color.White;
            this.btnAtivar.IndicateFocus = true;
            this.btnAtivar.Location = new System.Drawing.Point(822, 596);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(117, 36);
            this.btnAtivar.TabIndex = 48;
            this.btnAtivar.Text = "Desarquivar";
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(341, 40);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(305, 47);
            this.guna2HtmlLabel7.TabIndex = 46;
            this.guna2HtmlLabel7.Text = "Clientes Arquivados";
            // 
            // btnVoltarArquiv
            // 
            this.btnVoltarArquiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoltarArquiv.BackColor = System.Drawing.Color.Transparent;
            this.btnVoltarArquiv.BorderColor = System.Drawing.Color.Transparent;
            this.btnVoltarArquiv.BorderRadius = 8;
            this.btnVoltarArquiv.BorderThickness = 1;
            this.btnVoltarArquiv.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVoltarArquiv.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVoltarArquiv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVoltarArquiv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVoltarArquiv.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(127)))), ((int)(((byte)(21)))));
            this.btnVoltarArquiv.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarArquiv.ForeColor = System.Drawing.Color.White;
            this.btnVoltarArquiv.IndicateFocus = true;
            this.btnVoltarArquiv.Location = new System.Drawing.Point(94, 596);
            this.btnVoltarArquiv.Name = "btnVoltarArquiv";
            this.btnVoltarArquiv.Size = new System.Drawing.Size(117, 36);
            this.btnVoltarArquiv.TabIndex = 51;
            this.btnVoltarArquiv.Text = "Voltar";
            this.btnVoltarArquiv.Click += new System.EventHandler(this.btnVoltarArquiv_Click);
            // 
            // TelaArquivados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 682);
            this.Controls.Add(this.btnVoltarArquiv);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaArquivados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaArquivados";
            this.guna2ContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewArquivado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private System.Windows.Forms.DataGridView gridviewArquivado;
        private Guna.UI2.WinForms.Guna2Button btnAtivar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btnVoltarArquiv;
    }
}