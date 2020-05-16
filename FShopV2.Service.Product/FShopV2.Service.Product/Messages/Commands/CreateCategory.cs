using FShopV2.Base.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Messages.Commands
{
    public class CreateCategory:ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonConstructor]
        public CreateCategory(Guid id, string name,string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
