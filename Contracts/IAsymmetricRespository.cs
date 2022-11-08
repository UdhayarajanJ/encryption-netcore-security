using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryption_netcore_security.Contracts
{
    public interface IAsymmetricRespository
    {
        public string AsymmetricEncryptionMethod(string rawText);
        public string AsymmetricDecryptionMethod(string cipherText);
    }
}
