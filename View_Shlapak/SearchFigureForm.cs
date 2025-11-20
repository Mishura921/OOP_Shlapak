using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;


namespace View
{
    /// <summary>
    /// Класс, описывающий форму для поиска 
    /// </summary>
    public partial class SearchFigureForm : Form
    {
        /// <summary>
        /// Ивент для передачи данных 
        /// </summary>
        public event EventHandler<FigureEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Лист фильтрованных фигур
        /// </summary>
        private readonly BindingList<FigureBase> _listFigureSearch;

        /// <summary>
        /// Событие при инициализации формы
        /// </summary>
        public SearchFigureForm(BindingList<FigureBase> figures)
        {
            InitializeComponent();
            _listFigureSearch = figures;
            MaximizeBox = false;
            TextBoxSquare.Enabled = false;
        }

        /// <summary>
        /// Обработка чисел на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextboxKeyPress(object sender, 
            KeyPressEventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) 
                return;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта SquareCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxSquareCheckedChanged(object sender, EventArgs e)
        {
            TextBoxSquare.Enabled = CheckBoxSquare.Checked;
        }

        /// <summary>
        /// Кнопка Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowFigure_Click(object sender, EventArgs e)
        {
            // Очищаем результаты предыдущего поиска
            SendDataFromFormEvent?.Invoke(this, new FigureEventArgs(null));

            int count = 0;
            if (!CheckBoxRectangle.Checked &&
                !CheckBoxTriangle.Checked &&
                !CheckBoxCircle.Checked &&
                !CheckBoxSquare.Checked)
            {
                MessageBox.Show(
                    "Не выбрано ни одного критерия фильтрации!\n" +
                    "Выбор осуществляется постановкой флажка.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double filterSquare = 0;
            bool hasSquare = false;

            if (CheckBoxSquare.Checked)
            {
                if (string.IsNullOrWhiteSpace(TextBoxSquare.Text))
                {
                    MessageBox.Show(
                        "Вы выбрали фильтрацию по площади, " +
                        "но не ввели значение площади!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(TextBoxSquare.Text,
                    System.Globalization.NumberStyles.Any,
                    new System.Globalization.CultureInfo("ru-RU"),
                    out filterSquare))
                {
                    MessageBox.Show(
                        "Некорректное значение площади! Используйте число с запятой.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                filterSquare = Math.Round(filterSquare, 3);
                hasSquare = true;
            }

            foreach (FigureBase figures in _listFigureSearch)
            {
                bool matchType =
                    (CheckBoxRectangle.Checked
                    && figures is Rectangle) || 
                    (CheckBoxTriangle.Checked && figures is Triangle) ||
                    (CheckBoxCircle.Checked && figures is Circle);

                // Если вообще ни один чекбокс типа не выбран — считаем,
                // что matchType = true (разрешить любые типы)
                if (!CheckBoxRectangle.Checked &&
                    !CheckBoxTriangle.Checked &&
                    !CheckBoxCircle.Checked)
                    matchType = true;

                bool matchSquare = !hasSquare ||
                    Math.Round(figures.Square, 3) == filterSquare;

                // Добавлять только если выполнены ВСЕ активные фильтры
                if (matchType && matchSquare)
                {
                    count++;
                    SendDataFromFormEvent?.Invoke(this,
                        new FigureEventArgs(figures));
                }
            }

            if (count == 0)
            {
                MessageBox.Show(
                    "Нет ни одной фигуры, удовлетворяющей" +
                    " выбранным критериям поиска.",
                    "Информация", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            CheckBoxRectangle.Checked = false;
            CheckBoxTriangle.Checked = false;
            CheckBoxCircle.Checked = false;
            CheckBoxSquare.Checked = false;
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
