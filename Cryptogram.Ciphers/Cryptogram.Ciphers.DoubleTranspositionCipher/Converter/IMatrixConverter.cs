using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Converter
{
    public interface IMatrixConverter<T>
    {
        T Convert(object matrix);
    }
}
