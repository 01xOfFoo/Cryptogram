using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptogram.UI.ConsoleApp.Arguments
{
    public class EmptyArgumentException : ArgumentException
    {
        public EmptyArgumentException()
            : base("Argument should not be empty")
        {

        }
    }
}
