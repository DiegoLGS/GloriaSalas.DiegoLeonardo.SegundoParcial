﻿namespace WinFormsEmpleados
{
    partial class FrmMesero
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
            lblNumeroDeMesas = new Label();
            txtNumeroDeMesas = new TextBox();
            grpZonaDeTrabajo = new GroupBox();
            rdoSegundoPiso = new RadioButton();
            rdoPrincipal = new RadioButton();
            rdoPatio = new RadioButton();
            grpTurnoDeTrabajo.SuspendLayout();
            grpZonaDeTrabajo.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.TabIndex = 11;
            btnAceptar.Click += btnAceptar_ClickMesero;
            // 
            // btnCancelar
            // 
            btnCancelar.TabIndex = 12;
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
            // lblNumeroDeMesas
            // 
            lblNumeroDeMesas.AutoSize = true;
            lblNumeroDeMesas.Location = new Point(53, 285);
            lblNumeroDeMesas.Name = "lblNumeroDeMesas";
            lblNumeroDeMesas.Size = new Size(158, 15);
            lblNumeroDeMesas.TabIndex = 9;
            lblNumeroDeMesas.Text = "Número de mesas asignadas";
            // 
            // txtNumeroDeMesas
            // 
            txtNumeroDeMesas.Location = new Point(54, 303);
            txtNumeroDeMesas.Name = "txtNumeroDeMesas";
            txtNumeroDeMesas.Size = new Size(256, 23);
            txtNumeroDeMesas.TabIndex = 10;
            // 
            // grpZonaDeTrabajo
            // 
            grpZonaDeTrabajo.Controls.Add(rdoSegundoPiso);
            grpZonaDeTrabajo.Controls.Add(rdoPrincipal);
            grpZonaDeTrabajo.Controls.Add(rdoPatio);
            grpZonaDeTrabajo.Location = new Point(53, 232);
            grpZonaDeTrabajo.Name = "grpZonaDeTrabajo";
            grpZonaDeTrabajo.Size = new Size(257, 41);
            grpZonaDeTrabajo.TabIndex = 12;
            grpZonaDeTrabajo.TabStop = false;
            grpZonaDeTrabajo.Text = "Zona de trabajo";
            // 
            // rdoSegundoPiso
            // 
            rdoSegundoPiso.AutoSize = true;
            rdoSegundoPiso.Location = new Point(141, 16);
            rdoSegundoPiso.Name = "rdoSegundoPiso";
            rdoSegundoPiso.Size = new Size(97, 19);
            rdoSegundoPiso.TabIndex = 9;
            rdoSegundoPiso.Text = "Segundo piso";
            rdoSegundoPiso.UseVisualStyleBackColor = true;
            // 
            // rdoPrincipal
            // 
            rdoPrincipal.AutoSize = true;
            rdoPrincipal.Checked = true;
            rdoPrincipal.Location = new Point(6, 16);
            rdoPrincipal.Name = "rdoPrincipal";
            rdoPrincipal.Size = new Size(71, 19);
            rdoPrincipal.TabIndex = 7;
            rdoPrincipal.TabStop = true;
            rdoPrincipal.Text = "Principal";
            rdoPrincipal.UseVisualStyleBackColor = true;
            // 
            // rdoPatio
            // 
            rdoPatio.AutoSize = true;
            rdoPatio.Location = new Point(83, 16);
            rdoPatio.Name = "rdoPatio";
            rdoPatio.Size = new Size(52, 19);
            rdoPatio.TabIndex = 8;
            rdoPatio.TabStop = true;
            rdoPatio.Text = "Patio";
            rdoPatio.UseVisualStyleBackColor = true;
            // 
            // FrmMesero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 437);
            Controls.Add(grpZonaDeTrabajo);
            Controls.Add(txtNumeroDeMesas);
            Controls.Add(lblNumeroDeMesas);
            Name = "FrmMesero";
            Text = "Nuevo Mesero";
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtLegajo, 0);
            Controls.SetChildIndex(grpTurnoDeTrabajo, 0);
            Controls.SetChildIndex(lblNumeroDeMesas, 0);
            Controls.SetChildIndex(txtNumeroDeMesas, 0);
            Controls.SetChildIndex(grpZonaDeTrabajo, 0);
            grpTurnoDeTrabajo.ResumeLayout(false);
            grpTurnoDeTrabajo.PerformLayout();
            grpZonaDeTrabajo.ResumeLayout(false);
            grpZonaDeTrabajo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNumeroDeMesas;
        private TextBox txtNumeroDeMesas;
        private GroupBox grpZonaDeTrabajo;
        private RadioButton rdoPatio;
        private RadioButton rdoSegundoPiso;
        private RadioButton rdoPrincipal;
    }
}