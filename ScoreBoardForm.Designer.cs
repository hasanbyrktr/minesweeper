namespace minesweeper
{
    partial class ScoreBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoardForm));
            label1 = new Label();
            scoreListBox = new ListBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(323, 46);
            label1.TabIndex = 0;
            label1.Text = "EN İYİ 10 OYUNCU";
            // 
            // scoreListBox
            // 
            scoreListBox.FormattingEnabled = true;
            scoreListBox.Location = new Point(12, 78);
            scoreListBox.Name = "scoreListBox";
            scoreListBox.Size = new Size(150, 104);
            scoreListBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(10, 498);
            label2.Name = "label2";
            label2.Size = new Size(237, 20);
            label2.TabIndex = 2;
            label2.Text = "*Her yeni oyun başlattığınızda -\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label3.Location = new Point(12, 518);
            label3.Name = "label3";
            label3.Size = new Size(268, 20);
            label3.TabIndex = 3;
            label3.Text = "son oyununuzun skoru tabloya işlenir.";
            // 
            // ScoreBoardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(344, 560);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(scoreListBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ScoreBoardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Skor Tablosu";
            Load += ScoreBoardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label siralamaLabel;
        private ListBox scoreListBox;
        private Label label2;
        private Label label3;
    }
}