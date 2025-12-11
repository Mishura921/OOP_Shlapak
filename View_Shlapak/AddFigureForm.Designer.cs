using System;

namespace View
{
    partial class AddFigureForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FigureChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OkAddFigureButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadiusTextbox = new System.Windows.Forms.TextBox();
            this.WidthTextbox = new System.Windows.Forms.TextBox();
            this.HeightTextbox = new System.Windows.Forms.TextBox();
            this.LengthTextbox = new System.Windows.Forms.TextBox();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FigureChoiceComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фигура";
            // 
            // FigureChoiceComboBox
            // 
            this.FigureChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FigureChoiceComboBox.FormattingEnabled = true;
            this.FigureChoiceComboBox.Items.AddRange(new object[] {
                "Прямоугольник",
                "Треугольник",
                "Круг"});
            this.FigureChoiceComboBox.Location = new System.Drawing.Point(10, 22);
            this.FigureChoiceComboBox.Name = "FigureChoiceComboBox";
            this.FigureChoiceComboBox.Size = new System.Drawing.Size(180, 21);
            this.FigureChoiceComboBox.TabIndex = 5;
            this.FigureChoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.FigureChoiceComboBox_SelectedIndexChanged);
            // 
            // OkAddFigureButton
            // 
            this.OkAddFigureButton.Enabled = false;
            this.OkAddFigureButton.Location = new System.Drawing.Point(12, 125);
            this.OkAddFigureButton.Name = "OkAddFigureButton";
            this.OkAddFigureButton.Size = new System.Drawing.Size(90, 30);
            this.OkAddFigureButton.TabIndex = 1;
            this.OkAddFigureButton.Text = "ОК";
            this.OkAddFigureButton.UseVisualStyleBackColor = true;
            this.OkAddFigureButton.Click += new System.EventHandler(this.OkAddFigureButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadiusTextbox);
            this.groupBox2.Controls.Add(this.WidthTextbox);
            this.groupBox2.Controls.Add(this.HeightTextbox);
            this.groupBox2.Controls.Add(this.LengthTextbox);
            this.groupBox2.Controls.Add(this.RadiusLabel);
            this.groupBox2.Controls.Add(this.WidthLabel);
            this.groupBox2.Controls.Add(this.HeightLabel);
            this.groupBox2.Controls.Add(this.LengthLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 40);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры (м)";
            // 
            // RadiusTextbox
            // 
            this.RadiusTextbox.Location = new System.Drawing.Point(80, 15);
            this.RadiusTextbox.Name = "RadiusTextbox";
            this.RadiusTextbox.Size = new System.Drawing.Size(110, 20);
            this.RadiusTextbox.TabIndex = 7;
            this.RadiusTextbox.Visible = false;
            this.RadiusTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // WidthTextbox
            // 
            this.WidthTextbox.Location = new System.Drawing.Point(80, 40);
            this.WidthTextbox.Name = "WidthTextbox";
            this.WidthTextbox.Size = new System.Drawing.Size(110, 20);
            this.WidthTextbox.TabIndex = 5;
            this.WidthTextbox.Visible = false;
            this.WidthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // HeightTextbox
            // 
            this.HeightTextbox.Location = new System.Drawing.Point(80, 40);
            this.HeightTextbox.Name = "HeightTextbox";
            this.HeightTextbox.Size = new System.Drawing.Size(110, 20);
            this.HeightTextbox.TabIndex = 8;
            this.HeightTextbox.Visible = false;
            this.HeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // LengthTextbox
            // 
            this.LengthTextbox.Location = new System.Drawing.Point(80, 15);
            this.LengthTextbox.Name = "LengthTextbox";
            this.LengthTextbox.Size = new System.Drawing.Size(110, 20);
            this.LengthTextbox.TabIndex = 4;
            this.LengthTextbox.Visible = false;
            this.LengthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(10, 18);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(46, 13);
            this.RadiusLabel.TabIndex = 3;
            this.RadiusLabel.Text = "Радиус:";
            this.RadiusLabel.Visible = false;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(10, 43);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(49, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Ширина:";
            this.WidthLabel.Visible = false;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(10, 43);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(48, 13);
            this.HeightLabel.TabIndex = 6;
            this.HeightLabel.Text = "Высота:";
            this.HeightLabel.Visible = false;
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(10, 18);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(43, 13);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "Длина:";
            this.LengthLabel.Visible = false;
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Location = new System.Drawing.Point(122, 125);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(90, 30);
            this.CloseFormButton.TabIndex = 5;
            this.CloseFormButton.Text = "Закрыть";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // AddFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 165);
            this.ControlBox = false;
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.OkAddFigureButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFigureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить фигуру";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OkAddFigureButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.TextBox WidthTextbox;
        private System.Windows.Forms.TextBox HeightTextbox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox LengthTextbox;
        private System.Windows.Forms.ComboBox FigureChoiceComboBox;
        private System.Windows.Forms.TextBox RadiusTextbox;
        private System.Windows.Forms.Button CloseFormButton;
    }
}