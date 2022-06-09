using System.IO;

namespace WebUI_v2.Utilities
{
    public class Utility
    {
        public static string GetPath(string root, params string[] folders)
        {
            string resultPath = root;
            foreach (string folder in folders)
            {
                resultPath = Path.Combine(resultPath, folder);
            }
            return resultPath;
        }
    }
}
