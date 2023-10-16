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
            btnInformacionDetallada = new Button();
            lblUsuario = new Label();
            lblOrdenarLista = new Label();
            grpParametro = new GroupBox();
            rdoPorLegajo = new RadioButton();
            rdoPorNombre = new RadioButton();
            grpOrden = new GroupBox();
            rdoAscendente = new RadioButton();
            rdoDescendente = new RadioButton();
            btnOrdenarLista = new Button();
            grpParametro.SuspendLayout();
            grpOrden.SuspendLayout();
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
            btnAgregarMesero.Location = new Point(319, 49);
            btnAgregarMesero.Name = "btnAgregarMesero";
            btnAgregarMesero.Size = new Size(117, 29);
            btnAgregarMesero.TabIndex = 1;
            btnAgregarMesero.Text = "Agregar Mesero";
            btnAgregarMesero.UseVisualStyleBackColor = true;
            btnAgregarMesero.Click += btnAgregarMesero_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(319, 154);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(117, 29);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(319, 189);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(117, 29);
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
            btnAgregarCocinero.Location = new Point(319, 84);
            btnAgregarCocinero.Name = "btnAgregarCocinero";
            btnAgregarCocinero.Size = new Size(117, 29);
            btnAgregarCocinero.TabIndex = 5;
            btnAgregarCocinero.Text = "Agregar Cocinero";
            btnAgregarCocinero.UseVisualStyleBackColor = true;
            btnAgregarCocinero.Click += btnAgregarCocinero_Click;
            // 
            // btnAgregarCajero
            // 
            btnAgregarCajero.Location = new Point(319, 119);
            btnAgregarCajero.Name = "btnAgregarCajero";
            btnAgregarCajero.Size = new Size(117, 29);
            btnAgregarCajero.TabIndex = 6;
            btnAgregarCajero.Text = "Agregar Cajero";
            btnAgregarCajero.UseVisualStyleBackColor = true;
            btnAgregarCajero.Click += btnAgregarCajero_Click;
            // 
            // btnInformacionDetallada
            // 
            btnInformacionDetallada.Location = new Point(319, 250);
            btnInformacionDetallada.Name = "btnInformacionDetallada";
            btnInformacionDetallada.Size = new Size(117, 42);
            btnInformacionDetallada.TabIndex = 7;
            btnInformacionDetallada.Text = "Ver informacion detallada";
            btnInformacionDetallada.UseVisualStyleBackColor = true;
            btnInformacionDetallada.Click += btnInformacionDetallada_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(200, 505);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario";
            // 
            // lblOrdenarLista
            // 
            lblOrdenarLista.AutoSize = true;
            lblOrdenarLista.Location = new Point(35, 365);
            lblOrdenarLista.Name = "lblOrdenarLista";
            lblOrdenarLista.Size = new Size(74, 15);
            lblOrdenarLista.TabIndex = 9;
            lblOrdenarLista.Text = "Ordenar lista";
            // 
            // grpParametro
            // 
            grpParametro.Controls.Add(rdoPorLegajo);
            grpParametro.Controls.Add(rdoPorNombre);
            grpParametro.Location = new Point(35, 383);
            grpParametro.Name = "grpParametro";
            grpParametro.Size = new Size(108, 73);
            grpParametro.TabIndex = 10;
            grpParametro.TabStop = false;
            grpParametro.Text = "Parámetro";
            // 
            // rdoPorLegajo
            // 
            rdoPorLegajo.AutoSize = true;
            rdoPorLegajo.Location = new Point(6, 45);
            rdoPorLegajo.Name = "rdoPorLegajo";
            rdoPorLegajo.Size = new Size(60, 19);
            rdoPorLegajo.TabIndex = 1;
            rdoPorLegajo.TabStop = true;
            rdoPorLegajo.Text = "Legajo";
            rdoPorLegajo.UseVisualStyleBackColor = true;
            // 
            // rdoPorNombre
            // 
            rdoPorNombre.AutoSize = true;
            rdoPorNombre.Checked = true;
            rdoPorNombre.Location = new Point(6, 20);
            rdoPorNombre.Name = "rdoPorNombre";
            rdoPorNombre.Size = new Size(69, 19);
            rdoPorNombre.TabIndex = 0;
            rdoPorNombre.TabStop = true;
            rdoPorNombre.Text = "Nombre";
            rdoPorNombre.UseVisualStyleBackColor = true;
            // 
            // grpOrden
            // 
            grpOrden.Controls.Add(rdoAscendente);
            grpOrden.Controls.Add(rdoDescendente);
            grpOrden.Location = new Point(163, 383);
            grpOrden.Name = "grpOrden";
            grpOrden.Size = new Size(102, 73);
            grpOrden.TabIndex = 11;
            grpOrden.TabStop = false;
            grpOrden.Text = "Orden";
            // 
            // rdoAscendente
            // 
            rdoAscendente.AutoSize = true;
            rdoAscendente.Checked = true;
            rdoAscendente.Location = new Point(6, 20);
            rdoAscendente.Name = "rdoAscendente";
            rdoAscendente.Size = new Size(87, 19);
            rdoAscendente.TabIndex = 2;
            rdoAscendente.TabStop = true;
            rdoAscendente.Text = "Ascendente";
            rdoAscendente.UseVisualStyleBackColor = true;
            // 
            // rdoDescendente
            // 
            rdoDescendente.AutoSize = true;
            rdoDescendente.Location = new Point(6, 45);
            rdoDescendente.Name = "rdoDescendente";
            rdoDescendente.Size = new Size(93, 19);
            rdoDescendente.TabIndex = 3;
            rdoDescendente.TabStop = true;
            rdoDescendente.Text = "Descendente";
            rdoDescendente.UseVisualStyleBackColor = true;
            // 
            // btnOrdenarLista
            // 
            btnOrdenarLista.Location = new Point(319, 392);
            btnOrdenarLista.Name = "btnOrdenarLista";
            btnOrdenarLista.Size = new Size(108, 64);
            btnOrdenarLista.TabIndex = 12;
            btnOrdenarLista.Text = "Ordenar";
            btnOrdenarLista.UseVisualStyleBackColor = true;
            btnOrdenarLista.Click += btnOrdenarLista_Click;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 529);
            Controls.Add(btnOrdenarLista);
            Controls.Add(grpOrden);
            Controls.Add(grpParametro);
            Controls.Add(lblOrdenarLista);
            Controls.Add(lblUsuario);
            Controls.Add(btnInformacionDetallada);
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
            FormClosing += FrmCRUD_FormClosing;
            Load += FrmCRUD_Load;
            grpParametro.ResumeLayout(false);
            grpParametro.PerformLayout();
            grpOrden.ResumeLayout(false);
            grpOrden.PerformLayout();
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
        private Button btnInformacionDetallada;
        private Label lblUsuario;
        private Label lblOrdenarLista;
        private GroupBox grpParametro;
        private GroupBox grpOrden;
        private RadioButton rdoPorNombre;
        private RadioButton rdoAscendente;
        private RadioButton rdoDescendente;
        private RadioButton rdoPorLegajo;
        private Button btnOrdenarLista;
    }
}