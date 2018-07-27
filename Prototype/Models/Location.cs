using System;
using System.Collections.Generic;

namespace Prototype.Models {

    public class DealerCreationViewModel {
        public string DataPartitionName { get; set; }
        public List<Location> Locations { get; set; }
        public Location CurrentLocation { get; set; }
        public Address CurrentAddress { get; set; }
        public Phone CurrentPhone { get; set; }
    }

    public class Location {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Text { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }

    public class Address {
        public string LocationId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class Phone {
        public string LocationId { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string LineNumber { get; set; }
    }
}