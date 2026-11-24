using System;
using System.Globalization;
using System.Windows.Forms;

namespace LR_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Підготовка рядка: прибирає пробіли, замінює різні види мінуса та кому
        private string Normalize(TextBox tb)
        {
            return tb.Text.Replace(" ", "").Replace(" ", "")
                          .Replace('−', '-').Replace('–', '-').Replace('—', '-')
                          .Replace(',', '.');
        }

        // Зчитування дійсного числа
        private double ReadDouble(TextBox tb, string name)
        {
            double value;
            if (!double.TryParse(Normalize(tb), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                throw new FormatException("Некоректне значення поля \"" + name + "\"");
            return value;
        }

        // Зчитування цілого числа
        private int ReadInt(TextBox tb, string name)
        {
            int value;
            if (!int.TryParse(Normalize(tb), NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                throw new FormatException("Поле \"" + name + "\" повинно містити ціле число");
            return value;
        }

        // Виведення характеристик об'єкта у відповідну групу
        private void ShowResult(ArithmeticProgression p, int n,
            Label lA1, Label lD, Label lKind, Label lTerms, Label lTerm, Label lSum)
        {
            lA1.Text = "Перший член a1 = " + p.A1;
            lD.Text = "Різниця d = " + p.D;
            lKind.Text = "Вид прогресії: " + p.Kind;
            lTerms.Text = "Перші 5 членів: " + p.FirstTerms(5);
            lTerm.Text = n + "-й член: " + Math.Round(p.Term(n), 4);
            lSum.Text = "Сума " + n + " перших членів: " + Math.Round(p.Sum(n), 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArithmeticProgression p1, p2, p3;
            try
            {
                // Об'єкт 1: введення даних з клавіатури
                double a1 = ReadDouble(textBox1, "a1");
                double d = ReadDouble(textBox2, "d");
                int n1 = ReadInt(textBox3, "n (об'єкт 1)");
                p1 = new ArithmeticProgression(a1, d);
                ShowResult(p1, n1, lblA1_1, lblD_1, lblKind_1, lblTerms_1, lblTerm_1, lblSum_1);

                // Об'єкт 2: генерація даних на інтервалі [a, b]
                int a = ReadInt(textBox4, "a");
                int b = ReadInt(textBox5, "b");
                int n2 = ReadInt(textBox6, "n (об'єкт 2)");
                p2 = new ArithmeticProgression(a, b);
                ShowResult(p2, n2, lblA1_2, lblD_2, lblKind_2, lblTerms_2, lblTerm_2, lblSum_2);

                // Об'єкт 3: генерація даних від 0 до 100
                int n3 = ReadInt(textBox7, "n (об'єкт 3)");
                p3 = new ArithmeticProgression();
                ShowResult(p3, n3, lblA1_3, lblD_3, lblKind_3, lblTerms_3, lblTerm_3, lblSum_3);

                labelCount.Text = "Створено об'єктів: " + ArithmeticProgression.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення даних!\n" + ex.Message, "Помилка");
            }
        }

        // Очищення полів введення та результатів
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 })
                tb.Clear();
            foreach (GroupBox g in new GroupBox[] { groupBox1, groupBox2, groupBox3 })
                foreach (Control c in g.Controls)
                    if (c is Label && c.Name.StartsWith("lbl"))
                        c.Text = "";
        }
    }
}
