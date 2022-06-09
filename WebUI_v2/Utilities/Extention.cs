using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebUI_v2.Utilities
{
    public static class Extention
    {
        public static bool CheckFileSize(this IFormFile file,int kb)
        {
            return file.Length / 1024 <= kb;
        }

        public static bool CheckFileType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static async Task<string> SaveFileAsync(this IFormFile file, string root , params string[] folders)
        {
            var fileName = Guid.NewGuid().ToString() + file.FileName;

            var resultPath = Path.Combine(Utility.GetPath(root,folders), fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
