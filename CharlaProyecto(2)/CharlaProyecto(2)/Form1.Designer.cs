namespace CharlaProyecto_2_
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnGeneratePdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(29, 71);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(118, 16);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "Correo Electronico";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(29, 148);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(40, 16);
            this.labelAge.TabIndex = 2;
            this.labelAge.Text = "Edad";
            // 
            // errorProviderInput
            // 
            this.errorProviderInput.ContainerControl = this;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(153, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(223, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(153, 142);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(223, 22);
            this.txtAge.TabIndex = 4;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(316, 198);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 31);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Procesar";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(136, 205);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Estado";
            // 
            // btnGeneratePdf
            // 
            this.btnGeneratePdf.Location = new System.Drawing.Point(443, 198);
            this.btnGeneratePdf.Name = "btnGeneratePdf";
            this.btnGeneratePdf.Size = new System.Drawing.Size(105, 31);
            this.btnGeneratePdf.TabIndex = 8;
            this.btnGeneratePdf.Text = "Generar PDF";
            this.btnGeneratePdf.UseVisualStyleBackColor = true;
            this.btnGeneratePdf.Click += new System.EventHandler(this.btnGeneratePdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGeneratePdf);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelEmail);
            this.Name = "Form1";
            this.Text = "Validacion de Datos";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnGeneratePdf;
    }
}

