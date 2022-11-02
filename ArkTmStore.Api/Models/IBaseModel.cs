using System;
namespace ArkTmStore.Api.Models
{
    public interface IBaseModel<TKey>
    {
        
        public abstract TKey id { get; set; }

        DateTime createDate { get; }
        bool deleted { get; set; }
    }
}

