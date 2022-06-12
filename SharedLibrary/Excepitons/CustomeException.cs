using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Excepitons
{
    public class CustomeException : Exception
    {
        public CustomeException()
        {
        }

        public CustomeException(string? message) : base(message)
        {
        }

        public CustomeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

     
    }
}
