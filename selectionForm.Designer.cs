namespace minesweeper
{
    partial class selectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectionForm));
            label1 = new Label();
            label2 = new Label();
            MineTextBox = new MaskedTextBox();
            startButton = new Button();
            radioBtn10 = new RadioButton();
            radioBtn20 = new RadioButton();
            radioBtn30 = new RadioButton();
            label3 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(1, 27);
            label1.Name = "label1";
            label1.Size = new Size(360, 28);
            label1.TabIndex = 0;
            label1.Text = "Harita büyüklüğünü seçiniz (10-30)";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(1, 105);
            label2.Name = "label2";
            label2.Size = new Size(328, 28);
            label2.TabIndex = 1;
            label2.Text = "Mayın sayısı giriniz ( min 10 - ..)";
            // 
            // MineTextBox
            // 
            MineTextBox.BackColor = SystemColors.ActiveCaption;
            MineTextBox.Location = new Point(12, 147);
            MineTextBox.Mask = "000";
            MineTextBox.Name = "MineTextBox";
            MineTextBox.Size = new Size(32, 27);
            MineTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            startButton.Location = new Point(197, 250);
            startButton.Name = "startButton";
            startButton.Size = new Size(132, 41);
            startButton.TabIndex = 4;
            startButton.Text = "Hadi Başla!";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // radioBtn10
            // 
            radioBtn10.AutoSize = true;
            radioBtn10.Location = new Point(12, 69);
            radioBtn10.Name = "radioBtn10";
            radioBtn10.Size = new Size(69, 24);
            radioBtn10.TabIndex = 5;
            radioBtn10.TabStop = true;
            radioBtn10.Text = "10x10";
            radioBtn10.UseVisualStyleBackColor = true;
            // 
            // radioBtn20
            // 
            radioBtn20.AutoSize = true;
            radioBtn20.Location = new Point(87, 69);
            radioBtn20.Name = "radioBtn20";
            radioBtn20.Size = new Size(69, 24);
            radioBtn20.TabIndex = 6;
            radioBtn20.TabStop = true;
            radioBtn20.Text = "20x20";
            radioBtn20.UseVisualStyleBackColor = true;
            // 
            // radioBtn30
            // 
            radioBtn30.AutoSize = true;
            radioBtn30.Location = new Point(162, 69);
            radioBtn30.Name = "radioBtn30";
            radioBtn30.Size = new Size(69, 24);
            radioBtn30.TabIndex = 7;
            radioBtn30.TabStop = true;
            radioBtn30.Text = "30x30";
            radioBtn30.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(1, 187);
            label3.Name = "label3";
            label3.Size = new Size(81, 28);
            label3.TabIndex = 8;
            label3.Text = "Adınız:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.Location = new Point(12, 218);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 9;
            // 
            // selectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(360, 303);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(radioBtn30);
            Controls.Add(radioBtn20);
            Controls.Add(radioBtn10);
            Controls.Add(startButton);
            Controls.Add(MineTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "selectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MaskedTextBox MapTextBox;
        private MaskedTextBox MineTextBox;
        private Button startButton;
        private RadioButton radioBtn10;
        private RadioButton radioBtn20;
        private RadioButton radioBtn30;
        private Label label3;
        private TextBox textBox1;
    }
}