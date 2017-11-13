using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        public delegate void DescargaDelegado(int progreso);
        public delegate void DescargaCompletaDelegado(string html);
        
        public event DescargaDelegado eventoDescarga;
        public event DescargaCompletaDelegado eventoDescargaFinalizada;

        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            eventoDescarga.Invoke(100);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                eventoDescargaFinalizada.Invoke(this.html);
            }
          
            catch (System.Reflection.TargetInvocationException)
            {
                eventoDescargaFinalizada.Invoke("Pagina no encontrada");
            }
        }
    }
}
