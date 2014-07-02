using Cryptogram.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptogram.Core.Contracts
{
    public interface IKeywordedEncryption : IEncryption, INeedsKeywords
    {
    }
}
