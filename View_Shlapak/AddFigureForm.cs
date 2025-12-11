using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму добавления фигур
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

        /// <summary>
        /// Тип выбранной фигуры
        /// </summary>
        private FigureType _figureType;

        // ========== КОНСТАНТЫ ДЛЯ МАКЕТА ФОРМЫ ==========

        /// <summary>
        /// Минимальное заполненное значение для активации кнопки
        /// </summary>
        private const int MINIMUM_TEXT_LENGTH = 0;

        /// <summary>
        /// Базовая высота GroupBox (верхний отступ + нижний отступ)
        /// </summary>
        private const int GROUPBOX_BASE_HEIGHT = 15;

        /// <summary>
        /// Высота одного элемента управления в GroupBox
        /// </summary>
        private const int CONTROL_HEIGHT = 25;

        /// <summary>
        /// Отступ между GroupBox и кнопками
        /// </summary>
        private const int BUTTON_MARGIN_TOP = 5;

        /// <summary>
        /// Отступ снизу формы
        /// </summary>
        private const int FORM_BOTTOM_MARGIN = 50;

        /// <summary>
        /// Отступ кнопки "ОК" от левого края
        /// </summary>
        private const int OK_BUTTON_LEFT = 12;

        /// <summary>
        /// Отступ кнопки "Закрыть" от левого края
        /// </summary>
        private const int CLOSE_BUTTON_LEFT = 122;

        /// <summary>
        /// Высота кнопок
        /// </summary>
        private const int BUTTON_HEIGHT = 30;

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
        /// <param name="figureType">Тип фигуры</param>
        private void MakeVisible(FigureType figureType)
        {
            HideAllControls();
            int visibleControlsCount = 0;

            switch (figureType)
            {
                case FigureType.Rectangle:
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
            //TODO: const+
            int newHeight = GROUPBOX_BASE_HEIGHT + (controlsCount * CONTROL_HEIGHT);
            groupBox2.Height = newHeight;
        }

        /// <summary>
        /// Перемещение кнопок в зависимости от размера groupBox2
        /// </summary>
        private void MoveButtons()
        {
            //TODO: const+
            int buttonY = groupBox2.Top + groupBox2.Height + BUTTON_MARGIN_TOP;

            OkAddFigureButton.Location = new System.Drawing.Point
                (OK_BUTTON_LEFT, buttonY);
            CloseFormButton.Location = new System.Drawing.Point
                (CLOSE_BUTTON_LEFT, buttonY);

            this.Height = buttonY + BUTTON_HEIGHT + FORM_BOTTOM_MARGIN;
        }

        /// <summary>
        /// Обработка изменения выбранной фигуры в комбобоксе
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void FigureChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = FigureChoiceComboBox.SelectedItem?.ToString();

            switch (selectedText)
            {
                case "Прямоугольник":
                    {
                        _figureType = FigureType.Rectangle;
                        break;
                    }
                case "Треугольник":
                    {
                        _figureType = FigureType.Triangle;
                        break;
                    }
                case "Круг":
                    {
                        _figureType = FigureType.Circle;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            MakeVisible(_figureType);
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
        private FigureBase InsertData()
        {
            switch (_figureType)
            {
                case FigureType.Rectangle:
                    {
                        return GetNewRectangle();
                    }
                case FigureType.Triangle:
                    {
                        return GetNewTriangle();
                    }
                case FigureType.Circle:
                    {
                        return GetNewCircle();
                    }
                default:
                    {
                        throw new ArgumentException("Неизвестный тип фигуры.");
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
                _figure = InsertData();
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
            switch (_figureType)
            {
                case FigureType.Rectangle:
                    {
                        OkAddFigureButton.Enabled =
                            LengthTextbox.Text.Length > MINIMUM_TEXT_LENGTH &&
                            WidthTextbox.Text.Length > MINIMUM_TEXT_LENGTH;
                        break;
                    }
                case FigureType.Triangle:
                    {
                        OkAddFigureButton.Enabled =
                            LengthTextbox.Text.Length > MINIMUM_TEXT_LENGTH &&
                            HeightTextbox.Text.Length > MINIMUM_TEXT_LENGTH;
                        break;
                    }
                case FigureType.Circle:
                    {
                        OkAddFigureButton.Enabled =
                            RadiusTextbox.Text.Length > MINIMUM_TEXT_LENGTH;
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