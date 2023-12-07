using System.Text;

namespace Tumultu.Domain.Extensions;

public static class CryptographyExtensions
{
    public static string GetMD5(this byte[] data)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();

        var hashBytes = md5.ComputeHash(data);

        StringBuilder sb = new();
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

    public static string GetSHA1(this byte[] data)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();

        var hashBytes = sha1.ComputeHash(data);
        
        StringBuilder sb = new();
        foreach(byte b in hashBytes)
        {
            sb.Append((b.ToString("x2")));
        }
        return sb.ToString();
    }

    public static string GetSHA256(this byte[] data)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();

        var hashBytes = sha256.ComputeHash(data);

        StringBuilder sb = new();
        foreach(byte b in hashBytes)
        {
            sb.Append((b.ToString("x2")));
        }
        return sb.ToString();
    }
}
