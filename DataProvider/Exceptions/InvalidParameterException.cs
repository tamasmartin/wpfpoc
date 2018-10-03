using System;

namespace DataProvider.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string msg) : base(msg) {}
    }
}