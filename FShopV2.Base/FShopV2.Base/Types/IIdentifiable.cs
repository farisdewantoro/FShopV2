using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
