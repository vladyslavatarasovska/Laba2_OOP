using System;

namespace LR_2
{
    public class ArithmeticProgression
    {
        private double a1;
        private double d;
        private static Random rnd = new Random();
        public string Name;
        public static int Count = 0;

        public ArithmeticProgression(double a1, double d)
        {
            this.a1 = a1;
            this.d = d;
            Name = "Введення з клавіатури";
            Count++;
        }
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
        public ArithmeticProgression()
        {
            a1 = rnd.Next(0, 101);
            d = rnd.Next(0, 101);
            Name = "Генерація від 0 до 100";
            Count++;
        }
        public double A1
        {
            get { return a1; }
            set { a1 = value; }
        }
        public double D
        {
            get { return d; }
            set { d = value; }
        }
        public string Kind
        {
            get
            {
                if (d > 0) return "зростаюча";
                if (d < 0) return "спадна";
                return "стала";
            }
        }
        public double Term(int n)
        {
            CheckN(n);
            return a1 + (n - 1) * d;
        }
        public double Sum(int n)
        {
            CheckN(n);
            return (2 * a1 + (n - 1) * d) * n / 2;
        }
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
        private static void CheckN(int n)
        {
            if (n < 1)
                throw new ArgumentException("Номер члена n повинен бути натуральним числом (n >= 1)");
        }
    }
}
