using System;
using System.Collections.Generic;

namespace AAPZ_Backend
{
    public partial class Workplace
    {
        public Workplace()
        {
            WorkplaceOrder = new HashSet<WorkplaceOrder>();
        }

        public int Id { get; set; }
        public int? Mark { get; set; }
        public int IsComputerExists { get; set; }
        public int IsTableExists { get; set; }
        public int IsChairExists { get; set; }
        public int IsConditionerExists { get; set; }
        public int IsLampExists { get; set; }
        public int IsCofeMachineExists { get; set; }
        public int Cost { get; set; }
        public int BuildingId { get; set; }

        public Building Building { get; set; }
        public ICollection<WorkplaceOrder> WorkplaceOrder { get; set; }
    }
}
