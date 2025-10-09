using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IBenefitRepository
{
    List<Benefit> All();
    Benefit? Find(int? id);
    bool Create(Benefit entity);
    bool Update(Benefit entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class BenefitRepository(BooasacreContext booasacreContext) : IBenefitRepository
{
    public List<Benefit> All()
    {
        return (booasacreContext.Benefit ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(b => b.Deleted == false || b.Deleted == null).ToListAsync().Result;
    }

    public Benefit? Find(int? id)
    {
        return booasacreContext.Benefit == null ? throw new Except(ErrorHttp.DbQueryRunFailed) : booasacreContext.Benefit.FindAsync(id).Result;
    }

    public bool Create(Benefit entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.Benefit == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Benefit.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(Benefit entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Benefit == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Benefit.Update(entity);
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
        if (booasacreContext.Benefit == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Benefit.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Benefit == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Benefit.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}