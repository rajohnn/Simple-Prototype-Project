using System.Collections.Generic;

namespace Prototype.Tests.Model {
    public class BaseEntity {
        public int? Id { get; set; }
    }

    public class Import : BaseEntity {
        public string Name { get; set; }
    }

    public class ImportSetting : BaseEntity {        
        public int Index { get; set; }
        public string ColumnName { get; set; }
        public string TypeOf { get; set; }
        public bool HasDelimiter { get; set; }
        public string Delimiter { get; set; }
        public string MapsTo { get; set; }
        public string Property { get; set; }
        public List<BusinessRule> Rules { get; set; } = new List<BusinessRule>();
    }

    public class BusinessRule {

    }
}