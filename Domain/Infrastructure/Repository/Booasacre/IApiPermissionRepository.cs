using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IApiPermissionRepository
{
    List<ApiPermission> All();
    ApiPermission? Find(int? id);
    ApiPermission? FindByName(string? name);
    bool Create(ApiPermission entity);
    bool Update(ApiPermission entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ApiPermissionRepository(BooasacreContext apiCoreContext) : IApiPermissionRepository
{
    public List<ApiPermission> All()
    {
        return (apiCoreContext.ApiPermission ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(a => a.Deleted != true).ToListAsync().Result;
    }

    public ApiPermission? Find(int? id)
    {
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return apiCoreContext.ApiPermission.FindAsync(id).Result;
    }

    public ApiPermission? FindByName(string? name)
    {
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return name != null
            ? apiCoreContext.ApiPermission
                .FirstOrDefault(a => a.Name == name && a.Deleted != true)
            : null;
    }

    public bool Create(ApiPermission entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        entity.CreatedBy = "USER";
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiPermission.Add(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(ApiPermission entity)
    {
        entity.DateUpdated = DateTime.Now;
        entity.UpdatedBy = "USER";
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiPermission.Update(entity);
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
        entity.DeletedBy = "USER";
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiPermission.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Status(int? id, bool active)
    {
        var entity = Find(id);
        if (id == null || entity == null) throw new Except(ErrorHttp.NotFound);
        entity.Active = active;
        entity.DateUpdated = DateTime.Now;
        entity.UpdatedBy = "USER";
        if (apiCoreContext.ApiPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiPermission.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}