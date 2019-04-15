using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPZ_Backend.Models
{
    public class WorkplaceEquipment
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }
        public int WorkplaceId { get; set; }

        public Equipment Equipment { get; set; }
        public Workplace Workplace { get; set; }
    }
}
