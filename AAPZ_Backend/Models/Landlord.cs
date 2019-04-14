using System;
using System.Collections.Generic;
using AAPZ_Backend.Models;

namespace AAPZ_Backend
{
    public partial class Landlord
    {
        public Landlord()
        {
            Building = new HashSet<Building>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PassportNumber { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public int IsInBlackList { get; set; }
        public string IdentityId { get; set; }
        public User Identity { get; set; }  // navigation property


        public ICollection<Building> Building { get; set; }
    }
}
