namespace minesweeper
{
    partial class gameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameForm));
            timer1 = new System.Windows.Forms.Timer(components);
            bilgiLabel = new Label();
            panel1 = new Panel();
            hamleLabel = new Label();
            sureLabel = new Label();
            panel2 = new Panel();
            restartButton = new Button();
            oyuncuLabel = new Label();
            scoreBoard = new Button();
            panel3 = new Panel();
            mayinLabel = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // bilgiLabel
            // 
            bilgiLabel.AutoSize = true;
            bilgiLabel.BackColor = SystemColors.ControlLight;
            bilgiLabel.BorderStyle = BorderStyle.Fixed3D;
            bilgiLabel.Location = new Point(3, 8);
            bilgiLabel.Name = "bilgiLabel";
            bilgiLabel.Size = new Size(194, 22);
            bilgiLabel.TabIndex = 0;
            bilgiLabel.Text = "240229090 Hasan Bayraktar";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(mayinLabel);
            panel1.Controls.Add(hamleLabel);
            panel1.Controls.Add(sureLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(978, 78);
            panel1.TabIndex = 1;
            // 
            // hamleLabel
            // 
            hamleLabel.AutoSize = true;
            hamleLabel.BackColor = SystemColors.ControlLight;
            hamleLabel.BorderStyle = BorderStyle.Fixed3D;
            hamleLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            hamleLabel.Location = new Point(606, 26);
            hamleLabel.Name = "hamleLabel";
            hamleLabel.Size = new Size(96, 33);
            hamleLabel.TabIndex = 1;
            hamleLabel.Text = "HAMLE";
            // 
            // sureLabel
            // 
            sureLabel.AutoSize = true;
            sureLabel.BackColor = SystemColors.ControlLight;
            sureLabel.BorderStyle = BorderStyle.Fixed3D;
            sureLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            sureLabel.Location = new Point(10, 26);
            sureLabel.Name = "sureLabel";
            sureLabel.Size = new Size(85, 33);
            sureLabel.TabIndex = 0;
            sureLabel.Text = "SÜRE :";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(restartButton);
            panel2.Controls.Add(oyuncuLabel);
            panel2.Controls.Add(scoreBoard);
            panel2.Controls.Add(bilgiLabel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 911);
            panel2.Name = "panel2";
            panel2.Size = new Size(978, 38);
            panel2.TabIndex = 2;
            // 
            // restartButton
            // 
            restartButton.BackColor = SystemColors.ControlLight;
            restartButton.Location = new Point(737, 4);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(105, 29);
            restartButton.TabIndex = 3;
            restartButton.Text = "Yeni Oyun";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += restartButton_Click;
            // 
            // oyuncuLabel
            // 
            oyuncuLabel.AutoSize = true;
            oyuncuLabel.BackColor = SystemColors.ControlLight;
            oyuncuLabel.BorderStyle = BorderStyle.FixedSingle;
            oyuncuLabel.Location = new Point(523, 8);
            oyuncuLabel.Name = "oyuncuLabel";
            oyuncuLabel.Size = new Size(71, 22);
            oyuncuLabel.TabIndex = 2;
            oyuncuLabel.Text = "Oyuncu : ";
            // 
            // scoreBoard
            // 
            scoreBoard.BackColor = SystemColors.ControlLight;
            scoreBoard.Location = new Point(859, 4);
            scoreBoard.Name = "scoreBoard";
            scoreBoard.Size = new Size(105, 29);
            scoreBoard.TabIndex = 1;
            scoreBoard.Text = "Skor Tablosu";
            scoreBoard.UseVisualStyleBackColor = false;
            scoreBoard.Click += scoreBoard_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(978, 833);
            panel3.TabIndex = 3;
            // 
            // mayinLabel
            // 
            mayinLabel.AutoSize = true;
            mayinLabel.BackColor = SystemColors.ControlLight;
            mayinLabel.BorderStyle = BorderStyle.Fixed3D;
            mayinLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            mayinLabel.Location = new Point(775, 26);
            mayinLabel.Name = "mayinLabel";
            mayinLabel.Size = new Size(175, 33);
            mayinLabel.TabIndex = 2;
            mayinLabel.Text = "KALAN MAYIN";
            // 
            // gameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 949);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "gameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Label bilgiLabel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label oyuncuLabel;
        private Button scoreBoard;
        private Label hamleLabel;
        private Label sureLabel;
        private Button restartButton;
        private Label mayinLabel;
    }
}