using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.Messages
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
