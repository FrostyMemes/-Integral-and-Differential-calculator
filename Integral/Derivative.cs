using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class Derivative
    {
        Parser parser;
        const double dx = 0.0000001;

        public Derivative(string function)
        {
            parser = new Parser(function);
        }

        private double DifferFirst(double x)
        {
            double Diffresult = 0.0;         
            Diffresult = (parser.f(x+dx) - parser.f(x)) / (dx);
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

        private double getStep(double x, double eps)
        {
            double M, result;
            M = DifferThird(x);
            result = (3.0 * eps) / M;
            result = Math.Pow(result, 1.0 / 3.0);
            if (double.IsNaN(result))
                return 0.00001;
            return result;
        }

        public double FindDiv(double x, double eps)
        {
            double result = 0.0;
            double h = getStep(x,eps);
            double a = parser.f(x + h);
            double b = parser.f(x - h);
            result = (a-b) / (2 * h);
            return result;
        }
    }
}
