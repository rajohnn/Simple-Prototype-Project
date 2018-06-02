using L5.DomainModel.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel {

    public abstract class Entity {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }        
    }    

    public abstract class SystemEntity : Entity {
        public DateTimeOffset? DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public string LastModifiedBy { get; set; }
    }    

    public abstract class DealerEntity : Entity {
        public int LocationId { get; set; }
        public int DataPartitionId { get; set; }
        public bool IsLocked { get; set; }
        public DateTimeOffset? LockCreatedOn { get; set; }
        public string LockedBy { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
    /// <summary>
    /// TODO: Need to determine if inventory is set for a specific location, or a group.
    /// </summary>
    public abstract class ProductCatalogEntity : SystemEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string ExternalMasterId { get; set; } 
        public bool IsFromDatabase { get; set; }
    }

    public class Identifiers : SystemEntity {
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }
    }

    public class DataPartition : Entity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DealershipUrl { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(200)]
        public string ReasonForDeletion { get; set; }
    }

    
}