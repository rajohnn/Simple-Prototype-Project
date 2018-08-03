using Prototype.Domain;
using Prototype.Domain.Mapping;
using System.Collections.Generic;

namespace Prototype.Models {

    public class ImportViewModel {
        public List<string> Headers { get; set; }
        public List<DixieProduct> Products { get; set; }
        public List<RowDetail> RowDetails { get; set; }
        public List<MappingOption> MappingOptions { get; set; }
        public List<Industry> Industries { get; set; }
        public List<ReferenceCodeModel> ReferenceCodes { get; set; }
        public List<ReferenceCodeModel> SpecificationTypes { get; set; }
        public List<ReferenceCodeModel> UnitTypes { get; set; }
        public List<ReferenceCodeModel> ClassTypes { get; set; }
        public List<ReferenceCodeModel> PriceTypes { get; set; }
        public List<ReferenceCodeModel> ActivityTypes { get; set; }
        public List<ReferenceCodeModel> Designations { get; set; }
        public List<ReferenceCodeModel> ColorTypes { get; set; }
        public List<ReferenceCodeModel> StatusTypes { get; set; }
        public List<string> CurrentMappingOptions { get; set; } = new List<string>();
        public List<ClassMap> ClassMaps { get; set; } = new List<ClassMap>();

        public int? SelectedMappingOption { get; set; }
        public int? SelectedIndustry { get; set; }
        public int? SelectedActivity { get; set; }
        public int? SelectedClass { get; set; }
        public string SelectedCsvOption { get; set; }

        public string SelectedColumn { get; set; }
        public string CurrentName { get; set; }
        public string CurrentValue { get; set; }

        public bool ShowFeature { get; set; } = false;
        public bool ShowIdentifiers { get; set; } = false;
        public bool ShowSpecification { get; set; } = false;
        public bool ShowClass { get; set; } = false;
        public bool ShowPrice { get; set; } = false;
        public bool ShowColor { get; set; } = false;
        public bool ShowMarketingDetail { get; set; } = false;
        public bool ShowActivity { get; set; } = false;
        public bool ShowDesignation { get; set; } = false;
        public bool ShowModel { get; set; } = false;
        public bool ShowSubModel { get; set; } = false;
        public bool ShowMake { get; set; } = false;
        public bool ShowCondition { get; set; } = false;
        public bool ShowQuantity { get; set; } = false;
        public bool ShowMedia { get; set; } = false;
        public bool ShowStatus { get; set; } = false;
    }

    public class ClassMap {
        public int Id { get; set; }
        public string CsvColumn { get; set; }
        public int ReferenceCodeId { get; set; }
        public string Value { get; set; }
    }

    public class RowDetail {
        public string Header { get; set; }
        public string Value { get; set; }
    }

    public class MappingOption {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}