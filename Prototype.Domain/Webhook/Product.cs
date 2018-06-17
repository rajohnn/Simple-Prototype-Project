using System.Collections.Generic;

namespace Prototype.Domain.Webhook {

    public abstract class BaseModel {
        public string Source { get; set; }
    }

    public abstract class Secret {
        public string CustomerKey { get; set; }
        public string CustomerSecret { get; set; }
        public string Industry { get; set; }
    }

    public class DealerMessage : Secret {
        public Product Product { get; set; }
    }

    public class DealerBatchMessage : Secret {
        public List<Product> Products = new List<Product>();
    }

    /// <summary>
    ///
    /// </summary>
    /// <example>
    /// Model should have a body style property
    /// </example>
    public class Product : BaseModel {

        /// <summary>
        /// If there is no external ID supplied by client use stock number.
        /// </summary>
        public string Id { get; set; }

        // TODO: Stock Number moves to identifier.  If stock number is null, or it is a general product catalog in here
        // SET LOCATION to Proxmity
        // Next serialize has the product has a location of Clearwater
        // Maybe a type of product:
        // Catalog, Inventory, and Configurator,
        /// <summary>
        /// /
        /// </summary>
        //public string StockNumber { get; set; }
        public DataType DataType { get; set; } = DataType.Catalog;

        public Model Model { get; set; }
        public string CatalogId { get; set; }

        public Manufacturer Manufacturer { get; set; } = new Manufacturer();

        /// <summary>
        /// Maps to condition in most dealerships.
        /// Maps to identifer
        /// </summary>
        public string Designation { get; set; }
        public string Configuration { get; set; }

        public List<Activity> Activities { get; set; } = new List<Activity>();

        // TODO: Consider moving into specification.
        /// <summary>
        /// Could be moved to identifer
        /// </summary>
        public string Condition { get; set; }

        public string ProductType { get; set; }
        //public string Description { get; set; }
        public string Status { get; set; }
        public Class Class { get; set; }
        public Location Location { get; set; }
        public List<Identifier> Identifiers { get; set; } = new List<Identifier>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<MarketingDescription> MarketingDescriptions { get; set; } = new List<MarketingDescription>();

        public List<Specification> Specifications { get; set; } = new List<Specification>();

        public List<Color> Colors { get; set; } = new List<Color>();

        //public List<Engine> Engines { get; set; } = new List<Engine>();
        public List<Price> Prices { get; set; } = new List<Price>();

        public List<Media> MediaContent = new List<Media>();
    }

    public class Feature : Product {
        public bool IsInstalled { get; set; } = true;
        public bool IsOptional { get; set; } = false;
        public int Count { get; set; } = 1;
        public bool IsEquipment { get; set; } = false;
    }

    public enum DataType {
        Catalog,
        Inventory
    }

    public class Manufacturer {
        public string Code { get; set; }
        public string Make { get; set; }
        public Location Location { get; set; } = new Location();
    }

    public class Model {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; } = new List<Model>();
    }

    public class Identifier {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class Color {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Activity : Attribute {
    }

    public class Price {
        public string Category { get; set; }
        public string DisplayValue { get; set; }
        public decimal? Value { get; set; }
    }

    //public class Engine {
    //    public string Make { get; set; }
    //    public Model Model { get; set; }
    //    public string DriveType { get; set; }
    //    public string FuelType { get; set; }
    //    public int Horsepower { get; set; }
    //    public int EngineCount { get; set; } = 1;
    //}

    public class Location {
        public string Code { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones = new List<Phone>();
    }

    /// <summary>
    /// TODO: Come back and think this through.  Might need generic names fro the attribute descriptor.
    /// </summary>
    public abstract class Attribute : BaseModel {

        /// <summary>
        /// Contains a list of descriptions for different industries and or customers.
        /// </summary>
        /// <remarks>
        /// Example: Measure could be called "Specification" by the dealer.  The descriptor type of "Marine", "PowerSports"
        /// </remarks>
        public string Descriptors { get; set; } 
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Descriptor {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Class : Attribute {        
        public List<Class> SubClasses = new List<Class>();
    }

    public class MarketingDescription : Attribute {
    }

    public class Specification : Attribute {
        public string UnitType { get; set; }
        public decimal? NumericValue { get; set; }
    }

    public class Media {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
    }

    public class Address {
        public string Description { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class Phone {
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string LineNumber { get; set; }
        public string Extension { get; set; }
    }
}