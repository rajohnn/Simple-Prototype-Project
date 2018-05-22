using L5.DomainModel.Inventory;
using Microsoft.AspNet.Identity.EntityFramework;
using Prototype.Domain;
using Prototype.Domain.Dealership;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace L5.DomainModel {

    public class PrototypeContext : IdentityDbContext<ApplicationUser> {

        public PrototypeContext() : base("name=PrototypeContext", throwIfV1Schema: false) {
        }

        public static PrototypeContext Create() {
            return new PrototypeContext();
        }

        public virtual DbSet<MediaAsset> MediaAssets { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<ProductData> DataFeatures { get; set; }
        public virtual DbSet<Location> Locations { get; set; }       
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<ReferenceCode> ReferenceCodes { get; set; }
        public virtual DbSet<ReferenceCodeType> ReferenceCodeTypes { get; set; }
        public virtual DbSet<StandardFeature> StandardFeatures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<AttributeConfiguration> AttributeConfigurations { get; set; }
        public virtual DbSet<CustomAttribute> CustomAttributes { get; set; }
        public virtual DbSet<FeatureConfiguration> FeatureConfigurations { get; set; }
        public virtual DbSet<CustomFeature> CustomFeatures { get; set; }
        public virtual DbSet<MediaAssetConfiguration> MediaAssetConfigurations { get; set; }
        public virtual DbSet<CustomMediaAsset> CustomMediaAssets { get; set; }
        public virtual DbSet<PackageConfiguration> PackageConfigurations { get; set; }
        public virtual DbSet<CustomPackage> CustomPackages { get; set; }
        public virtual DbSet<PartConfiguration> PartConfigurations { get; set; }
        public virtual DbSet<CustomPart> CustomParts { get; set; }
        public virtual DbSet<StandardFeatureConfiguration> StandardFeatureConfigurations { get; set; }
        public virtual DbSet<CustomFeatureConfiguration> CustomFeatureConfigurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
        }
    }
}