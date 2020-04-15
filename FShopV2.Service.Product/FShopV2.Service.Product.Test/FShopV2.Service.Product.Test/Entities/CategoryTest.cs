using FShopV2.Service.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace FShopV2.Service.Product.Test.Entities
{
    public class CategoryTest : ValidatorEntity
    {
        private readonly Category _category;
        public CategoryTest()
        {
            _category = new Category();
        }

        public static IEnumerable<object[]> DataGuid
            => new List<object[]>
            {
                new object[]{Guid.Empty,"Id"}
            };
        public static IEnumerable<object[]> DataDate
            => new List<object[]>
            {
                new object[]{ default(DateTime), "CreatedDate"},
                 new object[]{default(DateTime),"UpdatedDate"}
            };
        private void AssignCategory()
        {
            _category.Name = "TESTING";
            _category.Description = "TESTING DESCRIPTION HERE";
        }
        [Theory]
        [MemberData(nameof(DataGuid))]
        public void RequiredValidation_GuidValue_ShouldThrowErrorRequired(Guid value, string field)
        {
            //arrange
            AssignCategory();
            PropertyInfo prop = _category.GetType().GetProperty(field);
            prop.SetValue(_category, value);
            var tes = ValidateModel(_category);
            //assert
            Assert.Contains(ValidateModel(_category), x => x.MemberNames.Contains(field)
                    && x.ErrorMessage.ToLower().Contains("required")
            );
        }
        [Theory]
        [MemberData(nameof(DataDate))]
        public void RequiredValidation_DateValue_ShouldThrowErrorRequired(DateTime value, string field)
        {
            //arrange
            AssignCategory();
            PropertyInfo prop = _category.GetType().GetProperty(field);
            prop.SetValue(_category, value);
            //assert
            Assert.Contains(ValidateModel(_category), x => x.MemberNames.Contains(field)
                    && x.ErrorMessage.ToLower().Contains("required")
            );
        }
        [Theory]
        [InlineData("","Name")]
        public void RequiredValidation_StringValue_ShouldThrowErrorRequired(string value,string field)
        {
            //arrange
            PropertyInfo prop = _category.GetType().GetProperty(field);
            prop.SetValue(_category, value);
            //assert
            Assert.Contains(ValidateModel(_category), x => x.MemberNames.Contains(field)
                    && x.ErrorMessage.ToLower().Contains("required")
            );
        }
        [Theory]
        [InlineData("a", "Name","between")]
        [InlineData("b", "Description","between")]
        public void MinLengthValidation_ShouldThrowErrorBetween(string value, string field, string errorMessage)
        {
            //arrange
            PropertyInfo prop = _category.GetType().GetProperty(field);
            prop.SetValue(_category, value);
            //assert
            Assert.Contains(ValidateModel(_category), x => x.MemberNames.Contains(field)
                    && x.ErrorMessage.ToLower().Contains(errorMessage)
            );
        }
    }
}
