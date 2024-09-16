using Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Services.Interfaces;
public interface IContactService
{
    Task AddAsync(IFormFile file);
    Task DeleteAsync(int id);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task UpdateAsync(Contact contact);
}