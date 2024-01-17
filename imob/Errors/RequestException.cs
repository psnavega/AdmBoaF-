using System;
namespace immob.Errors
{
    public class RequestException : Exception
    {
        public int ErrorCode { get; }

        public RequestException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

