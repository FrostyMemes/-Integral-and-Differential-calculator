using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{

    class Parser
    {
        public string function;
	
        private List<string> Functs = new List<string>() { "sin", "cos", "tan", "cot", "abs", "asin", "acos", "atan", "sqrt", "exp", "log", "ln" }; //Список всех функций
        private List<string> number = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", ".", "x" }; //Список всех значений, которые принимаются за числа
        private List<string> MulDiv = new List<string>() { "*", "/" }; //Список знаков высокого приоритета
        private List<string> AddSub = new List<string>() { "+", "-" }; //Список знаков низкого приоритета

        private List<string> tokens = new List<string>(); //Список для сортировки токенов введенной функции
        private List<string> result = new List<string>(); //Список для содержания комбинации знаков обратой польской нотации введенной функции

        public Parser(string Formula)
        {
            this.function = Formula;
            GetPolishRecord(Formula);
        }

       public double f(double x) 
       {
            double firstNumber, secondNumber, res;
            bool ErrorNaN = false;
            tokens.Clear();

            try
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (!MulDiv.Contains(result[i]) && !AddSub.Contains(result[i]) && !Functs.Contains(result[i]) && result[i] != "^")
                    {
                        if (result[i] == "x")
                            tokens.Add(x.ToString());
                        else
                            tokens.Add(result[i]);
                    }
                    else
                    {
                        if (Functs.Contains(result[i]))
                        {
                            switch (result[i])
                            {
                                case "sin":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Sin(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "cos":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Cos(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "tan":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Tan(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "cot":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = 1 / Math.Tan(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "asin":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    if (firstNumber <= 1 && firstNumber >= -1)
                                    {
                                        res = Math.Asin(firstNumber);
                                        tokens[tokens.Count - 1] = res.ToString();
                                    }
                                    else
                                    {
                                        ErrorNaN = true;
                                    }
                                    break;
                                case "acos":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    if (firstNumber <= 1 && firstNumber >= -1)
                                    {
                                        res = Math.Asin(firstNumber);
                                        tokens[tokens.Count - 1] = res.ToString();
                                    }
                                    else
                                        ErrorNaN = true;
                                    break;
                                case "atan":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Atan(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "abs":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Abs(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "sqrt":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    if (firstNumber >= 0)
                                    {
                                        res = Math.Sqrt(firstNumber);
                                        tokens[tokens.Count - 1] = res.ToString();
                                    }
                                    else
                                        ErrorNaN = true;
                                    break;
                                case "exp":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Exp(firstNumber);
                                    tokens[tokens.Count - 1] = res.ToString();
                                    break;
                                case "log":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    if (firstNumber > 0)
                                    {
                                        res = Math.Log10(firstNumber);
                                        tokens[tokens.Count - 1] = res.ToString();
                                    }
                                    else
                                        ErrorNaN = true;
                                    break;
                                case "ln":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    if (firstNumber > 0)
                                    {
                                        res = Math.Log(firstNumber);
                                        tokens[tokens.Count - 1] = res.ToString();
                                    }
                                    else
                                        ErrorNaN = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (result[i])
                            {
                                case "+":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 2]);
                                    secondNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = (firstNumber + secondNumber) * 1.0;
                                    tokens.RemoveAt(tokens.Count - 2);
                                    tokens.RemoveAt(tokens.Count - 1);
                                    tokens.Add(res.ToString());
                                    break;
                                case "-":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 2]);
                                    secondNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = (firstNumber - secondNumber) * 1.0;
                                    tokens.RemoveAt(tokens.Count - 2);
                                    tokens.RemoveAt(tokens.Count - 1);
                                    tokens.Add(res.ToString());
                                    break;
                                case "/":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 2]);
                                    secondNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = firstNumber * 1.0 / secondNumber * 1.0;
                                    tokens.RemoveAt(tokens.Count - 2);
                                    tokens.RemoveAt(tokens.Count - 1);
                                    tokens.Add(res.ToString());
                                    break;
                                case "*":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 2]);
                                    secondNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = firstNumber * 1.0 * secondNumber * 1.0;
                                    tokens.RemoveAt(tokens.Count - 2);
                                    tokens.RemoveAt(tokens.Count - 1);
                                    tokens.Add(res.ToString());
                                    break;
                                case "^":
                                    firstNumber = Convert.ToDouble(tokens[tokens.Count - 2]);
                                    secondNumber = Convert.ToDouble(tokens[tokens.Count - 1]);
                                    res = Math.Pow(firstNumber * 1.0, secondNumber * 1.0);
                                    tokens.RemoveAt(tokens.Count - 2);
                                    tokens.RemoveAt(tokens.Count - 1);
                                    tokens.Add(res.ToString());
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
                    return Convert.ToDouble(tokens[0]);
                else
                {
                    return 0;
                }
            }
            catch(NaNErrorException)
            {
                throw new NaNErrorException("Недопустипое значение аргумента");
            }
            catch
            {   
                throw new FunctionErrorException("Ошибка в выполнении функции");
            }

       }

        private void GetPolishRecord(string Formula)
        {
            string numberComb;
            string functComb;
            bool lastSigh = false;

            tokens.Clear();
            result.Clear();
            Formula = Formula.Replace(".", ",");
            Formula = Formula.Replace("X", "x");
            try
            {

                for (int i = 0; i < Formula.Length; i++)
                {
                    switch (Formula[i].ToString())
                    {
                        case "(":
                            tokens.Add("(");
                            lastSigh = true;
                            break;
                        case ")":
                            string a = tokens[tokens.Count - 1].ToString();
                            while (tokens[tokens.Count - 1] != "(")
                            {
                                result.Add(tokens[tokens.Count - 1]);
                                tokens.RemoveAt(tokens.Count - 1);
                            }

                            tokens.RemoveAt(tokens.Count - 1);
                            if (tokens.Count != 0)
                            {
                                if (Functs.Contains(tokens[tokens.Count - 1]))
                                {
                                    result.Add(tokens[tokens.Count - 1]);
                                    tokens.RemoveAt(tokens.Count - 1);
                                }
                            }
                            break;

                        case "*":
                            if (tokens.Count == 0)
                            {
                                tokens.Add("*");
                                lastSigh = true;
                            }
                            else
                            {

                                if (MulDiv.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^")
                                {
                                    do
                                    {
                                        result.Add(tokens[tokens.Count - 1]);
                                        tokens.RemoveAt(tokens.Count - 1);
                                        if (tokens.Count == 0)
                                            break;

                                    } while ((MulDiv.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^"));

                                    tokens.Add("*");
                                    lastSigh = true;
                                }
                                else
                                {
                                    tokens.Add("*");
                                    lastSigh = true;
                                }
                            }
                            break;

                        case "/":
                            if (tokens.Count == 0)
                            {
                                tokens.Add("/");
                                lastSigh = true;
                            }
                            else
                            {
                                if (MulDiv.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^")
                                {
                                    do
                                    {
                                        result.Add(tokens[tokens.Count - 1]);
                                        tokens.RemoveAt(tokens.Count - 1);
                                        if (tokens.Count == 0)
                                            break;

                                    } while ((MulDiv.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^"));

                                    tokens.Add("/");
                                    lastSigh = true;
                                }
                                else
                                {
                                    tokens.Add("/");
                                    lastSigh = true;
                                }
                            }
                            break;

                        case "+":
                            if (tokens.Count == 0)
                            {
                                tokens.Add("+");
                                lastSigh = true;
                            }
                            else
                            {
                                if (MulDiv.Contains(tokens[tokens.Count - 1]) || AddSub.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^")
                                {
                                    do
                                    {
                                        result.Add(tokens[tokens.Count - 1]);
                                        tokens.RemoveAt(tokens.Count - 1);
                                        if (tokens.Count == 0)
                                            break;

                                    } while ((MulDiv.Contains(tokens[tokens.Count - 1]) || AddSub.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^"));
                                    tokens.Add("+");
                                    lastSigh = true;
                                }
                                else
                                {
                                    tokens.Add("+");
                                    lastSigh = true;
                                }

                            }
                            break;

                        case "-":
                            if (i == 0)
                            {
                                numberComb = null;
                                numberComb += "-";
                                i++;
                                do
                                {
                                    numberComb += Formula[i].ToString();
                                    i++;
                                    if (i == Formula.Length)
                                        break;


                                }
                                while (number.Contains(Formula[i].ToString()));
                                i--;
                                result.Add(numberComb);
                                lastSigh = false;
                            }
                            else
                            {
                                if (lastSigh)
                                {
                                    numberComb = null;
                                    numberComb += "-";
                                    i++;
                                    do
                                    {
                                        numberComb += Formula[i].ToString();
                                        i++;
                                        if (i == Formula.Length)
                                            break;

                                    }
                                    while (number.Contains(Formula[i].ToString()));
                                    i--;
                                    result.Add(numberComb);
                                    lastSigh = false;
                                }
                                else
                                {
                                    if (tokens.Count == 0)
                                    {
                                        tokens.Add("-");
                                        lastSigh = true;
                                    }
                                    else
                                    {
                                        if (MulDiv.Contains(tokens[tokens.Count - 1]) || AddSub.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^")
                                        {
                                            do
                                            {
                                                result.Add(tokens[tokens.Count - 1]);
                                                tokens.RemoveAt(tokens.Count - 1);
                                                if (tokens.Count == 0)
                                                    break;

                                            } while ((MulDiv.Contains(tokens[tokens.Count - 1]) || AddSub.Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "^"));
                                            tokens.Add("-");
                                            lastSigh = true;
                                        }
                                        else
                                        {
                                            tokens.Add("-");
                                            lastSigh = true;
                                        }
                                    }
                                }
                            }
                            break;
                        case "^":
                            if (tokens.Count == 0)
                            {
                                tokens.Add("^");
                                lastSigh = true;
                            }
                            else
                            {
                                tokens.Add("^");
                                lastSigh = true;
                            }
                            break;
                        default:
                            if (number.Contains(Formula[i].ToString()))
                            {
                                numberComb = null;
                                do
                                {
                                    numberComb += Formula[i].ToString();
                                    i++;
                                    if (i == Formula.Length)
                                        break;


                                }
                                while (number.Contains(Formula[i].ToString()));
                                i--;
                                result.Add(numberComb);
                                lastSigh = false;
                            }
                            else
                            {
                                functComb = null;
                                do
                                {
                                    functComb += Formula[i].ToString();
                                    i++;
                                    if (i == Formula.Length)
                                        break;
                                }
                                while (!number.Contains(Formula[i].ToString()) && Formula[i].ToString() != "(");
                                i--;
                                tokens.Add(functComb);
                            }
                            break;
                    }
                }
                for (int i = tokens.Count - 1; i >= 0; i--)
                    result.Add(tokens[i]);
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
