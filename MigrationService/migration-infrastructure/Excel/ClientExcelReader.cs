using ClosedXML.Excel;
using migration_application.Models;
using migration_application.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_infrastructure.Excel;

public class ClientExcelReader : IExcelParser<ParsedClient>
{
    public List<ParsedClient> Parse(Stream stream)
    {
        using var workbook = new XLWorkbook(stream);
        var sheet = workbook.Worksheets.First();

        var results = new List<ParsedClient>();
        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            results.Add(new ParsedClient
            {
                FirstName = row.Cell(1).GetString(),
                LastName = row.Cell(2).GetString()
            });
        }

        return results;
    }
}
