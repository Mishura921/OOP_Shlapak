using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму добавления
    /// </summary>
    public partial class AddFigureForm : Form
    {
        /// <summary>
        /// Поле для создания фигуры
        /// </summary>
        private FigureBase _figure;

        /// <summary>
        /// Свойство для вывода данных о фигуре
        /// </summary>
        public FigureBase FigureData => _figure;

        private FigureType _figureType;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();

            OkAddFigureButton.Enabled = false;
            LengthTextbox.TextChanged += ShowOKButton;
            WidthTextbox.TextChanged += ShowOKButton;
            HeightTextbox.TextChanged += ShowOKButton;
            RadiusTextbox.TextChanged += ShowOKButton;
            HideAllControls();
        }

        /// <summary>
        /// Скрыть все элементы управления
        /// </summary>
        private void HideAllControls()
        {
            LengthTextbox.Visible = false;
            LengthLabel.Visible = false;
            WidthTextbox.Visible = false;
            WidthLabel.Visible = false;
            HeightTextbox.Visible = false;
            HeightLabel.Visible = false;
            RadiusTextbox.Visible = false;
            RadiusLabel.Visible = false;
        }

        /// <summary>
        /// Установка видимых TextBox в зависимости от выбранной фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        private void MakeVisible(FigureType figureType)
        {
            HideAllControls();
            int visibleControlsCount = 0;

            switch (figureType)
            {
                case FigureType.Rectangular:
                {
                    LengthTextbox.Visible = true;
                    LengthLabel.Visible = true;
                    WidthTextbox.Visible = true;
                    WidthLabel.Visible = true;
                    LengthLabel.Text = "Длина:";
                    WidthLabel.Text = "Ширина:";
                    visibleControlsCount = 2;
                    break;
                }
                case FigureType.Triangle:
                {
                    LengthTextbox.Visible = true;
                    LengthLabel.Visible = true;
                    HeightTextbox.Visible = true;
                    HeightLabel.Visible = true;
                    LengthLabel.Text = "Основание:";
                    HeightLabel.Text = "Высота:";
                    visibleControlsCount = 2;
                    break;
                }
                case FigureType.Circle:
                {
                    RadiusTextbox.Visible = true;
                    RadiusLabel.Visible = true;
                    visibleControlsCount = 1;
                    break;
                }
                default:
                {
                    throw new ArgumentException("Вы не выбрали тип фигуры...");
                }
            }

            ResizeGroupBox(visibleControlsCount);
            MoveButtons();
        }

        /// <summary>
        /// Динамическое изменение размера группы параметров в зависимости от количества элементов
        /// </summary>
        /// <param name="controlsCount">Количество видимых элементов</param>
        private void ResizeGroupBox(int controlsCount)
        {
            //TODO: const
            int baseHeight = 15;
            int controlHeight = 25;

            int newHeight = baseHeight + (controlsCount * controlHeight);
            groupBox2.Height = newHeight;
        }

        /// <summary>
        /// Перемещение кнопок в зависимости от размера groupBox2
        /// </summary>
        private void MoveButtons()
        {
            //TODO: const?
            int buttonY = groupBox2.Top + groupBox2.Height + 5;

            OkAddFigureButton.Location = new System.Drawing.Point(12, buttonY);
            CloseFormButton.Location = new System.Drawing.Point(122, buttonY);

            this.Height = buttonY + OkAddFigureButton.Height + 50;
        }

        /// <summary>
        /// Обработка изменения выбранной фигуры в комбобоксе
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void FigureChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (FigureChoiceComboBox.SelectedIndex)
            {
                case 0:
                {
                    _figureType = FigureType.Rectangular;
                    MakeVisible(_figure);
                    break;
                }
                case 1:
                {
                    _figureType = FigureType.Triangle;
                    MakeVisible(_figure);
                    break;
                }
                case 2:
                {
                    _figureType = FigureType.Circle;
                    MakeVisible(_figure);
                    break;
                }
            }

            ClearAllFields();
            OkAddFigureButton.Enabled = false;
        }

        /// <summary>
        /// Очистка всех полей ввода
        /// </summary>
        private void ClearAllFields()
        {
            LengthTextbox.Clear();
            WidthTextbox.Clear();
            HeightTextbox.Clear();
            RadiusTextbox.Clear();
        }

        /// <summary>
        /// Установка значения свойствам экземпляра класса 
        /// </summary>
        private void SetValue(Action action)
        {
            action.Invoke();
        }

        /// <summary>
        /// Ввод данных прямоугольника
        /// </summary>
        private Rectangle GetNewRectangle()
        {
            var newRectangle = new Rectangle();
            var actions = new List<Action>()
            {
                new Action(() => newRectangle.Length = 
                    Convert.ToDouble(LengthTextbox.Text)),
                new Action(() => newRectangle.Width = 
                    Convert.ToDouble(WidthTextbox.Text))
            };
            actions.ForEach(SetValue);
            return newRectangle;
        }

        /// <summary>
        /// Ввод данных треугольника
        /// </summary>
        private Triangle GetNewTriangle()
        {
            var newTriangle = new Triangle();
            var actions = new List<Action>()
            {
                new Action(() => newTriangle.Length = 
                    Convert.ToDouble(LengthTextbox.Text)),
                new Action(() => newTriangle.Height = 
                    Convert.ToDouble(HeightTextbox.Text))
            };
            actions.ForEach(SetValue);
            return newTriangle;
        }

        /// <summary>
        /// Ввод данных о круге
        /// </summary>
        private Circle GetNewCircle()
        {
            var newCircle = new Circle();
            var actions = new List<Action>()
            {
                new Action(() => newCircle.Radius = 
                    Convert.ToDouble(RadiusTextbox.Text))
            };
            actions.ForEach(SetValue);
            return newCircle;
        }

        /// <summary>
        /// Ввод данных о фигурах
        /// </summary>
        private FigureBase InsertData(FigureBase figure)
        {
            switch (figure)
            {
                case Rectangle _:
                {
                    return GetNewRectangle();
                }
                case Triangle _:
                {
                    return GetNewTriangle();
                }
                case Circle _:
                {
                    return GetNewCircle();
                }
                default:
                {
                    throw new ArgumentException("Такой фигуры не существует.");
                }
            }
        }

        /// <summary>
        /// Событие при добавлении новой фигуры
        /// </summary>
        private void OkAddFigureButton_Click(object sender, EventArgs e)
        {
            try
            {
                _figure = InsertData(_figure);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show(
                    "Введено некорректное значение, проверьте данные!\n" +
                    "Вы должны ввести одно положительное десятичное число " +
                    "в каждое текстовое поле.\n" +
                    "В качестве разделителя используйте запятую.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ClearAllFields();
            }
        }

        /// <summary>
        /// Обработка чисел на форме
        /// </summary>
        private void NumericTextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) 
                return;
        }

        /// <summary>
        /// Активация кнопки ОК, если заполнены поля
        /// </summary>
        private void ShowOKButton(object sender, EventArgs e)
        {
            switch (FigureChoiceComboBox.SelectedIndex)
            {
                case 0:
                {
                    OkAddFigureButton.Enabled =
                        LengthTextbox.Text.Length > 0 &&
                        WidthTextbox.Text.Length > 0;
                    break;
                }
                case 1:
                {
                    OkAddFigureButton.Enabled =
                        LengthTextbox.Text.Length > 0 &&
                        HeightTextbox.Text.Length > 0;
                    break;
                }
                case 2:
                {
                    OkAddFigureButton.Enabled =
                        RadiusTextbox.Text.Length > 0;
                    break;
                }
                default:
                {
                    OkAddFigureButton.Enabled = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Закрыть"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события нажатия кнопки</param>
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}