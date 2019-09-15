using System;
using System.Collections;

namespace Yanyixiao
{
    class Program
    {

        private static String[] op = { "+", "-", "*", "/" };// Operation set
        static void Main(string[] args)
        {
            String question = MakeFormula();
            System.Console.WriteLine(question);
            String ret = Solve(question);
            System.Console.WriteLine(ret);

        }


        public static String MakeFormula()
        {
            Random ran = new Random();
            String build = null;
            int count = (int)ran.Next(1, 3); // generate random count
            int start = 0;
            int number1 = ran.Next(1, 99);
            build = build + number1;
            while (start <= count)
            {
                int operation = (int)ran.Next(0, 3); ; // generate operator
                int number2 = (int)ran.Next(1, 99);
                build = build + op[operation] + number2;
                start++;
            }
            return build;
        }


        public static String Solve(String formula)
        {
            Stack tempStack = new Stack();//Store number or operator
            Stack operatorStack = new Stack();//Store operator
            int len = formula.Length;
            int k = 0;
            for (int j = -1; j < len - 1; j++)
            {
                string formulaChar = formula.Substring(j + 1, 2);
                if (j == len - 2 || formulaChar.Equals('+') || formulaChar.Equals('-') || formulaChar.Equals('/') || formulaChar.Equals('*'))
                {
                    if (j == len - 2)
                    {
                        tempStack.Push(formula.Substring(k));
                    }
                    else
                    {
                        if (k < j)
                        {
                            tempStack.Push(formula.Substring(k, j + 1));
                        }
                        if (operatorStack.Count == 0)
                        {
                            operatorStack.Push(formulaChar); //if operatorStack is empty, store it)
                        }
                        else
                        {
                            char stackChar = (char)operatorStack.Peek();
                            if ((stackChar == '+' || stackChar == '-') && (formulaChar.Equals('*') || formulaChar.Equals('/')))
                            {
                                operatorStack.Push(formulaChar);
                            }
                            else
                            {
                                tempStack.Push(operatorStack.Pop());
                                operatorStack.Push(formulaChar);
                            }
                        }
                    }
                    k = j + 2;
                }
            }
            while (!(operatorStack.Count == 0))
            { // Append remaining operators
                tempStack.Push(operatorStack.Pop());
            }
            Stack calcStack = new Stack();
            foreach (String peekChar in tempStack)
            { // Reverse traversing of stack
                if (!(peekChar.CompareTo("+") == 0) && !(peekChar.CompareTo("-") == 0) && !(peekChar.CompareTo("/") == 0) && (peekChar.CompareTo("*") == 0))
                {
                    calcStack.Push(peekChar); // Push number to stack
                }
                else
                {
                    int a1 = 0;
                    int b1 = 0;
                    if (!(calcStack.Count == 0))
                    {
                        b1 = (int)(calcStack.Pop());
                    }
                    if (!(calcStack.Count == 0))
                    {
                        a1 = (int)(calcStack.Pop());
                    }
                    switch (peekChar)
                    {
                        case "+":
                            calcStack.Push((char)(a1 + b1));
                            break;
                        case "-":
                            calcStack.Push((char)(a1 - b1));
                            break;
                        case "*":
                            calcStack.Push((char)(a1 * b1));
                            break;
                        default:
                            calcStack.Push((char)(a1 / b1));
                            break;
                    }
                }
            }
            return formula + "=" + calcStack.Pop();
        }
    }
}

