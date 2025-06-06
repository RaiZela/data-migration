using BuildingBlocks.Contracts;
using MassTransit;
using migration_application.Models;
using migration_application.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Services;

public class TechnicianMigrationService
{
    private readonly IExcelParser<ParsedTechnician> _excelParser;
    private readonly IPublishEndpoint _publishEndpoint;

    public TechnicianMigrationService(
        IExcelParser<ParsedTechnician> excelParser,
        IPublishEndpoint publishEndpoint)
    {
        _excelParser = excelParser;
        _publishEndpoint = publishEndpoint;
    }

    public async Task ImportAsync(Stream excelStream)
    {
        var technicians = _excelParser.Parse(excelStream);

        foreach (var technician in technicians)
        {
            var message = new CreateTechnicianMessage(
                Guid.NewGuid(),
                technician.FirstName,
                technician.LastName
            );

            await _publishEndpoint.Publish(message);
        }
    }
}

