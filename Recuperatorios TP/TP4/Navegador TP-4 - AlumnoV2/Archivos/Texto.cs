using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public Texto(string archivo)
        {
        }
        public bool guardar(string datos)
        {
            try
            {
                if (!File.Exists("historico.dat")) 
                {
                    using (StreamWriter file = File.CreateText("historico.dat")) 
                      {
                         file.WriteLine(datos);
                        }	
                }
                else
                {
                    using (StreamWriter file = File.AppendText("historico.dat"))
                    {
                        file.WriteLine(datos);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public bool leer(out List<string> datos)
        {
            try
            {
                datos = new List<string>();
                using (StreamReader file = new StreamReader("historico.dat"))
                {
                    while (!file.EndOfStream)
                        datos.Add(file.ReadLine());
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = null;
                return false;
            }
        }

    }
}
