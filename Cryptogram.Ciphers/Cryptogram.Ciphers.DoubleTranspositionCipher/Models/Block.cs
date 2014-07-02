using System;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Models
{
    public class Block
    {
        private char[] blockKeys;

        public Block() : this(0)
        {
        }
          
        public Block(int keylen)
        {
            this.blockKeys = new char[keylen];
        }

        public int GetBlockSize()
        {
            return this.blockKeys.Length;
        }

        public void SetKeyAt(int keyIndex, char key)
        {
            this.blockKeys[keyIndex] = key;
        }

        public String GetKeyAt(int keyIndex)
        {
            if (blockKeys.Length > keyIndex)
                return blockKeys[keyIndex].ToString();
            else
                return "";
        }

        public String GetBlockKeys()
        {
            return ConvertCharArrayToString();
        }

        private string ConvertCharArrayToString()
        {
            String value = new String(blockKeys);
            value = RemoveEmptyElements(value);
            return value;
        }

        private static string RemoveEmptyElements(String value)
        {
            return value.Replace("\0", "");
        }

        public void SetBlockKeys(String keys)
        {
            this.blockKeys = keys.ToCharArray();
        }
    }
}
