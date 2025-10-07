using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Db;


public class BooasacreContext(DbContextOptions<BooasacreContext> options) : DbContext(options)
{
    public DbSet<AuditLog>? AuditLog { get; set; }
    public DbSet<AlertNotif>? AlertNotif { get; set; }
    public DbSet<OneTimePassword>? OneTimePassword { get; set; }
    public DbSet<ApiUser>? ApiUser { get; set; }
    public DbSet<ApiPermission>? ApiPermission { get; set; }
    public DbSet<ApiUserPermission>? ApiUserPermission { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApiUserPermission>().Navigation(e => e.FkPermission).AutoInclude();
        modelBuilder.Entity<ApiUserPermission>().Navigation(e => e.FkUser).AutoInclude();
    }
}