using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;
        public PlatformRepository( AppDbContext context)
        {
            _context=context;
        }
        void IPlatformRepository.CreatePlatform(Platform platform)
        {

            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
                                  
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
           return  _context.Platforms.ToList();
        }

        public Platform PlayformById(int id)
        {

            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >=0;
            
        }
    }
}
