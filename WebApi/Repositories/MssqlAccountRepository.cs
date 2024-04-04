namespace Repositories;

public class MssqlAccountRepository : IAccountRepository
{
    public string GetAccountName(int id)
    {
        return "Microsoft";
    }
}
