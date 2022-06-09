using Microsoft.AspNetCore.Http;
using System;
using System.IO;

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

        public static string SaveFile(this IFormFile file, string root , string[] folders)
        {
            var fileName = Guid.NewGuid().ToString() + file.FileName;

            var resultPath = Path.Combine(GetPath(root,folders), fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

        private static string GetPath(string root,string[] folders)
        {
            string resultPath = root;
            foreach(string folder in folders)
            {
                resultPath = Path.Combine(resultPath, folder);    
            }
            return resultPath;
        }
    }
}
