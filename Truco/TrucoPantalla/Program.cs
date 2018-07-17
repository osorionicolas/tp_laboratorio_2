using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrucoPantalla
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Usuario form = new Usuario();
            form.ShowDialog();
            Application.Run(new Truco(form.NombreUsuario, form.CheckedFlor, form.Puntos));
        }
    }
}
