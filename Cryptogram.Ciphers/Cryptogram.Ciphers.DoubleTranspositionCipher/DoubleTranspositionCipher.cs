using Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher
{
    public class DoubleTranspositionCipher : IKeywordedCipher
    {
        private Keywords keywords;
        private IKeywordedEncryption encryption;
        private IKeywordedDecryption decryption;

        public DoubleTranspositionCipher()
        {
            this.encryption = new DTEncryption();
            this.decryption = new DTDecryption();
        }

        public DoubleTranspositionCipher(IKeywordedEncryption encryption, IKeywordedDecryption decryption)
        {
            this.encryption = encryption;
            this.decryption = decryption;
        }

        public string Encrypt(string text)
        {
            this.encryption.SetKeywords(this.keywords);
            return this.encryption.Encrypt(text);
        }

        public string Decrypt(string text)
        {
            this.decryption.SetKeywords(this.keywords);
            return this.decryption.Decrypt(text);
        }

        public void SetKeywords(Keywords keywords)
        {
            this.keywords = keywords;            
        }
    }
}
