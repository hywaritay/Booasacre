
using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface ICoreValuesRepository
{
    List<CoreValues> All();
    CoreValues? Find(int? id);
    bool Create(CoreValues entity);
    bool Update(CoreValues entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class CoreValuesRepository(BooasacreContext booasacreContext) : ICoreValuesRepository
{
    public List<CoreValues> All()
    {
        return (booasacreContext.CoreValues ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(c => c.Deleted == false || c.Deleted == null).ToListAsync().Result;
    }

    public CoreValues? Find(int? id)
    {
        if (booasacreContext.CoreValues == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return booasacreContext.CoreValues.FindAsync(id).Result;
    }

    public bool Create(CoreValues entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.CoreValues == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.CoreValues.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(CoreValues entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.CoreValues == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.CoreValues.Update(entity);
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
        if (booasacreContext.CoreValues == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.CoreValues.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.CoreValues == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.CoreValues.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}