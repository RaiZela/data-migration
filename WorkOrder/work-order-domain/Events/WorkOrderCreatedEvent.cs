using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_domain.Abstractions;
using work_order_domain.Models;

namespace work_order_domain.Events;

public record WorkOrderCreatedEvent(WorkOrder Technician) : IDomainEvent;
