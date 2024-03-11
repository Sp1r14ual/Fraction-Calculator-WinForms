namespace Fraction_Calculator_WinForms
{
    internal class TMemory
    {
        private TFrac FNumber;

        public enum State { _Off, _On }

        public State FState;

        //Реализовать свойства для FNumber и FState

        public TMemory()
        {
            FNumber = new TFrac();
            FState = State._Off;
        }

        public void TStore(TFrac fraction)
        {
            FNumber = fraction.Copy();
            FState = State._On;
        }

        public TFrac TGet()
        {
            FState = State._On;
            return FNumber.Copy();
        }

        public void TAdd(TFrac fraction)
        {
            if (FState == State._Off)
                TStore(fraction);
            else
                FNumber += fraction;

            FState = State._On;
        }

        public void TClear()
        {
            FNumber = new TFrac();
            FState = State._Off;
        }

        public string GetState()
        {
            return FState.ToString();
        }

        public TFrac TRead()
        {
            return FNumber.Copy();
        }
    }
}
