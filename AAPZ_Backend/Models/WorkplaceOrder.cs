using System;
using System.Collections.Generic;

namespace AAPZ_Backend
{
    public partial class WorkplaceOrder
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int WorkplaceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int SumToPay { get; set; }

        public Client Client { get; set; }
        public Workplace Workplace { get; set; }
    }
}
