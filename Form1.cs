using System.Data;

namespace SD_320_W22SD_Assignment
{
    public partial class Form1 : Form
    {
        private string storedOperand;
        private string currentOperand;
        private string storedOperation;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Number_Clicked(object sender, EventArgs e)
        {
            if(storedOperand != null && storedOperation == null)
            {
                storedOperand = null;
                currentOperand += (sender as Button).Text;
                textBoxOutput.Text = currentOperand;
            }
            else
            {
                currentOperand += (sender as Button).Text;
                textBoxOutput.Text = currentOperand;
            }          
        }

        private void button_Operation_Clicked(object sender, EventArgs e)
        {
            if(storedOperand != null && currentOperand == null)
            {
                storedOperation = (sender as Button).Text;
                textBoxOutput.Text = (sender as Button).Text;
            }
            else if(storedOperand != null && storedOperation != null && currentOperand != null)
            {
                string calculation = (storedOperand + storedOperation + currentOperand).Replace("X", "*").Replace("¡Â", "/");
                string answer = new DataTable().Compute(calculation, null).ToString();
                textBoxOutput.Text = answer;
                storedOperand = answer;
                storedOperation = (sender as Button).Text;
                currentOperand = null;
            }else if (storedOperand == null && storedOperation == null && currentOperand != null)
            {
                textBoxOutput.Text = (sender as Button).Text;
                storedOperand = currentOperand;
                currentOperand = null;
                storedOperation = (sender as Button).Text;
            }
        }

        private void button_Equals_Clicked(object sender, EventArgs e)
        {
            if (storedOperand != null && currentOperand != null && storedOperation != null)
            {
                string calculation = (storedOperand + storedOperation + currentOperand).Replace("X","*").Replace("¡Â","/");
                string answer = new DataTable().Compute(calculation, null).ToString();
                textBoxOutput.Text = answer;
                storedOperand = answer;
                storedOperation = null;
                currentOperand = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {             

        }

        private void button_Clear(object sender, EventArgs e)
        {
            storedOperand = null;
            currentOperand = null;
            storedOperation = null;
            textBoxOutput.Text = "";
            Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_BIN(object sender, EventArgs e)
        {
            if (textBoxOutput.Text != null && textBoxOutput.Text != "")
            {
                string binary = Convert.ToString(Int32.Parse(textBoxOutput.Text), 2);
                textBoxOutput.Text = binary;
            }
        }

        private void button_DEC(object sender, EventArgs e)
        {
            if (textBoxOutput.Text != null && textBoxOutput.Text != "")
            {
                if (isBinary(textBoxOutput.Text))
                {
                    string decimalNum = Convert.ToInt32(textBoxOutput.Text, 2).ToString();
                    textBoxOutput.Text = decimalNum;
                }
            }
        }

        private bool isBinary(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if ((int)Char.GetNumericValue(num[i]) > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}