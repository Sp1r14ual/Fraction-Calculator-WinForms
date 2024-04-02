using System;
using System.Collections.Generic;

namespace Fraction_Calculator_WinForms
{
    public struct Record
    {
        private TFrac left_operand;
        private TFrac right_operand;
        private string operation;
        private TFrac result;

        public Record()
        {
            left_operand = new TFrac();
            right_operand = new TFrac();
            operation = "None";
            result = new TFrac();
        }

        public Record(TFrac left_operand, TFrac right_operand, string operation, TFrac result)
        {
            this.left_operand = left_operand;
            this.right_operand = right_operand;
            this.operation = operation;
            this.result = result;
        }

        public TFrac LOperand
        {
            get { return left_operand; }
            set { left_operand = value; }
        }

        public TFrac ROperand
        {
            get { return right_operand; }
            set { right_operand = value; }
        }

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public TFrac Result
        {
            get { return result; }
            set { result = value; }
        }
        public override string ToString()
        {
            return $"LOperand: {left_operand}; Operation: {operation}; ROperand: {right_operand} => Result: {result}";
        }
    }

    public class History
    {
        private List<Record> L;

        public void AddRecord(Record record)
        {
            L.Add(record);
        }

        public List<Record> GetHistory()
        {
            return L;
        }

        public Record GetLastRecord()
        {
            return L.Last();
        }

        public void Clear()
        {
            L.Clear();
        }

        public int Count()
        {
            return L.Count();
        }

        public History()
        {
            L = new List<Record>();
        }
    }
}
