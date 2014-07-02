using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptogram.UI.ConsoleApp.Arguments
{
    public class NotEnoughArgumentsException : Exception
    {
        public NotEnoughArgumentsException()
            : base("Not enough Arguments")
        {

        }
    }
}
