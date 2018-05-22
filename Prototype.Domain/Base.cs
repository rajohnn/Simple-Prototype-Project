using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel {

    public abstract class Entity {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }        
    }

    public class DataPartition : Entity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Subdomain { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(200)]
        public string ReasonForDeletion { get; set; }
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

    public abstract class InventoryEntity : SystemEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string ExternalMasterId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string ExternalId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string ExternalName { get; set; }        
    }
}