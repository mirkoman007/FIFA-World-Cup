using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.FileManager
{
    public class FavoritePlayersFM
    {
        private static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string folder = Path.Combine(myDocumentsPath, "FIFA World Cup", "Favorite players");

        public static void AddFavoritePlayersData(string competition, string fifaCode, int num)
        {
            List<int> favoritePlayers = LoadFavoritePlayersData(competition.ToString(), fifaCode);
            favoritePlayers.Add(num);
            if (!Directory.Exists($"{folder}/{competition}"))
            {
                Directory.CreateDirectory($"{folder}/{competition}");
            }
            using (StreamWriter writer = new StreamWriter($"{folder}/{competition}/{fifaCode}.txt"))
            {
                foreach (int player in favoritePlayers)
                {
                    writer.Write(player);
                    writer.Write(Environment.NewLine);
                }
            }
        }
        public static void RemoveFavoritePlayersData(string competition, string fifaCode, int num)
        {
            List<int> favoritePlayers = LoadFavoritePlayersData(competition.ToString(), fifaCode);
            favoritePlayers.Remove(num);

            using (StreamWriter writer = new StreamWriter($"{folder}/{competition}/{fifaCode}.txt"))
            {
                foreach (int player in favoritePlayers)
                {
                    writer.Write(player);
                    writer.Write(Environment.NewLine);
                }
            }
        }

        public static List<int> LoadFavoritePlayersData(string competition, string fifaCode)
        {
            List<int> list=new List<int>();
            if (File.Exists($"{folder}/{competition}/{fifaCode}.txt"))
            {
                int igrac;
                using (StreamReader reader = new StreamReader($"{folder}/{competition}/{fifaCode}.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        igrac = int.Parse(reader.ReadLine());
                        list.Add(igrac);
                    }
                }
            }
            return list;
        }
    }
}
