using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Integral
{
    class Integral
    {
        Parser parser; //Объект типо парсера
       
        readonly Form form;
       
        const double dx = 0.0000001;
        public Integral(string function, Form form)
        {
            this.form = form;
            parser = new Parser(function);
        }

        private bool FindGap(double a, double b, string Formula)
        {                            
                int scobCount = 0;
                int scobStartIndex;
                int scobEndIndex = 0;
                string checkFormula = null;
                double ResA;
                double ResB;          
                while (Formula.Contains("/"))
                {
                    for (int i = 0; i < Formula.Length; i++)
                    {
                        if (Formula[i] == '/')
                        {
                            i++;
                            if (Formula[i] == '(')
                            {
                                scobStartIndex = i;
                                scobCount++;
                                while (scobCount != 0)
                                {
                                    i++;
                                    if (Formula[i] == '(')
                                    {
                                        scobCount++;
                                    }
                                    if (Formula[i] == ')')
                                    {
                                        scobCount--;
                                        scobEndIndex = i;
                                    }
                                }
                                checkFormula = Formula.Substring(scobStartIndex + 1, scobEndIndex - scobStartIndex - 1);
                                Formula = Formula.Substring(scobStartIndex);
                                ResA = parser.f(a);
                                ResB = parser.f(b);
                                if (ResA * ResB <= 0)
                                    return true;
                                else
                                    break;
                            }
                            else
                            {
                                if (Formula[i] == 'x')
                                {
                                    if (a * b <= 0)
                                        return true;
                                    else
                                    {
                                        Formula = Formula.Substring(i);
                                        break;
                                    }

                                }
                                else
                                {
                                    Formula = Formula.Substring(i);
                                    break;
                                }
                            }
                        }
                        else
                            continue;
                    }
                }
                return false; 
        }

        private double DifferFirst(double x)
        {
            double Diffresult = 0.0;
            Diffresult = (parser.f(x + dx) - parser.f(x)) / (dx);
            return Diffresult;
        }

        private double DifferSecond(double x)
        {
            double Diffresult = 0.0;
            Diffresult = (DifferFirst(x + dx) - DifferFirst(x)) / (dx);
            return Diffresult;
        }


        private double DifferThird(double x)
        {
            double Diffresult = 0.0;
            Diffresult = (DifferSecond(x + dx) - DifferSecond(x)) / (dx);
            return Diffresult;
        }


        private double DifferFourth(double x)
        {
            double Diffresult = 0.0;
            Diffresult = (DifferThird(x + dx) - DifferThird(x)) / (dx);
            return Diffresult;
        }


       


        private int GetLeftRightPartCount(double a, double b, double eps)
        {
            double da, db, max, result;
            da = Math.Abs(DifferFirst(a));
            db = Math.Abs(DifferFirst(b));
            if (da > db)
                max = da;
            else
                max = db;

            result = (max * Math.Pow((b - a), 2)) / eps / 2;

            return (int)result + 1000;
        }

        private int GetTrapecPartCount(double a, double b, double eps)
        {

            double da, db, max, result;
            int n;

            da = Math.Abs(DifferSecond(a));
            db = Math.Abs(DifferSecond(b));

            if (da > db)
                max = da;
            else
                max = db;

            result = ((max * Math.Pow((b - a), 3)) / 12) / eps;

            n = (int)Math.Abs(Math.Sqrt(result)) + 500;

            return n;
        }

        private int GetSimpsonPartCount(double a, double b, double eps)
        {

            double da, db, max, result;
            int n;

            da = Math.Abs(DifferFourth(a));
            db = Math.Abs(DifferFourth(b));

            if (da > db)
                max = da;
            else
                max = db;

            result = ((max * Math.Pow((b - a), 5)) / 2880) / eps;

            n = (int)Math.Abs(Math.Pow(result, 1.0 / 4.0)) + 200;

            return n;
        }

        public double LeftMethod(double aborder, double bborder, double epsilon, ProgressBar progressBar, BackgroundWorker backgroundWorker)
        {
            double result = 0.0;
            double step;
            int parts;
            Action action;
            if (FindGap(aborder, bborder, parser.function))
                throw new Exception("Имеется разрыв второго рода");
            else
            {

                parts = GetLeftRightPartCount(aborder, bborder, epsilon);
                step = (bborder - aborder) * 1.0 / parts;
                action =()=>progressBar.Maximum = parts;
                form.Invoke(action);
                action = () => progressBar.Value++;
                result = 0.0;
               
                for (double i = 1; i < parts; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        result += parser.f(aborder + i * step);
                        form.Invoke(action);
                    }
                    else
                        return 0;

                }
                return result*step;
            }
        }
        public double RightMethod(double aborder, double bborder, double epsilon, ProgressBar progressBar, BackgroundWorker backgroundWorker)
        {
            double result = 0.0;
            double step;
            int parts;
            Action action;
            if (FindGap(aborder, bborder, parser.function))
                throw new Exception("Имеется разрыв второго рода");
            else
            {

                parts = GetLeftRightPartCount(aborder, bborder, epsilon);
                step = (bborder - aborder) * 1.0 / parts;
                action = () => progressBar.Maximum = parts;
                form.Invoke(action);
                action = () => progressBar.Value++;
                result = 0.0;

                for (double i = 1; i < parts; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        result += parser.f(aborder + i * step);
                        form.Invoke(action);
                    }
                    else
                        return 0;
                }
                return result * step;
            }
        }
        public double MiddleMethod(double aborder, double bborder, double epsilon, ProgressBar progressBar, BackgroundWorker backgroundWorker)
        {
            double result = 0.0;
            double step;
            int parts;
            Action action;
            if (FindGap(aborder, bborder, parser.function))
                throw new Exception("Имеется разрыв второго рода");
            else
            {

                parts = GetLeftRightPartCount(aborder, bborder, epsilon);
                step = (bborder - aborder) * 1.0 / parts;
                action = () => progressBar.Maximum = parts;
                form.Invoke(action);
                action = () => progressBar.Value++;
                result = 0.0;

                for (double i = 1; i <= parts - 1; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        result += parser.f(aborder + i * step);
                        form.Invoke(action);
                    }
                    else
                        return 0;
                }
                return result * step;
            }
        }

        public double TrapecMethod(double aborder, double bborder, double epsilon, ProgressBar progressBar, BackgroundWorker backgroundWorker)
        {
            double x1;
            double x2;
            double result = 0.0;
            double step;
            int parts;
            Action action;
            if (FindGap(aborder, bborder, parser.function))
                throw new Exception("Имеется разрыв второго рода");
            else
            {

                parts = GetTrapecPartCount(aborder, bborder, epsilon);
                step = (bborder - aborder) * 1.0 / parts;
                action = () => progressBar.Maximum = parts;
                form.Invoke(action);
                action = () => progressBar.Value++;
                result = 0.0;

                for (double i = 0; i < parts; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        x1 = aborder + i * step;
                        x2 = aborder + (i + 1) * step;
                        result += 0.5 * (x2 - x1) * (parser.f(x1) + parser.f(x2));
                        form.Invoke(action);
                    }
                    else
                        return 0;
                }
                return result;
            }
        }

        public double SimpsonMethod(double aborder, double bborder, double epsilon, ProgressBar progressBar, BackgroundWorker backgroundWorker)
        {
            double x1;
            double x2;
            double result = 0.0;
            double step;
            int parts;
            Action action;
            if (FindGap(aborder, bborder, parser.function))
                throw new Exception("Имеется разрыв второго рода");
            else
            {

                parts = GetSimpsonPartCount(aborder, bborder, epsilon);
                step = (bborder - aborder) * 1.0 / parts;
                action = () => progressBar.Maximum = parts;
                form.Invoke(action);
                action = () => progressBar.Value++;
                result = 0.0;

                for (double i = 0; i < parts; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        x1 = aborder + i * step;
                        x2 = aborder + (i + 1) * step;
                        result += (x2 - x1) / 6.0 * (parser.f(x1) + 4.0 * parser.f(0.5 * (x1 + x2)) + parser.f(x2));
                        form.Invoke(action);
                    }
                    else
                        return 0;
                }
                return result;
            }
        }

    }
}
