using FShopV2.Base.Types;
using FShopV2.Service.Api.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Queries
{
    public class BrowseCustomers : PagedQueryBase, IQuery<PagedResult<CustomerDto>>
    {
    }
}
