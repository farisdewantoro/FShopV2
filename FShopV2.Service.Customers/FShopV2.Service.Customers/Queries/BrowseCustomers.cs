using FShopV2.Base.Types;
using FShopV2.Service.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Customers.Queries
{
    public class BrowseCustomers : PagedQueryBase, IQuery<PagedResult<CustomerDto>>
    {
    }
}
