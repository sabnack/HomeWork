using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCalc
{
    class ParsedData
    {
        public List<double> Numbers { get; set; }
        public List<string> Operations { get; set; }

        public ParsedData(string numbers, string operations)
        {
            Numbers = new List<double>();
            Operations = new List<string>();

            foreach (var item in Parse(numbers))
            {
                if (int.TryParse(item, out int tmp))
                {
                    Numbers.Add(tmp);
                }
            }

            foreach (var item in Parse(operations))
            {
                if (item == "/" || item == "*" || item == "+" || item == "-")
                {
                    Operations.Add(item);
                }
            }
        }

        private string[] Parse(string str)
        {
            return str.Split(new char[] { ',' });
        }
    }
}
