using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using ImageKeep.Models;
using Microsoft.AspNetCore.Http;
using System;
using ImageKeep.Data.DataContext;

namespace ImageKeep.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FotosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public FotosController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFoto([FromForm] IFormFile arquivo, [FromForm] string titulo, [FromForm] string descricao)
        {
            if (arquivo == null || arquivo.Length == 0)
                return BadRequest("Arquivo não selecionado");

            // Converte o arquivo de imagem em um array de bytes (byte[])
            byte[] imagemBytes;
            using (var memoryStream = new MemoryStream())
            {
                await arquivo.CopyToAsync(memoryStream);
                imagemBytes = memoryStream.ToArray();
            }

            // Cria um objeto Foto com a imagem em BLOB
            var foto = new Foto
            {
                Titulo = titulo,
                Descricao = descricao,
                Imagem = imagemBytes, // Armazena a imagem no banco como BLOB
                DataUpload = DateTime.Now
            };

            // Salva a foto no banco de dados
            _context.Fotos.Add(foto);
            await _context.SaveChangesAsync();

            return Ok("Foto salva com sucesso");
        }
    }
}
