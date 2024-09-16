using CsvHelper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using Services.Models;
using System.Globalization;

namespace Services.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepo;

    public ContactService(IContactRepository contactRepo)
    {
        _contactRepo = contactRepo;
    }

    public async Task AddAsync(IFormFile file)
    {
        var a = file.OpenReadStream();
        using var reader = new StreamReader(a);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<ContactModel>();
        Contact contact = new();

        foreach (var record in records)
        {

            contact.Name = record.Name;
            contact.Dob = record.Dob;
            contact.Married = record.Married;
            contact.Salary = record.Salary;
            contact.Phone = record.Phone;

            await _contactRepo.AddAsync(contact);
        }
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        var contacts = await _contactRepo.GetAllAsync();
        return contacts;
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        var contact = await _contactRepo.GetByIdAsync(id);
        return contact;
    }

    public async Task UpdateAsync(Contact contact)
    {
        await _contactRepo.UpdateAsync(contact);
    }

    public async Task DeleteAsync(int id)
    {
        await _contactRepo.RemoveAsync(id);
    }
}
