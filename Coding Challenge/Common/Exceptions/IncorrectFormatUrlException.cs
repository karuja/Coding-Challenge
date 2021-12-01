using System;
using System.Net;
using System.Runtime.Serialization;

namespace Coding_Challenge.Common.Exceptions
{
    [Serializable]
    public class IncorrectFormatUrlException : AppRuntimeException
    {
        public IncorrectFormatUrlException(string msg) : base(HttpStatusCode.ExpectationFailed, msg)
        {
        }

        protected IncorrectFormatUrlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}