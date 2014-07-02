using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Models;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Sort
{
    public interface IBlockMatrixSorter
    {
        BlockMatrix Sort(BlockMatrix matrix, Keyword keyword);
    }
}
