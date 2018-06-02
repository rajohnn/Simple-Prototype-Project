using System.Collections.Generic;

namespace Prototype.Domain.Webhook {

    public abstract class Secret {
        public string DealerKey { get; set; }
        public string DealerSecret { get; set; }
    }

    public class DealerMessage : Secret {
        public Product Product { get; set; }
    }

    public class DealerBatchMessage : Secret {
        public List<Product> Products = new List<Product>();
    }

    public class Product {
        public string Id { get; set; }
        public string StockNumber { get; set; }
        public Model Model { get; set; }
        public string Make { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Class Class { get; set; }
        public Location Location { get; set; }
        public List<Identifier> Identifiers { get; set; } = new List<Identifier>();
        public List<Feature> Features { get; set; } = new List<Feature>();
        public List<Option> Options { get; set; } = new List<Option>();
        public List<Specification> Specifications { get; set; } = new List<Specification>();
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public List<Color> Colors { get; set; } = new List<Color>();
        public List<Engine> Engines { get; set; } = new List<Engine>();
        public List<Price> Prices { get; set; } = new List<Price>();
        public List<Weight> Weights { get; set; } = new List<Weight>();
        public List<Media> MediaContent = new List<Media>();
    }

    public class Model {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class Identifier {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class Color {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Price {
        public string Type { get; set; }
        public decimal? Value { get; set; }
    }

    public class Engine {
        public string Make { get; set; }
        public Model Model { get; set; }
        public string DriveType { get; set; }
        public string FuelType { get; set; }
        public int Horsepower { get; set; }
    }

    public class Location {
        public string Code { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones = new List<Phone>();
    }

    public abstract class Attribute {
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Class : Attribute {
        public List<Class> SubClasses = new List<Class>();
    }

    public class Feature : Attribute {
    }

    public class Option : Attribute {
    }

    public class Specification : Attribute {
    }

    public class Weight : Attribute {
        public string Type { get; set; }
        public decimal? NumericValue { get; set; }
    }

    public class Measurement : Attribute {
        public string Type { get; set; }
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