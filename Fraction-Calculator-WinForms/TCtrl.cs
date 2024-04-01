using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fraction_Calculator_WinForms
{
    internal class TCtrl
    {
        public TEditor Editor;
        public TProc Proc;
        public TMemory Memory;
        public TFrac Fraction;
        public TCtlrState CtrlState;
        public enum TCtlrState { cStart, cEditing, FunDone, cValDone, cExpDone, cOpChange, cError }

        //костыль
        private string LastOperation;

        //private List<String> History;

        public TCtrl()
        {
            Editor = new TEditor();
            Proc = new TProc();
            Memory = new TMemory();
            Fraction = new TFrac();
            CtrlState = TCtlrState.cStart;
            //History = new List<String>();
        }

        public void EditCommand(string c)
        {
            CtrlState = TCtlrState.cEditing;
            Editor.Edit(c);
        }

        public void MemoryCommand(string c)
        {
            switch (c)
            {
                case "M+":
                    if (Fraction.Empty())
                        Memory.TAdd(Proc.Lop_Res_Read());
                    else
                        Memory.TAdd(Fraction);
                    break;
                case "MS":
                    if (Fraction.Empty())
                        Memory.TStore(Proc.Lop_Res_Read());
                    else
                        Memory.TStore(Fraction);
                    break;
                case "MR":
                    Fraction = Memory.TGet();
                    Editor.String = Fraction.GetFractionString();
                    break;
                case "MC":
                    Memory.TClear();
                    break;
            }
        }

        public void OperationCommand(string c)
        {
            switch (c)
            {
                case "+":
                    Proc.OprtnSet("Add");
                    break;
                case "-":
                    Proc.OprtnSet("Sub");
                    break;
                case "*":
                    Proc.OprtnSet("Mul");
                    break;
                case "/":
                    Proc.OprtnSet("Dvd");
                    break;
            }
        }

        public void FunctionCommand(string c)
        {
            switch (c)
            {
                case "Sqr":
                    Proc.FuncRun("Sqr");
                    break;
                case "Rev":
                    Proc.FuncRun("Rev");
                    break;
            }
        }
        
        public string CalculatorCommand(string c)
        {
            // Костыль на случай если Editor.Empty()
            try
            {
                Fraction = new TFrac(Editor.String);
            }
            catch
            {
                Fraction = Proc.Lop_Res_Read();
                if (Editor.Empty() && Proc.Rop_Read().Empty() && c == "=")
                    Proc.Rop_Set(Fraction);
            }
            //Мб можно придумать что-то получше?

            //Ещё костыль
            if (c != "=" && LastOperation == "=")
            {
                Editor.Clear();
                Proc.Rop_Set(new TFrac());
                LastOperation = c;
                return Proc.Lop_Res_Read().GetFractionString();
            }
            //Запомните, сукины дети, костыли это круто!
            //Давайте делать больше костылей
            //Давайте всё утыкаем этими костылями
            //Это же так весело, правда?

            LastOperation = c;

            EditCommand(c);
            MemoryCommand(c);

            switch (c)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "=":
                case "Sqr":
                case "Rev":
                    if (!Editor.Empty())
                    {
                        if (Proc.Lop_Res_Read().Empty() && Proc.OprtnRead() == "None")
                            Proc.Lop_Res_Set(Fraction);
                        else
                            Proc.Rop_Set(Fraction);

                        Editor.Clear();
                    }
                    //if (Editor.Empty() && c != "=")
                    //{
                    //    //Fraction = Proc.Lop_Res_Read();
                    //    Proc.Rop_Set(Fraction);
                    //}

                    if (!(c == "Sqr" || c == "Rev"))
                    {
                        if (Proc.OprtnRead() != "None")
                        {
                            Proc.OprtnRun();
                            if (c != "=")
                                Proc.OprtnSet("None");
                        }

                        OperationCommand(c);
                    }
                    else
                    {
                        FunctionCommand(c);
                        Fraction = Proc.OprtnRead() == "None" ? Proc.Lop_Res_Read() : Proc.Rop_Read();
                        return Fraction.GetFractionString();
                    }

                    Fraction = Proc.Lop_Res_Read();
                    return Fraction.GetFractionString();
            }

            return Editor.String;
        }
        
    }
}