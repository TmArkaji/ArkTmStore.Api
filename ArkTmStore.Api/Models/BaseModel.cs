using System;
namespace ArkTmStore.Api.Models
{
    public class BaseModel<TKey> : IBaseModel<TKey>
    {
        //public TKey id { get; set; }
        public virtual TKey id { get; set; }
        public DateTime createDate { get; set; }

        public bool deleted { get; set; }
    }
}


