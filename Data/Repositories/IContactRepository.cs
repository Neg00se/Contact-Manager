using Data.Entities;

namespace Data.Repositories;
public interface IContactRepository
{
    Task AddAsync(Contact contact);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(Contact contact);
}