using L5.DomainModel;
using Prototype.Domain.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Prototype.Domain.Repository {

    public class ProximityMappingRepository {
        private readonly PrototypeContext _context;
        private static string _codeQuery = @"select R.Id, R.DataPartitionId,	R.ReferenceCodeTypeId,RCT.Name,R.IndustryId,R.Value 
            FROM ReferenceCodes R join ReferenceCodeTypes RCT on RCT.id = R.ReferenceCodeTypeId order by R.IndustryId, RCT.Name, R.Value";

        public ProximityMappingRepository(PrototypeContext context) {
            _context = context;
        }

        public List<Industry> GetIndustries() {
            return _context.Industries.ToList();
        }

        public List<ReferenceCodeModel> GetReferenceCodes() {
            return _context.Database.SqlQuery<ReferenceCodeModel>(_codeQuery).ToList();
        }
    }
}