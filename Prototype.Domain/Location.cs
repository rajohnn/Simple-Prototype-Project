using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel {

    /// <summary>
    /// Represents the location structure.
    /// </summary>
    public class Location : Entity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("ParentLocationId")]
        public List<Location> ParentLocations { get; set; } = new List<Location>();

        public List<Location> Locations { get; set; } = new List<Location>();
        public int? DataPartitionId { get; set; }

        [ForeignKey("DataPartitionId")]
        public DataPartition DataPartition { get; set; }
    }    
}