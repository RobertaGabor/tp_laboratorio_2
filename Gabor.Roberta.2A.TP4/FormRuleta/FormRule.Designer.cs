namespace FormRuleta
{
    partial class FormRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRule));
            this.picBoxRuleta = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRuleta)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxRuleta
            // 
            this.picBoxRuleta.Image = ((System.Drawing.Image)(resources.GetObject("picBoxRuleta.Image")));
            this.picBoxRuleta.InitialImage = null;
            this.picBoxRuleta.Location = new System.Drawing.Point(-4, 2);
            this.picBoxRuleta.Name = "picBoxRuleta";
            this.picBoxRuleta.Size = new System.Drawing.Size(283, 246);
            this.picBoxRuleta.TabIndex = 0;
            this.picBoxRuleta.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Casino Shadow", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(96, 254);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(107, 28);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "PARAR";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnSpinParar_Click);
            // 
            // FormRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 294);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.picBoxRuleta);
            this.MaximumSize = new System.Drawing.Size(307, 333);
            this.MinimumSize = new System.Drawing.Size(307, 333);
            this.Name = "FormRule";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnClosingForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRuleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxRuleta;
        private System.Windows.Forms.Button btnStop;
    }
}

