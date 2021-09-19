using System;
using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public record ErrorModel(string Message, string Code = default, string Reference = default, IList<ErrorModel> InnerErrors = default);
}

