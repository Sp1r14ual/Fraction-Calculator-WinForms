using System;
using System.Collections.Generic;

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
                default:
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
                default:
                    break;
            }
        }
        
        public string CalculatorCommand(string c)
        {
            EditCommand(c);
            //MemoryCommand(c);

            switch (c)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "=":
                case "Sqr":
                case "Rev":

                    // Костыль
                    try
                    {
                        Fraction = new TFrac(Editor.String);
                    }
                    catch
                    {
                        Fraction = Proc.Lop_Res_Read();
                    }
                    //Мб можно придумать что-то получше?

                    if (!Editor.Empty())
                    {
                        if (Proc.Lop_Res_Read().Empty() && Proc.OprtnRead() == "None")
                            Proc.Lop_Res_Set(Fraction);
                        else
                            Proc.Rop_Set(Fraction);

                        Editor.Clear();
                    }
                    //else
                    //{
                    //    Fraction = Proc.Lop_Res_Read();
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