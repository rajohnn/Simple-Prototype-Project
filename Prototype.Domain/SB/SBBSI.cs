using System.Collections.Generic;

namespace Prototype.Domain.SB {

    public class SBBSI {
        public string Location { get; set; }
        public string CurrentPhysicalLocation { get; set; }
        public string Status { get; set; }
        public int? Type { get; set; }
        public string UnknownProperty { get; set; }
        public string BoatMake { get; set; }
        public string BoatSerial { get; set; }
        public string StockNumber { get; set; }
        public string BoatModel { get; set; }
        public int? BoatYear { get; set; }
        public string BoatPrice { get; set; }
        public string BoatColor { get; set; }
        public int EngineCount { get; set; }
        public int? EnginesHP { get; set; }
        public string EngineMake { get; set; }
        public string EngineModel { get; set; }
        public int? EngineYear { get; set; }
        public string BoatLength { get; set; }
        public string CurrentlyUnused { get; set; }
        public string BoatModelType { get; set; }
        public List<SBBSIO> BoatOptions { get; set; } = new List<SBBSIO>();
    }

    public class SBBSIO {
        // |StockNumber|BoatStatus|BoatOptionType|BoatOptionNumber|BoatOptionDescription
        public string StockNumber { get; set; }
        public string BoatStatus { get; set; }
        public string BoatOptionType { get; set; }
        public string BoatOptionNumber { get; set; }
        public string BoatOptionDescription { get; set; }
    }
}