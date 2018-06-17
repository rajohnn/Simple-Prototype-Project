using Prototype.Domain.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prototype.Domain.Repository {

    public class InventoryRepository : BaseRepository {
        public InventoryRepository(string connectionString) : base(connectionString) { }

        public async Task<InventoryProduct> GetProduct(int id) {
            string sql = "select * FROM Invt.Products where ProductId = " + id;
            return await _ctx.Database.SqlQuery<InventoryProduct>(sql).SingleOrDefaultAsync();
        }

        public async Task<List<InventoryFeature>> GetFeatures(int productId) {
            string sql = "select * FROM Invt.Features where ProductId = " + productId;
            return await _ctx.Database.SqlQuery<InventoryFeature>(sql).ToListAsync();
        }
    }
}