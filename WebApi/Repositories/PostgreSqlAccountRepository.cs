namespace Repositories;

public class PostgreSqlAccountRepository : IAccountRepository
{
    public string GetAccountName(int id)
    {
        return "Apple";
    }
}