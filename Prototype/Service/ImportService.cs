﻿using L5.DomainModel;
using Prototype.Domain;
using Prototype.Domain.Repository;
using Prototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototype.Service {

    public class ImportService {

        public ImportViewModel GetImportViewModel(string path) {
            var repo = new ImportRepository(path);

            var vm = new ImportViewModel {
                Headers = repo.Headers,
                Products = repo.Products.ToList(),
            };
            vm.RowDetails = GetRowDetails(vm.Headers, vm.Products);
            var list = new List<MappingOption> {
                new MappingOption { Id = 1, Name = "Feature" },
                new MappingOption { Id = 2, Name = "Identifers" },
                new MappingOption { Id = 3, Name = "Specification" },
                new MappingOption { Id = 4, Name = "Class" },
                new MappingOption { Id = 5, Name = "Price" },
                new MappingOption { Id = 6, Name = "Color" },
                new MappingOption { Id = 7, Name = "Marketing Detail" },
                new MappingOption { Id = 8, Name = "Activity" },
                new MappingOption { Id = 9, Name = "Designation" },
                new MappingOption { Id = 10, Name = "Model" },
                new MappingOption { Id = 11, Name = "Sub Model" },
                new MappingOption { Id = 12, Name = "Make" },
                new MappingOption { Id = 13, Name = "Condition" },
                new MappingOption { Id = 14, Name = "Quantity" },
                new MappingOption { Id = 15, Name = "Media" },
                new MappingOption { Id = 16, Name = "Status" }
            };
            vm.MappingOptions = list.OrderBy(l => l.Name).ToList();
            using (var ctx = new PrototypeContext()) {
                var mRepo = new ProximityMappingRepository(ctx);
                vm.Industries = mRepo.GetIndustries();
                vm.ReferenceCodes = mRepo.GetReferenceCodes();
            }
            vm.SelectedIndustry = 2;

            vm.ActivityTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Activity"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.ClassTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Class"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.ColorTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Color"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.Designations = vm.ReferenceCodes.Where(rc => rc.Name == "Designation"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.PriceTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Price"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.SpecificationTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Specification"
                && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.StatusTypes = vm.ReferenceCodes.Where(rc => rc.Name == "Status"
               && rc.IndustryId == vm.SelectedIndustry).ToList();
            vm.UnitTypes = vm.ReferenceCodes.Where(rc => rc.Name == "UnitType"
               && rc.IndustryId == vm.SelectedIndustry).ToList();

            return vm;
        }

        private List<RowDetail> GetRowDetails(List<string> headers, List<DixieProduct> products) {
            var list = new List<RowDetail>();
            var product = products[0];
            foreach (var h in headers) {
                var detail = new RowDetail();
                detail.Header = h;
                try {
                    detail.Value = product.GetType().GetProperty(h).GetValue(product, null).ToString();
                }
                catch (NullReferenceException) { }

                list.Add(detail);
            }
            return list;
        }
    }
}