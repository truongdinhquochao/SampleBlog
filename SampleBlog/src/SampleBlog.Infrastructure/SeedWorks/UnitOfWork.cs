using SampleBlog.Core.SeedWorks;

namespace SampleBlog.Infrastructure.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleBlogContext _context;

        public UnitOfWork(SampleBlogContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}