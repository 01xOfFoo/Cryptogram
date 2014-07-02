using Cryptogram.Ciphers.DoubleTranspositionCipher.Decryption;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Test.Decryption
{
    [TestClass]
    public class DTDecryptionTest
    {
        private Keywords keywords;
        private IKeywordedCipher cipher;

        private static String KEYWORD1 = "deckel";
        private static String KEYWORD2 = "notebook";
        private static String CRYPTED_MESSAGE = "nrsgsesaieozrabinadiilurtndehxusrhevieepaeheegtlzftlianmel";
        private static String PARTLY_DECRYPTED_MESSAGE = "oinpufzlrastruserlarghhibtseeaineevnndsgimaeateedhilelixez";
        private static String FULLY_DECRYPTED_MESSAGE = "hallodashieristeinlangerbeispieltextumdasverfahrenzuzeigen";

        [TestInitialize]
        public void SetUp()
        {
            cipher = new DoubleTranspositionCipher();
            keywords = new Keywords();
        }

        [TestMethod]
        public void testReturnsSameMessageAsPassedInIfKeywordsAreEmpty()
        {
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Decrypt(CRYPTED_MESSAGE);

            Assert.AreEqual(CRYPTED_MESSAGE.Replace(" ", ""), returnedMessage);
        }

        [TestMethod]
        public void testDecryptMessageWithOneKeyword()  
        {
            keywords.Add(KEYWORD1);
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Decrypt(CRYPTED_MESSAGE);

            Assert.AreEqual(PARTLY_DECRYPTED_MESSAGE, returnedMessage);
        }

        [TestMethod]
        public void testDecryptMessageWithTwoKeywords() 
        {
            keywords.Add(KEYWORD1);
            keywords.Add(KEYWORD2);
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Decrypt(CRYPTED_MESSAGE);

            Assert.AreEqual(FULLY_DECRYPTED_MESSAGE, returnedMessage);
        }
    }
}
