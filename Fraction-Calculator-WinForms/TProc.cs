namespace Fraction_Calculator_WinForms
{
    internal class TProc
    {
        public TFrac Lop_Res;
        public TFrac Rop;
        public State Operation;
        public enum State { None, Add, Sub, Mul, Dvd }

        //Добавить свойства для записи и чтения Lop_Res и Rop
        public TProc()
        {
            Lop_Res = new TFrac();
            Rop = new TFrac();
            Operation = State.None;
        }
        public void ReSet()
        {
            Lop_Res = new TFrac();
            Rop = new TFrac();
            Operation = State.None;
        }
        public void OprtnClear()
        {
            Operation = State.None;
        }

        public void OprtnRun()
        {
            if (Operation == State.None)
                return;

            switch (Operation)
            {
                case State.Add:
                    Lop_Res += Rop;
                    break;
                case State.Sub:
                    Lop_Res -= Rop;
                    break;
                case State.Mul:
                    Lop_Res *= Rop;
                    break;
                case State.Dvd:
                    Lop_Res /= Rop;
                    break;
            }
        }

        public void FuncRun(string function)
        {
            switch (function)
            {
                case "Sqr":
                    Rop = Operation == State.None ? Lop_Res = Lop_Res.Square() : Rop.Square();
                    break;
                case "Rev":
                    Rop = Operation == State.None ? Lop_Res = Lop_Res.Reciprocal() : Rop.Reciprocal();
                    break;
            }
        }

        public TFrac Lop_Res_Read()
        {
            return Lop_Res.Copy();
        }

        public void Lop_Res_Set(TFrac Operand)
        {
            Lop_Res = Operand.Copy();
        }

        public TFrac Rop_Read()
        {
            return Rop.Copy();
        }

        public void Rop_Set(TFrac Operand)
        {
            Rop = Operand.Copy();
        }

        public string OprtnRead()
        {
            return Operation.ToString();
        }

        public void OprtnSet(string S)
        {
            switch (S)
            {
                case "Add":
                    Operation = State.Add;
                    break;
                case "Sub":
                    Operation = State.Sub;
                    break;
                case "Mul":
                    Operation = State.Mul;
                    break;
                case "Dvd":
                    Operation = State.Dvd;
                    break;
                case "None":
                    Operation = State.None;
                    break;
            }
        }
    }
}
