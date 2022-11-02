using System;
namespace ArkTmStore.Api.Models
{
    public class Brand : BaseModel<int>
    {
        public override int id { get; set; }
        public string brand { get; set; }
    }
}

