using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArkTmStore.Api.Models
{
    public class PriceHistory : BaseModel<int>
    {
        public override int id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal valor { get; set; }
    }
}

