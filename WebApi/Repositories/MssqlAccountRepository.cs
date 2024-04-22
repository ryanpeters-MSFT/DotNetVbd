namespace Repositories;

public class MssqlAccountRepository : IDataRepository
{
    public string GetBackendName()
    {
        return "Microsoft";
    }
}
