using FShopV2.Base.Messages;
using FShopV2.Base.Types;
using FShopV2.Base.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Base.MessageModels.Products
{
    [MessageNamespace(CodeConstant.ServicesName.PRODUCT_SERVICE)]
    public class CategoryCreated:IEvent,IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        [JsonConstructor]
        public CategoryCreated(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
