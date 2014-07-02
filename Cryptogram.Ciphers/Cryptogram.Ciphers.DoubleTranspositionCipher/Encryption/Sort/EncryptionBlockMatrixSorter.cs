using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Sort;
using Cryptogram.Core.Models;
using System;
using System.Collections.Generic;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Sort
{
    public class EncryptionBlockMatrixSorter : IBlockMatrixSorter
    {
        protected Keyword sortedKeyword;
        protected Keyword unsortedKeyword;

        private BlockMatrix matrix;
        private List<int> sortedKeywordIndexes;

        private char sortedChar;
        private char unsortedChar;

        public BlockMatrix Sort(BlockMatrix matrix, Keyword keyword)
        {
            this.matrix = matrix;

            DetermineKeywordPairs(keyword);
            RearrangeTable();

            return this.matrix;
        }

        private void RearrangeTable()
        {
            sortedKeywordIndexes = new List<int>(); 
            for (int sortedCharIndex = 0; sortedCharIndex < GetKeywordLength(); sortedCharIndex++)
            {
                sortedChar = sortedKeyword.CharAt(sortedCharIndex);
                FindCharAndSwapColumns(sortedCharIndex);
            }
        }

        private void FindCharAndSwapColumns(int sortedCharIndex)
        {
            for (int unsortedCharIndex = 0; unsortedCharIndex < GetKeywordLength(); unsortedCharIndex++)
            {
                unsortedChar = unsortedKeyword.CharAt(unsortedCharIndex);
                if (IsSwapable(sortedCharIndex, unsortedCharIndex))
                {
                    Swap(sortedCharIndex, unsortedCharIndex);
                    break;
                }
            }
        }

        private bool IsSwapable(int sortedCharIndex, int unsortedCharIndex)
        {
            return IsSameChar(sortedChar, unsortedChar)
                    && AreIndexesMoreThenOneApart(sortedCharIndex, unsortedCharIndex)
                    && IsNotAlreadySwapped(unsortedCharIndex)
                    && IsDifferentIndex(sortedCharIndex, unsortedCharIndex)
                    && IsDifferentCharAtSwapTarget(sortedCharIndex, unsortedCharIndex);
        }

        private bool IsDifferentCharAtSwapTarget(int sortedCharIndex, int unsortedCharIndex)
        {
            char fromChar = unsortedKeyword.CharAt(unsortedCharIndex);
            char toChar = unsortedKeyword.CharAt(sortedCharIndex);
            return (fromChar != toChar);
        }

        private bool IsSameChar(char sortedChar, char unsortedChar)
        {
            return (sortedChar == unsortedChar);
        }

        private bool AreIndexesMoreThenOneApart(int sortedCharIndex, int unsortedCharIndex)
        {
            int steps = (sortedCharIndex - unsortedCharIndex);
            return (steps == -1) || (Math.Abs(steps) > 1);
        }

        private bool IsNotAlreadySwapped(int unsortedCharIndex)
        {
            return (!sortedKeywordIndexes.Contains(unsortedCharIndex));
        }

        private bool IsDifferentIndex(int sortedCharIndex, int unsortedCharIndex)
        {
            return (unsortedCharIndex != sortedCharIndex);
        }

        private void Swap(int sortedCharIndex, int unsortedCharIndex)
        {
            SwapTableColumns(sortedCharIndex, unsortedCharIndex);
            SwapKeywordChars(sortedCharIndex, unsortedCharIndex);
        }

        private void SwapTableColumns(int sortedCharIndex, int unsortedCharIndex)
        {
            this.matrix.Swap(sortedCharIndex, unsortedCharIndex);
        }

        private void SwapKeywordChars(int sortedCharIndex, int unsortedCharIndex)
        {
            unsortedKeyword.SwapChars(sortedCharIndex, unsortedCharIndex);
            sortedKeywordIndexes.Add(sortedCharIndex);
        }

        private int GetKeywordLength()
        {
            return this.sortedKeyword.GetLength();
        }

        private void DetermineKeywordPairs(Keyword keyword)
        {
            unsortedKeyword = Keyword.BuildNonSortedKeyword(keyword.Text);
            sortedKeyword = Keyword.BuildAlphaSortedKeyword(keyword.Text);
        }
    }
}
