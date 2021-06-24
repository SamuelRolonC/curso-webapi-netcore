using educacionit.cursowebapi.clase3.Models;

namespace educacionit.cursowebapi.clase3.EFCore
{
    public class ShipperRepository : EFCoreRepository<Shipper, NorthwindContext>
    {
        public ShipperRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
