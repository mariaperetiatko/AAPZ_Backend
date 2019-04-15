using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPZ_Backend.Models
{
    public class Equipment
    {
        public Equipment()
        {
            WorkplaceEquipment = new HashSet<WorkplaceEquipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<WorkplaceEquipment> WorkplaceEquipment { get; set; }
    }
}
