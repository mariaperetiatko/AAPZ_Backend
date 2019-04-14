using System;
using System.Collections.Generic;

namespace AAPZ_Backend
{
    public partial class Building
    {
        public Building()
        {
            Workplace = new HashSet<Workplace>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int Flat { get; set; }
        public int? LandlordId { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }

        public Landlord Landlord { get; set; }
        public ICollection<Workplace> Workplace { get; set; }
    }
}
