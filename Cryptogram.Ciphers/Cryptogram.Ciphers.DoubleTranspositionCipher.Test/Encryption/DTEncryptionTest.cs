using Cryptogram.Ciphers.DoubleTranspositionCipher.Encryption;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Contracts;
using Cryptogram.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cryptogram.Ciphers.DoubleTranspositionCipher.Test.Encryption
{
    [TestClass]
    public class DTEncryptionTest
    {
        private static readonly String KEYWORD1 = "notebook";
        private static readonly String KEYWORD2 = "deckel";
        private static readonly String TEST_MESSAGE = "hallo das hier ist ein langer beispieltext um das verfahren zu zeigen";
        private static readonly String ENCRYPTED_MESSAGE_KEYWORD1 = "oinpufzlrastruserlarghhibtseeaineevnndsgimaeateedhilelixez";
        private static readonly String ENCRYPTED_MESSAGE_KEYWORD2 = "nrsgsesaieozrabinadiilurtndehxusrhevieepaeheegtlzftlianmel";

        private Keywords keywords;
        private IKeywordedCipher cipher;

        [TestInitialize]
        public void setUp() 
        {
            cipher = new DoubleTranspositionCipher();
            keywords = new Keywords();
        }

        [TestMethod]
        public void testReturnedMessageIsSameAsPassedInIfNoKeywordIsGiven()
        {
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Encrypt(TEST_MESSAGE);

            Assert.AreEqual(TEST_MESSAGE.Replace(" ", ""), returnedMessage);
        }

        [TestMethod]
        public void testEncryptMessageWithOneKeyword()
        {
            keywords.Add(KEYWORD1);
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Encrypt(TEST_MESSAGE);

            Assert.AreEqual(ENCRYPTED_MESSAGE_KEYWORD1.ToLower(), returnedMessage);
        }

        [TestMethod]
        public void testEncryptMessageWithTwoKeywords()
        {
            keywords.Add(KEYWORD1);
            keywords.Add(KEYWORD2);
            cipher.SetKeywords(keywords);
            String returnedMessage = cipher.Encrypt(TEST_MESSAGE);

            Assert.AreEqual(ENCRYPTED_MESSAGE_KEYWORD2.ToLower(), returnedMessage);
        }
    }
}
