namespace TrucoPantalla
{
    partial class Usuario
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblFlor = new System.Windows.Forms.Label();
            this.chkBoxFlor = new System.Windows.Forms.CheckBox();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.chkBox15 = new System.Windows.Forms.CheckBox();
            this.chkBox30 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(113, 46);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(152, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(25, 272);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(111, 27);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Comenzar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(10, 46);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(97, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Ingrese su nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(148, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 26);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblFlor
            // 
            this.lblFlor.AutoSize = true;
            this.lblFlor.Location = new System.Drawing.Point(10, 111);
            this.lblFlor.Name = "lblFlor";
            this.lblFlor.Size = new System.Drawing.Size(108, 13);
            this.lblFlor.TabIndex = 2;
            this.lblFlor.Text = "Desea jugar con Flor:";
            // 
            // chkBoxFlor
            // 
            this.chkBoxFlor.AutoSize = true;
            this.chkBoxFlor.Location = new System.Drawing.Point(148, 111);
            this.chkBoxFlor.Name = "chkBoxFlor";
            this.chkBoxFlor.Size = new System.Drawing.Size(35, 17);
            this.chkBoxFlor.TabIndex = 4;
            this.chkBoxFlor.Text = "Si";
            this.chkBoxFlor.UseVisualStyleBackColor = true;
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Location = new System.Drawing.Point(35, 189);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(43, 13);
            this.lblPuntos.TabIndex = 2;
            this.lblPuntos.Text = "Puntos:";
            // 
            // chkBox15
            // 
            this.chkBox15.AutoSize = true;
            this.chkBox15.Location = new System.Drawing.Point(148, 185);
            this.chkBox15.Name = "chkBox15";
            this.chkBox15.Size = new System.Drawing.Size(38, 17);
            this.chkBox15.TabIndex = 5;
            this.chkBox15.Text = "15";
            this.chkBox15.UseVisualStyleBackColor = true;
            this.chkBox15.CheckedChanged += new System.EventHandler(this.chkBox15_CheckedChanged);
            // 
            // chkBox30
            // 
            this.chkBox30.AutoSize = true;
            this.chkBox30.Location = new System.Drawing.Point(148, 208);
            this.chkBox30.Name = "chkBox30";
            this.chkBox30.Size = new System.Drawing.Size(38, 17);
            this.chkBox30.TabIndex = 6;
            this.chkBox30.Text = "30";
            this.chkBox30.UseVisualStyleBackColor = true;
            this.chkBox30.CheckedChanged += new System.EventHandler(this.chkBox30_CheckedChanged);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 322);
            this.ControlBox = false;
            this.Controls.Add(this.chkBox30);
            this.Controls.Add(this.chkBox15);
            this.Controls.Add(this.chkBoxFlor);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.lblFlor);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtUsuario);
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblFlor;
        private System.Windows.Forms.CheckBox chkBoxFlor;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.CheckBox chkBox15;
        private System.Windows.Forms.CheckBox chkBox30;
    }
}