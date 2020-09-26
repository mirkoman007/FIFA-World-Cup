using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BasicSettingsFM
    {
        private static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string folder = Path.Combine("FIFA World Cup", "Settings");
        private static string destFolder = Path.Combine(myDocumentsPath, folder);


        public static bool IsExistSetting(SettingChoise choise)
        {
            string destFile = Path.Combine(destFolder, $"{choise.ToString()}.txt");

            if (File.Exists(destFile))
                return true;
            else
                return false;
        }

        public static void SetFifaCode(string value)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            using (StreamWriter writer = new StreamWriter($"{destFolder}/FifaCode.txt"))
                writer.Write(value);
        }
        public static string GetFifaCode()
        {
            string rez = "";
            if (File.Exists($"{destFolder}/FifaCode.txt"))
            {
                using (StreamReader reader = new StreamReader($"{destFolder}/FifaCode.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        rez = reader.ReadLine();
                    }
                }
            }
            return rez;
        }

        public static void SetSetting(SettingChoiseInt choise, int value)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            using (StreamWriter writer = new StreamWriter($"{destFolder}/{choise.ToString()}.txt"))
                writer.Write(value);

        }

        public static Language GetLanguage()
        {
            string rez = "";
            if (File.Exists($"{destFolder}/Language.txt"))
            {
                using (StreamReader reader = new StreamReader($"{destFolder}/Language.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        rez = reader.ReadLine();
                    }
                }
            }
            return (Language)int.Parse(rez);
        }

        public static Competition GetCompetition()
        {
            string rez = "";
            if (File.Exists($"{destFolder}/Competition.txt"))
            {
                using (StreamReader reader = new StreamReader($"{destFolder}/Competition.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        rez = reader.ReadLine();
                    }
                }
            }
            return (Competition)int.Parse(rez);
        }
        public static Resolution GetResolution()
        {
            string rez = "";
            if (File.Exists($"{destFolder}/Resolution.txt"))
            {
                using (StreamReader reader = new StreamReader($"{destFolder}/Resolution.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        rez = reader.ReadLine();
                    }
                }
            }
            return (Resolution)int.Parse(rez);
        }


        public enum Competition
        {
            Male=0,
            Female=1
        }

        public enum Language
        {
            EN=0,
            HR=1
        }
        public enum Resolution
        {
            r720=0,
            rFull=1,
            r1080=2,
            r900=3
        }
        
        public enum SettingChoise
        {
            Competition=0,
            Language=1,
            Resolution=2,
            FifaCode=3
        }
        public enum SettingChoiseInt
        {
            Competition=0,
            Language=1,
            Resolution=2
        }

    }
}
