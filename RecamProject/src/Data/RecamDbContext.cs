using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


using RecamProject.Domain;


namespace RecamProject.Data
{
    public class RecamDbContext : IdentityDbContext<ApplicationUser>
    {
        public RecamDbContext(DbContextOptions<RecamDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// 添加 DbSet<TEntity> 属性（每个表一个）
        /// </summary>
        public DbSet<Agent> Agents { get; set; }
        public DbSet<PhotographyCompany> PhotographyCompanies { get; set; }
        public DbSet<ListingCase> ListingCases { get; set; }
        public DbSet<MediaAsset> MediaAssets { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<AgentListingCase> AgentListingCases { get; set; }
        public DbSet<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; }
        public DbSet<CaseContact> CaseContacts { get; set; }



//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             // 配置业务表关系（示例）
//             // modelBuilder.Entity<Book>().HasMany<Publisher>(x => x.Publishers);

//             base.OnModelCreating(modelBuilder); // 必须保留，配置 Identity 的表



//             // 多对多复合主键
//             modelBuilder.Entity<AgentListingCase>()
//                 .HasKey(x => new { x.ListingCaseId, x.AgentId });




//             modelBuilder.Entity<AgentPhotographyCompany>()
//        .Property(apc => apc.AgentId);
   

//     modelBuilder.Entity<AgentPhotographyCompany>()
//     .Property(apc => apc.PhotographyCompanyId);
  

// modelBuilder.Entity<AgentPhotographyCompany>()
//     .HasKey(apc => new { apc.AgentId, apc.PhotographyCompanyId });
//             // ListingCase → StatusHistory 一对多
//             modelBuilder.Entity<StatusHistory>()
//                 .HasOne(sh => sh.ListingCase)
//                 .WithMany(lc => lc.StatusHistories)
//                 .HasForeignKey(sh => sh.ListingCaseId)
//                 .OnDelete(DeleteBehavior.Cascade);

//             // StatusHistory → User 一对多
//             modelBuilder.Entity<StatusHistory>()
//                 .HasOne(sh => sh.ChangedByUser)
//                 .WithMany()
//                 .HasForeignKey(sh => sh.ChangedByUserId)
//                 .OnDelete(DeleteBehavior.Restrict);

//             // ✅ 设置 Agent 外键
//             modelBuilder.Entity<AgentListingCase>()
//                 .HasOne(alc => alc.Agent)
//                 .WithMany(a => a.AgentListingCases)
//                 .HasForeignKey(alc => alc.AgentId)
//                 .OnDelete(DeleteBehavior.Restrict);

//             // ✅ 设置 ListingCase 外键
//             modelBuilder.Entity<AgentListingCase>()
//                 .HasOne(alc => alc.ListingCase)
//                 .WithMany(lc => lc.AgentListingCases)
//                 .HasForeignKey(alc => alc.ListingCaseId)
//                 .OnDelete(DeleteBehavior.Restrict);

//             modelBuilder.Entity<MediaAsset>()
// .HasOne(ma => ma.ListingCase)
// .WithMany(lc => lc.MediaAssets)
// .HasForeignKey(ma => ma.ListingCaseId)
// .OnDelete(DeleteBehavior.Restrict); // ✅ 阻止多级联路径

//             modelBuilder.Entity<MediaAsset>()
//                 .HasOne(ma => ma.User)
//                 .WithMany(u => u.MediaAssets)
//                 .HasForeignKey(ma => ma.UserId)
//                 .OnDelete(DeleteBehavior.Restrict);
    


// modelBuilder.Entity<AgentPhotographyCompany>()
//     .HasOne(apc => apc.Agent)
//     .WithMany(a => a.AgentPhotographyCompanies)
//     .HasForeignKey(apc => apc.AgentId)
//     .OnDelete(DeleteBehavior.Restrict); // ❗️禁用级联删除

// modelBuilder.Entity<AgentPhotographyCompany>()
//     .HasOne(apc => apc.PhotographyCompany)
//     .WithMany(pc => pc.AgentPhotographyCompanies)
//     .HasForeignKey(apc => apc.PhotographyCompanyId)
//     .OnDelete(DeleteBehavior.Restrict); // ❗️禁用级联删除

// modelBuilder.Entity<PhotographyCompany>()
//     .HasOne(pc => pc.User)
//     .WithMany()
//     .HasForeignKey(pc => pc.UserId)
//     .OnDelete(DeleteBehavior.Restrict); // 禁止级联删除


     //   }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder); // 必须保留，配置 Identity 的表

    // === 统一字符串长度配置 ===
    // Identity 用户 ID 默认是 nvarchar(450)，确保所有相关外键都匹配
    
    // Agent 表的 Id 长度配置
    modelBuilder.Entity<Agent>()
        .Property(a => a.Id)
        .HasMaxLength(450);

    // PhotographyCompany 表的 UserId 长度配置
    modelBuilder.Entity<PhotographyCompany>()
        .Property(pc => pc.UserId)
        .HasMaxLength(450);

    // === AgentListingCase 多对多配置 ===
    modelBuilder.Entity<AgentListingCase>()
        .HasKey(x => new { x.ListingCaseId, x.AgentId });

    // 确保 AgentListingCase.AgentId 长度匹配
    modelBuilder.Entity<AgentListingCase>()
        .Property(alc => alc.AgentId)
        .HasMaxLength(450);

    modelBuilder.Entity<AgentListingCase>()
        .HasOne(alc => alc.Agent)
        .WithMany(a => a.AgentListingCases)
        .HasForeignKey(alc => alc.AgentId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<AgentListingCase>()
        .HasOne(alc => alc.ListingCase)
        .WithMany(lc => lc.AgentListingCases)
        .HasForeignKey(alc => alc.ListingCaseId)
        .OnDelete(DeleteBehavior.Restrict);

    // === AgentPhotographyCompany 多对多配置 ===
    modelBuilder.Entity<AgentPhotographyCompany>()
        .HasKey(apc => new { apc.AgentId, apc.PhotographyCompanyId });

    // 确保字符串长度匹配 Identity 的 450 长度
    modelBuilder.Entity<AgentPhotographyCompany>()
        .Property(apc => apc.AgentId)
        .HasMaxLength(450);

    modelBuilder.Entity<AgentPhotographyCompany>()
        .Property(apc => apc.PhotographyCompanyId)
        .HasMaxLength(450);

    modelBuilder.Entity<AgentPhotographyCompany>()
        .HasOne(apc => apc.Agent)
        .WithMany(a => a.AgentPhotographyCompanies)
        .HasForeignKey(apc => apc.AgentId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<AgentPhotographyCompany>()
        .HasOne(apc => apc.PhotographyCompany)
        .WithMany(pc => pc.AgentPhotographyCompanies)
        .HasForeignKey(apc => apc.PhotographyCompanyId)
        .OnDelete(DeleteBehavior.Restrict);

    // === Agent 与 User 的一对一关系 ===
    modelBuilder.Entity<Agent>()
        .HasOne(a => a.User)
        .WithOne(u => u.Agent)
        .HasForeignKey<Agent>(a => a.Id)
        .OnDelete(DeleteBehavior.Restrict);

    // === PhotographyCompany 与 User 的一对一关系 ===
    modelBuilder.Entity<PhotographyCompany>()
        .HasOne(pc => pc.User)
        .WithOne(u => u.PhotographyCompany)
        .HasForeignKey<PhotographyCompany>(pc => pc.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // === 其他关系配置 ===
    
    // StatusHistory 关系
    modelBuilder.Entity<StatusHistory>()
        .HasOne(sh => sh.ListingCase)
        .WithMany(lc => lc.StatusHistories)
        .HasForeignKey(sh => sh.ListingCaseId)
        .OnDelete(DeleteBehavior.Cascade);

    // 确保 StatusHistory.ChangedByUserId 长度匹配
    modelBuilder.Entity<StatusHistory>()
        .Property(sh => sh.ChangedByUserId)
        .HasMaxLength(450);

    modelBuilder.Entity<StatusHistory>()
        .HasOne(sh => sh.ChangedByUser)
        .WithMany(u => u.ChangedStatusHistories)
        .HasForeignKey(sh => sh.ChangedByUserId)
        .OnDelete(DeleteBehavior.Restrict);

    // MediaAsset 关系
    modelBuilder.Entity<MediaAsset>()
        .HasOne(ma => ma.ListingCase)
        .WithMany(lc => lc.MediaAssets)
        .HasForeignKey(ma => ma.ListingCaseId)
        .OnDelete(DeleteBehavior.Restrict);

    // 确保 MediaAsset.UserId 长度匹配
    modelBuilder.Entity<MediaAsset>()
        .Property(ma => ma.UserId)
        .HasMaxLength(450);

    modelBuilder.Entity<MediaAsset>()
        .HasOne(ma => ma.User)
        .WithMany(u => u.MediaAssets)
        .HasForeignKey(ma => ma.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // ListingCase 与 User 关系
    modelBuilder.Entity<ListingCase>()
        .Property(lc => lc.UserId)
        .HasMaxLength(450);

    modelBuilder.Entity<ListingCase>()
        .HasOne(lc => lc.User)
        .WithMany(u => u.ListingCases)
        .HasForeignKey(lc => lc.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // CaseContact 关系
    modelBuilder.Entity<CaseContact>()
        .HasOne(cc => cc.ListingCase)
        .WithMany(lc => lc.CaseContacts)
        .HasForeignKey(cc => cc.ListingCaseId)
        .OnDelete(DeleteBehavior.Restrict);
}

    }
    
}
