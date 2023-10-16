namespace WinFormsEmpleados
{
    partial class FrmCajero
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
            txtPropina = new TextBox();
            lblPropina = new Label();
            grpCaja = new GroupBox();
            rdoCajaDos = new RadioButton();
            rdoCajaUno = new RadioButton();
            grpTurnoDeTrabajo.SuspendLayout();
            grpCaja.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Click += btnAceptar_ClickCajero;
            // 
            // txtPropina
            // 
            txtPropina.Location = new Point(46, 256);
            txtPropina.Name = "txtPropina";
            txtPropina.Size = new Size(245, 23);
            txtPropina.TabIndex = 8;
            // 
            // lblPropina
            // 
            lblPropina.AutoSize = true;
            lblPropina.Location = new Point(46, 238);
            lblPropina.Name = "lblPropina";
            lblPropina.Size = new Size(83, 15);
            lblPropina.TabIndex = 9;
            lblPropina.Text = "Propina actual";
            // 
            // grpCaja
            // 
            grpCaja.Controls.Add(rdoCajaDos);
            grpCaja.Controls.Add(rdoCajaUno);
            grpCaja.Location = new Point(50, 298);
            grpCaja.Name = "grpCaja";
            grpCaja.Size = new Size(241, 55);
            grpCaja.TabIndex = 10;
            grpCaja.TabStop = false;
            grpCaja.Text = "Caja asignada";
            // 
            // rdoCajaDos
            // 
            rdoCajaDos.AutoSize = true;
            rdoCajaDos.Location = new Point(129, 22);
            rdoCajaDos.Name = "rdoCajaDos";
            rdoCajaDos.Size = new Size(95, 19);
            rdoCajaDos.TabIndex = 1;
            rdoCajaDos.TabStop = true;
            rdoCajaDos.Text = "Caja 2 - Patio";
            rdoCajaDos.UseVisualStyleBackColor = true;
            // 
            // rdoCajaUno
            // 
            rdoCajaUno.AutoSize = true;
            rdoCajaUno.Checked = true;
            rdoCajaUno.Location = new Point(9, 22);
            rdoCajaUno.Name = "rdoCajaUno";
            rdoCajaUno.Size = new Size(114, 19);
            rdoCajaUno.TabIndex = 0;
            rdoCajaUno.TabStop = true;
            rdoCajaUno.Text = "Caja 1 - Principal";
            rdoCajaUno.UseVisualStyleBackColor = true;
            // 
            // FrmCajero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 450);
            Controls.Add(grpCaja);
            Controls.Add(lblPropina);
            Controls.Add(txtPropina);
            Name = "FrmCajero";
            Text = "FrmCajero";
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtLegajo, 0);
            Controls.SetChildIndex(grpTurnoDeTrabajo, 0);
            Controls.SetChildIndex(txtPropina, 0);
            Controls.SetChildIndex(lblPropina, 0);
            Controls.SetChildIndex(grpCaja, 0);
            grpTurnoDeTrabajo.ResumeLayout(false);
            grpTurnoDeTrabajo.PerformLayout();
            grpCaja.ResumeLayout(false);
            grpCaja.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPropina;
        private Label lblPropina;
        private GroupBox grpCaja;
        private RadioButton rdoCajaUno;
        private RadioButton rdoCajaDos;
    }
}