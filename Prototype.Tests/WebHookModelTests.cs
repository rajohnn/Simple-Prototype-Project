﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Prototype.Domain.Repository;
using Prototype.Domain.Webhook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototype.Tests {

    [TestClass]
    public class WebHookModelTests {

        [TestMethod]
        public void WebHook_TestProductGeneration() {
            var product = GetTestProduct();

            var message = new DealerMessage {
                CustomerKey = "TestKey",
                CustomerSecret = "v0VRCRMDohbRpTxyAeVYw40zlewnPem5s",
                Industry = "Marine",
                Product = product
            };
            var json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void WebHook_TestMessageGeneration() {
            var product = GetTestProduct();

            var message = new DealerMessage {
                CustomerKey = "TestKey",
                CustomerSecret = "v0VRCRMDohbRpTxyAeVYw40zlewnPem5s",
                Industry = "Marine",
                Product = product
            };
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void WebHook_TestBatchMessageGeneration() {
            var p1 = GetTestProduct();
            var p2 = GetTestProduct();

            var message = new DealerBatchMessage {
                CustomerKey = "TestKey",
                CustomerSecret = "v0VRCRMDohbRpTxyAeVYw40zlewnPem5s",
                Industry = "Marine",
                Products = new List<Product> {
                    p1, p2
                }
            };
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void WebHook_GetSkipperBudSample() {
            var product = GetSkipperBudProduct();

            var message = new DealerMessage {
                CustomerKey = "TestKey",
                CustomerSecret = "v0VRCRMDohbRpTxyAeVYw40zlewnPem5s",
                Product = product,
                Industry = "Marine"
            };
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void GetProduct() {
            var product = new Product();
            var json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void WebHook_GetNewModel() {
            var message = new DealerMessage {
                CustomerKey = "TestKey",
                CustomerSecret = "v0VRCRMDohbRpTxyAeVYw40zlewnPem5s",
                Industry = "Marine",
                Product = new Product {
                    Activities = new List<Activity>(),
                    Class = new Class(),
                    Colors = new List<Color>(),
                    Condition = "Super Duper",
                    Configuration = "",
                    DataType = DataType.Catalog,
                    Description = "Description",
                    Designation = "Designation",
                    Features = new List<Feature> {
                        new Feature {
                            Count = 1,
                            IsEquipment = false,                            
                            IsInstalled = true,
                            IsOptional = false,
                            Activities = new List<Activity>(),
                            Class = new Class(),
                            Colors = new List<Color>(),
                            Condition = "Super Duper",
                            Configuration = "",
                            DataType = DataType.Catalog,
                            Description = "Description",
                            Designation = "Designation",
                            Identifiers = new List<Identifier>(),
                            Location = new Location(),
                            Manufacturer = new Manufacturer(),
                            MarketingDescriptions = new List<MarketingDescription>(),
                            MediaContent = new List<Media>(),
                            Model = new Model(),
                            Prices = new List<Price>(),
                            ProductType = "Product Type",
                            Source = "Source",
                            Specifications = new List<Specification>(),
                            Status = "Status"
                        }
                    },
                    Id = "External SkipperBud ID",
                    Identifiers = new List<Identifier>(),
                    Location = new Location(),
                    Manufacturer = new Manufacturer(),
                    MarketingDescriptions = new List<MarketingDescription>(),
                    MediaContent = new List<Media>(),
                    Model = new Model(),
                    Prices = new List<Price>(),
                    ProductType = "Product Type",
                    Source = "Source",
                    Specifications = new List<Specification>(),
                    Status = "Status"
                }
            };
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
        }

        [TestMethod]
        public void MappingSample () {
            var product = new Product {
                Model = new Model {
                    Code = "12312",
                    Name = "AMG C",
                    Models = new List<Model> {
                        new Model {
                            Name = "43 4Matic"
                        }
                    }
                }
            };

            Console.WriteLine(product.Model.Name + string.Join(" ", product.Model.Models.Select(x => x.Name)));

            var detail = new ListingDetail {
                makeName = product.Manufacturer.Make,
                makeId = product.Manufacturer.Code,
                modelId = product.Model.Code,
                modelName = product.Model.Name + product.Model.Name + string.Join(" ", product.Model.Models.Select(x => x.Name)),
                modelYear = product.Identifiers.SingleOrDefault(i => i.Name == "Year").Value
            };

        }

        [TestMethod]
        public void GetTestPayloadFromFile() {
            var repo = new PayloadTestRepository();
            var payload = repo.GetTestPayload();
            var json = JsonConvert.SerializeObject(payload);
            Console.WriteLine(json);
        }

        private Product GetTestProduct() {
            var product = new Product {
                Condition = "Used",
                Description = "2011 Coachmen Freedom Express 260BL - SW2152",
                Id = "123454321",

                Identifiers = new List<Identifier> {
                    new Identifier { Name = "ExternalID", Value = "1" },
                    new Identifier { Name = "CMF", Description = "", Value = "76175138" },
                    new Identifier { Name = "StockNumber", Description="", Value="SW2152" },
                },
                Location = new Location {
                    Addresses = new List<Address> {
                    new Address {
                        Street1 = "3443 Southwestern Blvd",
                        City = "Orchard Park",
                        State = "NY",
                        PostalCode = "14127",
                        Country = "USA"
                    }},
                    Code = "12312"
                },
                Manufacturer = new Manufacturer { Make = "Coachmen" },
                Model = new Model {
                    Name = "Freedom Express 260BL - SW2152",
                    // Year = 2011
                },
                Status = "Pending Sale",

                Specifications = new List<Specification> {
                    new Specification{ CategoryName = "Body", Name = "Body Style", Value = "Travel Trailer" },
                    new Specification{ Name = "Hours", Value = "0" },
                    new Specification{ Name = "Has Trailer", Value = "False" }
                },
                Colors = new List<Color> {
                    new Color { Name = "Exterior Color", Value = "White"}
                },
                Features = new List<Feature> {
                    new Feature{
                        ProductType = "Air Conditioning",
                        Count = 1,
                        Description = "Air Conditioning Type",
                        Class = new Class {
                            CategoryName = "Foobar",
                            Name = ""
                        },
                        //Measurements = new List<Measurement> {
                        //    new Measurement {
                        //        Name = "BTUS",
                        //        Value = "13,500",
                        //        NumericValue = 13500.00m,
                        //        Type = "BTUS"
                        //    }
                        //}
                    },
                    new Feature {
                        ProductType = "Engine",
                        Count = 1,
                        MarketingDescriptions = new List<MarketingDescription> {
                            new MarketingDescription {
                                Value = "",
                            }
                        }
                    }
                },
                //Engines = new List<Engine> {
                //    new Engine { DriveType = "Outboard", FuelType = "Gas", Horsepower = 115, ModelName = "115 ELPT 4S EFI CT", Make = "Mercury", ModelYear = 1999}
                //},
                MarketingDescriptions = new List<MarketingDescription> {
                    new MarketingDescription { CategoryName = "Air Conditioning", Name = "Air Conditioning Type", Value = "Automatic" },
                    new MarketingDescription { CategoryName = "Air Conditioning", Name = "Air Conditioning (BTUS)", Value = "13,500" },
                    new MarketingDescription { CategoryName = "Bathroom", Name = "Number of bathrooms", Value = "1" },
                    new MarketingDescription { CategoryName = "Bathroom", Name = "Bathroom Flooring Type", Value = "Vinyl" },
                    new MarketingDescription { CategoryName = "Bathroom", Name = "Bathroom Location", Value = "Center" },
                    new MarketingDescription { CategoryName = "Battery", Name = "Battery Powered Converter", Value = "True" },
                    new MarketingDescription { CategoryName = "Battery", Name = "Battery Converter Amps", Value = "55" },
                    new MarketingDescription { CategoryName = "Beds", Name = "Max Sleeping Count", Value = "6" },
                    new MarketingDescription { CategoryName = "Beds", Name = "Number of Queen Size Beds", Value = "2" },
                    new MarketingDescription { CategoryName = "Beds", Name = "Number of convertible/sofa beds", Value = "2" },
                    new MarketingDescription { CategoryName = "Brakes", Name = "Front Brake Type", Value = "Not applicable" },
                    new MarketingDescription { CategoryName = "Brakes", Name = "Rear Brake Type", Value = "Electric Drum" },
                    new MarketingDescription { CategoryName = "Construction", Name = "Body Material", Value = "Aluminum" },
                    new MarketingDescription { CategoryName = "Construction", Name = "Sidewall Construction", Value = "Fiberglass" },
                    new MarketingDescription { CategoryName = "Doors", Name = "Number of Doors", Value = "1" },
                },
                //Measurements = new List<Measurement> {
                //    new Measurement { CategoryName = "", Name = "Length", NumericValue = 29.17m, Type = "Feet", Value = "29.17ft"}
                //},
                //Options = new List<Option> {
                //    new Option { CategoryName = "Cockpit", Name = "Drink Holders", Value = "Stainless Steel drink holders" },
                //     new Option { CategoryName = "Cockpit", Name = "Lounge Seating", Value = "Forward lounge seating with electric hi-low table (converts to sun lounge)" }
                //},
                //Prices = new List<Price> {
                //    new Price { Type = "MSRP", Value = 18398.00m },
                //    new Price { Type = "Internet Price", Value = 17800.00m },
                //    new Price { Type = "Sales Price", Value = 17655.34m }
                //},
                //Weights = new List<Weight> {
                //    new Weight { CategoryName = "", Name = "Dry Weight", NumericValue=4850.00m, Type = "Pounds", Value = "4,850 lbs." },
                //}
            };

            return product;
        }       

        private Product GetSkipperBudProduct() {
            var product = new Product {
                DataType = DataType.Inventory,
                Designation = "New",
                Colors = new List<Color> {
                    new Color { Name = "Exterior Color", Value = "Black"},
                    new Color { Name = "Exterior Alternate Color", Value = "Red"},
                    new Color { Name = "Interior Accent", Value = "Kiwi Green"}
                },
                Class = new Class {
                    CategoryName = "???",
                    Value = "Class A"
                },
                ProductType = "Watersport",
                Condition = "Fresh from the factory",
                Description = "At just under 23 feet, this unique configuration delivers more room and more comfort.Its side console gives way to a roomy L - lounge in the bow, and additional seating for a total of up to 12 people.The aft section features Heyday's unique 'Hot Tub' seats-equally comfortable for aft viewing or forward cruising. It's the perfect combination of attitude and practicality.You're welcome!",
                Features = new List<Feature> {
                    new Feature {
                        ProductType = "Engine",
                        //Measurements = new List<Measurement> {
                        //    new Measurement {
                        //        CategoryName = "Performance",
                        //        Name = "",
                        //        Type = "Horsepower",
                        //        NumericValue = 350,
                        //        Descriptor = "350 HP"
                        //    }
                        //},
                        //Manufacturer = new Manufacturer {
                        //    Make = ""
                        //},
                        //Features = new List<Feature> {
                        //},
                        //Model = new Model {
                        //    Name = "",
                        //    Year = 2017
                        //},
                    },
                    new Feature {
                        ProductType = "Controls",
                        Description = "Billet Toggle Switches",
                    },
                    new Feature {
                        ProductType = "Interior",
                        Description = "Non-Skid Flooring"
                    },
                    new Feature {
                        ProductType = "Interior",
                        Description = "Pop-up Cleats"
                    },
                    new Feature {
                        ProductType = "Trailer",
                        Description = "Standard Trailer",
                        //IsOptional = true,
                        //Options = new List<Option> {
                        //    new Option {
                        //        CategoryName = "General Options",
                        //        Name = "",
                        //        Value = "Tandem Axle Trailer w/Brakes"
                        //    },
                        //}
                    },
                    new Feature {
                        ProductType = "Exterior",
                        Description = "Deck",
                        Colors = new List<Color> {
                            new Color {
                                Category = "",
                                Name = "",
                                Value = "Zeus Black"
                            }
                        },
                        MarketingDescriptions = new List<MarketingDescription> {
                            new MarketingDescription {
                                CategoryName = "??????",
                                Name = "Deck Upgrade"
                            }
                        }
                    },
                    new Feature {
                        ProductType = "Exterior",
                        Description = "Deluxe Travel Cover"
                    },
                    new Feature {
                        ProductType = "Exterior",
                        Description = "Elevator Plate"
                    },
                    new Feature {
                        ProductType = "Exterior",
                        Description = "Hull",
                        Colors = new List<Color> {
                            new Color {
                                Name = "Exterior Color",
                                Value = "Oxford Pure White"
                            }
                        }
                    }
                },
                Id = "[SkipperBud ID]",
                Identifiers = new List<Identifier> {
                    new Identifier {
                        Name = "Stock Number",
                        Value = "HD0047"
                    }
                },
                Location = new Location {
                    Addresses = new List<Address> {
                        new Address {
                            Description = "Actual Location",
                            City = "Round Lake",
                            Country = "USA",
                            PostalCode = "60073",
                            State = "IL",
                            Street1 = "31535 N US Highway 12",
                            Street2 = ""
                        }
                    },
                    Code = "Volo",
                    Phones = new List<Phone> {
                        new Phone {
                            AreaCode = "888",
                            Prefix = "334",
                            LineNumber = "6739",
                            Description = "SkipperBud's - Volo"
                        }
                    }
                },
                Manufacturer = new Manufacturer { Make = "Wake Boat WT-2" },
                //Measurements = new List<Measurement> {
                //    new Measurement {
                //        CategoryName = "Dimension",
                //        Name = "Beam Width",
                //        NumericValue = 8,
                //        Type = "Feet",
                //        Value = "8'0\""
                //    },
                //    new Measurement {
                //        CategoryName = "Dimension",
                //        Name = "Draft Depth",
                //        NumericValue = 31,
                //        Type = "Feet",
                //        Value = "31\""
                //    },
                //    new Measurement {
                //        CategoryName = "Dimension",
                //        Name = "Overall Length",
                //        NumericValue = 6.71m,
                //        Type = "Meters",
                //        Value = "22'0\"/6.71m"
                //    },
                //    new Measurement {
                //        CategoryName = "Capacity",
                //        Name = "Seating",
                //        Value = "12 Persons",
                //        NumericValue = 12
                //    },
                //    new Measurement {
                //        CategoryName = "Capacity",
                //        Name = "Fuel",
                //        Type = "Gallons",
                //        Value = "35 Gallons",
                //        NumericValue = 35
                //    },
                //},
                MediaContent = new List<Media> {
                    new Media {
                        SortOrder = 1,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/electronic_brochure/company80203/363674_p_t_640x480_image01.jpg"
                    },
                    new Media {
                        SortOrder = 2,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/electronic_brochure/company80203/363674_p_t_640x480_image02.jpg"
                    },
                    new Media {
                        SortOrder = 3,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/electronic_brochure/company80203/363674_p_t_640x480_image03.jpg"
                    },
                    new Media {
                        SortOrder = 4,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672560.jpg"
                    },
                    new Media {
                        SortOrder = 5,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672562.jpg"
                    },
                    new Media {
                        SortOrder = 6,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/electronic_brochure/company80203/363674_d_t_270x360_image01.jpg"
                    },
                    new Media {
                        SortOrder = 7,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672566.jpg"
                    },
                    new Media {
                        SortOrder = 8,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672568.jpg"
                    },
                    new Media {
                        SortOrder = 9,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672570.jpg"
                    },
                    new Media {
                        SortOrder = 10,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672572.jpg"
                    },
                    new Media {
                        SortOrder = 11,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = "http://cdn.channelblade.com/boat_graphics/dealers/2582/digi57672574.jpg"
                    },
                    new Media {
                        SortOrder = 12,
                        Name = "",
                        Category = "",
                        Description = "2017 HeyDay Wake Boat WT-2",
                        Type = "",
                        Url = ""
                    },
                },
                Model = new Model {
                    Name = "Heyday ",
                    // Year = 2018
                },
                //Options = new List<Option> {
                //    new Option {
                //        CategoryName = "General Options",
                //        Name = "",
                //        Value = "5.7 Crusader (350php)"
                //    },
                //    new Option {
                //        CategoryName = "General Options",
                //        Name = "",
                //        Value = "Accent Package"
                //    },
                //    new Option {
                //        CategoryName = "General Options",
                //        Name = "",
                //        Value = "Battery On/Off Disconnect Switch"
                //    }
                //},
                //Prices = new List<Price> {
                //    new Price {
                //        Type = "Contact Dealer",
                //        Value = 0.00m
                //    }
                //},
                //Specifications = new List<Specification> {
                //    new Specification {
                //        CategoryName = "",
                //        Name = "Hours",
                //        Value = "0"
                //    }
                //},
                //Status = "In Stock",               
                //Weights = new List<Weight> {
                //    new Weight {
                //        CategoryName = "Capacity",
                //        Name = "Ballast",
                //        NumericValue = 1800,
                //        Type = "Pounds",
                //        Value = "1,800 Pounds"
                //    },
                //    new Weight {
                //        CategoryName = "Dry Weight",
                //        Name = "Dry Weight",
                //        NumericValue = 3550,
                //        Type = "Pounds",
                //        Value = "3,550 Pounds"
                //    }
                //}
            };

            return product;
        }
    }
}