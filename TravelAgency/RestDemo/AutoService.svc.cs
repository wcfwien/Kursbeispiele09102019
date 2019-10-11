using System.Collections.Generic;

namespace RestDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AutoService : IAutoService
    {
        public List<Auto> GetAutos()
        {
            List<Auto> autos = new List<Auto>();
            autos.Add(new Auto { Id = "123", Name = "VW Golf" });
            return autos;
        }
    }
}
