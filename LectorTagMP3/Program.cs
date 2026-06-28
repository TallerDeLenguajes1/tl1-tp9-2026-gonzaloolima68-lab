using System;
using System.Data.SqlTypes;
using System.Text;
using EstructuraTag;
using System.IO;

namespace punto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la ruta en donde se encuentra el Archivo MP3");
            string ruta = Console.ReadLine()!;

            while (!File.Exists(ruta))
            {
                Console.WriteLine("El archivo no existe.");
                Console.WriteLine("Ingrese otra ruta:");
                ruta = Console.ReadLine()!;
            }
            //FilesStream metodo de lectura binaria,lo abrimos con el Mode.open y los leemos con el Access.Read
            FileStream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            // retrocedemos 128 bits desde el final del archivo para obtener el tag
            archivo.Seek(-128, SeekOrigin.End);

            //leemos los bits del archivo
            BinaryReader bits = new BinaryReader(archivo);

            //guardamos los 128 bytes del tag
            byte[] dato = bits.ReadBytes(128);

            //convertimos los arreglo de byts en texto y con el GetString leemos desde la posicion 0 y 3 lugares mas
            String Header = Encoding.GetEncoding("latin1").GetString(dato, 0, 3);
            //eliminamos los espacios no ocupados con trim();
            String Titulo = Encoding.GetEncoding("latin1").GetString(dato, 3, 30).Trim();
            String Artista = Encoding.GetEncoding("latin1").GetString(dato, 33, 30).Trim();
            String Albun = Encoding.GetEncoding("latin1").GetString(dato, 63, 30).Trim();
            String Año = Encoding.GetEncoding("latin1").GetString(dato, 93, 4).Trim();
            String Comentario = Encoding.GetEncoding("latin1").GetString(dato, 97, 30).Trim();
            String Genero = Encoding.GetEncoding("latin1").GetString(dato, 127, 1);

            tagID3v1 tag = new tagID3v1();

            tag.Titulo = Titulo;
            tag.Artista = Artista;
            tag.Albun = Albun;
            tag.Año = Año;
            tag.Comentario = Comentario;
            tag.Genero = Genero;

            Console.WriteLine("Informacion de la Cancion");
            Console.WriteLine("");
            Console.WriteLine("Titulo: "+tag.Titulo);
            Console.WriteLine("Artista: "+tag.Artista);
            Console.WriteLine("Albun: "+tag.Albun);
            Console.WriteLine("Año: "+tag.Año);
            Console.WriteLine("Genero:"+tag.Genero);

        }
    }
}
