using Microsoft.EntityFrameworkCore;
using SampleBlog.Core.Domain.Content;
using SampleBlog.Core.Repositories;
using SampleBlog.Infrastructure.SeedWorks;

namespace SampleBlog.Infrastructure.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(SampleBlogContext context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
