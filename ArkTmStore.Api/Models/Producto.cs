using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArkTmStore.Api.Models
{
    public class Product : BaseModel<int>
    {
        public override int id { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string model { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal depth { get; set; }  // Profundidad
        [Column(TypeName = "decimal(18,2)")]
        public decimal width { get; set; }  // Ancho
        [Column(TypeName = "decimal(18,2)")]
        public decimal heigth { get; set; } // Alto
        [Column(TypeName = "decimal(18,2)")]
        public decimal weight { get; set; } // Peso

        [Column(TypeName = "decimal(18,2)")]
        public decimal priceDolar { get; set; }

        public string description1 { get; set; }
        public string description2 { get; set; }

        public bool hasDiscount { get; set; }

        #region Relaciones
        public int brandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int colorId { get; set; }
        public virtual Color Color { get; set; }

        public int categoryId { get; set; }
        public virtual Category Category { get; set; }

        #endregion

        public decimal pricePesos
        {
            get
            {
                return priceDolar * 4500;
            }

        }

        public string code
        {
            get
            {
                return (this.id > 0) ? "ARK" + this.id.ToString("D6") : "";
            }

        }

        public string mainImage
        {
            get
            {
                return (this.id > 0) ? "assets/images/productos/" + this.id.ToString() + "/img-min.jpg" : "";
            }

        }

        public string images
        {
            get
            {
                return (this.id > 0) ? "assets/images/productos/" + this.id.ToString() + "/img-XX.jpg" : "";
            }

        }

    }
}