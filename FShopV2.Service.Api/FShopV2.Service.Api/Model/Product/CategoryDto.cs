using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Api.Model.Product
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public CategoryDto()
        {

        }
    }
}
