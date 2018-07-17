using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrucoPantalla
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            this.AcceptButton = btnOk;
            this.chkBox30.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("No ingreso ningun nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chkBox15.Checked == false && chkBox30.Checked == false)
            {
                MessageBox.Show("No Selecciono los puntos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();   
            }
        }

        public string NombreUsuario
        {
            get
            {
                return txtUsuario.Text;
            }
        }

        public bool CheckedFlor
        {
            get
            {
                bool resultado = false;
                if (this.chkBoxFlor.Checked == true)
                    resultado = true;
                return resultado;
            }
        }

        public int Puntos
        {
            get
            {
                int resultado = 0;
                if (this.chkBox15.Checked == true)
                    resultado = 15;
                else if (this.chkBox30.Checked == true)
                    resultado = 30;
                return resultado;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void chkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBox15.Checked == true)
                this.chkBox30.Checked = !chkBox15.Checked;
        }

        private void chkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox30.Checked == true)
                this.chkBox15.Checked = !chkBox30.Checked;
        }

    }
}
