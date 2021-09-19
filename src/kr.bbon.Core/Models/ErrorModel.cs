using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
        public ErrorModel() { }

        public ErrorModel(string message, string code = null, IList<ErrorModel> innerErrors = null)
        {
            Message = message;
            Code = code;
            InnerErrors = innerErrors ?? new List<ErrorModel>();
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public IList<ErrorModel> InnerErrors { get; set; } = new List<ErrorModel>();
    }
}
