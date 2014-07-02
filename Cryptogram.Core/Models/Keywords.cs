using System;
using System.Collections.Generic;

namespace Cryptogram.Core.Models
{
    public class Keywords : List<Keyword>
    {
        public Keyword Add(String value)
        {
            Keyword keyword = Keyword.BuildNonSortedKeyword(value);
            base.Add(keyword);
            return keyword;
        }
    }
}
