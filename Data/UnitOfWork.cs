namespace Data;
public class UnitOfWork
{
    private readonly ContactMangerDbContext _context;

    public UnitOfWork(ContactMangerDbContext context)
    {
        _context = context;
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
