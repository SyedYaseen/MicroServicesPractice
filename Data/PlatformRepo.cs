using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(platform => platform.Id == id);
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform == null) throw new ArgumentNullException(nameof(platform));
        _context.Add(platform);
    }
}