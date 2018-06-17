using System;

namespace Prototype.Domain.Inventory {

    public class InventoryFeature {
        public long? FeatureId { get; set; } //(bigint, not null)
        public string FeatureName { get; set; } //(varchar(255), null)
        public string AttributeName { get; set; } //(varchar(255), null)
        public string Value { get; set; } //(varchar(255), null)
        public long? ProductId { get; set; } //(bigint, not null)
        public DateTime? FromDate { get; set; } //(datetime2(7), not null)
        public DateTime? ThruDate { get; set; } //(datetime2(7), not null)
    }
}