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
            textBox1.Text = controller.EditCommand("0");
        }

        //button 1
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("3");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("5");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("6");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("7");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("8");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("9");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("\\");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("+");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("-");
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("*");
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("/");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("BS");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = controller.EditCommand("CE");
        }


    }
}
