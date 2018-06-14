using Newtonsoft.Json;
using Prototype.Domain.Webhook;
using System.IO;

namespace Prototype.Domain.Repository {

    public class PayloadTestRepository {

        public DealerMessage GetTestPayload() {
            var path = Directory.GetCurrentDirectory();
            var file = Path.Combine(path, "data/payload.json");
            return JsonConvert.DeserializeObject<DealerMessage>(File.ReadAllText(file));
        }
    }
}