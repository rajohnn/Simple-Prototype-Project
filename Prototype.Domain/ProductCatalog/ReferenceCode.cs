using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class ReferenceCode : SystemEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }

        public int ReferenceCodeTypeId { get; set; }

        [Required]
        [ForeignKey("ReferenceCodeTypeId")]
        public virtual ReferenceCodeType ReferenceCodeType { get; set; }
    }

    /// <summary>
    /// TODO: Allow user to choose between pushing the reference code changes
    /// either up or down.
    /// </summary>
    public class ReferenceCodeConfiguration : DealerEntity {
        public int? ReferenceCodeId { get; set; }

        [ForeignKey("ReferenceCodeId")]
        public ReferenceCode ReferenceCode { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class CustomReferenceCode : DealerEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }

        public int ReferenceCodeTypeId { get; set; }

        [Required]
        [ForeignKey("ReferenceCodeTypeId")]
        public virtual ReferenceCodeType ReferenceCodeType { get; set; }

        [DefaultValue(true)]
        public bool IsVisibleToUser { get; set; }
    }

    public class ReferenceCodeType : Entity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ReferenceCodeTypeConfiguration : DealerEntity {
        public int? ReferenceCodeTypeId { get; set; }
        [ForeignKey("ReferenceCodeTypeId")]
        public ReferenceCodeType ReferenceCodeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}