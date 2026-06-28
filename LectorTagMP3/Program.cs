using System;
using System.Data.SqlTypes;
using System.Text;
using EstructuraTag;

namespace punto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la ruta en donde se encuentra el Archivo MP3");
            string? ruta=Console.ReadLine();
            
            //FilesStream metodo de lectura binaria,lo abrimos con el Mode.open y los leemos con el Access.Read
            FileStream archivo=new FileStream(ruta,FileMode.Open,FileAccess.Read);

            // retrocedemos 128 bits desde el final del archivo para obtener el tag
            archivo.Seek(-128.seekOrigin.End);

            //leemos los bits del archivo
            BinaryReader bits=new BinaryReader(archivo);
            
            //guardamos los 128 bytes del tag
            byte[] dato=bits.Read(128);

            //convertimos los arreglo de byts en texto y con el GetString leemos desde la posicion 0 a la 3
            String Header=Encoding.GetEncoding("latin1").GetString(dato,0,3);
            //eliminamos los espacios no ocupados con trim();
            String Titulo=Encoding.GetEncoding("latin1").GetString(dato,3,33).Trim();
            String Artista=Encoding.GetEncoding("latin1").GetString(dato,33,3);
            String Albun=Encoding.GetEncoding("latin1").GetString(dato,0,3);
            String Año=Encoding.GetEncoding("latin1").GetString(dato,0,3);
            String Comentario=Encoding.GetEncoding("latin1").GetString(dato,0,3);
            String Genero=Encoding.GetEncoding("latin1").GetString(dato,0,3);

        }
    }
}
