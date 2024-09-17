using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;
public class ContactRepository : IContactRepository
{
    private readonly ContactMangerDbContext _context;

    public ContactRepository(ContactMangerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        var contacts = await _context.Contacts.ToListAsync();

        return contacts;
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        return contact;
    }

    public async Task AddAsync(Contact contact)
    {

        await _context.Contacts.AddAsync(contact);
    }

    public async Task UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
    }

    public async Task RemoveAsync(int id)
    {
        var contact = await GetByIdAsync(id);
        if (contact is not null)
        {
            _context.Contacts.Remove(contact);
        }
    }


}
