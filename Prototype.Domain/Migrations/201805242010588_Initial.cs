namespace Prototype.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttributeConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributeId = c.Int(),
                        CustomDescription = c.String(),
                        IsVisible = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attribute", t => t.AttributeId)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.Attribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(),
                        Name = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        DisplayValue = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feature", t => t.FeatureId)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        PackageId = c.Int(),
                        Name = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Package", t => t.PackageId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        Code = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceTypeId = c.Int(),
                        Name = c.String(),
                        Value = c.Decimal(precision: 18, scale: 2),
                        SuggestedValue = c.Decimal(precision: 18, scale: 2),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Package_Id = c.Int(),
                        Product_Id = c.Int(),
                        ProductData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceType", t => t.PriceTypeId)
                .ForeignKey("dbo.Package", t => t.Package_Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.ProductData", t => t.ProductData_Id)
                .Index(t => t.PriceTypeId)
                .Index(t => t.Package_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductData_Id);
            
            CreateTable(
                "dbo.PriceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockNumber = c.String(),
                        Year = c.Int(),
                        ProductTypeId = c.Int(),
                        Make = c.String(),
                        Model = c.String(),
                        Name = c.String(maxLength: 100),
                        DisplayName = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferenceCode", t => t.ProductTypeId)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.MediaAsset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaAssetTypeId = c.Int(),
                        Description = c.String(),
                        Url = c.String(maxLength: 400),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Product_Id = c.Int(),
                        ProductData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferenceCode", t => t.MediaAssetTypeId)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.ProductData", t => t.ProductData_Id)
                .Index(t => t.MediaAssetTypeId)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductData_Id);
            
            CreateTable(
                "dbo.ReferenceCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        ReferenceCodeTypeId = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CustomPackage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferenceCodeType", t => t.ReferenceCodeTypeId)
                .ForeignKey("dbo.CustomPackage", t => t.CustomPackage_Id)
                .Index(t => t.ReferenceCodeTypeId)
                .Index(t => t.CustomPackage_Id);
            
            CreateTable(
                "dbo.ReferenceCodeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Identifiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.CustomAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        DisplayValue = c.String(maxLength: 100),
                        IsLocked = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CustomFeature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomFeature", t => t.CustomFeature_Id)
                .Index(t => t.CustomFeature_Id);
            
            CreateTable(
                "dbo.CustomFeatureConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        PackageId = c.Int(),
                        Name = c.String(maxLength: 100),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Package", t => t.PackageId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.CustomMediaAsset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaAssetTypeId = c.Int(),
                        Url = c.String(maxLength: 400),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomReferenceCode", t => t.MediaAssetTypeId)
                .Index(t => t.MediaAssetTypeId);
            
            CreateTable(
                "dbo.CustomReferenceCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        ReferenceCodeTypeId = c.Int(nullable: false),
                        IsVisibleToUser = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferenceCodeType", t => t.ReferenceCodeTypeId)
                .Index(t => t.ReferenceCodeTypeId);
            
            CreateTable(
                "dbo.CustomPackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        Code = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.CustomPart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        DataType = c.String(maxLength: 30),
                        Name = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        SalesStatus = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        DataType = c.String(maxLength: 30),
                        Name = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        ProductData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.ProductData", t => t.ProductData_Id)
                .Index(t => t.ProductId)
                .Index(t => t.ProductData_Id);
            
            CreateTable(
                "dbo.StandardFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        ExternalMasterId = c.String(maxLength: 100),
                        IsFromDatabase = c.Boolean(nullable: false),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        ProductData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductData", t => t.ProductData_Id)
                .Index(t => t.ProductData_Id);
            
            CreateTable(
                "dbo.FeatureConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(),
                        CustomName = c.String(),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feature", t => t.FeatureId)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        DisplayName = c.String(maxLength: 100),
                        DataPartitionId = c.Int(),
                        AllowsInventory = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .ForeignKey("dbo.DataPartition", t => t.DataPartitionId)
                .Index(t => t.DataPartitionId)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressTypeId = c.Int(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReferenceCode", t => t.AddressTypeId)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.AddressTypeId)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.DataPartition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Subdomain = c.String(maxLength: 100),
                        ReasonForDeletion = c.String(maxLength: 200),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MediaAssetConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaAssetId = c.Int(),
                        Description = c.String(),
                        IsVisible = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MediaAsset", t => t.MediaAssetId)
                .Index(t => t.MediaAssetId);
            
            CreateTable(
                "dbo.PackageConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(),
                        Code = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Package", t => t.PackageId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.PartConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartId = c.Int(),
                        DataType = c.String(maxLength: 30),
                        Name = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Part", t => t.PartId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StandardFeatureConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardFeatureId = c.Int(),
                        Description = c.String(maxLength: 250),
                        LocationId = c.Int(nullable: false),
                        DataPartitionId = c.Int(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        LockCreatedOn = c.DateTimeOffset(precision: 7),
                        LockedBy = c.String(),
                        DateCreated = c.DateTimeOffset(precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        LastModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StandardFeature", t => t.StandardFeatureId)
                .Index(t => t.StandardFeatureId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DataPartitionId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        IsTempPassword = c.Boolean(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(nullable: false, precision: 7),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataPartition", t => t.DataPartitionId)
                .Index(t => t.DataPartitionId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DataPartitionId", "dbo.DataPartition");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StandardFeatureConfiguration", "StandardFeatureId", "dbo.StandardFeature");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PartConfiguration", "PartId", "dbo.Part");
            DropForeignKey("dbo.PackageConfiguration", "PackageId", "dbo.Package");
            DropForeignKey("dbo.MediaAssetConfiguration", "MediaAssetId", "dbo.MediaAsset");
            DropForeignKey("dbo.Location", "DataPartitionId", "dbo.DataPartition");
            DropForeignKey("dbo.Location", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Address", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Address", "AddressTypeId", "dbo.ReferenceCode");
            DropForeignKey("dbo.FeatureConfiguration", "FeatureId", "dbo.Feature");
            DropForeignKey("dbo.StandardFeature", "ProductData_Id", "dbo.ProductData");
            DropForeignKey("dbo.ProductData", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Price", "ProductData_Id", "dbo.ProductData");
            DropForeignKey("dbo.Part", "ProductData_Id", "dbo.ProductData");
            DropForeignKey("dbo.Part", "ProductId", "dbo.Product");
            DropForeignKey("dbo.MediaAsset", "ProductData_Id", "dbo.ProductData");
            DropForeignKey("dbo.CustomPart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CustomPackage", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ReferenceCode", "CustomPackage_Id", "dbo.CustomPackage");
            DropForeignKey("dbo.CustomMediaAsset", "MediaAssetTypeId", "dbo.CustomReferenceCode");
            DropForeignKey("dbo.CustomReferenceCode", "ReferenceCodeTypeId", "dbo.ReferenceCodeType");
            DropForeignKey("dbo.CustomFeature", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CustomFeature", "PackageId", "dbo.Package");
            DropForeignKey("dbo.CustomAttribute", "CustomFeature_Id", "dbo.CustomFeature");
            DropForeignKey("dbo.AttributeConfiguration", "AttributeId", "dbo.Attribute");
            DropForeignKey("dbo.Feature", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Feature", "PackageId", "dbo.Package");
            DropForeignKey("dbo.Package", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ReferenceCode");
            DropForeignKey("dbo.Price", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Identifiers", "ProductId", "dbo.Product");
            DropForeignKey("dbo.MediaAsset", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.MediaAsset", "MediaAssetTypeId", "dbo.ReferenceCode");
            DropForeignKey("dbo.ReferenceCode", "ReferenceCodeTypeId", "dbo.ReferenceCodeType");
            DropForeignKey("dbo.Price", "Package_Id", "dbo.Package");
            DropForeignKey("dbo.Price", "PriceTypeId", "dbo.PriceType");
            DropForeignKey("dbo.Attribute", "FeatureId", "dbo.Feature");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "DataPartitionId" });
            DropIndex("dbo.StandardFeatureConfiguration", new[] { "StandardFeatureId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PartConfiguration", new[] { "PartId" });
            DropIndex("dbo.PackageConfiguration", new[] { "PackageId" });
            DropIndex("dbo.MediaAssetConfiguration", new[] { "MediaAssetId" });
            DropIndex("dbo.Address", new[] { "Location_Id" });
            DropIndex("dbo.Address", new[] { "AddressTypeId" });
            DropIndex("dbo.Location", new[] { "Location_Id" });
            DropIndex("dbo.Location", new[] { "DataPartitionId" });
            DropIndex("dbo.FeatureConfiguration", new[] { "FeatureId" });
            DropIndex("dbo.StandardFeature", new[] { "ProductData_Id" });
            DropIndex("dbo.Part", new[] { "ProductData_Id" });
            DropIndex("dbo.Part", new[] { "ProductId" });
            DropIndex("dbo.ProductData", new[] { "ProductId" });
            DropIndex("dbo.CustomPart", new[] { "ProductId" });
            DropIndex("dbo.CustomPackage", new[] { "ProductId" });
            DropIndex("dbo.CustomReferenceCode", new[] { "ReferenceCodeTypeId" });
            DropIndex("dbo.CustomMediaAsset", new[] { "MediaAssetTypeId" });
            DropIndex("dbo.CustomFeature", new[] { "PackageId" });
            DropIndex("dbo.CustomFeature", new[] { "ProductId" });
            DropIndex("dbo.CustomAttribute", new[] { "CustomFeature_Id" });
            DropIndex("dbo.Identifiers", new[] { "ProductId" });
            DropIndex("dbo.ReferenceCode", new[] { "CustomPackage_Id" });
            DropIndex("dbo.ReferenceCode", new[] { "ReferenceCodeTypeId" });
            DropIndex("dbo.MediaAsset", new[] { "ProductData_Id" });
            DropIndex("dbo.MediaAsset", new[] { "Product_Id" });
            DropIndex("dbo.MediaAsset", new[] { "MediaAssetTypeId" });
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropIndex("dbo.Price", new[] { "ProductData_Id" });
            DropIndex("dbo.Price", new[] { "Product_Id" });
            DropIndex("dbo.Price", new[] { "Package_Id" });
            DropIndex("dbo.Price", new[] { "PriceTypeId" });
            DropIndex("dbo.Package", new[] { "ProductId" });
            DropIndex("dbo.Feature", new[] { "PackageId" });
            DropIndex("dbo.Feature", new[] { "ProductId" });
            DropIndex("dbo.Attribute", new[] { "FeatureId" });
            DropIndex("dbo.AttributeConfiguration", new[] { "AttributeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StandardFeatureConfiguration");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PartConfiguration");
            DropTable("dbo.PackageConfiguration");
            DropTable("dbo.MediaAssetConfiguration");
            DropTable("dbo.DataPartition");
            DropTable("dbo.Address");
            DropTable("dbo.Location");
            DropTable("dbo.FeatureConfiguration");
            DropTable("dbo.StandardFeature");
            DropTable("dbo.Part");
            DropTable("dbo.ProductData");
            DropTable("dbo.CustomPart");
            DropTable("dbo.CustomPackage");
            DropTable("dbo.CustomReferenceCode");
            DropTable("dbo.CustomMediaAsset");
            DropTable("dbo.CustomFeature");
            DropTable("dbo.CustomFeatureConfiguration");
            DropTable("dbo.CustomAttribute");
            DropTable("dbo.Identifiers");
            DropTable("dbo.ReferenceCodeType");
            DropTable("dbo.ReferenceCode");
            DropTable("dbo.MediaAsset");
            DropTable("dbo.Product");
            DropTable("dbo.PriceType");
            DropTable("dbo.Price");
            DropTable("dbo.Package");
            DropTable("dbo.Feature");
            DropTable("dbo.Attribute");
            DropTable("dbo.AttributeConfiguration");
        }
    }
}
