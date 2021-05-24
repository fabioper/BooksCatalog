using System.IO;
using System.Threading.Tasks;

namespace BooksCatalog.Application.Services.Contracts
{
    public interface IStorageService
    {
        Task<string> UploadFile(byte[] stream, string filename);
    }
}