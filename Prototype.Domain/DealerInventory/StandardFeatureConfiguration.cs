using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class StandardFeatureConfiguration : DealerEntity {
        public int? StandardFeatureId { get; set; }
        public StandardFeature StandardFeature { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }
    }

    public class CustomFeatureConfiguration : DealerEntity {
        [Column(TypeName = "NVARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}