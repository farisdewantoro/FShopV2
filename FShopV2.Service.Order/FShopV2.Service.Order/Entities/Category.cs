using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Order.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(Guid id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
