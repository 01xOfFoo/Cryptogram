using Cryptogram.Ciphers.DoubleTranspositionCipher.Builder;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Converter;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption.Converter;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption.Filler;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;
using System;
using System.Linq;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption
{
    public class DTDecryption : IKeywordedDecryption
    {
        private Keywords keywords;
        private String cipherText;

        private BlockMatrix matrix;
        private IBlockMatrixBuilder matrixBuilder;
        private IDecryptionBlockMatrixFiller matrixFiller;
        private IMatrixConverter<string> matrixConverter;

        public DTDecryption()
        {
            this.matrixBuilder = new BlockMatrixBuilder();
            this.matrixFiller = new DecryptionBlockMatrixFiller();
            this.matrixConverter = new DecryptionBlockMatrixConverter();
        }

        public DTDecryption(BlockMatrixBuilder matrixBuilder, IDecryptionBlockMatrixFiller matrixFiller, IMatrixConverter<string> matrixConverter)
        {
            this.matrixBuilder = matrixBuilder;
            this.matrixFiller = matrixFiller;
            this.matrixConverter = matrixConverter;
        }

        public string Decrypt(string text)
        {
            this.cipherText = text.Replace(" ", "");
            return DecryptMessageWithKeywords();
        }

        public void SetKeywords(Keywords keywords)
        {
            this.keywords = keywords;
        }

        private string DecryptMessageWithKeywords()
        {
            for (int keywordIndex = 0; keywordIndex < GetAmountOfKeywords(); keywordIndex++)
            {
                Keyword keyword = GetKeyword(keywordIndex);
                DecryptTextWithKeyword(keyword);

                this.cipherText = ConvertBlockTableToString();
            }
            return this.cipherText;
        }

        private void DecryptTextWithKeyword(Keyword keyword)
        {
            matrix = BuildBlockMatrix(keyword);
            FillBlockTable(keyword);
        }

        private int GetAmountOfKeywords()
        {
            return this.keywords.Count;
        }

        private void FillBlockTable(Keyword keyword)
        {
            this.matrixFiller.Fill(matrix, keyword, cipherText);
        }

        private Keyword GetKeyword(int keywordIndex)
        {
            return keywords.ElementAt(keywordIndex);
        }

        private BlockMatrix BuildBlockMatrix(Keyword keyword)
        {
            int keywordLength = keyword.GetLength();
            int cipherTextLength = this.cipherText.Length;

            return this.matrixBuilder.Build(keywordLength, cipherTextLength);
        }

        private String ConvertBlockTableToString()
        {
            return matrixConverter.Convert(matrix);
        }
    }
}
