using SIGEBI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SIGEBI.Infrastructure.Services
{
    public class LocalStorageService : IStorageService
    {

        private readonly IWebHostEnvironment _env;
        public LocalStorageService(IWebHostEnvironment env) {

            _env = env;
        }
        public async Task<string> GuardarImagenAsync(Stream archivoStream, string extensionArchivo, string nombreCarpeta = "imagenes")
        {
            
            if (archivoStream == null || archivoStream.Length == 0) return string.Empty;

            
            string nombreArchivo = $"{Guid.NewGuid()}{extensionArchivo}";

            
            string carpetaDestino = Path.Combine(_env.WebRootPath, nombreCarpeta);

            
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

            
            return $"/{nombreCarpeta}/{nombreArchivo}";

        }
    }
}
