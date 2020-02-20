using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200223057_a2
{
    public partial class frm_Calculator : Form
    {
        Calculator calc = new Calculator();

        public frm_Calculator()
        {
            InitializeComponent();
            this.KeyPreview = true; //Allows form to check key before focus item.
            this.KeyDown += new KeyEventHandler(frm_Calculator_KeyDown);
        }

        private Boolean OperatorCheck() //Saves redundant code.
        {
            StringBuilder sb = new StringBuilder(tBox_calculator.Text);
            Boolean isone = false;
            for (int i = 0; i < sb.Length; i++) //Checks to make sure there is no operator.
            {
                if (sb.ToString(i, 1).Equals("+") || sb.ToString(i, 1).Equals("-") ||
                    sb.ToString(i, 1).Equals("/") || sb.ToString(i, 1).Equals("*"))
                {
                    try
                    {
                        sb.ToString(i - 1, 1); //Makes sure isn't a negative number.
                        isone = true;
                    }
                    catch
                    {
                    }
                }
            }
            return isone;
        }

        private void RunEquals() //Saves redundant code.
        {
            StringBuilder sb = new StringBuilder(tBox_calculator.Text);
            int indexed = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb.ToString(i, 1).Equals("+") || sb.ToString(i, 1).Equals("-") ||
                    sb.ToString(i, 1).Equals("/") || sb.ToString(i, 1).Equals("*"))
                {
                    indexed = i+1; //Checks for operator and sets index point.
                }
            }
            try //If this doesn't work than there is no value after the operator.
            {
                calc.Equals(Convert.ToDecimal(sb.ToString(indexed, (sb.Length - indexed))));
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
            }
            catch { }
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text += "9";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder(tBox_calculator.Text);
                int size = sb.Length;
                if(sb.ToString(size - 1, 1).Equals("+") || sb.ToString(size - 1, 1).Equals("-")
                   || sb.ToString(size - 1, 1).Equals("+") || sb.ToString(size - 1, 1).Equals("+"))
                {
                    calc.None();
                }
                sb.Remove(size - 1, 1);
                tBox_calculator.Text = sb.ToString();
            }
            catch { }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tBox_calculator.Text = "";
            calc.Clear();
        }

        private void btn_decimal_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(tBox_calculator.Text);
            Boolean isone = false;

            for(int i = 0; i < sb.Length; i++) //Checks to make sure there isn't a decimal.
            {
                if (sb.ToString(i, 1).Equals("."))
                {
                    isone = true;
                }
                else if (sb.ToString(i, 1).Equals("+") || sb.ToString(i, 1).Equals("-") ||
                        sb.ToString(i, 1).Equals("/") || sb.ToString(i, 1).Equals("*"))
                {
                    isone = false; //This else if allows a second decimal
                }
            }

            if (isone) //If there is a decimal doesn't do anything.
            { }
            else
            {
                tBox_calculator.Text += "."; //If false, adds a decimal.
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (OperatorCheck())
            {
                RunEquals();
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
                calc.Add(Convert.ToDecimal(tBox_calculator.Text));
                tBox_calculator.Text += "+";
            }
            else
            {
                try
                {
                    calc.Add(Convert.ToDecimal(tBox_calculator.Text));
                    tBox_calculator.Text += "+";
                }
                catch { }
            }
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            if (OperatorCheck())
            {
                RunEquals();
            }
            else
            {
                calc.Equals();
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
            }
        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            if (OperatorCheck())
            {
                RunEquals();
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
                calc.Subtract(Convert.ToDecimal(tBox_calculator.Text));
                tBox_calculator.Text += "-";
            }
            else
            {
                try
                {
                    calc.Subtract(Convert.ToDecimal(tBox_calculator.Text));
                    tBox_calculator.Text += "-";
                }
                catch { }
            }
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            if (OperatorCheck())
            {
                RunEquals();
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
                calc.Multiply(Convert.ToDecimal(tBox_calculator.Text));
                tBox_calculator.Text += "*";
            }
            else
            {
                try
                {
                    calc.Multiply(Convert.ToDecimal(tBox_calculator.Text));
                    tBox_calculator.Text += "*";
                }
                catch { }
            }
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            if (OperatorCheck())
            {
                RunEquals();
                tBox_calculator.Text = calc.GetCurrentValue().ToString();
                calc.Divide(Convert.ToDecimal(tBox_calculator.Text));
                tBox_calculator.Text += "/";
            }
            else
            {
                try
                {
                    calc.Divide(Convert.ToDecimal(tBox_calculator.Text));
                    tBox_calculator.Text += "/";
                }
                catch { }
            }
        }

        private void btn_1x_Click(object sender, EventArgs e)
        {
            if (OperatorCheck()) //If theres an operator doesn't do anything.
            {
            }
            else
            {
                try
                {
                    calc.Divide(1); //Sets to division with 1.
                    RunEquals(); //Runs the equation.
                }
                catch { }
            }
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            if (OperatorCheck()) //If theres an operator doesn't do anything.
            {
            }
            else
            {
                try //Converts text to a double, square roots, converts back, sets current value and operand1.
                {
                    tBox_calculator.Text = Math.Sqrt(Convert.ToDouble(tBox_calculator.Text)).ToString();
                    calc.SetCurrentValue(Convert.ToDecimal(tBox_calculator.Text));
                    calc.SetOperand1(Convert.ToDecimal(tBox_calculator.Text));
                }
                catch { }
            }
        }

        private void btn_negative_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(tBox_calculator.Text);
            try
            {
                sb.ToString(0, 1);
            }
            catch
            {
                tBox_calculator.Text += "-";
            }
        }

        void frm_Calculator_KeyDown(object sender, KeyEventArgs e) //All keydown events.
        {
            if (e.KeyCode == Keys.D8 && e.Shift || e.KeyCode == Keys.Multiply)
            {
                if (OperatorCheck())
                {
                    RunEquals();
                    tBox_calculator.Text = calc.GetCurrentValue().ToString();
                    calc.Multiply(Convert.ToDecimal(tBox_calculator.Text));
                    tBox_calculator.Text += "*";
                }
                else
                {
                    try
                    {
                        calc.Multiply(Convert.ToDecimal(tBox_calculator.Text));
                        tBox_calculator.Text += "*";
                    }
                    catch { }
                }
            }
            else if(e.KeyCode == Keys.Oemplus && e.Shift || e.KeyCode == Keys.Enter)
            {
                if (OperatorCheck())
                {
                    RunEquals();
                }
                else
                {
                    calc.Equals();
                    tBox_calculator.Text = calc.GetCurrentValue().ToString();
                }
            }
            else
            {
                {
                    tBox_calculator.Text += "";
                }
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    tBox_calculator.Text += "0";
                }

                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    tBox_calculator.Text += "1";
                }

                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    tBox_calculator.Text += "2";
                }

                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    tBox_calculator.Text += "3";
                }

                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    tBox_calculator.Text += "4";
                }

                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    tBox_calculator.Text += "5";
                }

                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    tBox_calculator.Text += "6";
                }

                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    tBox_calculator.Text += "7";
                }

                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    tBox_calculator.Text += "8";
                }

                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    tBox_calculator.Text += "9";
                }

                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder(tBox_calculator.Text);
                        int size = sb.Length;
                        if (sb.ToString(size - 1, 1).Equals("+") || sb.ToString(size - 1, 1).Equals("-")
                           || sb.ToString(size - 1, 1).Equals("+") || sb.ToString(size - 1, 1).Equals("+"))
                        {
                            calc.None();
                        }
                        sb.Remove(size - 1, 1);
                        tBox_calculator.Text = sb.ToString();
                    }
                    catch { }
                }

                if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
                {
                    if (OperatorCheck())
                    {
                        RunEquals();
                        tBox_calculator.Text = calc.GetCurrentValue().ToString();
                        calc.Divide(Convert.ToDecimal(tBox_calculator.Text));
                        tBox_calculator.Text += "/";
                    }
                    else
                    {
                        try
                        {
                            calc.Divide(Convert.ToDecimal(tBox_calculator.Text));
                            tBox_calculator.Text += "/";
                        }
                        catch { }
                    }
                }

                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    if (OperatorCheck())
                    {
                        RunEquals();
                        tBox_calculator.Text = calc.GetCurrentValue().ToString();
                        calc.Add(Convert.ToDecimal(tBox_calculator.Text));
                        tBox_calculator.Text += "+";
                    }
                    else
                    {
                        try
                        {
                            calc.Add(Convert.ToDecimal(tBox_calculator.Text));
                            tBox_calculator.Text += "+";
                        }
                        catch { }
                    }
                }

                if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    if (OperatorCheck())
                    {
                        RunEquals();
                        tBox_calculator.Text = calc.GetCurrentValue().ToString();
                        calc.Subtract(Convert.ToDecimal(tBox_calculator.Text));
                        tBox_calculator.Text += "-";
                    }
                    else
                    {
                        try
                        {
                            calc.Subtract(Convert.ToDecimal(tBox_calculator.Text));
                            tBox_calculator.Text += "-";
                        }
                        catch { }
                    }
                }

                if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
                {
                    StringBuilder sb = new StringBuilder(tBox_calculator.Text);
                    Boolean isone = false;

                    for (int i = 0; i < sb.Length; i++) //Checks to make sure there isn't a decimal.
                    {
                        if (sb.ToString(i, 1).Equals("."))
                        {
                            isone = true;
                        }
                        else if (sb.ToString(i, 1).Equals("+") || sb.ToString(i, 1).Equals("-") ||
                                sb.ToString(i, 1).Equals("/") || sb.ToString(i, 1).Equals("*"))
                        {
                            isone = false; //This else if allows a second decimal
                        }
                    }

                    if (isone) //If there is a decimal doesn't do anything.
                    { }
                    else
                    {
                        tBox_calculator.Text += "."; //If false, adds a decimal.
                    }
                }
            }
        }
    }
}
