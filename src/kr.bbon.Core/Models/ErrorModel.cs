using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public class ErrorModel
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public IList<ErrorModel> InnerErrors { get; set; } = new List<ErrorModel>();
    }
}
