using System;

namespace minesweeper // Proje adýnýza göre namespace deðiþebilir
{
    public partial class welcomeForm : Form
    {
        public welcomeForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            selectionForm selectionForm = new();
            //opening the form
            selectionForm.Show();
            this.Hide();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}