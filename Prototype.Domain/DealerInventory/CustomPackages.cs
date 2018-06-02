using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class PackageConfiguration : DealerEntity {
        public int? PackageId { get; set; }

        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Code { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Title { get; set; }
    }

    public class CustomPackage : DealerEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Code { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Title { get; set; }

        public List<ReferenceCode> Prices { get; set; } = new List<ReferenceCode>();
    }
}