namespace Fraction_Calculator_WinForms
{
    public class TFrac
    {
        private int a;
        private int b;

        public int Numerator
        {
            get { return a; }
            set { a = value; }
        }

        public int Denominator
        {
            get { return b; }
            set { b = value; }
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private KeyValuePair<int, int> unify_fraction(int a, int b)
        {
            int num = a; 
            int den = b;
            int gcd = GCD(Math.Abs(a), Math.Abs(b));

            if (gcd > 1)
            {
                if ((a < 0 && b < 0) || (a > 0 && b > 0))
                {
                    num = Math.Abs(a) / gcd;
                    den = Math.Abs(b) / gcd;
                }
                else
                {
                    //a = a > 0 ? a / gcd : -(Math.Abs(a) / gcd);
                    //b = b > 0 ? b / gcd : -(Math.Abs(b) / gcd);

                    num = a < 0 ? a / gcd : -a / gcd;
                    den = Math.Abs(b) / gcd;
                }
            }

            return new KeyValuePair<int, int>(num, den);
        }

        public TFrac()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public TFrac(int a)
        {
            Numerator = a;
            Denominator = 1;
        }

        public TFrac(int a, int b)
        {
            KeyValuePair<int, int> fraction = unify_fraction(a, b);

            Numerator = fraction.Key;
            Denominator = fraction.Value;
        }

        public TFrac(string fraction_str)
        {
            if (fraction_str == String.Empty)
            {
                Numerator = 0;
                Denominator = 1;
            }

            if (!(fraction_str.Contains('/')))
            {
                Numerator = Convert.ToInt32(fraction_str);
                Denominator = 1;
                return;
            }

            int a = Convert.ToInt32(fraction_str.Split("/")[0]);
            int b = Convert.ToInt32(fraction_str.Split("/")[1]);

            KeyValuePair<int, int> fraction = unify_fraction(a, b);

            Numerator = fraction.Key;
            Denominator = fraction.Value;
        }

        public bool Empty()
        {
            return Numerator == 0 && Denominator == 1;
        }

        public TFrac Copy()
        {
            return new TFrac(Numerator, Denominator);
        }

        public static TFrac operator +(TFrac a, TFrac b)
        {
            int new_a = (a.Numerator * b.Denominator + b.Numerator * a.Denominator);
            int new_b = a.Denominator * b.Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Add(TFrac fraction)
        {
            int new_a = (Numerator * fraction.Denominator + fraction.Numerator * Denominator);
            int new_b = Denominator * fraction.Denominator;
            return new TFrac(new_a, new_b);
        }

        public static TFrac operator *(TFrac a, TFrac b)
        {
            int new_a = a.Numerator * b.Numerator;
            int new_b = a.Denominator * b.Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Multiply(TFrac fraction)
        {
            int new_a = Numerator * fraction.Numerator;
            int new_b = Denominator * fraction.Denominator;
            return new TFrac(new_a, new_b);
        }

        public static TFrac operator -(TFrac a, TFrac b)
        {
            int new_a = (a.Numerator * b.Denominator - b.Numerator * a.Denominator);
            int new_b = a.Denominator * b.Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Subtract(TFrac fraction)
        {
            int new_a = (Numerator * fraction.Denominator - fraction.Numerator * Denominator);
            int new_b = Denominator * fraction.Denominator;
            return new TFrac(new_a, new_b);
        }

        public static TFrac operator /(TFrac a, TFrac b)
        {
            int new_a = a.Numerator * b.Denominator;
            int new_b = b.Numerator * a.Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Divide(TFrac fraction)
        {
            int new_a = Numerator * fraction.Denominator;
            int new_b = fraction.Numerator * Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Square()
        {
            int new_a = Numerator * Numerator;
            int new_b = Denominator * Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Reciprocal()
        {
            int new_a = Denominator;
            int new_b = Numerator;
            return new TFrac(new_a, new_b);
        }
        public static TFrac operator -(TFrac a)
        {
            int new_a = -Math.Abs(a.Numerator);
            int new_b = a.Denominator;
            return new TFrac(new_a, new_b);
        }
        public static TFrac operator +(TFrac a)
        {
            int new_a = Math.Abs(a.Numerator);
            int new_b = a.Denominator;
            return new TFrac(new_a, new_b);
        }

        public TFrac Minus()
        {
            int new_a = -Numerator;
            int new_b = Denominator;
            return new TFrac(new_a, new_b);
        }
        public static bool operator ==(TFrac a, TFrac b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(TFrac a, TFrac b)
        {
            return a.Numerator != b.Numerator || a.Denominator != b.Denominator;
        }

        public bool Equals(TFrac fraction)
        {
            return Numerator == fraction.Numerator && Denominator == fraction.Denominator;
        }

        public static bool operator >(TFrac a, TFrac b)
        {
            if (a.Denominator == b.Denominator)
                return a.Numerator > b.Numerator;

            return (a - b).Numerator > 0;
        }

        public static bool operator <(TFrac a, TFrac b)
        {
            if (a.Denominator == b.Denominator)
                return a.Numerator < b.Numerator;

            return (b - a).Numerator > 0;
        }

        public bool Greater(TFrac fraction)
        {
            if (Denominator == fraction.Denominator)
                return Numerator > fraction.Numerator;

            return Subtract(fraction).Numerator > 0;
        }

        public int GetNumeratorInt()
        {
            return Numerator;
        }

        public int GetDenominatorInt()
        {
            return Denominator;
        }

        public string GetNumeratorString()
        {
            return Numerator.ToString();
        }

        public string GetDenominatorString()
        {
            return Denominator.ToString();
        }

        public string GetFractionString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }
    }
}
