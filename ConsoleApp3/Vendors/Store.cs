using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Vendors.ValueObjects;

namespace HIT.Hastim.IDR.Domain.Vendors
{
    public class Store : Entity<long>
    {
        private Store() { }
        public Store(StoreName storeName)
        {
            StoreName = storeName;
        }

        public StoreName StoreName { get; private set; }
        public string LogoPath { get; set; }
    }
}