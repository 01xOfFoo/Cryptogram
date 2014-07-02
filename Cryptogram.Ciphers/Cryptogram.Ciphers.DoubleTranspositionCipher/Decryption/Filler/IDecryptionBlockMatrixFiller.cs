using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption.Filler
{
    public interface IDecryptionBlockMatrixFiller
    {
        BlockMatrix Fill(BlockMatrix matrix, Keyword keyword, String cipherText);
    }
}
