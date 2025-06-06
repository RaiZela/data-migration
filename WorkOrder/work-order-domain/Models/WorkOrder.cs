using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_domain.Abstractions;
using work_order_domain.Events;

namespace work_order_domain.Models;


public class WorkOrder : Aggregate<Guid>
{
    private WorkOrder()
    { }

    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid TechnicianId { get; set; }
    public string Info { get; set; }
    public decimal Total {  get; set; }
    public DateTime Date {  get; set; }


    public static WorkOrder Create(
        Guid Id,
        Guid clientId,
        Guid technicianId ,
        string info,
        decimal total,
        DateTime date)
    {

        //TODO - Validate the input parameters

        var WorkOrder = new WorkOrder
        {
            Id= Id == Guid.Empty ? Guid.NewGuid() : Id,
            ClientId = clientId,
            TechnicianId = technicianId ,
            Info = info,
            Total = total,
            Date = date
        };


        WorkOrder.AddDomainEvent(new WorkOrderCreatedEvent(WorkOrder));
        return WorkOrder;
    }


}

