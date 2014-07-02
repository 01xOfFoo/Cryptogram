using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptogram.Core.Models
{
    public class Keyword
    {
        private String value;

        private Keyword(String text)
        {
            value = text;
        }

        public static Keyword BuildEmptyKeyword()
        {
            return BuildNonSortedKeyword("");
        }

        public static Keyword BuildAlphaSortedKeyword(String text)
        {
            Keyword keyword = BuildNonSortedKeyword(text);
            keyword.SortByAlphabet();
            return keyword;
        }

        public static Keyword BuildNonSortedKeyword(String text)
        {
            return new Keyword(text);
        }

        public String Text
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int GetLength()
        {
            return value.Length;
        }

        private void SortByAlphabet()
        {
            char[] textArray = this.value.ToCharArray();
            Array.Sort(textArray);
            this.value = new String(textArray);
        }

        public char CharAt(int charIndex)
        {
            return Text.ElementAt(charIndex);
        }
     
        private void ReplaceAt(int charIndex, char character)
        {
            if (this.value.Count() <= charIndex)
                throw new IndexOutOfRangeException();

            StringBuilder sb = new StringBuilder(this.value);
            sb[charIndex] = character;
            this.value = sb.ToString();
        }

        public void SwapChars(int sortedCharIndex, int unsortedCharIndex)
        {
            char fromChar = this.CharAt(unsortedCharIndex);
            char toChar = this.CharAt(sortedCharIndex);

            this.ReplaceAt(sortedCharIndex, fromChar);
            this.ReplaceAt(unsortedCharIndex, toChar);
        }
    }
}
