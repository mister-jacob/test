using System;

namespace TestBack.BL.Common
{
    public class LoggerException : ApplicationException
    {
        public LoggerException(string message) : base(message)
        {

        }

        public LoggerException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
