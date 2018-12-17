using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCalc
{

    class Calc
    {
        delegate double DOperations(double x, double y);
        private DOperations Dop;
        private ParsedData Data;

        public Calc(ParsedData data)
        {
            Data = data;
        }

        public void Operations()
        {
            var tmpStr = new StringBuilder();
            double tmp = 0;
            foreach (var item in Data.Operations)
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

                tmp = Data.Numbers[0];
                tmpStr.Append(Data.Numbers[0].ToString());

                for (var i = 1; i < Data.Numbers.Count; i++)
                {
                    tmp = Dop(tmp, Data.Numbers[i]);
                    tmpStr.Append(item.ToString());
                    tmpStr.Append(Data.Numbers[i].ToString());
                }

                Console.WriteLine("{0} = {1}", tmpStr, tmp);
                tmp = Data.Numbers[0];
                tmpStr.Clear();
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
