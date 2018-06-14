using System.Collections.Generic;

namespace Prototype.Domain.Webhook {

    public class InventoryItemViewModel {
        public ProductDetailsModel ProductDetailsModel { get; set; } = new ProductDetailsModel();

        public SpecificationModel NewSpecification { get; set; } = new SpecificationModel();
        public PriceModel NewPrice { get; set; } = new PriceModel();
        public ColorModel NewColor { get; set; } = new ColorModel();
        public MarketingDetailModel NewMarketingDetail { get; set; } = new MarketingDetailModel();

        public List<SpecificationModel> Specifications { get; set; } = new List<SpecificationModel>();
        public List<PriceModel> Prices { get; set; } = new List<PriceModel>();
        public List<ColorModel> Colors { get; set; } = new List<ColorModel>();
        public List<MarketingDetailModel> MarketingDetails { get; set; } = new List<MarketingDetailModel>();
        public List<ActivityModel> Activities { get; set; } = new List<ActivityModel>();

        public bool IsFeatureExpanded { get; set; } = false;
        public bool IsSpecificationExpanded { get; set; } = false;
        public bool IsPricesExpanded { get; set; } = false;
        public bool IsColorsExpanded { get; set; } = false;
        public bool IsMarketingDetailsExpanded { get; set; } = false;
    }

    public class ProductDetailsModel {
        public string DisplayName { get; set; }
        public string StockNumber { get; set; }
        public string Category { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerMake { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string SubModelName { get; set; }
        public int? ModelYear { get; set; }
        public string Designation { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }      
    }

    public class FeatureModel : ProductDetailsModel {
        public bool 
    }

    public class SpecificationModel {
        public string Category { get; set; }
        public string UnitType { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public string Value { get; set; }
    }

    public class PriceModel {
        public string Category { get; set; }
        public decimal? Amount { get; set; }
        public string DisplayValue { get; set; }
    }

    public class ColorModel {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class MarketingDetailModel {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ActivityModel {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}