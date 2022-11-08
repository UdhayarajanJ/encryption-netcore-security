using encryption_netcore_security.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace encryption_netcore_security.Repository
{
    public class AsymmetricRepository : IAsymmetricRespository
    {
        private readonly string _asymmetricPrivateKey = string.Empty;
        private readonly string _asymmetricPublicKey = string.Empty;
        public AsymmetricRepository()
        {
            _asymmetricPrivateKey = ConfigurationManager.AppSettings["asymmetricPrivateKey"].Trim().ToString();
            _asymmetricPublicKey= ConfigurationManager.AppSettings["asymmetricPublicKey"].Trim().ToString();
        }

        /// <summary>
        /// Private Key Based Decrypt The Data
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string AsymmetricDecryptionMethod(string cipherText)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(cipherText);
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportFromPem(_asymmetricPrivateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }
            return Encoding.UTF8.GetString(decryptedData);
        }

        /// <summary>
        /// Public Key Based Encrypt The Data
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        public string AsymmetricEncryptionMethod(string rawText)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(rawText);
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportFromPem(_asymmetricPublicKey);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
            return Convert.ToBase64String(encryptedData);
            throw new NotImplementedException();
        }
    }
}
