using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
        public ErrorModel(string message, string code = default, string reference = default, IList<ErrorModel> innerErrors = default)
        {
            Message = message;
            Code = code;
            Reference = reference;
            InnerErrors = innerErrors ?? new List<ErrorModel>();
        }

        public string Code { get; init; }

        public string Message { get; init; }

        public string Reference { get; init; }

        public IList<ErrorModel> InnerErrors { get; init; } = new List<ErrorModel>();
    }
}
