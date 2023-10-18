namespace WinFormsEmpleados
{
    partial class FrmRegistroUsuarios
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
            txtRegistroUsuarios = new TextBox();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // txtRegistroUsuarios
            // 
            txtRegistroUsuarios.Location = new Point(12, 12);
            txtRegistroUsuarios.Multiline = true;
            txtRegistroUsuarios.Name = "txtRegistroUsuarios";
            txtRegistroUsuarios.ReadOnly = true;
            txtRegistroUsuarios.ScrollBars = ScrollBars.Vertical;
            txtRegistroUsuarios.Size = new Size(249, 324);
            txtRegistroUsuarios.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(186, 355);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmRegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 390);
            Controls.Add(btnCerrar);
            Controls.Add(txtRegistroUsuarios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmRegistroUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de usuarios";
            Load += FrmRegistroUsuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRegistroUsuarios;
        private Button btnCerrar;
    }
}