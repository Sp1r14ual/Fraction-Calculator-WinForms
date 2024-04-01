namespace Fraction_Calculator_WinForms
{
    public partial class Form1 : Form
    {
        TCtrl controller = new TCtrl();
        public Form1()
        {
            InitializeComponent();
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
            textBox1.Text = controller.CalculatorCommand("+");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("-");
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("*");
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("/");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.CalculatorCommand("=");
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
    }
}
