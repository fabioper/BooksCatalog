using System.Threading.Tasks;

namespace BooksCatalog.Infra.Services.Storage.Contracts
{
    public interface IStorageService
    {
        Task<string> UploadFile(byte[] stream, string filename, string container);
    }
}