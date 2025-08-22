using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Portfolio.Application.Interfaces;

namespace Portfolio.Infrastructure.Service
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;

        public FileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        #region save or replace file
        public async Task<string> SaveOrReplaceAsync(IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var existingFiles = Directory.GetFiles(folderPath);
            foreach (var filePath in existingFiles)
            {
                File.Delete(filePath);
            }

            var dbFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var physicalPath = Path.Combine(folderPath, dbFileName);

            using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return dbFileName;
        }
        #endregion

        #region save file
        public async Task<string> SaveFileAsync(IFormFile file, string folderName, string fileName)
        {
            var folderPath = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = Path.Combine("/", folderName, fileName).Replace("\\", "/");
            return relativePath;
        }
        #endregion

        #region generate file path for saving
        public Task<string> GenerateFilePath(string folderName, string originalFileName)
        {
            if (string.IsNullOrWhiteSpace(originalFileName))
                throw new ArgumentException("Original file name is required.");

            var extension = Path.GetExtension(originalFileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var relativePath = Path.Combine("/", folderName, fileName).Replace("\\", "/");

            return Task.FromResult(relativePath);
        }
        #endregion

        #region delete file
        public async Task DeleteFileAsync(string folderName, string fileName)
        {
            var folderPath = Path.Combine(_env.WebRootPath, folderName);
            var fullPath = Path.Combine(folderPath, fileName);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            await Task.CompletedTask;
        }
        #endregion
    }
}
