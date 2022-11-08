using encryption_netcore_security.Contracts;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryption_netcore_security.Repository
{
    public class PemKeyGenerateRepository : IPemKeyGenerateRepository
    {
        /// <summary>
        /// These Method Generate Standard SSL Key Both Private And Public RSA Key
        /// </summary>
        public void GeneratePEMKey()
        {
            //RSA Algorithm Based Generate Key [ Public And Private ]
            RsaKeyPairGenerator rsaGenerator = new RsaKeyPairGenerator();
            rsaGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = rsaGenerator.GenerateKeyPair();

            //Variable
            string _privateKey = string.Empty;
            string _publicKey = string.Empty;

            //Private Key Generate
            using (TextWriter privateKeyTextWriter = new StringWriter())
            {
                PemWriter pemWriter = new PemWriter(privateKeyTextWriter);
                pemWriter.WriteObject(keyPair.Private);
                pemWriter.Writer.Flush();
                _privateKey = privateKeyTextWriter.ToString();
            }

            //Public Key Generate
            using (TextWriter publicKeyTextWriter = new StringWriter())
            {

                PemWriter pemWriter = new PemWriter(publicKeyTextWriter);
                pemWriter.WriteObject(keyPair.Public);
                pemWriter.Writer.Flush();
                _publicKey = publicKeyTextWriter.ToString();
            }

            //Print The Value
            Console.WriteLine(_privateKey);
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(_publicKey);
        }
    }
}
