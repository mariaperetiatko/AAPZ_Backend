using System;
using System.Collections.Generic;
using AAPZ_Backend.Models;
namespace AAPZ_Backend
{
    public partial class Client
    {
        public Client()
        {
            WorkplaceOrder = new HashSet<WorkplaceOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public long PassportNumber { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public int? Hight { get; set; }
        public int? Vision { get; set; }
        public int? TableHight { get; set; }
        public int? ChairHight { get; set; }
        public int? Light { get; set; }
        public int? Temperature { get; set; }
        public string Music { get; set; }
        public string Drink { get; set; }
        public int IsInBlackList { get; set; }
        public int? Sale { get; set; }
        public string IdentityId { get; set; }
        public User Identity { get; set; }  // navigation property


        public ICollection<WorkplaceOrder> WorkplaceOrder { get; set; }
    }
}
