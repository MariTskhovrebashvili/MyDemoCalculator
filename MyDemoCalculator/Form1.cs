using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDemoCalculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool enterValue = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNumbers_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || txtResult.Text == "." || enterValue || txtResult.Text == "∞")
            {
                txtResult.Clear();
            }

            Button button = (Button)sender;
            enterValue = false;

            if (button.Text != ".")
            {
                txtResult.Text += button.Text;
            }
            else
            {
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text += button.Text;
                }
            }
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result != 0 && operation != "" && !enterValue)
            {
                btnGetResult.PerformClick();
            }
            else
            {
                result = Double.Parse(txtResult.Text);
            }
            enterValue = true;
            operation = button.Text;
            lblExpression.Text = result + " " + operation;
        }

        private void BtnGetResult_Click(object sender, EventArgs e)
        {
            lblExpression.Text = "";

            switch (operation)
            {
                case "+":
                    txtResult.Text = (result + Double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (result - Double.Parse(txtResult.Text)).ToString();
                    break;
                case "×":
                    txtResult.Text = (result * Double.Parse(txtResult.Text)).ToString();
                    break;
                case "÷":
                    if (Double.Parse(txtResult.Text) == 0)
                    {
                        lblExpression.Text = "Cannot divide by zero";
                    }
                    else
                    {
                        txtResult.Text = (result / Double.Parse(txtResult.Text)).ToString();
                    }
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtResult.Text);
            operation = "";
        }

        /*private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            //it prevents letters from entering and decimal point from re-entering.
            //line-451 in Form1Designer
            //behabior enabled statuse - false
            e.Handled = char.IsLetter(e.KeyChar) || (e.KeyChar == '.' && txtResult.Text.Contains('.'));
        }*/

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lblExpression.Text = "";
            result = 0;
            operation = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }

            if (txtResult.Text.Length == 0)
            {
                txtResult.Text = "0";
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            txtResult.Text = (-1 * Double.Parse(txtResult.Text)).ToString();
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            txtResult.Text = (Double.Parse(txtResult.Text) / 100).ToString();
        }
    }
}
