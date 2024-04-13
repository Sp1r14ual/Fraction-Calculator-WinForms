using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Fraction_Calculator_WinForms
{
    public class TCtrl
    {
        public TEditor Editor;
        public TProc Proc;
        public TMemory Memory;
        public TFrac Fraction;
        public TCtlrState CtrlState;
        public enum TCtlrState { cStart, cEditing, FunDone, cValDone, cExpDone, cOpChange, cError }

        public History History;

        private bool integer_format;

        //костыль
        private string LastOperation;

        public TCtrl()
        {
            Editor = new TEditor();
            Proc = new TProc();
            Memory = new TMemory();
            Fraction = new TFrac();
            CtrlState = TCtlrState.cStart;
            History = new History();

            integer_format = false;
        }

        public void integer_format_check()
        {
            integer_format = true;
        }

        public void integer_format_uncheck()
        {
            integer_format = false;
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

        private void PrepareRecord(ref Record record)
        {
            record.LOperand = Proc.Lop_Res_Read();
            record.ROperand = Proc.Rop_Read();
            //record.Operation = Proc.OprtnRead();

            switch (Proc.OprtnRead())
            {
                case "None":
                    record.Operation = "None";
                    break;
                case "Add":
                    record.Operation = "+";
                    break;
                case "Sub":
                    record.Operation = "-";
                    break;
                case "Mul":
                    record.Operation = "*";
                    break;
                case "Dvd":
                    record.Operation = "/";
                    break;
            }
        }

        public string CalculatorCommand(string c)
        {
            Record record = new Record();

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
                OperationCommand(c);
                Proc.Rop_Set(new TFrac());
                LastOperation = c;
                return Proc.Lop_Res_Read().Denominator == 1 && integer_format ? Proc.Lop_Res_Read().GetFractionString().Split("/")[0] : Proc.Lop_Res_Read().GetFractionString();
            }
            //Костыли это круто!
            //Давайте делать больше костылей
            //Давайте всё утычем этими костылями

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

                    //Готовим запись в историю
                    PrepareRecord(ref record);

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
                        record.LOperand = Fraction.Copy();
                        record.Operation = c;

                        FunctionCommand(c);
                        Fraction = Proc.OprtnRead() == "None" ? Proc.Lop_Res_Read() : Proc.Rop_Read();

                        record.ROperand = new TFrac();
                        record.Result = Fraction.Copy();

                        History.AddRecord(record);

                        return Fraction.Denominator == 1 && integer_format ? Fraction.GetFractionString().Split("/")[0] : Fraction.GetFractionString();
                    }

                    Fraction = Proc.Lop_Res_Read();

                    record.Result = Fraction.Copy();

                    History.AddRecord(record);

                    return Fraction.Denominator == 1 && integer_format ? Fraction.GetFractionString().Split("/")[0] : Fraction.GetFractionString();
            }

            return Editor.String;
        }
        
    }
}