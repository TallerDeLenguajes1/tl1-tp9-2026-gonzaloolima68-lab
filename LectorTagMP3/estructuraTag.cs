namespace EstructuraTag
{
    public class tagID3v1
    {
        private string titulo="";
        private string artista="";
        private string albun="";
        private string año="";
        private string comentario="";
        private string genero="";

        public string Titulo {get=>titulo; set=>titulo=value;}
        public string Artista{get=>artista; set=>artista=value;}
        public string Albun{get=>albun; set=>albun=value;}
        public string Año{get=>año; set=>año=value;}
        public string Comentario{get=>comentario; set=>comentario=value;}
        public string Genero{get=>genero; set=>genero=value;}
    }
}