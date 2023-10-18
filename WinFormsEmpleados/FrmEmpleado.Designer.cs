namespace WinFormsEmpleados
{
    partial class FrmEmpleado
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
            lblNombre = new Label();
            lblLegajo = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtNombre = new TextBox();
            txtLegajo = new TextBox();
            grpTurnoDeTrabajo = new GroupBox();
            rdoNochePartTime = new RadioButton();
            rdoTardePartTime = new RadioButton();
            rdoMañanaFullTime = new RadioButton();
            rdoMañanaPartTime = new RadioButton();
            rdoTardeFullTime = new RadioButton();
            grpTurnoDeTrabajo.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(53, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Location = new Point(53, 65);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(42, 15);
            lblLegajo.TabIndex = 1;
            lblLegajo.Text = "Legajo";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(82, 378);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(84, 47);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(180, 378);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 47);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(53, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(257, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(53, 83);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(257, 23);
            txtLegajo.TabIndex = 1;
            // 
            // grpTurnoDeTrabajo
            // 
            grpTurnoDeTrabajo.Controls.Add(rdoNochePartTime);
            grpTurnoDeTrabajo.Controls.Add(rdoTardePartTime);
            grpTurnoDeTrabajo.Controls.Add(rdoMañanaFullTime);
            grpTurnoDeTrabajo.Controls.Add(rdoMañanaPartTime);
            grpTurnoDeTrabajo.Controls.Add(rdoTardeFullTime);
            grpTurnoDeTrabajo.Location = new Point(54, 126);
            grpTurnoDeTrabajo.Name = "grpTurnoDeTrabajo";
            grpTurnoDeTrabajo.Size = new Size(256, 100);
            grpTurnoDeTrabajo.TabIndex = 5;
            grpTurnoDeTrabajo.TabStop = false;
            grpTurnoDeTrabajo.Text = "Turno de trabajo";
            // 
            // rdoNochePartTime
            // 
            rdoNochePartTime.AutoSize = true;
            rdoNochePartTime.Location = new Point(6, 72);
            rdoNochePartTime.Name = "rdoNochePartTime";
            rdoNochePartTime.Size = new Size(113, 19);
            rdoNochePartTime.TabIndex = 6;
            rdoNochePartTime.Text = "Noche Part Time";
            rdoNochePartTime.UseVisualStyleBackColor = true;
            // 
            // rdoTardePartTime
            // 
            rdoTardePartTime.AutoSize = true;
            rdoTardePartTime.Location = new Point(6, 47);
            rdoTardePartTime.Name = "rdoTardePartTime";
            rdoTardePartTime.Size = new Size(106, 19);
            rdoTardePartTime.TabIndex = 4;
            rdoTardePartTime.Text = "Tarde Part Time";
            rdoTardePartTime.UseVisualStyleBackColor = true;
            // 
            // rdoMañanaFullTime
            // 
            rdoMañanaFullTime.AutoSize = true;
            rdoMañanaFullTime.Location = new Point(133, 22);
            rdoMañanaFullTime.Name = "rdoMañanaFullTime";
            rdoMañanaFullTime.Size = new Size(119, 19);
            rdoMañanaFullTime.TabIndex = 3;
            rdoMañanaFullTime.Text = "Mañana Full Time";
            rdoMañanaFullTime.UseVisualStyleBackColor = true;
            // 
            // rdoMañanaPartTime
            // 
            rdoMañanaPartTime.AutoSize = true;
            rdoMañanaPartTime.Checked = true;
            rdoMañanaPartTime.Location = new Point(6, 22);
            rdoMañanaPartTime.Name = "rdoMañanaPartTime";
            rdoMañanaPartTime.Size = new Size(121, 19);
            rdoMañanaPartTime.TabIndex = 2;
            rdoMañanaPartTime.TabStop = true;
            rdoMañanaPartTime.Text = "Mañana Part Time";
            rdoMañanaPartTime.UseVisualStyleBackColor = true;
            // 
            // rdoTardeFullTime
            // 
            rdoTardeFullTime.AutoSize = true;
            rdoTardeFullTime.Location = new Point(133, 47);
            rdoTardeFullTime.Name = "rdoTardeFullTime";
            rdoTardeFullTime.Size = new Size(104, 19);
            rdoTardeFullTime.TabIndex = 2;
            rdoTardeFullTime.Text = "Tarde Full Time";
            rdoTardeFullTime.UseVisualStyleBackColor = true;
            // 
            // FrmEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 437);
            Controls.Add(grpTurnoDeTrabajo);
            Controls.Add(txtLegajo);
            Controls.Add(txtNombre);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblLegajo);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmEmpleado";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmEmpleado";
            grpTurnoDeTrabajo.ResumeLayout(false);
            grpTurnoDeTrabajo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblLegajo;
        protected Button btnAceptar;
        protected Button btnCancelar;
        protected TextBox txtNombre;
        protected TextBox txtLegajo;
        protected GroupBox grpTurnoDeTrabajo;
        protected RadioButton rdoNochePartTime;
        protected RadioButton rdoTardePartTime;
        protected RadioButton rdoMañanaFullTime;
        protected RadioButton rdoMañanaPartTime;
        protected RadioButton rdoTardeFullTime;
    }
}