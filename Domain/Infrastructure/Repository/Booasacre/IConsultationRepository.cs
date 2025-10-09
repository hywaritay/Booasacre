using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IConsultationRepository
{
    List<Consultation> All();
    Consultation? Find(int? id);
    bool Create(Consultation entity);
    bool Update(Consultation entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ConsultationRepository(BooasacreContext booasacreContext) : IConsultationRepository
{
    public List<Consultation> All()
    {
        return (booasacreContext.Consultation ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(c => c.Deleted == false || c.Deleted == null).ToListAsync().Result;
    }

    public Consultation? Find(int? id)
    {
        return booasacreContext.Consultation == null ? throw new Except(ErrorHttp.DbQueryRunFailed) : booasacreContext.Consultation.FindAsync(id).Result;
    }

    public bool Create(Consultation entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.Consultation == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Consultation.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(Consultation entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Consultation == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Consultation.Update(entity);
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
        if (booasacreContext.Consultation == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Consultation.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Consultation == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Consultation.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}