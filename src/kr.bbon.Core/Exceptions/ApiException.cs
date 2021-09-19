using kr.bbon.Core.Models;
using System;
using System.Net;

namespace kr.bbon.Core
{
    /// <summary>
    /// Represent situation that can not provide an appropriate response.
    /// </summary>
    public class ApiException : Exception
    {
        public const string Name = "ApiException ";

        private const string DEFAULT_MESSAGE = "Could not provide an appropriate response.";

        public ApiException(int statusCode, string message, ErrorModel error)
            : base(message)
        {
            StatusCode = statusCode;
            HttpStatusCode = (HttpStatusCode)statusCode;
            Error = error ?? new ErrorModel(Message: message, Code: $"{(HttpStatusCode)statusCode}");
        }

        public ApiException(HttpStatusCode statusCode, string message, ErrorModel error)
            : this((int)statusCode, message, error) { }

        public ApiException(int statusCode, ErrorModel error)
            : this(statusCode, error.Message, error) { }

        public ApiException(HttpStatusCode statusCode, ErrorModel error)
            : this(statusCode, error.Message, error) { }

        public ApiException(int statusCode, string message)
            : this(statusCode, message, null) { }

        public ApiException(HttpStatusCode statusCode, string message)
            : this(statusCode, message, null) { }

        public ApiException(int statusCode)
            : this(statusCode, DEFAULT_MESSAGE) { }
        public ApiException(HttpStatusCode statusCode)
          : this(statusCode, DEFAULT_MESSAGE) { }

        public int StatusCode { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public ErrorModel Error { get; }
    }
}
