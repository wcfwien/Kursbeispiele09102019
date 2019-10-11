using System.Runtime.Serialization;

namespace Autovermietung.Service
{
    [DataContract]
    public class Auto 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Hersteller { get; set; }
        [DataMember]
        public string ModelName { get; set; }
    }
}
