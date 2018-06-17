using System;

namespace Prototype.Domain.Inventory {
    public class InventoryProduct {
        public long? ProductId { get; set; } //(bigint, not null)
        public int? LocationId { get; set; } //(int, not null)
        public string ProdType { get; set; } //(varchar(255), not null)
        public int? MakeId { get; set; } //(int, null)
        public int? ModelId { get; set; } //(int, null)
        public int? TrimId { get; set; } //(int, null)
        public int? PackageId { get; set; } //(int, null)
        public string Designation { get; set; } //(varchar(255), null)
        public string Description { get; set; } //(varchar(max), null)
        public string Status { get; set; } //(varchar(255), null)
        public long? ParentId { get; set; } //(bigint, null)
        public DateTime? FromDate { get; set; } //(datetime2(7), null)
        public DateTime? ThruDate { get; set; } //(datetime2(7), null)
    }
}