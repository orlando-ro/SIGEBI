
namespace SIGEBI.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> GuardarImagenAsync(Stream archivoStream, string extensionArchivo, string nombreCarpeta = "imagenes");
    }
}
