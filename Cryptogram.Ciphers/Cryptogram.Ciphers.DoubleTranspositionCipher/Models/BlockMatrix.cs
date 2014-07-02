using Cryptogram.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Models
{
    public class BlockMatrix : SwappableList<Block>
    {
        public int GetBlockSize()
        {
            return this.FirstOrDefault<Block>().GetBlockSize();
        }
    }
}
