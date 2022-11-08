using encryption_netcore_security.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace encryption_netcore_security.Repository
{
    public class SymmetricRepository : ISymmetricRepository
    {
        private readonly string _symmetricPrivateKey = string.Empty;
        public SymmetricRepository()
        {
            _symmetricPrivateKey = ConfigurationManager.AppSettings["symmetricPrivateKey"].Trim().ToString();
        }

        /// <summary>
        /// To Perform Operation On Symmetric Decryption 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string SymmetricDecryptionMethod(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_symmetricPrivateKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// To Perform Operation On Symmetric Encryption 
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        public string SymmetricEncryptionMethod(string rawText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_symmetricPrivateKey);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(rawText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);     
        }
    }
}
