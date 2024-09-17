using CsvHelper;
using Data;
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
    private readonly UnitOfWork _unitOfWork;

    public ContactService(IContactRepository contactRepo, UnitOfWork unitOfWork)
    {
        _contactRepo = contactRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(IFormFile file)
    {
        var a = file.OpenReadStream();
        using var reader = new StreamReader(a);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<ContactModel>();


        foreach (var record in records)
        {
            Contact contact = new();

            contact.Name = record.Name;
            contact.Dob = record.Dob;
            contact.Married = record.Married;
            contact.Salary = record.Salary;
            contact.Phone = record.Phone;

            await _contactRepo.AddAsync(contact);
        }

        await _unitOfWork.SaveAsync();
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
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _contactRepo.RemoveAsync(id);
        await _unitOfWork.SaveAsync();

    }
}
