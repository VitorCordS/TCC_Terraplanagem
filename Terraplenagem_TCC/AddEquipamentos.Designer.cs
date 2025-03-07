
namespace Terraplenagem_TCC
{
    partial class AddEquipamentos
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
            Guna.UI2.WinForms.Guna2Button guna2Button4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEquipamentos));
            this.txtValdia = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDes = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEqui = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.addBtn = new Guna.UI2.WinForms.Guna2Button();
            this.checkAlu = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkDia = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtValhora = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.checkMet = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtMet = new Guna.UI2.WinForms.Guna2TextBox();
            this.checkViag = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtViag = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Button4
            // 
            guna2Button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            guna2Button4.BackColor = System.Drawing.Color.Transparent;
            guna2Button4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(178)))), ((int)(((byte)(47)))));
            guna2Button4.BorderRadius = 10;
            guna2Button4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            guna2Button4.BorderThickness = 3;
            guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2Button4.FillColor = System.Drawing.Color.White;
            guna2Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2Button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(178)))), ((int)(((byte)(47)))));
            guna2Button4.Location = new System.Drawing.Point(489, 491);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.Size = new System.Drawing.Size(160, 36);
            guna2Button4.TabIndex = 7;
            guna2Button4.Text = "Cancelar";
            guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // txtValdia
            // 
            this.txtValdia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValdia.BackColor = System.Drawing.Color.Transparent;
            this.txtValdia.BorderColor = System.Drawing.Color.Black;
            this.txtValdia.BorderRadius = 10;
            this.txtValdia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValdia.DefaultText = "";
            this.txtValdia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValdia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValdia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValdia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValdia.Enabled = false;
            this.txtValdia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValdia.ForeColor = System.Drawing.Color.Black;
            this.txtValdia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValdia.Location = new System.Drawing.Point(489, 375);
            this.txtValdia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValdia.Name = "txtValdia";
            this.txtValdia.PasswordChar = '\0';
            this.txtValdia.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtValdia.PlaceholderText = "Valor Por Dia";
            this.txtValdia.SelectedText = "";
            this.txtValdia.Size = new System.Drawing.Size(160, 39);
            this.txtValdia.TabIndex = 3;
            this.txtValdia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtVal_KeyPress);
            this.txtValdia.Leave += new System.EventHandler(this.txtValdia_Leave);
            // 
            // txtDes
            // 
            this.txtDes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDes.BackColor = System.Drawing.Color.Transparent;
            this.txtDes.BorderColor = System.Drawing.Color.Black;
            this.txtDes.BorderRadius = 10;
            this.txtDes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDes.DefaultText = "";
            this.txtDes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.ForeColor = System.Drawing.Color.Black;
            this.txtDes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDes.Location = new System.Drawing.Point(220, 227);
            this.txtDes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.PasswordChar = '\0';
            this.txtDes.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDes.PlaceholderText = "Descrição";
            this.txtDes.SelectedText = "";
            this.txtDes.Size = new System.Drawing.Size(608, 102);
            this.txtDes.TabIndex = 2;
            // 
            // txtEqui
            // 
            this.txtEqui.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEqui.BackColor = System.Drawing.Color.Transparent;
            this.txtEqui.BorderColor = System.Drawing.Color.Black;
            this.txtEqui.BorderRadius = 10;
            this.txtEqui.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEqui.DefaultText = "";
            this.txtEqui.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEqui.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEqui.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEqui.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEqui.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEqui.ForeColor = System.Drawing.Color.Black;
            this.txtEqui.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEqui.Location = new System.Drawing.Point(220, 173);
            this.txtEqui.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEqui.Name = "txtEqui";
            this.txtEqui.PasswordChar = '\0';
            this.txtEqui.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtEqui.PlaceholderText = "Nome";
            this.txtEqui.SelectedText = "";
            this.txtEqui.Size = new System.Drawing.Size(608, 36);
            this.txtEqui.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(341, 60);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(355, 44);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Adicionar Equipamento";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(220, 340);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(58, 22);
            this.guna2HtmlLabel6.TabIndex = 16;
            this.guna2HtmlLabel6.Text = "Tipo:";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.BorderRadius = 10;
            this.addBtn.BorderThickness = 1;
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(127)))), ((int)(((byte)(21)))));
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(668, 491);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(160, 36);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Adicionar";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // checkAlu
            // 
            this.checkAlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkAlu.AutoSize = true;
            this.checkAlu.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkAlu.CheckedState.BorderRadius = 0;
            this.checkAlu.CheckedState.BorderThickness = 0;
            this.checkAlu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkAlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkAlu.Location = new System.Drawing.Point(220, 397);
            this.checkAlu.Name = "checkAlu";
            this.checkAlu.Size = new System.Drawing.Size(49, 17);
            this.checkAlu.TabIndex = 6;
            this.checkAlu.Text = "Hora";
            this.checkAlu.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.checkAlu.UncheckedState.BorderRadius = 1;
            this.checkAlu.UncheckedState.BorderThickness = 1;
            this.checkAlu.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkAlu.CheckedChanged += new System.EventHandler(this.checkAlu_CheckedChanged);
            // 
            // checkDia
            // 
            this.checkDia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkDia.AutoSize = true;
            this.checkDia.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkDia.CheckedState.BorderRadius = 0;
            this.checkDia.CheckedState.BorderThickness = 0;
            this.checkDia.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkDia.Location = new System.Drawing.Point(220, 368);
            this.checkDia.Name = "checkDia";
            this.checkDia.Size = new System.Drawing.Size(53, 17);
            this.checkDia.TabIndex = 5;
            this.checkDia.Text = "Diaria";
            this.checkDia.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.checkDia.UncheckedState.BorderRadius = 1;
            this.checkDia.UncheckedState.BorderThickness = 1;
            this.checkDia.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkDia.CheckedChanged += new System.EventHandler(this.checkDia_CheckedChanged);
            // 
            // txtValhora
            // 
            this.txtValhora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValhora.BackColor = System.Drawing.Color.Transparent;
            this.txtValhora.BorderColor = System.Drawing.Color.Black;
            this.txtValhora.BorderRadius = 10;
            this.txtValhora.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValhora.DefaultText = "";
            this.txtValhora.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValhora.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValhora.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValhora.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValhora.Enabled = false;
            this.txtValhora.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValhora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValhora.ForeColor = System.Drawing.Color.Black;
            this.txtValhora.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValhora.Location = new System.Drawing.Point(489, 422);
            this.txtValhora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtValhora.Name = "txtValhora";
            this.txtValhora.PasswordChar = '\0';
            this.txtValhora.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtValhora.PlaceholderText = "Valor Por Hora";
            this.txtValhora.SelectedText = "";
            this.txtValhora.Size = new System.Drawing.Size(160, 39);
            this.txtValhora.TabIndex = 4;
            this.txtValhora.Leave += new System.EventHandler(this.txtValhora_Leave);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(489, 346);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(58, 22);
            this.guna2HtmlLabel2.TabIndex = 30;
            this.guna2HtmlLabel2.Text = "Valor:";
            // 
            // checkMet
            // 
            this.checkMet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkMet.AutoSize = true;
            this.checkMet.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkMet.CheckedState.BorderRadius = 0;
            this.checkMet.CheckedState.BorderThickness = 0;
            this.checkMet.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkMet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkMet.Location = new System.Drawing.Point(279, 368);
            this.checkMet.Name = "checkMet";
            this.checkMet.Size = new System.Drawing.Size(53, 17);
            this.checkMet.TabIndex = 31;
            this.checkMet.Text = "Metro";
            this.checkMet.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.checkMet.UncheckedState.BorderRadius = 1;
            this.checkMet.UncheckedState.BorderThickness = 1;
            this.checkMet.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkMet.CheckedChanged += new System.EventHandler(this.checkMet_CheckedChanged);
            // 
            // txtMet
            // 
            this.txtMet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMet.BackColor = System.Drawing.Color.Transparent;
            this.txtMet.BorderColor = System.Drawing.Color.Black;
            this.txtMet.BorderRadius = 10;
            this.txtMet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMet.DefaultText = "";
            this.txtMet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMet.Enabled = false;
            this.txtMet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtMet.ForeColor = System.Drawing.Color.Black;
            this.txtMet.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMet.Location = new System.Drawing.Point(668, 375);
            this.txtMet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMet.Name = "txtMet";
            this.txtMet.PasswordChar = '\0';
            this.txtMet.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtMet.PlaceholderText = "Valor Por Metro";
            this.txtMet.SelectedText = "";
            this.txtMet.Size = new System.Drawing.Size(160, 39);
            this.txtMet.TabIndex = 32;
            this.txtMet.TextChanged += new System.EventHandler(this.txtMet_TextChanged);
            this.txtMet.Leave += new System.EventHandler(this.txtMet_Leave);
            // 
            // checkViag
            // 
            this.checkViag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkViag.AutoSize = true;
            this.checkViag.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkViag.CheckedState.BorderRadius = 0;
            this.checkViag.CheckedState.BorderThickness = 0;
            this.checkViag.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkViag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkViag.Location = new System.Drawing.Point(279, 397);
            this.checkViag.Name = "checkViag";
            this.checkViag.Size = new System.Drawing.Size(64, 17);
            this.checkViag.TabIndex = 33;
            this.checkViag.Text = "Viagens";
            this.checkViag.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.checkViag.UncheckedState.BorderRadius = 1;
            this.checkViag.UncheckedState.BorderThickness = 1;
            this.checkViag.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkViag.CheckedChanged += new System.EventHandler(this.checkViag_CheckedChanged);
            // 
            // txtViag
            // 
            this.txtViag.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtViag.BackColor = System.Drawing.Color.Transparent;
            this.txtViag.BorderColor = System.Drawing.Color.Black;
            this.txtViag.BorderRadius = 10;
            this.txtViag.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtViag.DefaultText = "";
            this.txtViag.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtViag.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtViag.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtViag.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtViag.Enabled = false;
            this.txtViag.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtViag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtViag.ForeColor = System.Drawing.Color.Black;
            this.txtViag.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtViag.Location = new System.Drawing.Point(668, 422);
            this.txtViag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtViag.Name = "txtViag";
            this.txtViag.PasswordChar = '\0';
            this.txtViag.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtViag.PlaceholderText = "Valor Por Viagens";
            this.txtViag.SelectedText = "";
            this.txtViag.Size = new System.Drawing.Size(160, 39);
            this.txtViag.TabIndex = 34;
            this.txtViag.Leave += new System.EventHandler(this.txtViag_Leave);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAtualizar.BorderColor = System.Drawing.Color.Transparent;
            this.btnAtualizar.BorderRadius = 10;
            this.btnAtualizar.BorderThickness = 1;
            this.btnAtualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAtualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAtualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAtualizar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(127)))), ((int)(((byte)(21)))));
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(668, 491);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(160, 36);
            this.btnAtualizar.TabIndex = 35;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Visible = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // AddEquipamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 682);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtViag);
            this.Controls.Add(this.checkViag);
            this.Controls.Add(this.txtMet);
            this.Controls.Add(this.checkMet);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.txtValhora);
            this.Controls.Add(this.checkAlu);
            this.Controls.Add(this.checkDia);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(guna2Button4);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.txtValdia);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.txtEqui);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEquipamentos";
            this.Text = "-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtValdia;
        private Guna.UI2.WinForms.Guna2TextBox txtDes;
        private Guna.UI2.WinForms.Guna2TextBox txtEqui;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Button addBtn;
        private Guna.UI2.WinForms.Guna2CheckBox checkAlu;
        private Guna.UI2.WinForms.Guna2CheckBox checkDia;
        private Guna.UI2.WinForms.Guna2TextBox txtValhora;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2CheckBox checkMet;
        private Guna.UI2.WinForms.Guna2TextBox txtMet;
        private Guna.UI2.WinForms.Guna2CheckBox checkViag;
        private Guna.UI2.WinForms.Guna2TextBox txtViag;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
    }
}