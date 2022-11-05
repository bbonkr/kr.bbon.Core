using System;
using System.Net;

namespace kr.bbon.Core.Exceptions
{
    /// <summary>
    /// Exception with http status code and message
    /// </summary>
    [Obsolete("Consider to use ApiException instead of.")]
    public abstract class HttpStatusException : Exception
    {
        public HttpStatusException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusException(int httpStatusCode, string message)
            : this((HttpStatusCode)httpStatusCode, message) { }

        public HttpStatusCode StatusCode { get; private set; }

        public abstract object GetDetails();
    }

    /// <summary>
    /// Exception with http status code, message, detail information
    /// </summary>
    [Obsolete("Consider to use ApiException instead of.")]
    public class HttpStatusException<TDetails> : HttpStatusException where TDetails : class
    {
        public HttpStatusException(HttpStatusCode httpStatusCode, string message, TDetails details)
            : base(httpStatusCode, message)
        {
            Details = details;
        }

        public HttpStatusException(int httpStatusCode, string message, TDetails details)
            : this((HttpStatusCode)httpStatusCode, message, details) { }

        public TDetails Details { get; private set; }

        public override object GetDetails()
        {
            return Details;
        }
    }

    /// <summary>
    /// Exception with http status code
    /// </summary>
    [Obsolete("Consider to use ApiException instead of.")]
    public class DefaultHttpStatusException : HttpStatusException<object>
    {
        public DefaultHttpStatusException(HttpStatusCode httpStatusCode, string message = "", object details = null)
            : base(httpStatusCode, message, details)
        {
        }
    }
}
