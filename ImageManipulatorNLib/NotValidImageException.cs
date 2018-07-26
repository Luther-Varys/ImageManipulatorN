using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulatorNLib
{
    public class NotValidImageException : Exception
    {
        public NotValidImageException()
        {
        }

        public NotValidImageException(string message)
            : base(message)
        {
        }

        public NotValidImageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
