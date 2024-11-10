using System;
using System.Drawing;
using System.Windows.Forms;

using minesweeper;
namespace minesweeper
{
    // GameForm
    public partial class gameForm : Form
    {
        private string playerName; // Oyuncunun ismini tutacak değişken
        private int gridSize; // Grid boyutu
        private int mineCount; // Mayın sayısı
        private Button[,] gridButtons; // Butonlar
        private System.Windows.Forms.Timer gameTimer; // Zamanlayıcı
        private int elapsedTime; // Geçen süre
        private int moveCount; // Hamle sayısı
        private int correctFlags; // Doğru bayrak sayısı
        private Game game; // Oyun nesnesi

        public gameForm(int size, int mines, string playerName)
        {
            InitializeComponent();

            this.playerName = playerName; // Oyuncu ismini alıyoruz
            gridSize = size; // Grid boyutunu alıyoruz
            mineCount = mines; // Mayın sayısını alıyoruz
            game = new Game(gridSize, mineCount); // Oyun nesnesini başlatıyoruz
            gridButtons = new Button[gridSize, gridSize]; // Butonlar için array oluşturuyoruz
            game.StartGame(); // Oyun başlatılıyor
            InitializeGrid(); // Grid'i başlatıyoruz
            StartTimer(); // Zamanlayıcıyı başlatıyoruz
            moveCount = 0; // Hamle sayısını sıfırlıyoruz
            correctFlags = 0; // Doğru bayrak sayısını sıfırlıyoruz

            // Oyuncu ismini gösteren label'ı güncelle
            oyuncuLabel.Text = $"Oyuncu: {playerName}";
        }

        // Grid'i oluşturma fonksiyonu
        private void InitializeGrid()
        {
            int buttonSize = 30; // Buton boyutu
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(i * buttonSize, j * buttonSize),
                        Tag = new Point(i, j) // Butonun konumunu tag olarak ekliyoruz
                    };
                    btn.Click += GridButton_Click; // Butona tıklama olayı ekliyoruz
                    btn.MouseDown += GridButton_MouseDown; // Sağ tıklama olayını ekliyoruz
                    gridButtons[i, j] = btn; // Butonları grid'e ekliyoruz
                    panel3.Controls.Add(btn); // Panel3'e butonları ekliyoruz
                }
            }
        }
        private void StartTimer()
        {
            gameTimer = new System.Windows.Forms.Timer(); // Zamanlayıcı nesnesi
            gameTimer.Interval = 1000; // Her saniye çalışacak
            gameTimer.Tick += (sender, e) =>
            {
                elapsedTime++; // Geçen zamanı artırıyoruz
                UpdateTimeLabel(); // Süreyi güncelliyoruz
            };
            gameTimer.Start(); // Zamanlayıcıyı başlatıyoruz
        }

        // Zamanlayıcı etiketini güncelleyen fonksiyon
        private void UpdateTimeLabel()
        {
            sureLabel.Text = $"SÜRE : {elapsedTime}s"; // Süreyi label'a yazdırıyoruz
        }
        private void CheckWinCondition()
        {
            // Tüm mayınlar doğru işaretlendi mi?
            bool allMinesFlagged = correctFlags == mineCount;

            // Mayın olmayan tüm hücreler açıldı mı?
            bool allSafeCellsRevealed = true;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Point currentPoint = new Point(i, j);
                    Button currentButton = gridButtons[i, j];

                    // Eğer bu nokta mayın değilse ve hala açılmamışsa (F değilse ve boşsa)
                    if (!game.Mines.Contains(currentPoint) &&
                        (currentButton.Text == "" || currentButton.Text == "F"))
                    {
                        allSafeCellsRevealed = false;
                        break;
                    }
                }
                if (!allSafeCellsRevealed) break;
            }

            // Eğer her iki koşul da sağlanıyorsa oyun kazanılmış demektir
            if (allMinesFlagged && allSafeCellsRevealed)
            {
                Win();
            }
        }
        private void Win()
{
    // Zamanlayıcıyı durdur
    gameTimer.Stop();

    // Orijinal skor hesaplama sistemini kullan
    int score = correctFlags / elapsedTime * 1000;

    // Kazanma mesajını göster
    MessageBox.Show($"Tebrikler {playerName}! Oyunu Kazandınız!\n\n" +
                   $"Hamle: {moveCount}\n" +
                   $"Süre: {elapsedTime}s\n" +
                   $"Doğru Bayraklar: {correctFlags}\n" +
                   $"Skor: {score}",
                   "Oyun Kazanıldı!", 
                   MessageBoxButtons.OK, 
                   MessageBoxIcon.Information);

    // Skoru kaydet
    string scoreEntry = $"{playerName}: {score} points (WIN!) - {DateTime.Now}";
    try
    {
        File.AppendAllText("Scores.txt", scoreEntry + Environment.NewLine);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Skor kaydedilirken bir hata oluştu: " + ex.Message);
    }

    // Tüm mayınların yerlerini turuncu renkle göster
    foreach (var mine in game.Mines)
    {
        Button button = gridButtons[mine.X, mine.Y];
        button.BackColor = Color.Orange;
    }

    // Tüm butonları devre dışı bırak
    DisableAllButtons();

    // Yeniden başlama butonunu göster
    ShowRestartButton();
}

        // Sağ tıklama olayı (bayrak ekleyip, butonu tıklanamaz yapma)
        private void GridButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = sender as Button;
                Point location = (Point)button.Tag;

                if (button.Text == "F") // Eğer bayrak varsa
                {
                    // Bayrağı kaldırma işlemi
                    button.Text = "";
                    button.Enabled = true;
                    button.BackColor = SystemColors.Control;
                    button.UseVisualStyleBackColor = true;

                    // Eğer bu konumda gerçekten mayın varsa doğru bayrak sayısını azalt
                    if (game.Mines.Any(m => m.X == location.X && m.Y == location.Y))
                    {
                        correctFlags--;
                    }
                }
                else if (string.IsNullOrEmpty(button.Text)) // Eğer hücre boşsa ve açılmamışsa
                {
                    // Bayrak ekleme işlemi
                    button.Text = "F";
                    button.Enabled = false;
                    button.BackColor = Color.Yellow;

                    // Eğer bu konumda gerçekten mayın varsa doğru bayrak sayısını artır
                    if (game.Mines.Any(m => m.X == location.X && m.Y == location.Y))
                    {
                        correctFlags++;
                    }
                }
                CheckWinCondition(); // Her bayrak işleminden sonra kazanma durumunu kontrol et
                // Kalan mayın sayısını güncelle (opsiyonel - eğer gösteriyorsanız)
                int remainingMines = mineCount - correctFlags;
                mayinLabel.Text = $"Kalan Mayın: {remainingMines}";
            }
        }

        // Buton tıklama olayı (sol tıklama)
        private void GridButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Point location = (Point)button.Tag; // Butonun konumunu alıyoruz

            if (game.CheckCell(location))
            {
                button.Text = game.GetCellValue(location).ToString(); // Hücredeki değeri butona yazdır
                button.BackColor = Color.DimGray; // Sol tıklanmış buton gri renk olacak
                moveCount++; // Hamle sayısını artırıyoruz
                hamleLabel.Text = $"HAMLE: {moveCount}"; // Hamleyi label'a yansıtıyoruz

                // Eğer hücrede 0 varsa, etrafındaki hücreleri aç
                if (game.GetCellValue(location) == 0)
                {
                    FloodFill(location); // Boş hücreler etrafında olanları açıyoruz
                }
                CheckWinCondition(); // Her hamleden sonra kazanma durumunu kontrol et
            }
            else
            {
                button.BackColor = Color.Red; // Mayına basıldığında buton kırmızı olacak
                GameOver(); // Game Over fonksiyonunu çağır
            }
        }

        // Boş hücreleri açan fonksiyon
        private void FloodFill(Point location)
        {
            Stack<Point> cellsToCheck = new Stack<Point>();
            HashSet<Point> visitedCells = new HashSet<Point>(); // Ziyaret edilen hücreleri takip etmek için
            cellsToCheck.Push(location);

            while (cellsToCheck.Count > 0)
            {
                Point current = cellsToCheck.Pop();

                // Grid sınırları dışındaysa veya zaten ziyaret edilmişse atla
                if (current.X < 0 || current.X >= gridSize ||
                    current.Y < 0 || current.Y >= gridSize ||
                    visitedCells.Contains(current))
                    continue;

                visitedCells.Add(current);
                Button currentButton = gridButtons[current.X, current.Y];

                // Eğer bayrak konulmuşsa bu hücreyi atla
                if (currentButton.Text == "F")
                    continue;

                // Hücreyi aç
                int cellValue = game.GetCellValue(current);
                currentButton.Text = cellValue.ToString();
                currentButton.BackColor = Color.DimGray;
                currentButton.Enabled = false;
                

                // Eğer bu hücrede 0 varsa, etrafındaki hücreleri de kontrol et
                if (cellValue == 0)
                {
                    // Tüm komşu hücreleri ekle
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue; // Kendisini atlama

                            Point neighbor = new Point(current.X + dx, current.Y + dy);
                            cellsToCheck.Push(neighbor);
                        }
                    }
                }
            }

           
        }

        // Game Over işlemi
        // Game Over işlemi
        private void GameOver()
        {
            gameTimer.Stop();
            // Calculate score (flags * time * 1000)
            int score = correctFlags / elapsedTime * 1000;

            // Display Game Over message and score
            MessageBox.Show($"Game Over! Hamleler: {moveCount}, Zaman: {elapsedTime}s, Doğru Bayraklar: {correctFlags}, Puan: {score}",
                             "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Prepare the score entry
            string scoreEntry = $"{playerName}: {score} points - {DateTime.Now}";

            // Specify the file path
            string filePath = "Scores.txt";

            // Append the score entry to the file
            try
            {
                File.AppendAllText(filePath, scoreEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the score: " + ex.Message);
            }

            RevealMines(); 
            ShowRestartButton();
            DisableAllButtons();
        }

        // Mayınları gösterme fonksiyonu
        private void RevealMines()
        {
            foreach (var mine in game.Mines)
            {
                Point mineLocation = mine;
                Button button = gridButtons[mineLocation.X, mineLocation.Y];

                if (button.Text == "F") // Doğru tahmin edilen bayraklar
                {
                    button.BackColor = Color.Orange; // Doğru bayraklar turuncu olsun
                }
                else // Bulunamayan mayınlar
                {
                    button.Text = "X"; // Mayınları "X" ile gösteriyoruz
                    button.BackColor = Color.Red; // Diğer mayınların arka planını kırmızı yapıyoruz
                }

                button.Enabled = false; // Tüm mayınlı butonları disable et
            }

            // Yanlış konulan bayrakları da göster (opsiyonel)
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = gridButtons[i, j];
                    if (button.Text == "F" && !game.Mines.Any(m => m.X == i && m.Y == j))
                    {
                        // Yanlış konulan bayrakları farklı bir renkle göster
                        button.BackColor = Color.Gray;
                        button.Enabled = false;
                    }
                }
            }
        }
        // Yeniden başlatma butonunu ekleyen fonksiyon
        private void ShowRestartButton()
        {
            Button restartButton = new Button
            {
                Text = "Yeniden Başla",
                Size = new Size(100, 50),
                Location = new Point(10, 10) // Ekranın köşesine yerleştiriyoruz
            };
            restartButton.Click += restartButton_Click; // Yeniden başlatma butonuna tıklama olayını ekliyoruz
            Controls.Add(restartButton); // Butonu ekliyoruz
        }

        // Yeniden başlatma butonuna tıklama fonksiyonu
        private void restartButton_Click(object sender, EventArgs e)
        {
            selectionForm selectionForm = new();
            //opening the form
            selectionForm.Show();
            this.Hide();
        
        }
        private void DisableAllButtons()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    gridButtons[i, j].Enabled = false;
                }
            }
        }

        

        private void scoreBoard_Click(object sender, EventArgs e)
        {
            ScoreBoardForm scoreBoardForm = new();
            //opening the form
            scoreBoardForm.Show();

        }

        private void gameForm_Load(object sender, EventArgs e)
        {

        }
    }
}