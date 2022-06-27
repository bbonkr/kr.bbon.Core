using System;
using System.Collections.Generic;
using System.Linq;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
        //#if NET5_0_OR_GREATER
        //        private ErrorModel()
        //        {

        //        }
        //#else
        //#endif
        public ErrorModel()
        {

        }

        public ErrorModel(string Message, string Code = default, string Reference = default, IEnumerable<ErrorModel> InnerErrors = default)
        {
            this.Message = Message;
            this.Code = Code;
            this.Reference = Reference;
            this.InnerErrors = InnerErrors;
        }

        public string Message { get; set; }

        public string Code { get; set; }

        public string Reference { get; set; }

        public IEnumerable<ErrorModel> InnerErrors { get; set; } = Enumerable.Empty<ErrorModel>();
    }
}

