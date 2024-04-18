using Microsoft.Extensions.ObjectPool;

public class Service : IResettable
{
    private readonly Guid id = Guid.NewGuid();

    public Service()
    {
        // simulate a long instance construction time
        Thread.Sleep(2000);
    }

    public Guid GetInstanceId() => id;

    // optionally, apply any "reset" logic when the instance is returned to the pool
    public bool TryReset() => true;
}