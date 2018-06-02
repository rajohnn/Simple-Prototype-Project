using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class AttributeConfiguration : DealerEntity {
        public int? AttributeId { get; set; }
        [ForeignKey("AttributeId")]
        public Attribute Attriute { get; set; }
        public string CustomDescription { get; set; }
        public bool IsVisible { get; set; }
    }

    public class CustomAttribute : DealerEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DisplayValue { get; set; }

        public bool IsLocked { get; set; }
    }


}