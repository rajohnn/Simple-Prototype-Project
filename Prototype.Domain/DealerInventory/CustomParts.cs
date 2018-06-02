using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class PartConfiguration : DealerEntity {
        public int? PartId { get; set; }
        public Part Part { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string DataType { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }
    }

    public class CustomPart : DealerEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string DataType { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }
    }
}