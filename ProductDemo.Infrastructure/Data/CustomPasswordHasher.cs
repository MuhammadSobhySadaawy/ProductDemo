using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

public class Umbraco7PasswordHelper
{
    public static bool VerifyUmbraco7Password(string hashedPassword, string enteredPassword)
    {
        try
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // استخراج الـ Salt من البيانات المخزنة
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

            // استخراج الـ Hash المخزن
            byte[] storedHash = new byte[hashBytes.Length - salt.Length];
            Buffer.BlockCopy(hashBytes, salt.Length, storedHash, 0, storedHash.Length);

            // إعادة حساب الـ Hash باستخدام PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 1000, HashAlgorithmName.SHA1))
            {
                byte[] computedHash = pbkdf2.GetBytes(storedHash.Length);

                // مقارنة الـ Hash المستخرج بالـ Hash المحسوب
                return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
            }
        }
        catch
        {
            return false;
        }
    }

            public static string ConvertToAspNetIdentityPassword(string plainPassword)
    {
        var passwordHasher = new PasswordHasher<object>();
        return passwordHasher.HashPassword(null, plainPassword);
    }
    public static string? ExtractPassword(string hashedPassword)
    {
        try
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

            byte[] hash = new byte[hashBytes.Length - salt.Length];
            Buffer.BlockCopy(hashBytes, salt.Length, hash, 0, hash.Length);

            return Encoding.UTF8.GetString(hash);
        }
        catch
        {
            return null;
        }
    }
}
