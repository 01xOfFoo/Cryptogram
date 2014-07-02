using Cryptogram.Ciphers.DoubleTranspositionCipher.Models;
using Cryptogram.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptogram.UI.ConsoleApp.Arguments
{
    public abstract class ArgumentToKeywordsConverter
    {
        private Keywords keywords;
        private readonly char separator;

        public ArgumentToKeywordsConverter(char separator)
        {
            this.separator = separator;
        }

        public Keywords Convert(string keywordPairs)
        {
            ConvertArgumentsToKeywords(keywordPairs);
            return keywords;
        }

        private void ConvertArgumentsToKeywords(string keywordPairs)
        {
            this.keywords = new Keywords();

            if (string.IsNullOrEmpty(keywordPairs))
                throw new EmptyArgumentException();

            List<string> words = SplitStringToListOfStrings(keywordPairs);
            ConvertListOfStringsToKeywords(words);
        }

        private List<string> SplitStringToListOfStrings(string keywordPairs)
        {
            return keywordPairs.Split(new char[] { this.separator }).ToList();
        }

        private void ConvertListOfStringsToKeywords(List<string> words)
        {
            foreach (string value in words)
            {
                if (IsValidKeywordValue(value))
                    keywords.Add(value);
            }
        }

        private static bool IsValidKeywordValue(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
