using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FShopV2.Base
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
