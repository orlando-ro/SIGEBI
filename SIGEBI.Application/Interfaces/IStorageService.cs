using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SIGEBI.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> GuardarImagenAsync(Stream archivoStream, string extensionArchivo, string nombreCarpeta = "imagenes");
    }
}
