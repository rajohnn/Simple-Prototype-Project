using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class MediaAssetConfiguration : DealerEntity {
        public int? MediaAssetId { get; set; }

        [ForeignKey("MediaAssetId")]
        public MediaAsset MediaAsset { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public class CustomMediaAsset : DealerEntity {
        public int? MediaAssetTypeId { get; set; }

        [ForeignKey("MediaAssetTypeId")]
        public CustomReferenceCode MediaAssetType { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(400)]
        public string Url { get; set; }
    }
}