using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IApiUserPermissionRepository
{
    List<ApiUserPermission> All();
    List<ApiUserPermission> FindByUserId(int? userId);
    ApiUserPermission? Find(int? id);
    bool Create(ApiUserPermission entity);
    bool Update(ApiUserPermission entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
}

public class ApiUserPermissionRepository(BooasacreContext apiCoreContext) : IApiUserPermissionRepository
{
    public List<ApiUserPermission> All()
    {
        return (apiCoreContext.ApiUserPermission ?? throw new Except(ErrorHttp.DbQueryRunFailed))
            .Where(a => a.Deleted == false || a.Deleted == null).ToListAsync().Result;
    }

    public List<ApiUserPermission> FindByUserId(int? userId)
    {
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return apiCoreContext.ApiUserPermission
            .Where(a => a.FkUser != null && a.FkUser.Id == userId && a.Deleted != true).ToListAsync().Result;
    }

    public ApiUserPermission? Find(int? id)
    {
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return apiCoreContext.ApiUserPermission.FindAsync(id).Result;
    }

    public bool Create(ApiUserPermission entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        entity.CreatedBy = "USER";
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUserPermission.Add(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }

    public bool Update(ApiUserPermission entity)
    {
        entity.DateUpdated = DateTime.Now;
        entity.UpdatedBy = "USER";
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUserPermission.Update(entity);
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
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUserPermission.Update(entity);
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
        if (apiCoreContext.ApiUserPermission == null) throw new Except(ErrorHttp.DbCreateError);
        apiCoreContext.ApiUserPermission.Update(entity);
        var result = apiCoreContext.SaveChangesAsync().Result;
        return result > 0;
    }
}