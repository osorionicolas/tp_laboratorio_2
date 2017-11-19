﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {

        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }
    }
}
