using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCalc
{

    class Calc:ParsedData
    {
        private delegate void DOperations();
        private DOperations Dop { get; set; }
        private StringBuilder _tmpStr { get; set; }
        private double _result { get; set; }
        //    private ParsedData Data;

        public Calc(string numbers, string operations)
            :base (numbers, operations)
        {
            Dop = null;
            _tmpStr = new StringBuilder();
            _result = Numbers[0];
        }

        public void Start()
        {
            foreach (var item in Operations)
            {
                switch (item)
                {
                    case "+":
                        Dop += Add;
                        break;
                    case "-":
                        Dop += Sub;
                        break;
                    case "/":
                        Dop += Div;
                        break;
                    case "*":
                        Dop += Multi;
                        break;
                }
            }
            Dop?.Invoke();
        }

        private void Add()
        {
            _tmpStr.Append(Numbers[0].ToString());

            for (var i = 1; i < Numbers.Count; i++)
            {
                _result +=Numbers[i];
                _tmpStr.Append("+");
                _tmpStr.Append(Numbers[i].ToString());
            }

            Console.WriteLine("{0} = {1}", _tmpStr, _result);
            _result = Numbers[0];
            _tmpStr.Clear();
        }

        private void Sub()
        {
            _tmpStr.Append(Numbers[0].ToString());

            for (var i = 1; i < Numbers.Count; i++)
            {
                _result -= Numbers[i];
                _tmpStr.Append("-");
                _tmpStr.Append(Numbers[i].ToString());
            }

            Console.WriteLine("{0} = {1}", _tmpStr, _result);
            _result = Numbers[0];
            _tmpStr.Clear(); ;
        }

        private void Div()
        {
            _tmpStr.Append(Numbers[0].ToString());

            for (var i = 1; i < Numbers.Count; i++)
            {
                if(Numbers[i] == 0)
                {
                    continue;
                }
                _result /= Numbers[i];
                _tmpStr.Append("/");
                _tmpStr.Append(Numbers[i].ToString());
            }

            Console.WriteLine("{0} = {1}", _tmpStr, _result);
            _result = Numbers[0];
            _tmpStr.Clear(); ;
        }

        private void Multi()
        {
            _tmpStr.Append(Numbers[0].ToString());

            for (var i = 1; i < Numbers.Count; i++)
            {
                _result *= Numbers[i];
                _tmpStr.Append("*");
                _tmpStr.Append(Numbers[i].ToString());
            }

            Console.WriteLine("{0} = {1}", _tmpStr, _result);
            _result = Numbers[0];
            _tmpStr.Clear(); ;
        }
    }

}
