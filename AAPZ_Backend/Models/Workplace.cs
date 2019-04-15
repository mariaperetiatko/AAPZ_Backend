using System;
using System.Collections.Generic;

namespace AAPZ_Backend.Models
{
    public partial class Workplace
    {
        public Workplace()
        {
            WorkplaceOrder = new HashSet<WorkplaceOrder>();
            WorkplaceEquipment = new HashSet<WorkplaceEquipment>();
        }

        public int Id { get; set; }
        public int? Mark { get; set; }
        
        public int Cost { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }
        public ICollection<WorkplaceOrder> WorkplaceOrder { get; set; }
        public ICollection<WorkplaceEquipment> WorkplaceEquipment { get; set; }
    }
}
