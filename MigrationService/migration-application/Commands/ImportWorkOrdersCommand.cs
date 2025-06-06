using migration_application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Commands;

public class ImportWorkOrdersCommand
{
    private readonly WorkOrderMigrationService _migrationService;

    public ImportWorkOrdersCommand(WorkOrderMigrationService migrationService)
    {
        _migrationService = migrationService;
    }

    public async Task ExecuteAsync(Stream fileStream)
    {
        await _migrationService.ImportAsync(fileStream);
    }
}
