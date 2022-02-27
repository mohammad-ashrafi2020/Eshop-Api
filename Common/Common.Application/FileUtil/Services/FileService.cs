using Common.Application.FileUtil.Interfaces;
using Common.Application.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.FileUtil.Services
{
    public class FileService : IFileService
    {
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }

        public void DeleteFile(string path, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path,
                  fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public async Task SaveFile(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);
            using var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);
        }

        public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                          .Replace(":", "")
                                          .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }
    }
}