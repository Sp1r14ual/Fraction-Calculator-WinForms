namespace Fraction_Calculator_WinForms
{
    public partial class Form1 : Form
    {
        TCtrl controller = new TCtrl();
        public Form1()
        {
            InitializeComponent();
        }

        private void update_history()
        {


            dataGridView1.Rows.Clear();
            foreach (var record in controller.History.GetHistory())
            {
                string loperand_arg = record.LOperand.Denominator == 1 && radioButton2.Checked
                    ? record.LOperand.GetFractionString().Split("/")[0]
                    : record.LOperand.GetFractionString();

                string operation_arg = record.Operation;

                string roperand_arg = record.ROperand.Denominator == 1 && radioButton2.Checked
                    ? record.ROperand.GetFractionString().Split("/")[0]
                    : record.ROperand.GetFractionString();

                string result_arg = record.Result.Denominator == 1 && radioButton2.Checked
                    ? record.Result.GetFractionString().Split("/")[0]
                    : record.Result.GetFractionString();

                dataGridView1.Rows.Add(new string[]
                {
                    loperand_arg,
                    operation_arg,
                    roperand_arg,
                    result_arg
                });
            }
        }

        private bool check_input()
        {
            string input = textBox1.Text;
            return input.Split("/")[0].Length <= 10 && input.Split("/")[1].Length <= 10;
        }

        //button 0
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("0");
        }

        //button 1
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("3");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("5");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("6");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("7");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("8");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("9");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("Sgn");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("\\");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (check_input())
            {
                textBox1.Text = controller.CalculatorCommand("+");
                update_history();
            }
            else
            {
                controller.Editor.Clear();
                textBox1.Text = "ERR";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (check_input())
            {
                textBox1.Text = controller.CalculatorCommand("-");
                update_history();
            }
            else
            {
                controller.Editor.Clear();
                textBox1.Text = "ERR";
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (check_input())
            {
                textBox1.Text = controller.CalculatorCommand("*");
                update_history();
            }
            else
            {
                controller.Editor.Clear();
                textBox1.Text = "ERR";
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (check_input())
            {
                textBox1.Text = controller.CalculatorCommand("/");
                update_history();
            }
            else
            {
                controller.Editor.Clear();
                textBox1.Text = "ERR";
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (check_input())
            {
                textBox1.Text = controller.CalculatorCommand("=");
                update_history();
            }
            else
            {
                controller.Editor.Clear();
                textBox1.Text = "ERR";
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("Sqr");
        }
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("Rev");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("M+");
        }
        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("MS");
        }
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("MR");
        }
        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("MC");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("BS");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("CE");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //Отрефакторить
            controller.Proc.ReSet();
            textBox1.Text = controller.CalculatorCommand("CE");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            controller.History.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            controller.integer_format_uncheck();
            update_history();
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            controller.integer_format_check();
            update_history();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            List<string> symbols = new List<string>()
            {
                "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "Back", "Delete", "Enter",
                "NumPad0", "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8",
                "NumPad9", "Oemplus", "OemMinus", "Oem2", "Oem3", "OemPipe", "Add", "Subtract", "Multiply", "Divide", "C"
            };

            var sym = e.KeyCode.ToString();

            if (!(symbols.Contains(sym)))
                return;

            //textBox1.Text = sym;

            switch (sym)
            {
                case "D0":
                case "NumPad0":
                    textBox1.Text = controller.CalculatorCommand("0");
                    break;
                case "D1":
                case "NumPad1":
                    textBox1.Text = controller.CalculatorCommand("1");
                    break;
                case "D2":
                case "NumPad2":
                    textBox1.Text = controller.CalculatorCommand("2");
                    break;
                case "D3":
                case "NumPad3":
                    textBox1.Text = controller.CalculatorCommand("3");
                    break;
                case "D4":
                case "NumPad4":
                    textBox1.Text = controller.CalculatorCommand("4");
                    break;
                case "D5":
                case "NumPad5":
                    textBox1.Text = controller.CalculatorCommand("5");
                    break;
                case "D6":
                case "NumPad6":
                    textBox1.Text = controller.CalculatorCommand("6");
                    break;
                case "D7":
                case "NumPad7":
                    textBox1.Text = controller.CalculatorCommand("7");
                    break;
                case "D8":
                case "NumPad8":
                    textBox1.Text = controller.CalculatorCommand("8");
                    break;
                case "D9":
                case "NumPad9":
                    textBox1.Text = controller.CalculatorCommand("9");
                    break;
                case "OemPipe":
                    textBox1.Text = controller.CalculatorCommand("\\");
                    break;
                case "Oem3":
                    textBox1.Text = controller.CalculatorCommand("Sgn");
                    break;
                case "Oemplus":
                case "Add":
                    if (check_input())
                    {
                        textBox1.Text = controller.CalculatorCommand("+");
                        update_history();
                    }
                    else
                    {
                        controller.Editor.Clear();
                        textBox1.Text = "ERR";
                    }

                    break;
                case "OemMinus":
                case "Subtract":
                    if (check_input())
                    {
                        textBox1.Text = controller.CalculatorCommand("-");
                        update_history();
                    }
                    else
                    {
                        controller.Editor.Clear();
                        textBox1.Text = "ERR";
                    }
                    break;
                case "Multiply":
                    if (check_input())
                    {
                        textBox1.Text = controller.CalculatorCommand("*");
                        update_history();
                    }
                    else
                    {
                        controller.Editor.Clear();
                        textBox1.Text = "ERR";
                    }
                    break;
                case "Divide":
                case "Oem2":
                    if (check_input())
                    {
                        textBox1.Text = controller.CalculatorCommand("/");
                        update_history();
                    }
                    else
                    {
                        controller.Editor.Clear();
                        textBox1.Text = "ERR";
                    }
                    break;
                case "Back":
                    textBox1.Text = controller.CalculatorCommand("BS");
                    break;
                case "Delete":
                    textBox1.Text = controller.CalculatorCommand("CE");
                    break;
                case "C":
                    controller.Proc.ReSet();
                    textBox1.Text = controller.CalculatorCommand("CE");
                    break;
                case "Enter":
                    if (check_input())
                    {
                        textBox1.Text = controller.CalculatorCommand("=");
                        update_history();
                    }
                    else
                    {
                        controller.Editor.Clear();
                        textBox1.Text = "ERR";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
