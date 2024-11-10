using System;
using System.Collections.Generic;
using System.Drawing;

namespace minesweeper
{
    public class Game
    {
        public int Size { get; private set; }
        public int MineCount { get; private set; }
        public List<Point> Mines { get; private set; }
        private int[,] grid; // 0: boş, 1: mayın, diğer değerler çevredeki mayın sayısı

        public Game(int size, int mineCount)
        {
            Size = size;
            MineCount = mineCount;
            Mines = new List<Point>();
            grid = new int[Size, Size];
        }

        public void StartGame()
        {
            // Mayınları yerleştir
            PlaceMines();
            // Hücre değerlerini ayarla (çevredeki mayın sayısı)
            CalculateSurroundingMines();
        }

        // Grid'in 2D bir dizi olduğunu varsayalım, her hücre bir Point veya benzeri bir türdür
        public List<Point> GetNeighbors(Point location)
        {
            List<Point> neighbors = new List<Point>();
            int[] directions = new int[] { -1, 0, 1 }; // Yönler: Yukarı, Aşağı, Sol, Sağ

            foreach (int dx in directions)
            {
                foreach (int dy in directions)
                {
                    if (dx == 0 && dy == 0) continue; // Aynı hücreyi atla
                    Point neighbor = new Point(location.X + dx, location.Y + dy);

                    // Eğer komşu hücre grid'in sınırları içindeyse, listeye ekle
                    if (neighbor.X >= 0 && neighbor.X < Size && neighbor.Y >= 0 && neighbor.Y < Size)
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }
            return neighbors;
        }

        private void PlaceMines()
        {
            Random rand = new Random();
            while (Mines.Count < MineCount)
            {
                int x = rand.Next(0, Size);
                int y = rand.Next(0, Size);
                if (!Mines.Contains(new Point(x, y)))
                {
                    Mines.Add(new Point(x, y));
                    grid[x, y] = -1; // -1 mayın
                }
            }
        }

        private void CalculateSurroundingMines()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (grid[i, j] == -1)
                        continue;

                    int surroundingMines = 0;
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int nx = i + dx, ny = j + dy;
                            if (nx >= 0 && nx < Size && ny >= 0 && ny < Size && grid[nx, ny] == -1)
                                surroundingMines++;
                        }
                    }
                    grid[i, j] = surroundingMines;
                }
            }
        }

        public bool CheckCell(Point location)
        {
            return grid[location.X, location.Y] != -1;
        }

        public int GetCellValue(Point location)
        {
            return grid[location.X, location.Y];
        }
    }
}
