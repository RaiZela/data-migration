
namespace migration_application.Parsers;

public interface IExcelParser<T>
{
    List<T> Parse(Stream fileStream);
}
