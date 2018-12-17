using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace JsonCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(DeserializedData));

            
            

            DeserializedData dd = new DeserializedData();

            using (FileStream fs = new FileStream(startDir + "\\input.json", FileMode.OpenOrCreate))
            {
                dd = (DeserializedData)jsonFormatter.ReadObject(fs);
            }

            var calcNew = new Calc(dd.Numbers, dd.Operations);
            // calcNew.Parser();
            calcNew.Operationss();
            
        }
    }
}
