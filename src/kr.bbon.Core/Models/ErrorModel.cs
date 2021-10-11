using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
#if NET5_0_OR_GREATER
    public record ErrorModel(string Message, string Code = default, string Reference = default, IList<ErrorModel> InnerErrors = default);
#else
    public class ErrorModel
    {
        private ErrorModel()
        {

        }

        public ErrorModel(string Message, string Code = default, string Reference = default, IList<ErrorModel> InnerErrors = default)
        {
            this.Message = Message;
            this.Code = Code;
            this.Reference = Reference;
            this.InnerErrors = InnerErrors;
        }

        public string Message { get; }
        public string Code { get; }
        public string Reference { get; }
        public IList<ErrorModel> InnerErrors { get; }
    }
#endif

}

