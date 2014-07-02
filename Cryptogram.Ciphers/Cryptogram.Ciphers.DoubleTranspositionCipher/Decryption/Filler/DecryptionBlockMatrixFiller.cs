using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption.Filler
{
    public class DecryptionBlockMatrixFiller : IDecryptionBlockMatrixFiller
    {
        private Keyword sortedKeyword;
        private Keyword unsortedKeyword;
        private BlockMatrix matrix;
        private String cipherText;
        private List<int> filledBlockIndexes;
        private char sortedChar;
        private int lastCipherTextIndex;
        private int fillIndex;
        private int tableToTextDelta;

        public BlockMatrix Fill(BlockMatrix matrix, Keyword keyword, String cipherText)
        {
            this.matrix = matrix;
            this.cipherText = cipherText;

            BuildKeywords(keyword);
            CalculateBlockTableToTextDelta();
            FillTable();

            return this.matrix;
        }

        private void BuildKeywords(Keyword keyword)
        {
            this.sortedKeyword = Keyword.BuildAlphaSortedKeyword(keyword.Text);
            this.unsortedKeyword = Keyword.BuildNonSortedKeyword(keyword.Text);
        }

        private void CalculateBlockTableToTextDelta()
        {
            tableToTextDelta = (matrix.Count * matrix.GetBlockSize()) - cipherText.Length;
        }

        private void FillTable()
        {
            filledBlockIndexes = new List<int>();
            lastCipherTextIndex = 0;

            for (int currentCharIndex = 0; currentCharIndex < GetKeywordLength(); currentCharIndex++)
            {
                sortedChar = this.sortedKeyword.CharAt(currentCharIndex);
                fillIndex = DetermineNextIndex();
                FillTableBlock();
            }
        }

        private void FillTableBlock()
        {
            Block block = this.matrix.ElementAt(fillIndex);
            StripCipherTextAndFillBlock(block);
        }

        private void StripCipherTextAndFillBlock(Block block)
        {
            int blockLength = DetermineBlockLenght();
            String keys = ExtractText(blockLength);
            block.SetBlockKeys(keys);

            lastCipherTextIndex += blockLength;
        }

        private int DetermineBlockLenght()
        {
            int blockSize = matrix.GetBlockSize();
            return IsIndexInDeltaRange() ? blockSize - 1 : blockSize;
        }

        private bool IsIndexInDeltaRange()
        {
            return (matrix.Count - (fillIndex + 1)) < tableToTextDelta;
        }

        private string ExtractText(int cutIndex)
        {
            return this.cipherText.Substring(lastCipherTextIndex, cutIndex);
        }

        private int DetermineNextIndex()
        {
            for (int charIndex = 0; charIndex < GetKeywordLength(); charIndex++)
            {
                char unsortedChar = this.unsortedKeyword.CharAt(charIndex);
                if (IsValidSelection(charIndex, unsortedChar))
                {
                    filledBlockIndexes.Add(charIndex);
                    return charIndex;
                }
            }

            throw new InvalidOperationException();
        }

        private bool IsValidSelection(int charIndex, char unsortedChar)
        {
            return IsSameChar(unsortedChar) && IsBlockEmpty(charIndex);
        }

        private bool IsBlockEmpty(int charIndex)
        {
            return filledBlockIndexes.IndexOf(charIndex) < 0;
        }

        private bool IsSameChar(char unsortedChar)
        {
            return unsortedChar.Equals(sortedChar);
        }

        public int GetKeywordLength()
        {
            return this.unsortedKeyword.GetLength();
        }
    }
}
