using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class selectionForm : Form
    {
        public string PlayerName { get; set; }
        public selectionForm()
        {
            InitializeComponent();
        }

        private void selectionForm_Load(object sender, EventArgs e)
        {

        }

        // selectionFormda butona tıklandığında
        private void startButton_Click(object sender, EventArgs e)
        {
            PlayerName = textBox1.Text.Trim();
            // Eğer isim boşsa
            if (string.IsNullOrEmpty(PlayerName))
            {
                MessageBox.Show("Lütfen bir isim girin.");
                return;
            }
            int size = 0;

            // RadioButton'ların kontrol edilmesi
            if (radioBtn10.Checked)
                size = 10;
            else if (radioBtn20.Checked)
                size = 20;
            else if (radioBtn30.Checked)
                size = 30;
            else
            {
                MessageBox.Show("Lütfen bir grid boyutu seçin.");
                return;
            }

            // Mayın sayısını kontrol et
            string mayinDegeri = MineTextBox.Text;
            if (int.TryParse(mayinDegeri, out int mayinSayisi) && mayinSayisi >= 10 && mayinSayisi <= size * size)
            {
                gameForm game = new gameForm(size, mayinSayisi,PlayerName);
                game.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir mayın sayısı girin.");
            }
        }


    }
}
