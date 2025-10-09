using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IServicesRepository
{
    List<Services> All();
    Services? Find(int? id);
    bool Create(Services entity);
    bool Update(Services entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ServicesRepository(BooasacreContext booasacreContext) : IServicesRepository
{
    public List<Services> All()
    {
        return (booasacreContext.Services ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(s => s.Deleted == false || s.Deleted == null).ToListAsync().Result;
    }

    public Services? Find(int? id)
    {
        return booasacreContext.Services == null ? throw new Except(ErrorHttp.DbQueryRunFailed) : booasacreContext.Services.FindAsync(id).Result;
    }

    public bool Create(Services entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.Services == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Services.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(Services entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Services == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Services.Update(entity);
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
        if (booasacreContext.Services == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Services.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Services == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Services.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}