using Prototype.Domain;
using System.Collections.Generic;

namespace Prototype.Models {

    public class ImportViewModel {
        public List<string> Headers { get; set; }
        public List<DixieProduct> Products { get; set; }
        public List<RowDetail> RowDetails { get; set; }
        public List<MappingOption> MappingOptions { get; set; }

        public int? SelectedMappingOption { get; set; }
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

    public class RowDetail {
        public string Header { get; set; }
        public string Value { get; set; }
    }

    public class MappingOption {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}