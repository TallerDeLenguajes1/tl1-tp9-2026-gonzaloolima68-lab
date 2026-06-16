using System;

using System.IO;

using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        string ruta;

        do
        {
            Console.WriteLine("Ingrese la ruta a la cual quiere acceder");
            ruta = Console.ReadLine();

            if (!Directory.Exists(ruta))
            {
                Console.WriteLine("la ruta no existe.");
            }
        } while (!Directory.Exists(ruta));

        Console.WriteLine("Carpetas:");
        string[] carpetas = Directory.GetDirectories(ruta);

        foreach (string c in carpetas)
        {
            Console.WriteLine(Path.GetFileName(c));
        }
        string[] files = Directory.GetFiles(ruta);
        List<Archivo> listadearchivos = new List<Archivo>();

        Console.WriteLine("Archivos");
        foreach (string f in files)
        {
            FileInfo info = new FileInfo(f);
            Archivo a = new Archivo();

            a.Name = info.Name;
            a.Tamanio = Math.Round(info.Length / 1024.0, 2); //redondea a 2 decimales
            a.Date = info.LastWriteTime;

            listadearchivos.Add(a);
            Console.WriteLine(a.Name + " " + a.Tamanio + "Kb");
        }

        string rutaCsv = Path.Combine(ruta, "reporte_archivos.csv");
        List<string> lineas = new List<string>();
        lineas.Add("Nombre,tamanio(KB),FechaDeModificacion");

        foreach (Archivo a in listadearchivos)
        {
            lineas.Add(a.Name + a.Tamanio + a.Date);
        }
        ;
        File.WriteAllLines(rutaCsv, lineas);
        Console.WriteLine("csv generado correctamente");

    }
}