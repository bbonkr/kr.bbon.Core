using System;

namespace kr.bbon.Core
{
    /// <summary>
    /// Exception with data
    /// </summary>
    [Obsolete("Consider to use ApiException instead of.")]
    public abstract class SomethingWrongException : Exception
    {
        public SomethingWrongException(string message) : base(message) { }

        public abstract object GetDetails();
    }

    /// <summary>
    /// Exception with data
    /// </summary>
    /// <typeparam name="TDetails"></typeparam>
    [Obsolete("Consider to use ApiException instead of.")]
    public class SomethingWrongException<TDetails> : SomethingWrongException where TDetails : class
    {
        public SomethingWrongException(string message, TDetails details) : base(message)
        {
            this.Details = details;
        }

        public TDetails Details { get; private set; }

        public override object GetDetails()
        {
            return Details;
        }
    }
}
