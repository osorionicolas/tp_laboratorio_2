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
    public partial class Tanto : Form
    {
        private int _valor = 0;
        public Tanto()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            int.TryParse(this.txtTanto.Text, out resultado);
            if (this.txtTanto.Text == "" || resultado == 0)
            {
                MessageBox.Show("El valor ingresado no es válido, ingrese uno nuevamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtTanto.Clear();
            }
            else
            {
                this._valor = resultado;
                this.Hide();
            }
        }
        public int Valor
        {
            get
            {
                return this._valor;
            }
        }
    }
}
