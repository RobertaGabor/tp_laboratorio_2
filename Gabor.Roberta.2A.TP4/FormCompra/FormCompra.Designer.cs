namespace FormCompra
{
    partial class FormComprarMonedas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComprarMonedas));
            this.lblJugadorId = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbBoxTipoMoneda = new System.Windows.Forms.ComboBox();
            this.txtBoxCantidadMonedas = new System.Windows.Forms.TextBox();
            this.txtBoxIDJugador = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJugadorId
            // 
            this.lblJugadorId.AutoSize = true;
            this.lblJugadorId.Font = new System.Drawing.Font("Casino Shadow", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugadorId.Location = new System.Drawing.Point(12, 18);
            this.lblJugadorId.Name = "lblJugadorId";
            this.lblJugadorId.Size = new System.Drawing.Size(148, 23);
            this.lblJugadorId.TabIndex = 0;
            this.lblJugadorId.Text = "ID JUGADOR";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Casino Shadow", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(12, 159);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(125, 23);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "CANTIDAD";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Casino Shadow", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(12, 88);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(208, 23);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "TIPO DE MONEDA";
            // 
            // cmbBoxTipoMoneda
            // 
            this.cmbBoxTipoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTipoMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxTipoMoneda.FormattingEnabled = true;
            this.cmbBoxTipoMoneda.Location = new System.Drawing.Point(16, 114);
            this.cmbBoxTipoMoneda.Name = "cmbBoxTipoMoneda";
            this.cmbBoxTipoMoneda.Size = new System.Drawing.Size(204, 28);
            this.cmbBoxTipoMoneda.TabIndex = 3;
            // 
            // txtBoxCantidadMonedas
            // 
            this.txtBoxCantidadMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCantidadMonedas.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxCantidadMonedas.Location = new System.Drawing.Point(16, 194);
            this.txtBoxCantidadMonedas.Name = "txtBoxCantidadMonedas";
            this.txtBoxCantidadMonedas.Size = new System.Drawing.Size(204, 26);
            this.txtBoxCantidadMonedas.TabIndex = 5;
            // 
            // txtBoxIDJugador
            // 
            this.txtBoxIDJugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxIDJugador.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBoxIDJugador.Location = new System.Drawing.Point(12, 44);
            this.txtBoxIDJugador.Name = "txtBoxIDJugador";
            this.txtBoxIDJugador.Size = new System.Drawing.Size(204, 26);
            this.txtBoxIDJugador.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Casino Shadow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(120, 279);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 33);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Casino Shadow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 279);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 33);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormComprarMonedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 324);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtBoxIDJugador);
            this.Controls.Add(this.txtBoxCantidadMonedas);
            this.Controls.Add(this.cmbBoxTipoMoneda);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblJugadorId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(260, 363);
            this.MinimumSize = new System.Drawing.Size(260, 363);
            this.Name = "FormComprarMonedas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¡A Gastar!";
            this.Load += new System.EventHandler(this.FormComprarMonedas_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJugadorId;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbBoxTipoMoneda;
        private System.Windows.Forms.TextBox txtBoxCantidadMonedas;
        private System.Windows.Forms.TextBox txtBoxIDJugador;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

