using SIGEBI.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Services
{
    public class LocalStorageService : IStorageService
    {
        private readonly IWebHostEnvironment _env;

        public LocalStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> GuardarImagenAsync(Stream archivoStream, string extensionArchivo, string nombreCarpeta = "imagenes")
        {
            if (archivoStream == null || archivoStream.Length == 0) return string.Empty;

            string nombreArchivo = $"{Guid.NewGuid()}{extensionArchivo}";

            // Asegurar una ruta válida incluso si WebRootPath es null
            string rootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string carpetaDestino = Path.Combine(rootPath, nombreCarpeta);

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            string rutaFisicaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            using (var fileStream = new FileStream(rutaFisicaCompleta, FileMode.Create))
            {
                if (archivoStream.CanSeek) archivoStream.Position = 0;
                await archivoStream.CopyToAsync(fileStream);
            }

            return $"/{nombreCarpeta.Replace("\\", "/")}/{nombreArchivo}";
        }
    }
}