namespace ImageKeep.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string CaminhoFoto { get; set; }
         public byte[] Imagem { get; set; }
        public DateTime DataUpload { get; set; } = DateTime.Now;
    }
}