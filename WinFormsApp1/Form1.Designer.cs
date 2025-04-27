namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            label5 = new Label();
            metodeChoices = new ComboBox();
            label2 = new Label();
            y2Field = new NumericUpDown();
            y1Field = new NumericUpDown();
            x2Field = new NumericUpDown();
            x1Field = new NumericUpDown();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)y2Field).BeginInit();
            ((System.ComponentModel.ISupportInitialize)y1Field).BeginInit();
            ((System.ComponentModel.ISupportInitialize)x2Field).BeginInit();
            ((System.ComponentModel.ISupportInitialize)x1Field).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 1;
            label1.Text = "Titik Awal";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(metodeChoices);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(y2Field);
            groupBox1.Controls.Add(y1Field);
            groupBox1.Controls.Add(x2Field);
            groupBox1.Controls.Add(x1Field);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 426);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 138);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 12;
            label5.Text = "Metode";
            // 
            // metodeChoices
            // 
            metodeChoices.FormattingEnabled = true;
            metodeChoices.Items.AddRange(new object[] { "Brute Force", "DDA", "Bressenham" });
            metodeChoices.Location = new Point(6, 156);
            metodeChoices.Name = "metodeChoices";
            metodeChoices.Size = new Size(188, 23);
            metodeChoices.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 82);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 8;
            label2.Text = "Titik Akhir";
            label2.Click += label2_Click;
            // 
            // y2Field
            // 
            y2Field.Location = new Point(101, 100);
            y2Field.Name = "y2Field";
            y2Field.Size = new Size(89, 23);
            y2Field.TabIndex = 7;
            y2Field.ValueChanged += y2Field_ValueChanged;
            // 
            // y1Field
            // 
            y1Field.Location = new Point(101, 45);
            y1Field.Name = "y1Field";
            y1Field.Size = new Size(89, 23);
            y1Field.TabIndex = 6;
            // 
            // x2Field
            // 
            x2Field.Location = new Point(6, 100);
            x2Field.Name = "x2Field";
            x2Field.Size = new Size(89, 23);
            x2Field.TabIndex = 5;
            x2Field.ValueChanged += x2Field_ValueChanged;
            // 
            // x1Field
            // 
            x1Field.Location = new Point(6, 45);
            x1Field.Name = "x1Field";
            x1Field.Size = new Size(89, 23);
            x1Field.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(11, 395);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(218, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(700, 500);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 546);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)y2Field).EndInit();
            ((System.ComponentModel.ISupportInitialize)y1Field).EndInit();
            ((System.ComponentModel.ISupportInitialize)x2Field).EndInit();
            ((System.ComponentModel.ISupportInitialize)x1Field).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private NumericUpDown x1Field;
        private NumericUpDown x2Field;
        private NumericUpDown y1Field;
        private NumericUpDown y2Field;
        private Label label2;
        private Label label5;
        private ComboBox metodeChoices;
    }
}
