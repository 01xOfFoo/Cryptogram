using Cryptogram.UI.ConsoleApp.Arguments;
using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cryptogram.Core.Models;

namespace Cryptogram.UI.ConsoleApp.Test
{
    [TestClass]
    public class CommaArgumentToKeywordsConverterTest
    {
        private static string NO_KEYWORDS = "";
        private static string TWO_KEYWORDS = "keyword1,keyword2";

        private ArgumentToKeywordsConverter converter;

        [TestInitialize]
        public void SetUp()
        {
            converter = new CommaArgumentToKeywordsConverter();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyArgumentException))]
        public void FailsIfNoKeywordsAreGiven()
        {
            Keywords keywords = converter.Convert(NO_KEYWORDS);
            Assert.AreEqual(0, keywords.Count);
        }

        [TestMethod]
        public void ReturnsListWithCountTwoWhenTwoKeywordsAreGiven()
        {
            Keywords keywords = converter.Convert(TWO_KEYWORDS);
            Assert.AreEqual(2, keywords.Count);
        }
    }
}
