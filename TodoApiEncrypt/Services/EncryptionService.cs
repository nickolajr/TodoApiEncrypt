using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public interface IAESEncryptionService
{
    string Encrypt(string plainText, string key);
    //string Decrypt(string cipherText, string key);
}

public class AESEncryptionService : IAESEncryptionService
{


    [HttpPost("encrypt")]
    public async Task<IActionResult> Encrypt([FromBody] string plainText, string key)
    {
        string key = ""; 
        IAESEncryptionService encryptionService = new AESEncryptionService();
        string encryptedText = encryptionService.Encrypt(plainText, key);
        return Ok(encryptedText);
    }


    //public string Decrypt(string cipherText, string key)
    //{
    //    using (Aes aes = Aes.Create())
    //    {
    //        aes.Key = Encoding.UTF8.GetBytes(key);
    //        aes.IV = new byte[16]; 

    //        using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
    //        {
    //            using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
    //            {
    //                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
    //                {
    //                    using (var sr = new StreamReader(cs))
    //                    {
    //                        return sr.ReadToEnd();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
