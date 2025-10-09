using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Infrastructure.Entity.Content;
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
    public DbSet<Benefit>? Benefit { get; set; }
    public DbSet<Consultation>? Consultation { get; set; }
    public DbSet<ContactInfo>? ContactInfo { get; set; }
    public DbSet<Contact>? Contact { get; set; }
    public DbSet<CoreValues>? CoreValues { get; set; }
    public DbSet<Services>? Services { get; set; }
    public DbSet<Statement>? Statement { get; set; }
    public DbSet<TeamMembers>? TeamMembers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApiUserPermission>().Navigation(e => e.FkPermission).AutoInclude();
        modelBuilder.Entity<ApiUserPermission>().Navigation(e => e.FkUser).AutoInclude();
        modelBuilder.Entity<Benefit>().Navigation(e => e.FKService).AutoInclude();
        modelBuilder.Entity<Consultation>().Navigation(e => e.FKService).AutoInclude();
    }
}