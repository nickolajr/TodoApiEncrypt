using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public interface IRSAEncryptionService
{
    Task<string> Encrypt(string textToEncrypt, string publicKey);
}

public class RSAEncryptionService : IRSAEncryptionService
{
    public async Task<string> Encrypt(string textToEncrypt, string publicKeyXml)
    {
        if (string.IsNullOrEmpty(textToEncrypt) || string.IsNullOrEmpty(publicKeyXml))
        {
            throw new ArgumentException("Text to encrypt and public key cannot be empty.");
        }

        using (var rsa = new RSACryptoServiceProvider())
        {
            // Import the public key from the XML string
            rsa.FromXmlString(publicKeyXml);

            // Encrypt the text
            byte[] encryptedBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), RSAEncryptionPadding.Pkcs1);

            // Return the encrypted bytes as a Base64 string
            return Convert.ToBase64String(encryptedBytes);
        }
    }

}
