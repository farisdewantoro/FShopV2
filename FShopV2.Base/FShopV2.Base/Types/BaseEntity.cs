using FShopV2.Base.ValidatorAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FShopV2.Base.Types
{
    public abstract class BaseEntity : IIdentifiable
    {
        [Required]
        public Guid Id { get; protected set; }
        [Required]
        public DateTime CreatedDate { get; protected set; }
        [Required]
        public DateTime UpdatedDate { get; protected set; }

        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedDate = DateTime.UtcNow;
            SetUpdatedDate();
        }
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            SetUpdatedDate();
        }

        protected virtual void SetUpdatedDate()
            => UpdatedDate = DateTime.UtcNow;
    }
}
