namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.txtBoxNum2 = new System.Windows.Forms.TextBox();
            this.txtBoxNum1 = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnADecimal = new System.Windows.Forms.Button();
            this.btnABinario = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboBoxOperador = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtBoxNum2
            // 
            this.txtBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNum2.Location = new System.Drawing.Point(277, 51);
            this.txtBoxNum2.Multiline = true;
            this.txtBoxNum2.Name = "txtBoxNum2";
            this.txtBoxNum2.Size = new System.Drawing.Size(115, 56);
            this.txtBoxNum2.TabIndex = 3;
            this.txtBoxNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxNum1
            // 
            this.txtBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNum1.Location = new System.Drawing.Point(22, 51);
            this.txtBoxNum1.Multiline = true;
            this.txtBoxNum1.Name = "txtBoxNum1";
            this.txtBoxNum1.Size = new System.Drawing.Size(115, 56);
            this.txtBoxNum1.TabIndex = 1;
            this.txtBoxNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(306, 9);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(86, 31);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "label1";
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(22, 128);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(115, 34);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(277, 128);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 34);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnADecimal
            // 
            this.btnADecimal.Location = new System.Drawing.Point(208, 168);
            this.btnADecimal.Name = "btnADecimal";
            this.btnADecimal.Size = new System.Drawing.Size(184, 29);
            this.btnADecimal.TabIndex = 8;
            this.btnADecimal.Text = "Convertir a Decimal";
            this.btnADecimal.UseVisualStyleBackColor = true;
            // 
            // btnABinario
            // 
            this.btnABinario.Location = new System.Drawing.Point(22, 168);
            this.btnABinario.Name = "btnABinario";
            this.btnABinario.Size = new System.Drawing.Size(184, 29);
            this.btnABinario.TabIndex = 7;
            this.btnABinario.Text = "Convertir a Binario";
            this.btnABinario.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(160, 128);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(98, 34);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cboBoxOperador
            // 
            this.cboBoxOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoxOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoxOperador.FormattingEnabled = true;
            this.cboBoxOperador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cboBoxOperador.Location = new System.Drawing.Point(174, 57);
            this.cboBoxOperador.Name = "cboBoxOperador";
            this.cboBoxOperador.Size = new System.Drawing.Size(70, 46);
            this.cboBoxOperador.TabIndex = 2;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 246);
            this.Controls.Add(this.cboBoxOperador);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnABinario);
            this.Controls.Add(this.btnADecimal);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtBoxNum1);
            this.Controls.Add(this.txtBoxNum2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(431, 285);
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Roberta Gabor del curso 2A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxNum2;
        private System.Windows.Forms.TextBox txtBoxNum1;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnADecimal;
        private System.Windows.Forms.Button btnABinario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cboBoxOperador;
    }
}

