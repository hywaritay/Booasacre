using System.Security.Cryptography;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
namespace Booasacre.Domain.Utils;

public class Functions(IApiUserRepository apiUserRepository)
{
    public static string? PhoneLocalFormat(string? phoneNumber, bool? withoutPrefix = false)
    {
        if (phoneNumber == null) return null;
        phoneNumber = phoneNumber.Replace(" ", "");
        if (phoneNumber.Length < 8) return null;
        phoneNumber = phoneNumber.Length > 8 ? phoneNumber.Substring(phoneNumber.Length - 8, 8) : phoneNumber;
        return (withoutPrefix == true ? "" : "232") + phoneNumber;
    }

    public static string TitleCaseConvert(string title)
    {
        try
        {
            var wordStart = 0;
            var result = new char[title.Length];
            var ri = 0;
            for (var i = 0; i < title.Length; ++i)
                if (title[i] == '_')
                    wordStart = i + 1;
                else if (i == wordStart) result[ri++] = char.ToUpper(title[i]);
                else result[ri++] = char.ToLower(title[i]);

            return new string(result, 0, ri);
        }
        catch (Exception)
        {
            return title;
        }
    }

    public static string TitleCaseRevert(string title)
    {
        try
        {
            var result = new char[10000];
            var ri = 0;
            foreach (var t in title)
            {
                if (char.IsUpper(t) && ri != 0)
                {
                    result[ri] = '_';
                    ri++;
                    result[ri] = char.ToLower(t);
                }
                else
                {
                    result[ri] = char.ToLower(t);
                }

                ri++;
            }

            return new string(result, 0, ri);
        }
        catch (Exception)
        {
            return title;
        }
    }

    public static string GenerateUid(bool? braces = true)
    {
        return Guid.NewGuid().ToString(braces == true ? "D" : "N");
    }

    public static string Generate(int? length = 10, bool? digits = false)
    {
        // return Guid.NewGuid().ToString("");
        // string charset = "09182736455463728190ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var charset = digits == true ? "09182736455463728190" : "09182736455463728190ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (length != null && length > charset.Length) length = charset.Length;
        var outputChars = new char[length ?? 10];
        using var rng = RandomNumberGenerator.Create();
        const int minIndex = 0;
        var maxIndexExclusive = charset.Length;
        var diff = maxIndexExclusive - minIndex;
        var upperBound = uint.MaxValue / diff * diff;
        var randomBuffer = new byte[sizeof(int)];

        for (var i = 0; i < outputChars.Length; i++)
        {
            uint randomUInt;
            do
            {
                rng.GetBytes(randomBuffer);
                randomUInt = BitConverter.ToUInt32(randomBuffer, 0);
            } while (randomUInt >= upperBound);

            var charIndex = (int) (randomUInt % diff);

            outputChars[i] = charset[charIndex];
        }

        return new string(outputChars);
    }

    public ApiUser? GetUser(string? username)
    {
        return apiUserRepository.FindByApiKey(username);
    }

    public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }

    public static bool IsBase64(string base64)
    {
        var buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer, out var bytesParsed);
    }
    
}