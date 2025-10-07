using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Booasacre.Domain.Infrastructure.Repository.Booasacre;

public interface IOtpRepository
{
    List<OneTimePassword> All();
    OneTimePassword? Find(int? id);
    OneTimePassword? FindByOtp(string? otp);
    OneTimePassword? FindByReference(string? reference);
    OneTimePassword? FindToValidate(string? otp, string? reference);
    bool Create(OneTimePassword entity);
    bool Update(OneTimePassword entity);
    bool Delete(int? id);
    bool Status(int? id, bool active);
    OneTimePassword Generate(string? email, string? phone, string? purpose, ApiUser? user);
}

public class OtpRepository(BooasacreContext gtcollectionContext) : IOtpRepository
{
    private static readonly Random Random = new Random();

    public List<OneTimePassword> All()
    {
        return (gtcollectionContext.OneTimePassword ?? throw new Except(ErrorHttp.DbQueryRunFailed)).Where(a => a.Deleted == false || a.Deleted == null).ToListAsync().Result;
    }

    public OneTimePassword? Find(int? id)
    {
        if (gtcollectionContext.OneTimePassword == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return gtcollectionContext.OneTimePassword.FindAsync(id).Result;
    }
    
    public OneTimePassword? FindByOtp(string? otp)
    {
        if (gtcollectionContext.OneTimePassword == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return gtcollectionContext.OneTimePassword.FirstOrDefault(a => a.Otp == otp && a.Deleted != true);
    }
    
    public OneTimePassword? FindByReference(string? reference)
    {
        if (gtcollectionContext.OneTimePassword == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return gtcollectionContext.OneTimePassword.FirstOrDefault(a => a.Reference == reference && a.Deleted != true);
    }
    
    public OneTimePassword? FindToValidate(string? otp, string? reference)
    {
        if (gtcollectionContext.OneTimePassword == null) throw new Except(ErrorHttp.DbQueryRunFailed);
        return gtcollectionContext.OneTimePassword.FirstOrDefault(a => 
            a.Otp == otp && 
            a.Reference == reference && 
            a.Used != true && 
            a.Active == true && 
            a.Deleted != true
            );
    }

    public bool Create(OneTimePassword entity)
    {
        entity.Active = true;
        entity.Deleted = false;
        entity.DateCreated = DateTime.Now;
        if (gtcollectionContext.OneTimePassword == null) throw new Except(ErrorHttp.DbCreateError);
        gtcollectionContext.OneTimePassword.Add(entity);
        var result = gtcollectionContext.SaveChangesAsync().Result; return result > 0;
    }

    public bool Update(OneTimePassword entity)
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
    
    public OneTimePassword Generate(string? email, string? phone, string? purpose, ApiUser? user)
    {
        var generatedOtp = UniqueOtp();
        var otpEntity = new OneTimePassword
        {
            Otp = generatedOtp,
            Email = email,
            Phone = phone,
            Purpose = purpose,
            Active = true,
            DateCreated = DateTime.Now,
            ExpiredDate = DateTime.Now.AddMinutes(15),
            FkUser = user
        };
        var referenceFound = false;
        while (referenceFound == false)
        {
            otpEntity.Reference = Functions.Generate(10);
            var checkTrx = FindByReference(otpEntity.Reference);
            if (checkTrx == null) referenceFound = true;
        }

        gtcollectionContext.OneTimePassword?.Add(otpEntity);
        gtcollectionContext.SaveChanges();

        return otpEntity;
    }

    public bool IsOtpAlreadyUsed(string otp)
    {
        return gtcollectionContext.OneTimePassword?.Any(o => o.Otp == otp && o.Used != true && o.Active == true) ?? false;
    }

    private string UniqueOtp()
    {
        string otp;
        do
        {
            otp = Random.Next(100000, 1000000).ToString("D6");
        } while (IsOtpAlreadyUsed(otp));

        return otp;
    }
}