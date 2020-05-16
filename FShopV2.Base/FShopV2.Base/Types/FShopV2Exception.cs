using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.Types
{
    public class FShopV2Exception : Exception
    {
        public string Code { get; }

        public FShopV2Exception()
        {
        }

        public FShopV2Exception(string code)
        {
            Code = code;
        }

        public FShopV2Exception(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public FShopV2Exception(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public FShopV2Exception(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public FShopV2Exception(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
