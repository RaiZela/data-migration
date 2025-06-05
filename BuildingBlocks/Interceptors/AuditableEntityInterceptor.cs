using BuildingBlocks.Intefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuildingBlocks.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;
    private bool _isSavingChanges = false;  // To guard against recursive SaveChanges
    public AuditableEntityInterceptor(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (_isSavingChanges)
            return base.SavingChanges(eventData, result);

        try
        {
            _isSavingChanges = true;
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        catch (Exception ex)
        {
            // TODO: add logging here
            throw;
        }
        finally
        {
            _isSavingChanges = false;
        }
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (_isSavingChanges)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        try
        {
            _isSavingChanges = true;
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        catch (Exception ex)
        {
            // TODO: add logging here
            throw;
        }
        finally
        {
            _isSavingChanges = false;
        }
    }

    public void UpdateEntities(DbContext? context)
    {
        //TODO - Update audit entities
    }
}


