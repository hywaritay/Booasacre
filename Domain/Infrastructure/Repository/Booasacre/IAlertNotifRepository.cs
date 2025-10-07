using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IAlertNotifRepository
{
    List<AlertNotif> All();
    AlertNotif? Find(int? id);
    bool Create(AlertNotif entity);
    bool Update(AlertNotif entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class AlertNotifRepository(BooasacreContext gtcollectionContext) : IAlertNotifRepository
{
    public List<AlertNotif> All()
    {
        return (gtcollectionContext.AlertNotif ?? throw new Except(ErrorHttp.DbQueryRunFailed)).Where(a => a.Deleted == false || a.Deleted == null).ToListAsync().Result;
    }

    public AlertNotif? Find(int? id)
    {
        if (gtcollectionContext.AlertNotif == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return gtcollectionContext.AlertNotif.FindAsync(id).Result;
    }

    public bool Create(AlertNotif entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (gtcollectionContext.AlertNotif == null) throw new Except(ErrorHttp.DbCreateError);
        gtcollectionContext.AlertNotif.Add(entity);
        var result = gtcollectionContext.SaveChangesAsync().Result; return result > 0;
    }

    public bool Update(AlertNotif entity)
    {
        entity.DateUpdated = DateTime.Now;
        gtcollectionContext.Entry(Find(entity.Id) ?? throw new Except(ErrorHttp.DbUpdateError)).CurrentValues.SetValues(entity);
        var result = gtcollectionContext.SaveChangesAsync().Result; return result > 0;
    }

    public bool Delete(int? id)
    {
        var entity = this.Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = false;
        entity.Deleted = true;
        entity.DateDeleted = DateTime.Now;
        gtcollectionContext.Entry(Find(entity.Id) ?? throw new Except(ErrorHttp.DbUpdateError)).CurrentValues.SetValues(entity);
        var result =gtcollectionContext.SaveChangesAsync().Result; return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = this.Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        gtcollectionContext.Entry(Find(entity.Id) ?? throw new Except(ErrorHttp.DbUpdateError)).CurrentValues.SetValues(entity);
        var result =gtcollectionContext.SaveChangesAsync().Result; return result > 0;
    }
}