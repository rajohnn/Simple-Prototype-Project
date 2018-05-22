using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class StandardFeature : InventoryEntity {

        [Column(TypeName = "NVARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }
    }

}