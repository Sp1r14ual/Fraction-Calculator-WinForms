namespace Fraction_Calculator_WinForms
{
    public class TEditor
    {
        private string str;

        private const string separator = "/";

        private const string zero = "0";

        public TEditor()
        {
            this.str = String.Empty;
        }

        public TEditor(string str)
        {
            this.str = str;
        }

        public string String
        {
            get { return str; }
            set { str = value; }
        }

        public bool FractionIsZero()
        {
            //?
            return str == "0/1" ? true : false;
        }

        public string AddSign()
        {
            str = str.First() == '-' ? str.Substring(1) : '-' + str;
            return str;
        }

        public string AddSeparator()
        {
            str += separator;
            return str;
        }

        public string AddDigit(int a)
        {
            str += a.ToString();
            return str;
        }

        public string AddSymbol(string s)
        {
            str += s;
            return str;
        }

        public string AddZero()
        {
            str += zero;
            return str;
        }

        public string BackSpace()
        {
            try
            {
                str = str.Substring(0, str.Length - 1);
            }
            catch
            {
                str = String.Empty;
            }

            return str;
        }

        public string Clear()
        {
            str = String.Empty;
            return str;
        }

        public bool Empty()
        {
            return str == String.Empty;
        }

        public string Edit(string a)
        {
            switch (a)
            {
                case "0":
                    AddDigit(0);
                    return String;
                case "1":
                    AddDigit(1);
                    return String;
                case "2": 
                    AddDigit(2);
                    return String;
                case "3": 
                    AddDigit(3);
                    return String;
                case "4": 
                    AddDigit(4);
                    return String;
                case "5": 
                    AddDigit(5);
                    return String;
                case "6": 
                    AddDigit(6);
                    return String;
                case "7": 
                    AddDigit(7);
                    return String;
                case "8": 
                    AddDigit(8);
                    return String;
                case "9": 
                    AddDigit(9);
                    return String;
                case "\\":
                    if (String.Contains('/'))
                        return String;
                    AddSymbol("/");
                    return String;
                case "Sgn":
                    AddSign();
                    return String;
                //case "+":
                //    AddSymbol("+");
                //    return String;
                //case "-":
                //    AddSymbol("-");
                //    return String;
                //case "*":
                //    AddSymbol("*");
                //    return String;
                //case "/":
                //    AddSymbol(":");
                //    return String;
                case "BS":
                    BackSpace();
                    return String;
                case "CE":
                    Clear();
                    return String;
            }

            return String;
        }
    }
}
