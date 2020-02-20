using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200223057_a2
{
    public class Calculator
    {
        private decimal currentValue;
        private decimal operand1;
        private decimal operand2;
        private enum Operator {Add, Subtract, Multiply, Divide, None};
        private Operator op;

        public Calculator() //Initializes the default values.
        {
            currentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = Operator.None;
        }

        public decimal GetCurrentValue() //Gets the current value.
        {
            return currentValue;
        }

        public void SetCurrentValue(decimal displayValue)
        {
            currentValue = displayValue;
        }

        public void SetOperand1(decimal displayValue)
        {
            operand1 = displayValue;
        }

        public void Add(decimal displayValue) //Addition method.
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = Operator.Add;
        }

        public void Subtract(decimal displayValue) //Subtraction method.
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = Operator.Subtract;
        }

        public void Multiply(decimal displayValue) //Multiplication method.
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = Operator.Multiply;
        }

        public void Divide(decimal displayValue) //Division method.
        {
            operand1 = displayValue;
            currentValue = displayValue;
            op = Operator.Divide;
        }

        public void None() //So we can reset the operator
        {
            op = Operator.None;
        }

        public void Equals() //First overloaded equals method, repeats operand2 value.
        {
            switch(op)
            {
                case Operator.Add:
                    operand1 += operand2;
                    currentValue = operand1;
                    break;
                case Operator.Subtract:
                    operand1 -= operand2;
                    currentValue = operand1;
                    break;
                case Operator.Multiply:
                    operand1 *= operand2;
                    currentValue = operand1;
                    break;
                case Operator.Divide:
                    operand1 /= operand2;
                    currentValue = operand1;
                    break;
                case Operator.None:
                    break;
                default:
                    break;
            }
        }

        public void Equals(decimal displayValue) //Second overloaded Equals method,
        {                                        //that takes new operand2.
            operand2 = displayValue;
            switch (op)
            {
                case Operator.Add:
                    operand1 += operand2;
                    currentValue = operand1;
                    break;
                case Operator.Subtract:
                    operand1 -= operand2;
                    currentValue = operand1;
                    break;
                case Operator.Multiply:
                    operand1 *= operand2;
                    currentValue = operand1;
                    break;
                case Operator.Divide:
                    operand1 /= operand2;
                    currentValue = operand1;
                    break;
                case Operator.None:
                    break;
                default:
                    break;
            }
        }

        public void Clear() //Resets variables to default values.
        {
            currentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = Operator.None;
        }
    }
}
