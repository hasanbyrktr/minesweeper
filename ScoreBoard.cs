using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace minesweeper
{
    public static class ScoreBoard
    {
        private static readonly string filePath = "scores.txt";  // Skorların saklanacağı dosya yolu
        private static List<PlayerScore> scores = new List<PlayerScore>();

        // Skorları dosyadan yükleme
        public static void LoadScores()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('-');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int score))
                    {
                        scores.Add(new PlayerScore(parts[0].Trim(), score));
                    }
                }
            }
            // Skorları büyükten küçüğe sıralayıp ilk 10'u alıyoruz
            scores = scores.OrderByDescending(s => s.Score).Take(10).ToList();
        }

        // Skoru dosyaya kaydetme
        public static void SaveScores()
        {
            // Skorları büyükten küçüğe sıralayıp ilk 10'u alıyoruz
            var topScores = scores.OrderByDescending(s => s.Score).Take(10).ToList();
            var lines = topScores.Select(s => $"{s.PlayerName} - {s.Score}").ToArray();
            File.WriteAllLines(filePath, lines);
        }

        // Skora yeni bir oyuncu ekleme
        public static void AddScore(string playerName, int score)
        {
            scores.Add(new PlayerScore(playerName, score));
            // Skorları tekrar sıralayıp yalnızca ilk 10'u tutuyoruz
            scores = scores.OrderByDescending(s => s.Score).Take(10).ToList();
            SaveScores();  // Yeni skoru dosyaya kaydediyoruz
        }

        // Formatlı skorları döndürme
        public static string GetFormattedScores()
        {
            var formattedScores = "";
            for (int i = 0; i < scores.Count; i++)
            {
                formattedScores += $"{i + 1}. {scores[i].PlayerName} - {scores[i].Score} puan\n";
            }
            return formattedScores;
        }
    }

    // PlayerScore sınıfı
    public class PlayerScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public PlayerScore(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}
