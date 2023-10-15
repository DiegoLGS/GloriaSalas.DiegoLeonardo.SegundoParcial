namespace WinFormsApp1
{
    partial class FrmCRUD
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstEmpleados = new ListBox();
            btnAgregarMesero = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            lblListaEmpleados = new Label();
            btnAgregarCocinero = new Button();
            btnAgregarCajero = new Button();
            SuspendLayout();
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.ItemHeight = 15;
            lstEmpleados.Location = new Point(35, 49);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(261, 304);
            lstEmpleados.TabIndex = 0;
            // 
            // btnAgregarMesero
            // 
            btnAgregarMesero.Location = new Point(362, 49);
            btnAgregarMesero.Name = "btnAgregarMesero";
            btnAgregarMesero.Size = new Size(85, 55);
            btnAgregarMesero.TabIndex = 1;
            btnAgregarMesero.Text = "Agregar Mesero";
            btnAgregarMesero.UseVisualStyleBackColor = true;
            btnAgregarMesero.Click += btnAgregarMesero_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(362, 232);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(85, 55);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(362, 293);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 55);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblListaEmpleados
            // 
            lblListaEmpleados.AutoSize = true;
            lblListaEmpleados.Location = new Point(35, 19);
            lblListaEmpleados.Name = "lblListaEmpleados";
            lblListaEmpleados.Size = new Size(108, 15);
            lblListaEmpleados.TabIndex = 4;
            lblListaEmpleados.Text = "Lista de empleados";
            // 
            // btnAgregarCocinero
            // 
            btnAgregarCocinero.Location = new Point(362, 110);
            btnAgregarCocinero.Name = "btnAgregarCocinero";
            btnAgregarCocinero.Size = new Size(85, 55);
            btnAgregarCocinero.TabIndex = 5;
            btnAgregarCocinero.Text = "Agregar Cocinero";
            btnAgregarCocinero.UseVisualStyleBackColor = true;
            btnAgregarCocinero.Click += btnAgregarCocinero_Click;
            // 
            // btnAgregarCajero
            // 
            btnAgregarCajero.Location = new Point(362, 171);
            btnAgregarCajero.Name = "btnAgregarCajero";
            btnAgregarCajero.Size = new Size(85, 55);
            btnAgregarCajero.TabIndex = 6;
            btnAgregarCajero.Text = "Agregar Cajero";
            btnAgregarCajero.UseVisualStyleBackColor = true;
            btnAgregarCajero.Click += btnAgregarCajero_Click;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 408);
            Controls.Add(btnAgregarCajero);
            Controls.Add(btnAgregarCocinero);
            Controls.Add(lblListaEmpleados);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregarMesero);
            Controls.Add(lstEmpleados);
            Name = "FrmCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstEmpleados;
        private Button btnAgregarMesero;
        private Button btnModificar;
        private Button btnEliminar;
        private Label lblListaEmpleados;
        private Button btnAgregarCocinero;
        private Button btnAgregarCajero;
    }
}