using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryption_netcore_security.Contracts
{
    public interface IPemKeyGenerateRepository
    {
        public void GeneratePEMKey();
    }
}
