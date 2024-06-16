using Microsoft.EntityFrameworkCore;
using arusha.Data;

public class UniversityRepository
{
    private readonly ApplicationDbContext _context;

    public UniversityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void UpdateUniversityData(int universityId)
    {
        _context.Database.ExecuteSqlInterpolated($"EXEC UpdateUniversityDataBase @UniversityID = {universityId}");
    }
}
