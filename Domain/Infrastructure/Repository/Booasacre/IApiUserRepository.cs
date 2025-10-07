using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IApiUserRepository
{
    List<ApiUser> All();
    ApiUser? Find(int? id);
    ApiUser? FindByApiKey(string? apiKey);
    ApiUser? FindByEmail(string? email);
    bool Create(ApiUser entity);
    bool Update(ApiUser entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ApiUserRepository(BooasacreContext apiCoreContext) : IApiUserRepository
{
    public List<ApiUser> All()
    {
        return (apiCoreContext.ApiUser ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(a => a.Deleted == false || a.Deleted == null).ToListAsync().Result;
    }

    public ApiUser? Find(int? id)
    {
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return apiCoreContext.ApiUser.FindAsync(id).Result;
    }

    public ApiUser? FindByApiKey(string? apiKey)
    {
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return apiKey != null
            ? apiCoreContext.ApiUser.FirstOrDefault(a => a.ApiKey == apiKey && a.Active == true)
            : null;
    }

    public ApiUser? FindByEmail(string? email)
    {
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return email != null
            ? apiCoreContext.ApiUser.FirstOrDefault(a => a.Email == email && a.Active == true)
            : null;
    }

    public bool Create(ApiUser entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUser.Add(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(ApiUser entity)
    {
        entity.DateUpdated = DateTime.Now;
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUser.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Delete(int? id)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = false;
        entity.Deleted = true;
        entity.DateDeleted = DateTime.Now;
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUser.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        if (apiCoreContext.ApiUser == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUser.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}