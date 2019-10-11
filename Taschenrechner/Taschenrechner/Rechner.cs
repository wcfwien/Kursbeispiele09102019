using System.Runtime.Serialization;

namespace Taschenrechner
{
    [DataContract]
    public class Rechner 
    {
        [DataMember]
        public double zahl1 { get; set; }

        [DataMember]
        public double zahl2 { get; set; }
    }
}