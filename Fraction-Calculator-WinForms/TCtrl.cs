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

        public string EditCommand(string c)
        {
            CtrlState = TCtlrState.cEditing;
            return Editor.Edit(c);
        }
        public string MemoryCommand()
        {
            //To-Do
            return String.Empty;
        }
    }
}


//        if (CtrlState == TCtlrState.cEditing)
//        {
//            CtrlState = TCtlrState.cValDone;
//            if (Proc.OprtnRead() == "None")
//            {
//                string oprtn = c == "+" ? "Add" : c == "-" ? "Sub" : c == "*" ? "Mul" : "Dvd";
//                Proc.OprtnSet(oprtn);
//                Proc.Lop_Res_Set(Fraction);
//            }
//            else
//            {
//                string oprtn = c == "+" ? "Add" : c == "-" ? "Sub" : c == "*" ? "Mul" : "Dvd";
//                Proc.OprtnSet(oprtn);
//                Proc.Rop_Set(Fraction);
//            }
//        }
//        else if (CtrlState == TCtlrState.cValDone || CtrlState == TCtlrState.cOpChange)
//        {
//            CtrlState = TCtlrState.cOpChange;
//            for (uint i = 0; i < 3; i++)
//                Editor.Edit("BS");

//        }

//        Editor.Edit(c);
//        break;
//}

//return Editor.String;