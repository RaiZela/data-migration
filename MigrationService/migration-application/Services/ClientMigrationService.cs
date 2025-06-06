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

public class ClientMigrationService
{
    private readonly IExcelParser<ParsedClient> _excelParser;
    private readonly IPublishEndpoint _publishEndpoint;

    public ClientMigrationService(
        IExcelParser<ParsedClient> excelParser,
        IPublishEndpoint publishEndpoint)
    {
        _excelParser = excelParser;
        _publishEndpoint = publishEndpoint;
    }

    public async Task ImportAsync(Stream excelStream)
    {
        var clients = _excelParser.Parse(excelStream);

        foreach (var client in clients)
        {
            var message = new CreateClientMessage(
                Guid.NewGuid(),        
                client.FirstName,
                client.LastName
            );

            await _publishEndpoint.Publish(message);
        }
    }
}

