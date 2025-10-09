using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IStatementRepository
{
    List<Statement> All();
    Statement? Find(int? id);
    bool Create(Statement entity);
    bool Update(Statement entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class StatementRepository(BooasacreContext booasacreContext) : IStatementRepository
{
    public List<Statement> All()
    {
        return (booasacreContext.Statement ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(s => s.Deleted == false || s.Deleted == null).ToListAsync().Result;
    }

    public Statement? Find(int? id)
    {
        if (booasacreContext.Statement == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return booasacreContext.Statement.FindAsync(id).Result;
    }

    public bool Create(Statement entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (booasacreContext.Statement == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Statement.Add(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(Statement entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Statement == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Statement.Update(entity);
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
        if (booasacreContext.Statement == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Statement.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (booasacreContext.Statement == null) throw new Except(ErrorHttp.DbCreateError);
        booasacreContext.Statement.Update(entity);
        var result = booasacreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}