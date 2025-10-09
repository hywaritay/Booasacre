
using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IContactInfoRepository
{
    List<ContactInfo> All();
    ContactInfo? Find(int? id);
    bool Create(ContactInfo entity);
    bool Update(ContactInfo entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ContactInfoRepository(BooasacreContext booasacreContext) : IContactInfoRepository
{
    public List<ContactInfo> All()
    {
        return (booasacreContext.ContactInfo ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(c => c.Deleted == false || c.Deleted == null).ToListAsync().Result;
    }

    public ContactInfo? Find(int? id)
    {
        if (booasacreContext.ContactInfo == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return booasacreContext.ContactInfo.FindAsync(id).Result;
    }

    public bool Create(ContactInfo entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.ContactInfo == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.ContactInfo.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(ContactInfo entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.ContactInfo == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.ContactInfo.Update(entity);
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
        if (booasacreContext.ContactInfo == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.ContactInfo.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.ContactInfo == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.ContactInfo.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}