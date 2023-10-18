namespace WinFormsEmpleados
{
    partial class FrmCocinero
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
            groupBox1 = new GroupBox();
            cbPescados = new CheckBox();
            cbGourmet = new CheckBox();
            cbPastas = new CheckBox();
            cbParrilla = new CheckBox();
            cbVegana = new CheckBox();
            cbReposteria = new CheckBox();
            lblCertificacion = new Label();
            txtCertificacion = new TextBox();
            grpTurnoDeTrabajo.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.TabIndex = 14;
            btnAceptar.Click += btnAceptar_ClickCocinero;
            // 
            // btnCancelar
            // 
            btnCancelar.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.TabIndex = 0;
            // 
            // txtLegajo
            // 
            txtLegajo.TabIndex = 1;
            // 
            // rdoNochePartTime
            // 
            rdoNochePartTime.TabIndex = 6;
            // 
            // rdoTardePartTime
            // 
            rdoTardePartTime.TabIndex = 4;
            // 
            // rdoMañanaFullTime
            // 
            rdoMañanaFullTime.TabIndex = 3;
            // 
            // rdoMañanaPartTime
            // 
            rdoMañanaPartTime.TabIndex = 2;
            // 
            // rdoTardeFullTime
            // 
            rdoTardeFullTime.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbPescados);
            groupBox1.Controls.Add(cbGourmet);
            groupBox1.Controls.Add(cbPastas);
            groupBox1.Controls.Add(cbParrilla);
            groupBox1.Controls.Add(cbVegana);
            groupBox1.Controls.Add(cbReposteria);
            groupBox1.Location = new Point(53, 232);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(257, 70);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Especialidad del cocinero";
            // 
            // cbPescados
            // 
            cbPescados.AutoSize = true;
            cbPescados.Location = new Point(160, 47);
            cbPescados.Name = "cbPescados";
            cbPescados.Size = new Size(75, 19);
            cbPescados.TabIndex = 12;
            cbPescados.Text = "Pescados";
            cbPescados.UseVisualStyleBackColor = true;
            // 
            // cbGourmet
            // 
            cbGourmet.AutoSize = true;
            cbGourmet.Location = new Point(160, 22);
            cbGourmet.Name = "cbGourmet";
            cbGourmet.Size = new Size(73, 19);
            cbGourmet.TabIndex = 9;
            cbGourmet.Text = "Gourmet";
            cbGourmet.UseVisualStyleBackColor = true;
            // 
            // cbPastas
            // 
            cbPastas.AutoSize = true;
            cbPastas.Location = new Point(92, 47);
            cbPastas.Name = "cbPastas";
            cbPastas.Size = new Size(59, 19);
            cbPastas.TabIndex = 11;
            cbPastas.Text = "Pastas";
            cbPastas.UseVisualStyleBackColor = true;
            // 
            // cbParrilla
            // 
            cbParrilla.AutoSize = true;
            cbParrilla.Location = new Point(92, 22);
            cbParrilla.Name = "cbParrilla";
            cbParrilla.Size = new Size(62, 19);
            cbParrilla.TabIndex = 8;
            cbParrilla.Text = "Parrilla";
            cbParrilla.UseVisualStyleBackColor = true;
            // 
            // cbVegana
            // 
            cbVegana.AutoSize = true;
            cbVegana.Location = new Point(6, 47);
            cbVegana.Name = "cbVegana";
            cbVegana.Size = new Size(64, 19);
            cbVegana.TabIndex = 10;
            cbVegana.Text = "Vegana";
            cbVegana.UseVisualStyleBackColor = true;
            // 
            // cbReposteria
            // 
            cbReposteria.AutoSize = true;
            cbReposteria.Location = new Point(6, 22);
            cbReposteria.Name = "cbReposteria";
            cbReposteria.Size = new Size(81, 19);
            cbReposteria.TabIndex = 7;
            cbReposteria.Text = "Reposteria";
            cbReposteria.UseVisualStyleBackColor = true;
            // 
            // lblCertificacion
            // 
            lblCertificacion.AutoSize = true;
            lblCertificacion.Location = new Point(52, 305);
            lblCertificacion.Name = "lblCertificacion";
            lblCertificacion.Size = new Size(74, 15);
            lblCertificacion.TabIndex = 9;
            lblCertificacion.Text = "Certificacion";
            // 
            // txtCertificacion
            // 
            txtCertificacion.Location = new Point(53, 323);
            txtCertificacion.Name = "txtCertificacion";
            txtCertificacion.Size = new Size(257, 23);
            txtCertificacion.TabIndex = 13;
            // 
            // FrmCocinero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 437);
            Controls.Add(txtCertificacion);
            Controls.Add(lblCertificacion);
            Controls.Add(groupBox1);
            Name = "FrmCocinero";
            Text = "Nuevo Cocinero";
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtLegajo, 0);
            Controls.SetChildIndex(grpTurnoDeTrabajo, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(lblCertificacion, 0);
            Controls.SetChildIndex(txtCertificacion, 0);
            grpTurnoDeTrabajo.ResumeLayout(false);
            grpTurnoDeTrabajo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox cbReposteria;
        private CheckBox cbVegana;
        private CheckBox cbPastas;
        private CheckBox cbParrilla;
        private CheckBox cbPescados;
        private CheckBox cbGourmet;
        private Label lblCertificacion;
        private TextBox txtCertificacion;
    }
}