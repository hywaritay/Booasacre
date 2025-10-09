using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IContactRepository
{
    List<Contact> All();
    Contact? Find(int? id);
    bool Create(Contact entity);
    bool Update(Contact entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ContactRepository(BooasacreContext booasacreContext) : IContactRepository
{
    public List<Contact> All()
    {
        return (booasacreContext.Contact ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(c => c.Deleted == false || c.Deleted == null).ToListAsync().Result;
    }

    public Contact? Find(int? id)
    {
        if (booasacreContext.Contact == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return booasacreContext.Contact.FindAsync(id).Result;
    }

    public bool Create(Contact entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.Contact == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Contact.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(Contact entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Contact == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Contact.Update(entity);
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
        if (booasacreContext.Contact == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Contact.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Contact == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Contact.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}