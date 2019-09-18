

using System;
using System.Collections;
using System.Collections.Generic;

namespace Yanyixiao
{
    class Program
    {

        public class Formula
        {
            public string Form { get; internal set; }
            public Stack<string> Formstack = new Stack<string>();
        }

        public static string[] op = { "+", "-", "*", "/" };// Operation set
        static void Main(string[] args)
        {
            int i;
            System.Console.WriteLine("请输入需要的题目数量：");
            int n = Convert.ToInt32(System.Console.ReadLine());
            for (i = 0; i < n; i++)
            {
                Formula question = MakeFormula();
                System.Console.Write(question.Form);
                System.Console.Write("=");
                string ret = Solve(question);
                System.Console.WriteLine(ret);
            }

        }


        public static Formula MakeFormula()
        {
            Random ran = new Random();
            Formula Form = new Formula();
            string build = null;
            int count = (int)ran.Next(1, 3); // generate random count
            int start = 0;
            int number1 = ran.Next(1, 99);
            build = build + number1;
            Form.Formstack.Push(Convert.ToString(number1));//uytd 8796r756eu675v 786f876v

            while (start <= count)
            {
                int operation = (int)ran.Next(0, 3); ; // generate operator
                int number2 = (int)ran.Next(1, 99);
                build = build + op[operation] + number2;
                Form.Formstack.Push(op[operation]);
                Form.Formstack.Push(Convert.ToString(number2));
                start++;
            }
            Form.Form = build;
            return Form;
        }//Make a Formula(like 1*5+62-5)


        public static string Solve(Formula formula)
        {
            Stack<string> numberStack = new Stack<string>();//Store number
            Stack<string> operatorStack = new Stack<string>();//Store operator
            while (!(formula.Formstack.Count == 0))
            {
                if (!(formula.Formstack.Peek() == "+" || formula.Formstack.Peek() == "-"
                   || formula.Formstack.Peek() == "*" || formula.Formstack.Peek() == "/"))//判断是否数字或者operator
                {
                    numberStack.Push(formula.Formstack.Pop());
                }//如果是数字，压入numberStack
                else
                {
                    if ((string)formula.Formstack.Peek() == "*")
                    {
                        formula.Formstack.Pop();
                        int temp = int.Parse(formula.Formstack.Pop()) * int.Parse(numberStack.Pop());
                        numberStack.Push(Convert.ToString(temp));

                    }//如果栈顶为“*”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
                    else if ((string)formula.Formstack.Peek() == "/")
                    {
                        formula.Formstack.Pop();
                        int temp = int.Parse(formula.Formstack.Pop()) / int.Parse(numberStack.Pop());
                        numberStack.Push(Convert.ToString(temp));
                    }//如果栈顶为“/”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
                    else if ((string)formula.Formstack.Peek() == "+" || (string)formula.Formstack.Peek() == "-")
                    {
                        operatorStack.Push(formula.Formstack.Pop());
                    }
                }//非数字的处理方法
            }//计算算式中的乘除法，转化成加减法存入numberStack和opStack中
            while (!(numberStack.Count == 1))
            {
                if ((string)operatorStack.Peek() == "+")
                {
                    operatorStack.Pop();
                    int temp = int.Parse(numberStack.Pop()) + int.Parse(numberStack.Pop());
                    numberStack.Push(Convert.ToString(temp));

                }
                else if ((string)operatorStack.Peek() == "-")
                {
                    operatorStack.Pop();
                    int temp = int.Parse(numberStack.Pop()) - int.Parse(numberStack.Pop());
                    numberStack.Push(Convert.ToString(temp));
                }

            }//计算加减法
            return (string)numberStack.Pop();

        }
    }


}


//废弃代码 XD



//Stack tempStack = new Stack();//Store number or operator
//Stack operatorStack = new Stack();//Store operator
//int len = formula.Length;
//int k = 0;
//for (int j = -1; j < len - 1; j++)
//{
//    string formulaChar = formula.Substring(j + 1??, 2???);
//    if (j == len - 2 || formulaChar.Equals('+') || formulaChar.Equals('-') || formulaChar.Equals('/') || formulaChar.Equals('*'))
//    {
//        if (j == len - 2)
//        {
//            tempStack.Push(formula.Substring(k));
//        }
//        else
//        {
//            if (k < j)
//            {
//                tempStack.Push(formula.Substring(k, j + 1));
//            }
//            if (operatorStack.Count == 0)
//            {
//                operatorStack.Push(formulaChar); //if operatorStack is empty, store it)
//            }
//            else
//            {
//                char stackChar = (char)operatorStack.Peek();//Get the top char of opSrack
//                if ((stackChar == '+' || stackChar == '-') && (formulaChar.Equals('*') || formulaChar.Equals('/')))
//                {
//                    operatorStack.Push(formulaChar);
//                }
//                else
//                {
//                    tempStack.Push(operatorStack.Pop());
//                    operatorStack.Push(formulaChar);
//                }
//            }
//        }
//        k = j + 2;
//    }
//}
//while (!(operatorStack.Count == 0))
//{ // Append remaining operators
//    tempStack.Push(operatorStack.Pop());
//}
//Stack calcStack = new Stack();
//foreach (string peekChar in tempStack)
//{ // Reverse traversing of stack
//    if (!(peekChar.CompareTo("+") == 0) && !(peekChar.CompareTo("-") == 0) && !(peekChar.CompareTo("/") == 0) && (peekChar.CompareTo("*") == 0))
//    {
//        calcStack.Push(peekChar); // Push number to stack
//    }
//    else
//    {
//        int a1 = 0;
//        int b1 = 0;
//        if (!(calcStack.Count == 0))
//        {
//            b1 = (int)(calcStack.Pop());
//        }
//        if (!(calcStack.Count == 0))
//        {
//            a1 = (int)(calcStack.Pop());
//        }
//        switch (peekChar)
//        {
//            case "+":
//                calcStack.Push((char)(a1 + b1));
//                break;
//            case "-":
//                calcStack.Push((char)(a1 - b1));
//                break;
//            case "*":
//                calcStack.Push((char)(a1 * b1));
//                break;
//            default:
//                calcStack.Push((char)(a1 / b1));
//                break;
//        }
//    }
//}
//return formula + "=" + calcStack.Pop();//using System;
//using System.Collections;

//namespace Yanyixiao
//{
//    class Program
//    {
//        public class Formula
//        {
//            public string Form { get; internal set; }
//            public Stack Formstack { get; internal set; }
//        }

//        static string[] op = { "+", "-", "*", "/" };// Operation set
//        static void Main(string[] args)
//        {
//            Formula question = MakeFormula();
//            System.Console.WriteLine(question.Form);
//            string ret = Solve(question);
//            System.Console.WriteLine(ret);

//        }


//        public static Formula MakeFormula()
//        {
//            Random ran = new Random();
//            Formula Form = new Formula();
//            string build = null;
//            int count = (int)ran.Next(1, 3); // generate random count
//            int start = 0;
//            int number1 = ran.Next(1, 99);
//            build = build + number1;
//            Form.Formstack.Push(number1);
//            while (start <= count)
//            {
//                int operation = (int)ran.Next(0, 3); ; // generate operator
//                int number2 = (int)ran.Next(1, 99);
//                build = build + op[operation] + number2;
//                Form.Formstack.Push(op[operation]);
//                Form.Formstack.Push(number2);
//                start++;
//            }
//            Form.Form = build;
//            return Form;
//        }//Make a Formula(like 1*5+62-5)


//        public static string Solve(Formula formula)
//        {
//            Stack numberStack = new Stack(60);//Store number
//            Stack operatorStack = new Stack(60);//Store operator
//            while (!(formula.Formstack.Count == 0))
//            {
//                if (!((string)formula.Formstack.Peek() == "+" || (string)formula.Formstack.Peek() == "-"
//                    || (string)formula.Formstack.Peek() == "*" || (string)formula.Formstack.Peek() == "/"))//判断是否数字或者operator
//                {
//                    numberStack.Push(formula.Formstack.Pop());
//                }//如果是数字，压入numberStack
//                else
//                {
//                    if ((string)formula.Formstack.Peek() == "*")
//                    {
//                        formula.Formstack.Pop();
//                        int temp = (int)formula.Formstack.Pop() * (int)numberStack.Pop();
//                        numberStack.Push(temp);
//                    }//如果栈顶为“*”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
//                    else if ((string)formula.Formstack.Peek() == "/")
//                    {
//                        formula.Formstack.Pop();
//                        int temp = (int)formula.Formstack.Pop() / (int)numberStack.Pop();
//                        numberStack.Push(temp);
//                    }//如果栈顶为“/”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
//                    else if ((string)formula.Formstack.Peek() == "+" || (string)formula.Formstack.Peek() == "-")
//                    {
//                        operatorStack.Push(formula.Formstack.Pop());
//                    }
//                }//非数字的处理方法
//            }//计算算式中的乘除法，转化成加减法存入numberStack和opStack中
//            while (!(numberStack.Count == 1))
//            {
//                if ((string)operatorStack.Peek() == "+")
//                {
//                    operatorStack.Pop();
//                    int temp = (int)numberStack.Pop() + (int)numberStack.Pop();
//                    numberStack.Push(temp);

//                }
//                else if ((string)operatorStack.Peek() == "-")
//                {
//                    operatorStack.Pop();
//                    int temp = (int)numberStack.Pop() - (int)numberStack.Pop();
//                    numberStack.Push(temp);
//                }

//            }//计算加减法
//            return (string)numberStack.Pop();

//        }
//    }
//}


//class Stack
//{
//    public int Count = 0;
//    public object[] s;
//    object y;


//    public Stack(int len)
//    {
//        s = new object[len];
//    }
//    public object Peek()
//    {
//        return s[Count];
//    }
//    public void Push(object x)
//    {
//        s[Count] = x;
//        Count++;
//    }
//    public object Pop()
//    {
//        y = s[Count];
//        Count--;
//        return y;
//    }
//}
////废弃代码 XD



////Stack tempStack = new Stack();//Store number or operator
////Stack operatorStack = new Stack();//Store operator
////int len = formula.Length;
////int k = 0;
////for (int j = -1; j < len - 1; j++)
////{
////    string formulaChar = formula.Substring(j + 1??, 2???);
////    if (j == len - 2 || formulaChar.Equals('+') || formulaChar.Equals('-') || formulaChar.Equals('/') || formulaChar.Equals('*'))
////    {
////        if (j == len - 2)
////        {
////            tempStack.Push(formula.Substring(k));
////        }
////        else
////        {
////            if (k < j)
////            {
////                tempStack.Push(formula.Substring(k, j + 1));
////            }
////            if (operatorStack.Count == 0)
////            {
////                operatorStack.Push(formulaChar); //if operatorStack is empty, store it)
////            }
////            else
////            {
////                char stackChar = (char)operatorStack.Peek();//Get the top char of opSrack
////                if ((stackChar == '+' || stackChar == '-') && (formulaChar.Equals('*') || formulaChar.Equals('/')))
////                {
////                    operatorStack.Push(formulaChar);
////                }
////                else
////                {
////                    tempStack.Push(operatorStack.Pop());
////                    operatorStack.Push(formulaChar);
////                }
////            }
////        }
////        k = j + 2;
////    }
////}
////while (!(operatorStack.Count == 0))
////{ // Append remaining operators
////    tempStack.Push(operatorStack.Pop());
////}
////Stack calcStack = new Stack();
////foreach (string peekChar in tempStack)
////{ // Reverse traversing of stack
////    if (!(peekChar.CompareTo("+") == 0) && !(peekChar.CompareTo("-") == 0) && !(peekChar.CompareTo("/") == 0) && (peekChar.CompareTo("*") == 0))
////    {
////        calcStack.Push(peekChar); // Push number to stack
////    }
////    else
////    {
////        int a1 = 0;
////        int b1 = 0;
////        if (!(calcStack.Count == 0))
////        {
////            b1 = (int)(calcStack.Pop());
////        }
////        if (!(calcStack.Count == 0))
////        {
////            a1 = (int)(calcStack.Pop());
////        }
////        switch (peekChar)
////        {
////            case "+":
////                calcStack.Push((char)(a1 + b1));
////                break;
////            case "-":
////                calcStack.Push((char)(a1 - b1));
////                break;
////            case "*":
////                calcStack.Push((char)(a1 * b1));
////                break;
////            default:
////                calcStack.Push((char)(a1 / b1));
////                break;
////        }
////    }
////}
////return formula + "=" + calcStack.Pop();





////using System;
////using System.Collections.Generic;

////namespace Yanyixiao
////{
////    class Program
////    {

////        public class Formula
////        {
////            public string Form { get; internal set; }
////            public Stack<string> Formstack = new Stack<string>();
////        }

////        public  static string[] op = { "+", "-", "*", "/" };// Operation set
////        static void Main(string[] args)
////        {
////            int i;
////            System.Console.WriteLine("请输入需要的题目数量：");
////            int n = Convert.ToInt32(System.Console.ReadLine());
////            for (i = 0; i < n; i++)
////            {
////                Formula question = MakeFormula();
////                string ret = Solve(question);
////                System.Console.Write(question.Form);
////                System.Console.Write("=");
////                System.Console.WriteLine(ret);
////            }

////        }


////        public static Formula MakeFormula()
////        {
////            Random ran = new Random();
////            Formula Form = new Formula();
////            string build = null;
////            int count = (int)ran.Next(1, 3); // generate random count
////            int start = 0;
////            int number1 = ran.Next(1, 99);
////            Form.Formstack.Push(Convert.ToString(number1));//uytd 8796r756eu675v 786f876v

////            while (start <= count)
////            {
////                int operation = (int)ran.Next(0, 4); ; // generate operator
////                int number2 = (int)ran.Next(2, 10);
////                Form.Formstack.Push(op[operation]);
////                Form.Formstack.Push(Convert.ToString(number2));
////                start++;
////            }
////            return Form;
////        }//Make a Formula(like 1*5+62-5)

////        public static string Solve(Formula formula)
////        {
////            Stack<string> numberStack = new Stack<string>();//Store number
////            Stack<string> operatorStack = new Stack<string>();//Store operator
////            string stFormula=null;//Store Formula 4 Writeline                                                    Designed by Yanyixiao
////            Stack<string> tempStack = new Stack<string>();//Store 4 stFormula                                    09/17/2019 

////            while (!(formula.Formstack.Count == 0))
////            {
////                if (!(formula.Formstack.Peek() == "+" || formula.Formstack.Peek() == "-"
////                   || formula.Formstack.Peek() == "*" || formula.Formstack.Peek() == "/"))//判断是否数字或者operator

////                {
////                    numberStack.Push(formula.Formstack.Pop());
////                }//如果是数字，压入numberStack
////                else
////                {
////                    switch (formula.Formstack.Peek())
////                    {
////                        case "+":
////                            tempStack.Push(numberStack.Peek());////////////////////////////////////////////////////Store number 4 stFormula
////                            tempStack.Push(formula.Formstack.Peek());//////////////////////////////////////////////Store operator 4 stFormula



////                            break;
////                        case "-":

////                            break;

////                    }//处理加减法
////                    switch (formula.Formstack.Peek())
////                    {
////                        case "*":
////                            tempStack.Push(numberStack.Peek());////////////////////////////////////////////////////Store number 4 stFormula
////                            tempStack.Push(formula.Formstack.Peek());//////////////////////////////////////////////Store operator 4 stFormula
////                            formula.Formstack.Pop();
////                            int temp1 = int.Parse(numberStack.Pop()) * int.Parse(formula.Formstack.Pop());
////                            numberStack.Push(Convert.ToString(temp1));

////                            break;

////                        case "/":

////                            double A, B, C ,D ;//A为被除数 B为除数 C为结果 D为防止生成小数随机数
////                            tempStack.Push(numberStack.Peek());////////////////////////////////////////////////////Store operator 4 stFormula
////                            tempStack.Push(formula.Formstack.Peek());//////////////////////////////////////////////Store operator 4 stFormula

////                            B = double.Parse(numberStack.Pop());
////                            Random ran = new Random(); D = ran.Next(1, 3);
////                            A = double.Parse(formula.Formstack.Pop()) * (B * D);//防止 商 出现 小数
////                            C =A*

////                            break;
////                    }//处理乘除法




////                }
////        }

////        //废弃代码 ver2

////        //public static string Solve(Formula formula)
////        //{
////        //    Stack<string> numberStack = new Stack<string>();//Store number
////        //    Stack<string> operatorStack = new Stack<string>();//Store operator
////        //    while (!(formula.Formstack.Count == 0))
////        //    {
////        //        if (!(formula.Formstack.Peek() == "+" || formula.Formstack.Peek() == "-" 
////        //           || formula.Formstack.Peek() == "*" || formula.Formstack.Peek() == "/"))//判断是否数字或者operator
////        //        {
////        //            numberStack.Push(formula.Formstack.Pop());
////        //        }//如果是数字，压入numberStack
////        //        else
////        //        {
////        //            if ((string)formula.Formstack.Peek() == "*")
////        //            {
////        //                formula.Formstack.Pop();
////        //                int temp = int.Parse(formula.Formstack.Pop()) * int.Parse(numberStack.Pop());
////        //                numberStack.Push(Convert.ToString(temp));

////        //            }//如果栈顶为“*”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
////        //            else if ((string)formula.Formstack.Peek() == "/")
////        //            {
////        //                double devidend = 0;//被除数
////        //                double devisor = 0;//除数
////        //                devidend = double.Parse(numberStack.Pop());
////        //                devisor = double.Parse(formula.Formstack.Pop());
////        //                if ((devidend / devisor) % 1 <= 1e-5)
////        //                {
////        //                    numberStack.Push(Convert.ToString(devidend / devisor));

////        //                }
////        //                else
////        //                {
////        //                    return "Badthing";
////        //                }
////        //            }
////        //            //如果栈顶为“/”。弹出numberStack栈顶和Formstack自上而下第一个数字，用于计算。
////        //            else if ((string)formula.Formstack.Peek() == "+" || (string)formula.Formstack.Peek() == "-")
////        //            {
////        //                operatorStack.Push(formula.Formstack.Pop());
////        //            }
////        //            }//非数字的处理方法
////        //    }//计算算式中的乘除法，转化成加减法存入numberStack和opStack中
////        //    while (!(numberStack.Count == 1))
////        //    {
////        //        if ((string)operatorStack.Peek() == "+")
////        //        {
////        //            operatorStack.Pop();
////        //            int temp = int.Parse(numberStack.Pop()) + int.Parse(numberStack.Pop());
////        //            numberStack.Push(Convert.ToString(temp));

////        //        }else if ((string)operatorStack.Peek() == "-")
////        //        {
////        //            operatorStack.Pop();
////        //            int temp = int.Parse(numberStack.Pop()) - int.Parse(numberStack.Pop());
////        //            numberStack.Push(Convert.ToString(temp));
////        //        }

////        //    }//计算加减法
////        //    return (string)numberStack.Pop();

////        //}
////    }


////}


//////废弃代码 XD



//////Stack tempStack = new Stack();//Store number or operator
//////Stack operatorStack = new Stack();//Store operator
//////int len = formula.Length;
//////int k = 0;
//////for (int j = -1; j < len - 1; j++)
//////{
//////    string formulaChar = formula.Substring(j + 1??, 2???);
//////    if (j == len - 2 || formulaChar.Equals('+') || formulaChar.Equals('-') || formulaChar.Equals('/') || formulaChar.Equals('*'))
//////    {
//////        if (j == len - 2)
//////        {
//////            tempStack.Push(formula.Substring(k));
//////        }
//////        else
//////        {
//////            if (k < j)
//////            {
//////                tempStack.Push(formula.Substring(k, j + 1));
//////            }
//////            if (operatorStack.Count == 0)
//////            {
//////                operatorStack.Push(formulaChar); //if operatorStack is empty, store it)
//////            }
//////            else
//////            {
//////                char stackChar = (char)operatorStack.Peek();//Get the top char of opSrack
//////                if ((stackChar == '+' || stackChar == '-') && (formulaChar.Equals('*') || formulaChar.Equals('/')))
//////                {
//////                    operatorStack.Push(formulaChar);
//////                }
//////                else
//////                {
//////                    tempStack.Push(operatorStack.Pop());
//////                    operatorStack.Push(formulaChar);
//////                }
//////            }
//////        }
//////        k = j + 2;
//////    }
//////}
//////while (!(operatorStack.Count == 0))
//////{ // Append remaining operators
//////    tempStack.Push(operatorStack.Pop());
//////}
//////Stack calcStack = new Stack();
//////foreach (string peekChar in tempStack)
//////{ // Reverse traversing of stack
//////    if (!(peekChar.CompareTo("+") == 0) && !(peekChar.CompareTo("-") == 0) && !(peekChar.CompareTo("/") == 0) && (peekChar.CompareTo("*") == 0))
//////    {
//////        calcStack.Push(peekChar); // Push number to stack
//////    }
//////    else
//////    {
//////        int a1 = 0;
//////        int b1 = 0;
//////        if (!(calcStack.Count == 0))
//////        {
//////            b1 = (int)(calcStack.Pop());
//////        }
//////        if (!(calcStack.Count == 0))
//////        {
//////            a1 = (int)(calcStack.Pop());
//////        }
//////        switch (peekChar)
//////        {
//////            case "+":
//////                calcStack.Push((char)(a1 + b1));
//////                break;
//////            case "-":
//////                calcStack.Push((char)(a1 - b1));
//////                break;
//////            case "*":
//////                calcStack.Push((char)(a1 * b1));
//////                break;
//////            default:
//////                calcStack.Push((char)(a1 / b1));
//////                break;
//////        }
//////    }
//////}
//////return formula + "=" + calcStack.Pop();
///
