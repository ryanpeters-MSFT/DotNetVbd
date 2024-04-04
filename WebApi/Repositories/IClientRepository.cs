using Models;

namespace Repositories;

public interface IClientRepository
{
    Client GetClient(int id);
    ICollection<Client> GetClients();
}