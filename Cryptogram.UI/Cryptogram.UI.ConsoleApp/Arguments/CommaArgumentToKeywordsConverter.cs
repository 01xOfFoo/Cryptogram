using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptogram.UI.ConsoleApp.Arguments
{
    public class CommaArgumentToKeywordsConverter : ArgumentToKeywordsConverter
    {
        public CommaArgumentToKeywordsConverter()
            : base(',')
        {
        }
    }
}
