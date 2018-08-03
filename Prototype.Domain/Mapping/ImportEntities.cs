namespace Prototype.Domain.Mapping {

    public class Industry {
        public int Id { get; set; } //(int, not null)
        public bool IsDeleted { get; set; } //(bit, not null)
        public string Name { get; set; } //(nvarchar(100), null)
    }
    public class ReferenceCodeModel {
        public int Id { get; set; } //(int, not null)
        public int DataPartitionId { get; set; } //(int, null)
        public int ReferenceCodeTypeId { get; set; } //(int, not null)
        public string Name { get; set; } //(nvarchar(100), null)
        public int IndustryId { get; set; } //(int, null)
        public string Value { get; set; } //(nvarchar(200), null)
    }

}