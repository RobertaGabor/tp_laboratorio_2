namespace FormBase
{
    partial class FormPadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPadre));
            this.lblCasinoDeco = new System.Windows.Forms.Label();
            this.dtaGridView = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtaGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCasinoDeco
            // 
            this.lblCasinoDeco.AutoSize = true;
            this.lblCasinoDeco.Font = new System.Drawing.Font("Casino 3D Filled Marquee", 66F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasinoDeco.Location = new System.Drawing.Point(12, 9);
            this.lblCasinoDeco.Name = "lblCasinoDeco";
            this.lblCasinoDeco.Size = new System.Drawing.Size(328, 67);
            this.lblCasinoDeco.TabIndex = 0;
            this.lblCasinoDeco.Text = "Casino ";
            // 
            // dtaGridView
            // 
            this.dtaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtaGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtaGridView.Location = new System.Drawing.Point(12, 79);
            this.dtaGridView.Name = "dtaGridView";
            this.dtaGridView.Size = new System.Drawing.Size(440, 243);
            this.dtaGridView.TabIndex = 1;
            this.dtaGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DobleClick);
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Casino Shadow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.Location = new System.Drawing.Point(466, 79);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(192, 51);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar monedas";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnJugar
            // 
            this.btnJugar.Font = new System.Drawing.Font("Casino Shadow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.Location = new System.Drawing.Point(466, 162);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(192, 51);
            this.btnJugar.TabIndex = 3;
            this.btnJugar.Text = "Jugar!";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnAJugar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Casino Shadow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(466, 244);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(192, 51);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormPadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 334);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dtaGridView);
            this.Controls.Add(this.lblCasinoDeco);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(701, 373);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(701, 373);
            this.Name = "FormPadre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazte millonario!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingGuardado_FormBase);
            ((System.ComponentModel.ISupportInitialize)(this.dtaGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCasinoDeco;
        private System.Windows.Forms.DataGridView dtaGridView;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnSalir;
    }
}

