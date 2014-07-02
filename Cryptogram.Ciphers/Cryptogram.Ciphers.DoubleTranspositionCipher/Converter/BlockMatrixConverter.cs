using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Converter
{
    public abstract class BlockMatrixConverter<T> : IMatrixConverter<T>
    {
        protected BlockMatrix matrix;

        public T Convert(object matrix) 
        {
            this.matrix = (BlockMatrix)matrix;
            return ConvertBlockTable();
        }

        protected abstract T ConvertBlockTable();
    }
}
