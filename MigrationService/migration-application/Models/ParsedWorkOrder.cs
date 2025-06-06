using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Models;

public class ParsedWorkOrder
{
    public string ClientFullName { get; set; }
    public string TechnicianFullName { get; set; }
    public DateTime Date { get; set; }
    public string Information { get; set; }
    public decimal Total { get; set; }
}
