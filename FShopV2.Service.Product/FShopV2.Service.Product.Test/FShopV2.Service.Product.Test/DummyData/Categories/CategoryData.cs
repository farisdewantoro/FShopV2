using FShopV2.Service.Product.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FShopV2.Service.Product.Test.DummyData.Categories
{
    public class CategoryData
    {
        public List<Category> GetCategories {
            get
            {
                if(categories == null)
                {
                    return PopulateCategories();
                }
                return categories;
            }
        }
        public List<Category> categories = null;

        public virtual List<Category> PopulateCategories()
        {
            categories = new List<Category>();
            for (int i = 0; i <= 5; i++)
            {
                categories.Add(new Category()
                {
                    Name = "TESTING NAME" + i,
                    Description ="TESTING DESCRIPTION" +i
                });
            }

            return categories;
        }
    }
}
