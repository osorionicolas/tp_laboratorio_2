namespace TrucoPantalla
{
    partial class Tanto
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
            this.lblTanto = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTanto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTanto
            // 
            this.lblTanto.AutoSize = true;
            this.lblTanto.Location = new System.Drawing.Point(12, 9);
            this.lblTanto.Name = "lblTanto";
            this.lblTanto.Size = new System.Drawing.Size(86, 13);
            this.lblTanto.TabIndex = 5;
            this.lblTanto.Text = "Ingrese su tanto:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(115, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(111, 27);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Cantar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTanto
            // 
            this.txtTanto.Location = new System.Drawing.Point(46, 47);
            this.txtTanto.Name = "txtTanto";
            this.txtTanto.Size = new System.Drawing.Size(152, 20);
            this.txtTanto.TabIndex = 3;
            // 
            // Tanto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 141);
            this.ControlBox = false;
            this.Controls.Add(this.lblTanto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTanto);
            this.Name = "Tanto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTanto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtTanto;
    }
}