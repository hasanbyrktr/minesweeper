using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace minesweeper
{
    public partial class ScoreBoardForm : Form
    {
        private string scoreFilePath = "scores.txt";

        public ScoreBoardForm()
        {
            InitializeComponent();
        }

        private void ScoreBoardForm_Load(object sender, EventArgs e)
        {
            LoadScores();
        }

        private void LoadScores()
        {
            List<string> scores = new List<string>();
            try
            {
                if (File.Exists(scoreFilePath))
                {
                    scores.AddRange(File.ReadAllLines(scoreFilePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Skorlar yüklenirken bir hata oluştu: " + ex.Message);
                return;
            }

            var sortedScores = scores
                .Select(line =>
                {
                    try
                    {
                        // Satırı parçalara ayır
                        var playerNamePart = line.Split(':')[0].Trim();
                        var restOfLine = line.Split(':')[1].Trim();
                        var pointsPart = restOfLine.Split('-')[0].Trim();
                        var points = int.Parse(pointsPart.Split(' ')[0]); // "points" kelimesini ayıklayıp sayıyı al
                        var datePart = restOfLine.Split('-')[1].Trim();

                        return new
                        {
                            PlayerName = playerNamePart,
                            Points = points,
                            DateTime = datePart,
                            OriginalLine = line
                        };
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(x => x != null)
                .OrderByDescending(x => x.Points)
                .Take(10);

            // Mevcut label'ları temizle
            Controls.Clear();

            // Başlık label'ı ekle
            Label titleLabel = new Label
            {
                Text = "En Yüksek Skorlar",
                Location = new Point(10, 10),
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                AutoSize = true
            };
            Controls.Add(titleLabel);

            int yOffset = 40;
            int rank = 1;

            foreach (var score in sortedScores)
            {
                Label scoreLabel = new Label
                {
                    Text = $"{rank}. {score.PlayerName}: {score.Points} points - {score.DateTime}",
                    Location = new Point(10, yOffset),
                    AutoSize = true
                };

                if (rank <= 3)
                {
                    scoreLabel.Font = new Font(scoreLabel.Font, FontStyle.Bold);
                }

                Controls.Add(scoreLabel);
                yOffset += 25;
                rank++;
            }
        }
    }
}