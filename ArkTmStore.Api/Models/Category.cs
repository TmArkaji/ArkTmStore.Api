using System;
namespace ArkTmStore.Api.Models
{
    public class Category : BaseModel<int>
    {
        public override int id { get; set; }
        public string category { get; set; }
    }
}

