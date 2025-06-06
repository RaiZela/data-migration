using migration_application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_application.Commands;
public class ImportClientsCommand
{
    private readonly ClientMigrationService _migrationService;

    public ImportClientsCommand(ClientMigrationService migrationService)
    {
        _migrationService = migrationService;
    }

    public async Task ExecuteAsync(Stream fileStream)
    {
        await _migrationService.ImportAsync(fileStream);
    }
}

