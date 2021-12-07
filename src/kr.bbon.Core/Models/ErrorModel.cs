using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
#if NET5_0_OR_GREATER
        private ErrorModel()
        {

        }
#else
        public ErrorModel()
        {

        }
#endif

        public ErrorModel(string Message, string Code = default, string Reference = default, IEnumerable<ErrorModel> InnerErrors = default)
        {
            this.Message = Message;
            this.Code = Code;
            this.Reference = Reference;
            this.InnerErrors = InnerErrors;
        }

        public string Message
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif
        }
        public string Code
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif

        }
        public string Reference
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }
        public IEnumerable<ErrorModel> InnerErrors
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }
    }
}

