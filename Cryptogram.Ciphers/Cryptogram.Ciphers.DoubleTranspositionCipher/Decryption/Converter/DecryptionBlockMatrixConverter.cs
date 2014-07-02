using System;
using System.Linq;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Converter;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption.Converter
{
    public class DecryptionBlockMatrixConverter : BlockMatrixConverter<String>
    {
        protected override String ConvertBlockTable()
        {
            return ConvertMatrix();
        }

        private string ConvertMatrix()
        {
            String text = "";
            for (int charIndex = 0; charIndex < matrix.GetBlockSize(); charIndex++)
                text += ExtractCharsAtPositionOfBlocks(charIndex);

            return text;
        }

        private string ExtractCharsAtPositionOfBlocks(int charIndex)
        {
            String charString = "";
            for (int blockIndex = 0; blockIndex < matrix.Count; blockIndex++)
                charString += GetLineOfBlock(blockIndex, charIndex);

            return charString;
        }

        private String GetLineOfBlock(int blockIndex, int charIndex)
        {
            Block block = GetBlockAt(blockIndex);
            return GetKeyFromBlockAt(block, charIndex);
        }

        private Block GetBlockAt(int blockIndex)
        {
            return matrix.ElementAt(blockIndex);
        }

        private string GetKeyFromBlockAt(Block block, int charIndex)
        {
            return block.GetKeyAt(charIndex);
        }
    }
}
