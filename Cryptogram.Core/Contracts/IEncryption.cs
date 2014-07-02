using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptogram.Core.Contracts
{
    public interface IEncryption
    {
        string Encrypt(string text);
    }
}
