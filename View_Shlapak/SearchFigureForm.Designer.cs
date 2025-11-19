
namespace View
{
    partial class SearchFigureForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxSquare = new System.Windows.Forms.CheckBox();
            this.TextBoxSquare = new System.Windows.Forms.TextBox();
            this.CheckBoxCircle = new System.Windows.Forms.CheckBox();
            this.CheckBoxTriangle = new System.Windows.Forms.CheckBox();
            this.CheckBoxRectangle = new System.Windows.Forms.CheckBox();
            this.ButtonShowFigure = new System.Windows.Forms.Button();
            this.CloseFromButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CheckBoxSquare);
            this.groupBox1.Controls.Add(this.TextBoxSquare);
            this.groupBox1.Controls.Add(this.CheckBoxCircle);
            this.groupBox1.Controls.Add(this.CheckBoxTriangle);
            this.groupBox1.Controls.Add(this.CheckBoxRectangle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти фигуру...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "м";
            // 
            // CheckBoxSquare
            // 
            this.CheckBoxSquare.AutoSize = true;
            this.CheckBoxSquare.Location = new System.Drawing.Point(6, 88);
            this.CheckBoxSquare.Name = "CheckBoxSquare";
            this.CheckBoxSquare.Size = new System.Drawing.Size(83, 17);
            this.CheckBoxSquare.TabIndex = 5;
            this.CheckBoxSquare.Text = "Площадью: ";
            this.CheckBoxSquare.UseVisualStyleBackColor = true;
            this.CheckBoxSquare.CheckedChanged += new System.EventHandler(this.CheckBoxSquareCheckedChanged);
            // 
            // TextBoxSquare
            // 
            this.TextBoxSquare.Location = new System.Drawing.Point(95, 85);
            this.TextBoxSquare.Name = "TextBoxSquare";
            this.TextBoxSquare.Size = new System.Drawing.Size(58, 20);
            this.TextBoxSquare.TabIndex = 4;
            this.TextBoxSquare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // CheckBoxCircle
            // 
            this.CheckBoxCircle.AutoSize = true;
            this.CheckBoxCircle.Location = new System.Drawing.Point(6, 65);
            this.CheckBoxCircle.Name = "CheckBoxCircle";
            this.CheckBoxCircle.Size = new System.Drawing.Size(47, 17);
            this.CheckBoxCircle.TabIndex = 2;
            this.CheckBoxCircle.Text = "Круг";
            this.CheckBoxCircle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTriangle
            // 
            this.CheckBoxTriangle.AutoSize = true;
            this.CheckBoxTriangle.Location = new System.Drawing.Point(6, 42);
            this.CheckBoxTriangle.Name = "CheckBoxTriangle";
            this.CheckBoxTriangle.Size = new System.Drawing.Size(77, 17);
            this.CheckBoxTriangle.TabIndex = 1;
            this.CheckBoxTriangle.Text = "Треугольник";
            this.CheckBoxTriangle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxRectangle
            // 
            this.CheckBoxRectangle.AutoSize = true;
            this.CheckBoxRectangle.Location = new System.Drawing.Point(6, 19);
            this.CheckBoxRectangle.Name = "CheckBoxRectangle";
            this.CheckBoxRectangle.Size = new System.Drawing.Size(112, 17);
            this.CheckBoxRectangle.TabIndex = 0;
            this.CheckBoxRectangle.Text = "Прямоугольник";
            this.CheckBoxRectangle.UseVisualStyleBackColor = true;
            // 
            // ButtonShowFigure
            // 
            this.ButtonShowFigure.Location = new System.Drawing.Point(12, 135);
            this.ButtonShowFigure.Name = "ButtonShowFigure";
            this.ButtonShowFigure.Size = new System.Drawing.Size(89, 23);
            this.ButtonShowFigure.TabIndex = 1;
            this.ButtonShowFigure.Text = "Показать";
            this.ButtonShowFigure.UseVisualStyleBackColor = true;
            this.ButtonShowFigure.Click += new System.EventHandler(this.ButtonShowFigure_Click);
            // 
            // CloseFromButton
            // 
            this.CloseFromButton.Location = new System.Drawing.Point(107, 135);
            this.CloseFromButton.Name = "CloseFromButton";
            this.CloseFromButton.Size = new System.Drawing.Size(90, 23);
            this.CloseFromButton.TabIndex = 2;
            this.CloseFromButton.Text = "Закрыть";
            this.CloseFromButton.UseVisualStyleBackColor = true;
            this.CloseFromButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // SearchFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 170);
            this.ControlBox = false;
            this.Controls.Add(this.CloseFromButton);
            this.Controls.Add(this.ButtonShowFigure);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchFigureForm";
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxSquare;
        private System.Windows.Forms.TextBox TextBoxSquare;
        private System.Windows.Forms.CheckBox CheckBoxCircle;
        private System.Windows.Forms.CheckBox CheckBoxTriangle;
        private System.Windows.Forms.CheckBox CheckBoxRectangle;
        private System.Windows.Forms.Button ButtonShowFigure;
        private System.Windows.Forms.Button CloseFromButton;
    }
}