using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Prototype.Domain.Repository {

    public class ImportRepository {
        public List<string> Headers { get; set; }
        public List<DixieProduct> Products { get; set; }

        string _path;
        CsvReader _reader;

        public ImportRepository(string path) {
            _path = path;
            Initialize();           
        }

        private void Initialize() {
            var list = new List<DixieProduct>();            
            var file = Path.Combine(_path, @"data\dixierv-tv2514-072618.csv");
            using (var reader = File.OpenText(file)) {
                _reader = new CsvReader(reader);
                _reader.Configuration.HasHeaderRecord = true;
                _reader.Configuration.MissingFieldFound = null;
                _reader.Read();                
                _reader.ReadHeader();
                Headers = new List<string>(_reader.Context.HeaderRecord);
                var records = _reader.GetRecords<DixieProduct>();
                Products = new List<DixieProduct>(records);
            }          

        }        
    }
}