using System;

namespace LR_2
{
    // Клас «Арифметична прогресія»: перший член a1 і різниця d
    public class ArithmeticProgression
    {
        // Приховані поля
        private double a1;                          // перший член
        private double d;                           // різниця прогресії
        private static Random rnd = new Random();   // спільний генератор для всіх об'єктів

        // Відкриті поля
        public string Name;                         // спосіб отримання даних
        public static int Count = 0;                // кількість створених об'єктів

        // Конструктор з параметрами: введення даних з клавіатури
        public ArithmeticProgression(double a1, double d)
        {
            this.a1 = a1;
            this.d = d;
            Name = "Введення з клавіатури";
            Count++;
        }

        // Конструктор з параметрами: генерація даних на інтервалі [a, b]
        public ArithmeticProgression(int a, int b)
        {
            if (a > b)
            {
                int t = a; a = b; b = t;
            }
            a1 = rnd.Next(a, b + 1);
            d = rnd.Next(a, b + 1);
            Name = "Генерація на [" + a + "; " + b + "]";
            Count++;
        }

        // Конструктор без параметрів: генерація даних від 0 до 100
        public ArithmeticProgression()
        {
            a1 = rnd.Next(0, 101);
            d = rnd.Next(0, 101);
            Name = "Генерація від 0 до 100";
            Count++;
        }

        // Властивість: перший член прогресії
        public double A1
        {
            get { return a1; }
            set { a1 = value; }
        }

        // Властивість: різниця прогресії
        public double D
        {
            get { return d; }
            set { d = value; }
        }

        // Властивість тільки для читання: вид прогресії
        public string Kind
        {
            get
            {
                if (d > 0) return "зростаюча";
                if (d < 0) return "спадна";
                return "стала";
            }
        }

        // Знаходження n-го члена прогресії: an = a1 + (n - 1) * d
        public double Term(int n)
        {
            CheckN(n);
            return a1 + (n - 1) * d;
        }

        // Сума n перших членів: Sn = (2 * a1 + (n - 1) * d) * n / 2
        public double Sum(int n)
        {
            CheckN(n);
            return (2 * a1 + (n - 1) * d) * n / 2;
        }

        // Перші k членів прогресії у вигляді рядка
        public string FirstTerms(int k)
        {
            CheckN(k);
            string s = "";
            for (int i = 1; i <= k; i++)
            {
                s += Math.Round(Term(i), 4);
                if (i < k) s += "; ";
            }
            return s;
        }

        // Перевірка номера члена прогресії
        private static void CheckN(int n)
        {
            if (n < 1)
                throw new ArgumentException("Номер члена n повинен бути натуральним числом (n >= 1)");
        }
    }
}
