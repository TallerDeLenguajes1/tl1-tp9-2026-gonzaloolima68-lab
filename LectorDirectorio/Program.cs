using System;
using System.IO;
using System.Collections.Generic;

namespace tp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese La Ruta del Directorio");
            string ruta = Console.ReadLine();

            //verificamos si exite la ruta del directorio
            while (!Directory.Exists(ruta))
            {
                Console.WriteLine("No se encontro el directorio");
                Console.WriteLine();
                Console.WriteLine("Ingrese nuevamente una ruta del directorio");
                ruta = Console.ReadLine();
            }
            Console.WriteLine("Directorio valido");

            //Arreglo con todas las CARPETAS que estan dentro del directorio indicado por la ruta
            string[] carpetas = Directory.GetDirectories(ruta);
            Console.WriteLine();
            Console.WriteLine("Carpetas");

            foreach (string c in carpetas)
            {
                Console.WriteLine(Path.GetFileName(c));//tomamos la ultima parte de la ruta
            }

            Console.WriteLine();
            //arreglo con todos los ARCHIVOS que estan en el directorio indicado por la ruta
            string[] archivos = Directory.GetFiles(ruta);
            Console.WriteLine("Archivos");
            foreach (string a in archivos)
            {
                //accedemos a toda la informacion del archivo
                FileInfo info = new FileInfo(a);
                double kb = info.Length / 1024.0;
                Console.WriteLine("Nombre del archivo: " + info.Name + " Tamaño: " + kb.ToString("F2") + " kb");//toString redondea a 2 decimales
            }

            //unimos el ultimo nombre de la carpata con el archivo.csv
            string rutaCSV = Path.Combine(ruta, "reportes_archivo.csv");

            StreamWriter sw = new StreamWriter(rutaCSV);

            sw.WriteLine("Nombre , Tamaño , Fecha ");

            foreach (string a in archivos)
            {
                //accedemos a toda la informacion del archivo
                FileInfo info = new FileInfo(a);
                double kb = info.Length / 1024.0;
                sw.WriteLine(info.Name + " ," + kb.ToString("F2") + " kb ," + info.LastWriteTime);
            }
            sw.Close();
        }
    }
}
