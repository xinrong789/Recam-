using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using RecamProject.Models; // 假设你的业务实体放在这里

namespace RecamProject.Data
{
    public class RecamDbContext : IdentityDbContext
    {
        public RecamDbContext(DbContextOptions<RecamDbContext> options)
            : base(options)
        {
        }

        // // 业务表
        // public DbSet<Book> Books { get; set; } // 示例业务表
        // public DbSet<Author> Authors { get; set; } // 示例业务表

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置业务表关系（示例）
            // modelBuilder.Entity<Book>().HasMany<Publisher>(x => x.Publishers);

            base.OnModelCreating(modelBuilder); // 必须保留，配置 Identity 的表
        }
    }
}
