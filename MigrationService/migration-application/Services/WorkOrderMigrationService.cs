using BuildingBlocks.Contracts;
using MassTransit;
using migration_application.Models;
using migration_application.Parsers;
using migration_application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Services;

public class WorkOrderMigrationService
{
    private readonly IExcelParser<ParsedWorkOrder> _excelParser;
    private readonly IPublishEndpoint _publishEndpoint;

    public WorkOrderMigrationService(
        IExcelParser<ParsedWorkOrder> excelParser,
        IPublishEndpoint publishEndpoint)
    {
        _excelParser = excelParser;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<List<MigrationResult>> ImportAsync(Stream excelStream)
    {
        var results = new List<MigrationResult>();
        var parsedWorkOrders = _excelParser.Parse(excelStream);

        foreach (var order in parsedWorkOrders)
        {
            var inputData = $"Client: {order.ClientFullName}, Tech: {order.TechnicianFullName}, Info: {order.Information}";

            try
            {
              
                if (string.IsNullOrWhiteSpace(order.ClientFullName))
                    throw new Exception("Missing client name.");

                if (string.IsNullOrWhiteSpace(order.TechnicianFullName))
                    throw new Exception("Missing technician name.");

                if (order.Total <= 0)
                    throw new Exception("Invalid total value.");

                
                var message = new CreateWorkOrderMessage(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    //order.ClientFullName,
                    //order.TechnicianFullName,
                    order.Information,
                    order.Total,
                    order.Date
                );

              
                await _publishEndpoint.Publish(message);

                
                results.Add(new MigrationResult
                {
                    EntityType = "WorkOrder",
                    InputData = inputData,
                    Success = true
                });
            }
            catch (Exception ex)
            {
                
                results.Add(new MigrationResult
                {
                    EntityType = "WorkOrder",
                    InputData = inputData,
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        return results;
    }
}


