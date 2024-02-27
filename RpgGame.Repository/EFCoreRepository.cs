

using Microsoft.EntityFrameworkCore;

namespace RpgGame.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly DatabaseContext _context;

        public EFCoreRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
