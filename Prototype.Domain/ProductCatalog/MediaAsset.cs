using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class MediaAsset : SystemEntity {
        public int? MediaAssetTypeId { get; set; }

        [ForeignKey("MediaAssetTypeId")]
        public ReferenceCode MediaAssetType { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(400)]
        public string Url { get; set; }
    }
}