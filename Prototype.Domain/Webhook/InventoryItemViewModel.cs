using System;
using System.Collections.Generic;

namespace Prototype.Domain.Webhook {

    public class InventoryItemViewModel {
        public ProductDetailsModel ProductDetailsModel { get; set; } = new ProductDetailsModel();

        public SpecificationModel NewSpecification { get; set; } = new SpecificationModel();
        public PriceModel NewPrice { get; set; } = new PriceModel();
        public ColorModel NewColor { get; set; } = new ColorModel();
        public ActivityModel NewActivity { get; set; } = new ActivityModel();
        public MarketingDetailModel NewMarketingDetail { get; set; } = new MarketingDetailModel();
        public ProductDetailsModel CurrentProductDetailsModel { get; set; } = new ProductDetailsModel();
        public string CurrentSubclass { get; set; }
        public int CurrentSubclassIndex { get; set; }

        public int Count { get; set; } = 1;

        public int SelectedSpecificationType { get; set; }
        public int SelectedUnitType { get; set; }
        public int SelectedPriceType { get; set; }
        public int SelectedColorType { get; set; }
        public int SelectedActivityType { get; set; }
        public int SelectedClass { get; set; }

        public bool IsFeatureExpanded { get; set; } = false;
        public bool IsSpecificationExpanded { get; set; } = false;
        public bool IsPricesExpanded { get; set; } = false;
        public bool IsActivitiesExpaneded { get; set; } = false;
        public bool IsColorsExpanded { get; set; } = false;
        public bool IsMarketingDetailsExpanded { get; set; } = false;
        public bool IsClassesExpanded { get; set; } = true;

        public List<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>();
        public List<SelectItem> BaseClasses { get; set; } = new List<SelectItem>();
        public List<SelectItem> SpecificationTypes { get; set; } = new List<SelectItem>();
        public List<SelectItem> UnitTypes { get; set; } = new List<SelectItem>();
        public List<SelectItem> PriceTypes { get; set; } = new List<SelectItem>();
        public List<SelectItem> ColorTypes { get; set; } = new List<SelectItem>();
        public List<SelectItem> ActivityTypes { get; set; } = new List<SelectItem>();
    }

    public class ProductDetailsModel {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StockNumber { get; set; }
        public string ProductType { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerMake { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string SubModelName { get; set; }
        public int? ModelYear { get; set; }
        public string Designation { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }

        public List<SpecificationModel> Specifications { get; set; } = new List<SpecificationModel>();
        public List<PriceModel> Prices { get; set; } = new List<PriceModel>();
        public List<ColorModel> Colors { get; set; } = new List<ColorModel>();
        public List<MarketingDetailModel> MarketingDetails { get; set; } = new List<MarketingDetailModel>();
        public List<ActivityModel> Activities { get; set; } = new List<ActivityModel>();
        public List<FeatureModel> Features { get; set; } = new List<FeatureModel>();
        public List<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>();
        public List<string> SubClasses { get; set; } = new List<string>();
    }

    public class FeatureModel : ProductDetailsModel {
        public bool IsEquipment { get; set; } = false;
        public bool IsInstalled { get; set; } = false;
        public bool IsOptional { get; set; } = false;
        public int Count { get; set; } = 1;
    }

    public abstract class BaseSelectionModel {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }

    public class SpecificationModel : BaseSelectionModel {
        public SelectItem Category { get; set; }
        public SelectItem UnitType { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public string Value { get; set; }
    }

    public class PriceModel : BaseSelectionModel {
        public SelectItem Category { get; set; }
        public decimal? Amount { get; set; }
        public string FormattedAmount { get; set; }
        public string DisplayValue { get; set; }
    }

    public class ColorModel : BaseSelectionModel {
        public SelectItem Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class MarketingDetailModel : BaseSelectionModel {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ActivityModel : BaseSelectionModel {
        public SelectItem Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ClassModel : BaseSelectionModel {
        public SelectItem Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<ClassModel> SubClasses { get; set; } = new List<ClassModel>();
    }

    public class NavigationItem {
        public string Id { get; set; }
        public string DisplayName { get; set; }
    }

    public class SelectItem {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}