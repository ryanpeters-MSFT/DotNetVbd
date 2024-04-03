using Models;

namespace Repositories;

public interface IClientRepository
{
    Client GetClient(int id);
    ICollection<Client> GetClients();
}

public class InMemoryClientRepository : IClientRepository
{
    private readonly ICollection<Client> _clients =
    [
        new Client
        {
            Id = 1,
            Name = "Ryan",
            DateOfBirth = new DateTime(1983, 11, 20)
        },
        new Client
        {
            Id = 2,
            Name = "Krystle",
            DateOfBirth = new DateTime(1986, 3, 24)
        }
    ];

    public Client GetClient(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Client> GetClients()
    {
        throw new NotImplementedException();
    }
}