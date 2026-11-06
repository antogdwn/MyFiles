using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform PlayformById(int id);
        void CreatePlatform(Platform platform);
    }
}
