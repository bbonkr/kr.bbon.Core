using System;
using System.Collections.Generic;
using System.Linq;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {

        }

        public ErrorModel(string Message, string Code = default, string Reference = default, IEnumerable<ErrorModel> InnerErrors = default)
        {
            this.Message = Message;
            this.Code = Code;
            this.Reference = Reference;
            this.InnerErrors = InnerErrors ?? Enumerable.Empty<ErrorModel>();
        }

        public string Message { get; set; }

        public string Code { get; set; }

        public string Reference { get; set; }

        public IEnumerable<ErrorModel> InnerErrors { get; set; }
    }
}

