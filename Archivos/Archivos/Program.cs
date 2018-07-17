using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo directorio = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Archivos\\pagos\\");
            FileInfo[] archivos = null;
            try
            {
                archivos = directorio.GetFiles();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (!(archivos == null))
            {
                for (int x = 0; x < archivos.Length; x++)
                {
                    if (archivos[x].Name == DateTime.Now.ToString("yyyyMMdd") + "_pagos" + archivos[x].Extension)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMdd") + "_pagos" + archivos[x].Extension;
                        StreamReader archivo = new StreamReader(directorio.FullName + fileName);
                        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Lenovo\\Desktop\\Archivos\\Archivos\\VERDULEROS.mdb");

                        string select = "select * from Productos";

                        OleDbCommand comandoSelect = new OleDbCommand(select, conexion);

                        conexion.Open();

                        while (!archivo.EndOfStream)
                        {
                            string[] campos = archivo.ReadLine().Split(',');
                            string insert = "INSERT into Productos (IdProducto, NomProducto, IdGrupo, Precio) Values(@IdP,@Nom,@IdG,@Pre)";
                            OleDbCommand comandoInsert = new OleDbCommand(insert, conexion);
                            comandoInsert.Parameters.Add("@IdP", OleDbType.VarChar).Value = campos[0];
                            comandoInsert.Parameters.Add("@Nom", OleDbType.VarChar).Value = campos[1];
                            comandoInsert.Parameters.Add("@IdG", OleDbType.VarChar).Value = campos[2];
                            comandoInsert.Parameters.Add("@Pre", OleDbType.VarChar).Value = campos[3];
                            try
                            {
                                comandoInsert.ExecuteNonQuery();
                            }
                            catch (OleDbException e)
                            {
                                Console.WriteLine(e.Message + "\n\n");
                                break;
                            }
                        }
                        OleDbDataReader lectorDatos = comandoSelect.ExecuteReader();
                        while (lectorDatos.Read())
                        {
                            Console.WriteLine(lectorDatos.GetInt32(0) + ", " + lectorDatos.GetString(1) + ", " + lectorDatos.GetInt32(2) + ", " + lectorDatos.GetDecimal(3));
                        }
                        conexion.Close();
                        archivo.Close();
                    }
                    else
                        Console.WriteLine("No se encontró ningun archivo de la fecha");
                }
            }
            Console.ReadKey();
        }
    }
}
