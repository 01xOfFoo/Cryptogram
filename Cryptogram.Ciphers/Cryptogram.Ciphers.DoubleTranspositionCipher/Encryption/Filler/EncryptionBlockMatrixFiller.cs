using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using System;
using System.Linq;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Filler
{
    public class EncryptionBlockMatrixFiller : IEncryptionBlockMatrixFiller
    {
        protected BlockMatrix matrix;
        protected int actualColumn;
        protected int actualRow;
        private String cipherText;

        public void Fill(BlockMatrix matrix, String text) 
        {
            this.matrix = matrix;
            this.cipherText = text;

            FillRows();
        }

        private void FillRows() 
        {
            actualColumn = 0;
            actualRow = 0;

            for (int messageIndex = 0; messageIndex < GetCipherTextLength(); messageIndex++)
                FillSingleRow(messageIndex);
        }

        private void FillSingleRow(int messageIndex)
        {
            char messageChar = GetCipherTextCharAt(messageIndex);

            SetCharInBlockTableRow(messageChar);
            DetermineBounds();
        }

        private void SetCharInBlockTableRow(char messageChar)
        {
            Block block = matrix.ElementAt(actualRow);
            block.SetKeyAt(actualColumn, messageChar);
        }

        private int GetCipherTextLength()
        {
            return this.cipherText.Length;
        }

        private char GetCipherTextCharAt(int charIndex)
        {
            return this.cipherText.ElementAt(charIndex);
        }

        private void DetermineBounds()
        {
            actualRow++;
            if (actualRow >= matrix.Count)
            {
                actualRow = 0;
                actualColumn++;
            }
        }
    }
}
