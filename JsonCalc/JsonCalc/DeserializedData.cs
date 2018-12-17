using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonCalc
{
    [DataContract]
    class DeserializedData
    {
        [DataMember]
        public string Numbers { get; set; }
        [DataMember]
        public string Operations { get; set; }
    }
}
