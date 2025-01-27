using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses.CustomExceptions
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException() : base ("A connection error has occured") { }

        public DatabaseConnectionException(Exception? innerException) : base("A connection error has occured", innerException)
        {
        }

        protected DatabaseConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
