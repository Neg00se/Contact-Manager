using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ContactManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
    {
        try
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }
        catch (Exception)
        {

            return BadRequest();
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetById(int id)
    {
        try
        {
            var contact = await _contactService.GetByIdAsync(id);
            return Ok(contact);
        }
        catch (Exception)
        {

            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddContacts([FromForm] IFormFile file)
    {
        try
        {
            await _contactService.AddAsync(file);
            return Ok();
        }
        catch (Exception ex)
        {

            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(Contact contact)
    {
        try
        {
            await _contactService.UpdateAsync(contact);
            return Ok();
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _contactService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
