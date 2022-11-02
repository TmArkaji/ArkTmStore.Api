using System;
namespace ArkTmStore.Api.Models
{
    public class Color : BaseModel<int>
    {
        public override int id { get; set; }
        public string color { get; set; }
    }
}

