namespace Repositories;

public class PostgreSqlAccountRepository : IDataRepository
{
    public string GetBackendName()
    {
        return "PostgreSQL";
    }
}