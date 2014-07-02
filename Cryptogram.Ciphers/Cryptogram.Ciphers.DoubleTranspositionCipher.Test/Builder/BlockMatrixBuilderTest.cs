using Cryptogram.Ciphers.DoubleTranspositionCipher.Builder;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Test.Builder
{
    [TestClass]
    public class BlockMatrixBuilderTest
    {
        [TestMethod]
        public void MatrixHasOneBlockIfKeywordIsOneByteLong()
        {
            IBlockMatrixBuilder matrixBuilder = new BlockMatrixBuilder();
            BlockMatrix matrix = matrixBuilder.Build(1, 1);
            Assert.AreEqual(1, matrix.Count);
        }

        [TestMethod]
        public void MatrixHasTenBlockIfKeywordIsTenBytesLong()
        {
            IBlockMatrixBuilder matrixBuilder = new BlockMatrixBuilder();
            BlockMatrix matrix = matrixBuilder.Build(10, 1);
            Assert.AreEqual(10, matrix.Count);
        }

        [TestMethod]
        public void HasCorrectBlockSizeIfMessageAndKeywordLengthHaveNoRemainder()
        {
            IBlockMatrixBuilder matrixBuilder = new BlockMatrixBuilder();
            BlockMatrix matrix = matrixBuilder.Build(5, 15);
            Assert.AreEqual(3, matrix[0].GetBlockSize());
        }

        [TestMethod]
        public void HasCorrectBlockSizeIfMessageAndKeywordLengthHaveRemainder()
        {
            IBlockMatrixBuilder matrixBuilder = new BlockMatrixBuilder();
            BlockMatrix matrix = matrixBuilder.Build(5, 14);
            Assert.AreEqual(3, matrix[0].GetBlockSize());
        }
    }
}
