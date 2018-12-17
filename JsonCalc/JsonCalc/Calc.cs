using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCalc
{

    class Calc
    {
        public delegate double DOperations(double x, double y);
        private DOperations Dop;
        private List<double> _numbers;
        private List<string> _operations;

        public Calc()//string numbers, string operations)
        {
            _numbers = new List<double>();
            _operations = new List<string>();
        }

        public void Parser(string numbers, string operations)
        {
            foreach (var item in Parse(numbers))
            {
                if (int.TryParse(item, out int tmp))
                {
                    _numbers.Add(tmp);
                }
            }

            foreach (var item in Parse(operations))
            {
                if (item == "/" || item == "*" || item == "+" || item == "-")
                {
                    _operations.Add(item);
                }
            }
        }

        private string[] Parse(string str)
        {
            return str.Split(new char[] { ',' });
        }

        public void Operations()
        {
            double tmp = 0;
            foreach (var item in _operations)
            {
                switch (item)
                {
                    case "+":
                        Dop = Add;
                        break;
                    case "-":
                        Dop = Sub;
                        break;
                    case "/":
                        Dop = Div;
                        break;
                    case "*":
                        Dop = Multi;
                        break;
                }

                tmp = _numbers[0];
                for (var i = 1; i < _numbers.Count; i++)
                {
                    tmp = Dop(tmp, _numbers[i]);
                }
                Console.WriteLine(tmp);
                tmp = _numbers[0];
            }
        }

        private double Add(double x, double y)
        {
            return x + y;
        }

        private double Sub(double x, double y)
        {
            return x - y;
        }

        private double Div(double x, double y)
        {
            if (y == 0)
            {
                return x;
            }
            return x / y;
        }

        private double Multi(double x, double y)
        {
            return x * y;
        }
    }

}
