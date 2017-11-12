using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        private List<string> datos;
        public frmHistorial()
        {
            InitializeComponent();
            datos = new List<string>();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            archivos.leer(out datos);
            foreach (string s in datos)
            {
                lstHistorial.Items.Add(s);
            }
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
