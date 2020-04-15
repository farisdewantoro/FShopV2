using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FShopV2.Service.Product.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MinLength(10)]
        [MaxLength(500)]
        public string Description { get; set; }
        public Category()
        {

        }
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
