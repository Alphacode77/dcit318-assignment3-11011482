using System;

namespace SchoolGradingsys.Exceptions
{
    public class IncompleteRecordException : Exception
    {
        public IncompleteRecordException(string message) : base(message)
        {
        }
    }
}
