using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Builder
{
    public interface IBlockMatrixBuilder
    {
        BlockMatrix Build(int keywordlen, int messagelen);
    }
}
