using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_order_application.Dtos
{
    public class WorkOrderDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid TechnicianId { get; set; }
        public string Info { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}
