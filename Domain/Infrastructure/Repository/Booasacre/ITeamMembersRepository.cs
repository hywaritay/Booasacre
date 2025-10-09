using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface ITeamMembersRepository
{
    List<TeamMembers> All();
    TeamMembers? Find(int? id);
    bool Create(TeamMembers entity);
    bool Update(TeamMembers entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class TeamMembersRepository(BooasacreContext booasacreContext) : ITeamMembersRepository
{
    public List<TeamMembers> All()
    {
        return (booasacreContext.TeamMembers ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(t => t.Deleted == false || t.Deleted == null).ToListAsync().Result;
    }

    public TeamMembers? Find(int? id)
    {
        return booasacreContext.TeamMembers == null ? throw new Except(ErrorHttp.DbQueryRunFailed) : booasacreContext.TeamMembers.FindAsync(id).Result;
    }

    public bool Create(TeamMembers entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        
        if (!string.IsNullOrEmpty(entity.ImageFile))
        {
            var imageData = entity.ImageFile.Split(',')[1];
            entity.Image = imageData;
            entity.ImageSize = imageData.Length;
        }
        if (booasacreContext.TeamMembers == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.TeamMembers.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(TeamMembers entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.TeamMembers == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.TeamMembers.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Delete(int? id)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = false;
        entity.Deleted = true;
        entity.DateDeleted = DateTime.Now;
        if (booasacreContext.TeamMembers == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.TeamMembers.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.TeamMembers == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.TeamMembers.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}