using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Builder
{
    public class BlockMatrixBuilder : IBlockMatrixBuilder
    {
        private int keywordLength;
        private int messageLength;
        private int verticalDepth;
        private BlockMatrix matrix;

        public BlockMatrix Build(int keywordLenght, int messageLength)
        {
            this.matrix = new BlockMatrix();
            this.keywordLength = keywordLenght;
            this.messageLength = messageLength;

            return BuildMatrix(keywordLength);
        }

        private BlockMatrix BuildMatrix(int keywordLenght)
        {
            CalculateVerticalDepth(keywordLength, messageLength);
            AddBlocks();
            return matrix;
        }

        private void CalculateVerticalDepth(int keywordlen, int messagelen)
        {
            this.verticalDepth = ((messagelen + keywordlen - 1) / keywordlen);
        }

        private void AddBlocks()
        {
            for (int i = 0; i < keywordLength; i++)
                AddBlockToMatrix();
        }

        private void AddBlockToMatrix()
        {
            Block block = BuildBlockWithVerticalDepth();
            matrix.Add(block);
        }

        private Block BuildBlockWithVerticalDepth()
        {
            return new Block(verticalDepth);
        }
    }
}
