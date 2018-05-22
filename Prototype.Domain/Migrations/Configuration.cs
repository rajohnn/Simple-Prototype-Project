namespace Prototype.Domain.Migrations {

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<L5.DomainModel.PrototypeContext> {

        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(L5.DomainModel.PrototypeContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}