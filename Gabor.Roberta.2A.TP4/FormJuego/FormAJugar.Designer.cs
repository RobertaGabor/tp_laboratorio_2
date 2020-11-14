namespace FormJuego
{
    partial class FormJugar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJugar));
            this.lblJugador = new System.Windows.Forms.Label();
            this.lblMonedaAJugar = new System.Windows.Forms.Label();
            this.lblCantidadAJugar = new System.Windows.Forms.Label();
            this.txtBoxIDAJugar = new System.Windows.Forms.TextBox();
            this.txtCantidadAJugar = new System.Windows.Forms.TextBox();
            this.cmbBoxAJugar = new System.Windows.Forms.ComboBox();
            this.btnAJugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJugador
            // 
            this.lblJugador.AutoSize = true;
            this.lblJugador.Font = new System.Drawing.Font("Casino Shadow", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugador.Location = new System.Drawing.Point(13, 13);
            this.lblJugador.Name = "lblJugador";
            this.lblJugador.Size = new System.Drawing.Size(186, 21);
            this.lblJugador.TabIndex = 0;
            this.lblJugador.Text = "ID DEL JUGADOR";
            // 
            // lblMonedaAJugar
            // 
            this.lblMonedaAJugar.AutoSize = true;
            this.lblMonedaAJugar.Font = new System.Drawing.Font("Casino Shadow", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonedaAJugar.Location = new System.Drawing.Point(12, 71);
            this.lblMonedaAJugar.Name = "lblMonedaAJugar";
            this.lblMonedaAJugar.Size = new System.Drawing.Size(288, 21);
            this.lblMonedaAJugar.TabIndex = 1;
            this.lblMonedaAJugar.Text = "MONEDA QUE VA A JUGAR";
            // 
            // lblCantidadAJugar
            // 
            this.lblCantidadAJugar.AutoSize = true;
            this.lblCantidadAJugar.Font = new System.Drawing.Font("Casino Shadow", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadAJugar.Location = new System.Drawing.Point(13, 130);
            this.lblCantidadAJugar.Name = "lblCantidadAJugar";
            this.lblCantidadAJugar.Size = new System.Drawing.Size(304, 21);
            this.lblCantidadAJugar.TabIndex = 2;
            this.lblCantidadAJugar.Text = "CANTIDAD QUE VA A JUGAR";
            // 
            // txtBoxIDAJugar
            // 
            this.txtBoxIDAJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxIDAJugar.Location = new System.Drawing.Point(17, 38);
            this.txtBoxIDAJugar.Name = "txtBoxIDAJugar";
            this.txtBoxIDAJugar.Size = new System.Drawing.Size(182, 26);
            this.txtBoxIDAJugar.TabIndex = 3;
            // 
            // txtCantidadAJugar
            // 
            this.txtCantidadAJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadAJugar.Location = new System.Drawing.Point(17, 154);
            this.txtCantidadAJugar.Name = "txtCantidadAJugar";
            this.txtCantidadAJugar.Size = new System.Drawing.Size(182, 26);
            this.txtCantidadAJugar.TabIndex = 4;
            // 
            // cmbBoxAJugar
            // 
            this.cmbBoxAJugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxAJugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxAJugar.FormattingEnabled = true;
            this.cmbBoxAJugar.Location = new System.Drawing.Point(17, 96);
            this.cmbBoxAJugar.Name = "cmbBoxAJugar";
            this.cmbBoxAJugar.Size = new System.Drawing.Size(182, 28);
            this.cmbBoxAJugar.TabIndex = 5;
            // 
            // btnAJugar
            // 
            this.btnAJugar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAJugar.Font = new System.Drawing.Font("Casino Shadow", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAJugar.Location = new System.Drawing.Point(356, 71);
            this.btnAJugar.Name = "btnAJugar";
            this.btnAJugar.Size = new System.Drawing.Size(131, 52);
            this.btnAJugar.TabIndex = 6;
            this.btnAJugar.Text = "¡jugar!";
            this.btnAJugar.UseVisualStyleBackColor = true;
            this.btnAJugar.Click += new System.EventHandler(this.btnJugar_Click);
            this.btnAJugar.MouseEnter += new System.EventHandler(this.btnIniciativaJugar_Focus);
            this.btnAJugar.MouseLeave += new System.EventHandler(this.btnIniciativaDejarJugar_Focus);
            // 
            // FormJugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 195);
            this.Controls.Add(this.btnAJugar);
            this.Controls.Add(this.cmbBoxAJugar);
            this.Controls.Add(this.txtCantidadAJugar);
            this.Controls.Add(this.txtBoxIDAJugar);
            this.Controls.Add(this.lblCantidadAJugar);
            this.Controls.Add(this.lblMonedaAJugar);
            this.Controls.Add(this.lblJugador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(524, 234);
            this.MinimumSize = new System.Drawing.Size(524, 234);
            this.Name = "FormJugar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¡A jugar!";
            this.Load += new System.EventHandler(this.FormJugar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblMonedaAJugar;
        private System.Windows.Forms.Label lblCantidadAJugar;
        private System.Windows.Forms.TextBox txtBoxIDAJugar;
        private System.Windows.Forms.TextBox txtCantidadAJugar;
        private System.Windows.Forms.ComboBox cmbBoxAJugar;
        private System.Windows.Forms.Button btnAJugar;
    }
}

