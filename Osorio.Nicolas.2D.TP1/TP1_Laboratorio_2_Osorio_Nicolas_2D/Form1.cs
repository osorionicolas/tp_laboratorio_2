using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Laboratorio_2_Osorio_Nicolas_2D
{
    public partial class Form1 : Form
    {
        
        private void limpiar()
        {
            lblResultado.Text = "0";
            txtNumero1.Clear();
            txtNumero2.Clear();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            string resulTexto,operador;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            operador=Calculadora.validarOperador(cmbOperacion.Text);
            cmbOperacion.Text = operador;
            resultado=Calculadora.operar(numero1.getNumero(), numero2.getNumero(), operador);
            if (resultado == 0)
            {
                MessageBox.Show("Math Error");
                limpiar();
                lblResultado.Text = "0";
            }
            else
            {
                resulTexto = Convert.ToString(resultado);
                lblResultado.Text = resulTexto;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
