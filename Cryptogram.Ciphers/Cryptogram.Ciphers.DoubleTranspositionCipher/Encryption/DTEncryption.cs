using Cryptogram.Ciphers.DoubleTranspositionCipher.Builder;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Converter;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Converter;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Filler;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Sort;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Sort;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;
using System;
using System.Linq;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption
{
    public class DTEncryption : IKeywordedEncryption
    {
        private Keywords keywords;
        private String cipherText;
        private BlockMatrix matrix;

        private IBlockMatrixBuilder matrixBuilder;
        private IEncryptionBlockMatrixFiller matrixFiller;
        private IBlockMatrixSorter matrixSorter;
        private IMatrixConverter<String> matrixConverter;

        public DTEncryption()
        {
            matrixBuilder = new BlockMatrixBuilder();
            matrixFiller = new EncryptionBlockMatrixFiller();
            matrixSorter = new EncryptionBlockMatrixSorter();
            matrixConverter = new EncryptionBlockMatrixConverter();
        }

        public DTEncryption(IBlockMatrixBuilder builder, IEncryptionBlockMatrixFiller filler, IBlockMatrixSorter sorter, IMatrixConverter<String> converter)
        {
            matrixBuilder = builder;
            matrixFiller = filler;
            matrixSorter = sorter;
            matrixConverter = converter;
        }

        public String Encrypt(String cipherText)
        {
            this.cipherText = cipherText.Replace(" ", "");
            return EncryptMessageWithKeywords();
        }

        public void SetKeywords(Keywords keywords)
        {
            this.keywords = keywords;
        }

        private String EncryptMessageWithKeywords() 
        {
            for (int keywordIndex = 0; keywordIndex < this.keywords.Count; keywordIndex++) 
            {
                BuildCharTable(keywordIndex);
                FillTable(keywordIndex);
                SortTableByKeyword(keywordIndex);
                cipherText = ConvertBlockTableToString();
            }

            return cipherText;
        }

        private void BuildCharTable(int keywordIndex) 
        {
            matrix = matrixBuilder.Build(GetKeywordLength(keywordIndex), this.cipherText.Length);
        }

        private void FillTable(int keywordIndex) 
        {
            matrixFiller.Fill(matrix, cipherText);
        }

        private void SortTableByKeyword(int keywordIndex) 
        {
            matrix = matrixSorter.Sort(matrix, GetKeyword(keywordIndex));
        }

        private String ConvertBlockTableToString() 
        {
            return matrixConverter.Convert(matrix);
        }

        private Keyword GetKeyword(int keywordIndex) 
        {
            return this.keywords.ElementAt(keywordIndex);
        }

        private int GetKeywordLength(int keywordIndex) 
        {
            return GetKeyword(keywordIndex).GetLength();
        }
    }
}
