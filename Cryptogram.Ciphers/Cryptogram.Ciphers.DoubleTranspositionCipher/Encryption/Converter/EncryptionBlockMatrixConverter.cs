using System;
using System.Linq;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Converter;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption.Converter
{
    public class EncryptionBlockMatrixConverter : BlockMatrixConverter<String>
    {
        protected override String ConvertBlockTable()
        {
            String text = "";
            for (int tableRow = 0; tableRow < this.matrix.Count; tableRow++)
                text += GetTrimmedStringOfTableRow(tableRow);

            return text;
        }

        private String GetTrimmedStringOfTableRow(int tableRow)
        {
            Block block = GetBlockAt(tableRow);
            return GetTrimmedBlockKeys(block);
        }

        private string GetTrimmedBlockKeys(Block block)
        {
            String keys = block.GetBlockKeys();
            return keys.Trim();
        }

        private Block GetBlockAt(int tableRow)
        {
            return this.matrix.ElementAt(tableRow);
        }
    }
}
