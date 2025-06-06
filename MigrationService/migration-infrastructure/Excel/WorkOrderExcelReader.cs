using ClosedXML.Excel;
using migration_application.Models;
using migration_application.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_infrastructure.Excel;

public class WorkOrderExcelReader : IExcelParser<ParsedWorkOrder>
{
    public List<ParsedWorkOrder> Parse(Stream stream)
    {
        using var workbook = new XLWorkbook(stream);
        var sheet = workbook.Worksheets.First();

        var results = new List<ParsedWorkOrder>();
        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            results.Add(new ParsedWorkOrder
            {
                TechnicianFullName = row.Cell(1).GetString(),
                Information = row.Cell(2).GetString(),
                Total = row.Cell(3).GetValue<decimal>()
            });
        }

        return results;
    }
}
