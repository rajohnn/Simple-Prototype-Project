using L5.DomainModel.Inventory;
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

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DisplayName { get; set; }

        //[ForeignKey("ParentLocationId")]
        //public List<Location> ParentLocations { get; set; } = new List<Location>();

        public List<Location> ChildLocations { get; set; } = new List<Location>();
        public int? DataPartitionId { get; set; }
        public List<Address> Addresses { get; set; }


        [ForeignKey("DataPartitionId")]
        public DataPartition DataPartition { get; set; }
        public bool AllowsInventory { get; set; }
    }    

    public class UserLocation : Entity {       
       public Location Location { get; set; }
        public int? LocationId { get; set; }
       
        
    }

    public class Address : Entity {
        public int? AddressTypeId { get; set; }
        public ReferenceCode AddressType { get; set; }
        public string Address1 { get; set;    }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}