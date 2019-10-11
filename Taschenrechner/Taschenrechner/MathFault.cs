using System.Runtime.Serialization;

namespace Taschenrechner
{
    [DataContract]
    public class MathFault
    {
        [DataMember]
        public string Operation { get; set; }
        
        [DataMember]
        public string ProblemType { get; set; }
    }
}