using System;
using System.Net;
using System.Runtime.Serialization;

namespace Coding_Challenge.Common.Exceptions
{
    [Serializable]
    public class CouldNotParseEventFromBodyException : AppRuntimeException
    {
        public CouldNotParseEventFromBodyException(string msg) : base(HttpStatusCode.ExpectationFailed, msg)
        {
        }

        protected CouldNotParseEventFromBodyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}