using System;

namespace kr.bbon.Core
{
    /// <summary>
    /// Exception with data
    /// </summary>
    public abstract class SomethingWrongException : Exception
    {
        public SomethingWrongException(string message) : base(message) { }

        public abstract object GetDetails();
    }

    /// <summary>
    /// Exception with data
    /// </summary>
    /// <typeparam name="TDetails"></typeparam>
    public class SomethingWrongException<TDetails> : SomethingWrongException where TDetails : class
    {
        public SomethingWrongException(string message, TDetails details) : base(message)
        {
            this.Details = details;
        }

        public TDetails Details { get; init; }

        public override object GetDetails()
        {
            return Details;
        }
    }
}
