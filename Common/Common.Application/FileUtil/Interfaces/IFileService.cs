using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Common.Application.FileUtil.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Save File With Origin FileName
        /// </summary>
        /// <param name="file"></param>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        Task SaveFile(IFormFile file,string directoryPath);

        /// <summary>
        /// Saves the file with a unique name and returns the file name
        /// </summary>
        /// <param name="file"></param>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        Task<string> SaveFileAndGenerateName(IFormFile file,string directoryPath);
        void DeleteFile(string path, string fileName);
        void DeleteFile(string filePath);
        void DeleteDirectory(string directoryPath);
    }
}
