using Data.Entities;

namespace Data.Interfaces;
public interface IContactRepository
{
    Task AddAsync(Contact contact);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(Contact contact);
}