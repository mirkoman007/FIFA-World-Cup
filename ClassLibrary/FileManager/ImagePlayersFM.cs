using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.FileManager
{
    public class ImagePlayersFM
    {
        public static string UploadImage(string filePath, string competition, string fifaCode, string playerName)
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folder = Path.Combine("FIFA World Cup", "Images", "Players");
            var team = Path.Combine(competition, fifaCode);

            string destFolder = Path.Combine(myDocumentsPath, folder, team);
            string destFile = Path.Combine(destFolder, $"{playerName}.png");


            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            if (File.Exists(destFile))
                File.Delete(destFile);

            File.Copy(filePath, destFile);
            return destFile;
        }

        public static string GetImage(string competition, string fifaCode, string playerName)
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folder = Path.Combine("FIFA World Cup", "Images", "Players");
            var team = Path.Combine(competition, fifaCode);

            string destFolder = Path.Combine(myDocumentsPath, folder, team);
            string destFile = Path.Combine(destFolder, $"{playerName}.png");

            return destFile;
        }

        public static bool HasCustomImage(string competition, string fifaCode, string playerName)
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folder = Path.Combine("FIFA World Cup", "Images", "Players");
            var team = Path.Combine(competition, fifaCode);

            string destFolder = Path.Combine(myDocumentsPath, folder, team);
            string destFile = Path.Combine(destFolder, $"{playerName}.png");


            if (!Directory.Exists(destFolder))
                return false;

            return File.Exists(destFile);
        }

        public static void DeleteImage(string competition, string fifaCode, string playerName)
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var folder = Path.Combine("FIFA World Cup", "Images", "Players");
            var team = Path.Combine(competition, fifaCode);

            string destFolder = Path.Combine(myDocumentsPath, folder, team);
            string destFile = Path.Combine(destFolder, $"{playerName}.png");

            File.Delete(destFile);
        }
    }
}
