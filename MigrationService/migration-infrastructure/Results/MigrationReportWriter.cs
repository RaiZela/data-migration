using CsvHelper;
using CsvHelper.Configuration;
using migration_application.Results;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_infrastructure.Results;

public class MigrationReportWriter
{
    public async Task WriteReportAsync(IEnumerable<MigrationResult> results, Stream outputStream)
    {
        using var writer = new StreamWriter(outputStream, new UTF8Encoding(true), leaveOpen: true);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        });

        await csv.WriteRecordsAsync(results);
    }
}
