using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using System;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Filler
{
    public interface IEncryptionBlockMatrixFiller
    {
        void Fill(BlockMatrix matrix, String text);
    }
}
