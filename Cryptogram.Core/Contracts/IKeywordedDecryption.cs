using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptogram.Core.Contracts
{
    public interface IKeywordedDecryption : IDecryption, INeedsKeywords
    {
    }
}
