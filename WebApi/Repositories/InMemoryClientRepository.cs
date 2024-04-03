using Models;

namespace Repositories;

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
        return _clients.FirstOrDefault(c => c.Id == id);
    }

    public ICollection<Client> GetClients()
    {
        return _clients;
    }
}