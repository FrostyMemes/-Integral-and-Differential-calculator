using System;
using System.Collections.Generic;

namespace Integral
{

    class Parser
    {

        private List<string> Functs = new List<string>() { "sin", "cos", "tan", "cot", "abs", "asin", "acos", "atan", "sqrt", "exp", "log", "ln" }; //Список всех функций
        private List<string> numbers_values = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", ".", "x" }; //Список всех значений, которые принимаются за числа

        public List<Token> polishRecord = new List<Token>(); //Список для содержания комбинации знаков обратой польской нотации введенной функции
        public string Equation { get; }

        public Parser(string function)
        {
            Equation = function;
            GetPolishRecord(function);
        }

        

        public double f(double x)
        {
            double firstNumber, secondNumber;
            bool ErrorNaN = false;
            Stack<double> numbers = new Stack<double>();

            try
            {
                foreach (var token in polishRecord)
                {
                    if (token.Type == 1) 
                    {
                        if (token.Value == "x")
                            numbers.Push(x);
                        else
                            numbers.Push(Double.Parse(token.Value));

                    }
                    else
                    {
                        if (token.Type == 2)
                        {
                            firstNumber = numbers.Pop();
                            switch (token.Value)
                            {
                                case "sin":
                                    numbers.Push(Math.Sin(firstNumber));
                                    break;

                                case "cos":
                                    numbers.Push(Math.Cos(firstNumber));
                                    break;

                                case "tan":
                                    numbers.Push(Math.Tan(firstNumber));
                                    break;

                                case "cot":
                                    numbers.Push(1/Math.Tan(firstNumber));
                                    break;

                                case "asin":
                                    if (firstNumber <= 1 && firstNumber >= -1)
                                        numbers.Push(Math.Asin(firstNumber));
                                    else
                                        ErrorNaN = true;
                                    break;

                                case "acos":
                                    if (firstNumber <= 1 && firstNumber >= -1)
                                        numbers.Push(Math.Acos(firstNumber));
                                    else
                                        ErrorNaN = true;
                                    break;

                                case "atan":
                                    numbers.Push(Math.Atan(firstNumber));
                                    break;

                                case "abs":
                                    numbers.Push(Math.Abs(firstNumber));
                                    break;

                                case "sqrt":
                                    if (firstNumber >= 0)
                                        numbers.Push(Math.Sqrt(firstNumber));
                                    else
                                        ErrorNaN = true;
                                    break;

                                case "exp":
                                    numbers.Push(Math.Exp(firstNumber));
                                    break;

                                case "log":
                                    if (firstNumber > 0)
                                        numbers.Push(Math.Log10(firstNumber));
                                    else
                                        ErrorNaN = true;
                                    break;

                                case "ln":
                                    if (firstNumber > 0)
                                        numbers.Push(Math.Log(firstNumber));
                                    else
                                        ErrorNaN = true;
                                    break;
                            }
                        }
                        else
                        {
                            secondNumber = numbers.Pop();
                            firstNumber = numbers.Pop();                            
                            switch (token.Value)
                            {
                                case "+":
                                    numbers.Push((firstNumber + secondNumber) * 1.0);
                                    break;

                                case "-":
                                    numbers.Push((firstNumber - secondNumber) * 1.0);
                                    break;

                                case "/":
                                    numbers.Push((firstNumber * 1.0) / (secondNumber * 1.0));
                                    break;

                                case "*":
                                    numbers.Push((firstNumber * 1.0) * (secondNumber * 1.0));
                                    break;

                                case "^":
                                    numbers.Push(Math.Pow(firstNumber * 1.0, secondNumber * 1.0));
                                    break;
                            }
                        }
                    }
                    if (ErrorNaN)
                    {
                        throw new NaNErrorException("Недопустипое значение аргумента");
                    }
                }
                if (!ErrorNaN)
                    return numbers.Pop();
                else
                {
                    return 0;
                }
            }
            catch (NaNErrorException)
            {
                throw new NaNErrorException("Недопустипое значение аргумента");
            }
            catch
            {
                throw new FunctionErrorException("Ошибка в выполнении функции");
            }

        }


        private int GetPriority(String token)
        {

            switch (token)
            {
                case ")": return 4;
                case "^": return 3;
                case "*": return 2;
                case "/": return 2;
                case "+": return 1;
                case "-": return 1;
                case "(": return 0;
                default: return -1;
            }
        }
        private void GetPolishRecord(string function)
        {

            int tokenPriority;
            int tokensCount;
            string numberCombination;
            string functionCombination;

            bool negativeNumber = true;

            Stack<string> tokens = new Stack<string>();

            polishRecord.Clear();
            function = function.Replace(".", ",");
            function = function.Replace("X", "x");
            try
            {
                for (int i = 0; i < function.Length; i++)
                {
                    tokenPriority = GetPriority(function[i].ToString());

                    if (tokenPriority == 4)
                    {
                        while (tokens.Peek() != "(")
                            polishRecord.Add(new Token(tokens.Pop(), 0));
                        tokens.Pop();

                        if (tokens.Count != 0)
                        {
                            if (Functs.Contains(tokens.Peek()))
                                polishRecord.Add(new Token(tokens.Pop(), 2));
                        }
                    }

                    else if ((tokenPriority < 4 && tokenPriority > 0) && !(negativeNumber && function[i] == '-'))
                    {
                        tokensCount = tokens.Count;
                        if (tokensCount > 0)
                        {
                            if (GetPriority(tokens.Peek()) > tokenPriority)
                            {
                                do
                                {
                                    polishRecord.Add(new Token(tokens.Pop(), 0));
                                    tokensCount--;

                                    if (tokensCount == 0)
                                        break;

                                } while (GetPriority(tokens.Peek()) > tokenPriority);
                            }
                        }
                        tokens.Push(function[i].ToString());
                        negativeNumber = true;
                    }

                    else if (tokenPriority == 0)
                    {
                        tokens.Push(function[i].ToString());
                        negativeNumber = true;
                    }

                    else
                    {
                        if (numbers_values.Contains(function[i].ToString()) || (negativeNumber && function[i] == '-'))
                        {
                            numberCombination = String.Empty;
                            do
                            {
                                numberCombination += function[i].ToString();
                                i++;
                                if (i == function.Length)
                                    break;

                            }
                            while (numbers_values.Contains(function[i].ToString()));
                            i--;
                            polishRecord.Add(new Token(numberCombination, 1));
                            negativeNumber = false;
                        }
                        else
                        {
                            functionCombination = String.Empty;
                            do
                            {
                                functionCombination += function[i].ToString();
                                i++;
                                if (i == function.Length)
                                    break;
                            }
                            while (!numbers_values.Contains(function[i].ToString()) && function[i].ToString() != "(");
                            i--;
                            tokens.Push(functionCombination);
                        }
                    }
                }
                while (tokens.Count != 0)
                    polishRecord.Add(new Token(tokens.Pop(), 0));
            }
            catch
            {
                throw new SyntaxErrorException("Синтаксическая ошибка");
            }
        }


    }



    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string message)
           : base(message)
        {
        }
    }
    public class NaNErrorException : Exception
    {
        public NaNErrorException(string message)
           : base(message)
        {
        }
    }
    public class FunctionErrorException : Exception
    {
        public FunctionErrorException(string message)
           : base(message)
        {
        }
    }
}
