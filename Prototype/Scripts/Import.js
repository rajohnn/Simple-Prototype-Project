Declare("testImport", {
    serverModel: null,
    model: null,

    init: function () {
        if (testImport.serverModel) {
            testImport.model = ko.observable(
                ko.mapping.fromJS(testImport.serverModel));
        };
        testImport.model().SelectedMappingOption.subscribe(function (item) {
            testImport.hideViews(); 
            var model = testImport.model();
            if (item) {
                $.blockUI();
                switch (item) {
                    case 1:
                        model.ShowFeature(true);
                        break;
                    case 2:
                        model.ShowIdentifiers(true);
                        break;
                    case 3:
                        model.ShowSpecification(true);
                        break;
                    case 4:
                        model.ShowClass(true);
                        testImport.createCurrentMapOptions(model.SelectedColumn());
                        break;
                    case 5:
                        model.ShowPrice(true);
                        break;
                    case 6:
                        model.ShowColor(true);
                        break;
                    case 7:
                        model.ShowMarketingDetail(true);
                        break;
                    case 8:
                        model.ShowActivity(true);
                        break;
                    case 9:
                        model.ShowDesignation(true);
                        break;
                    case 10:
                        model.ShowModel(true);
                        break;
                    case 11:
                        model.ShowSubModel(true);
                        break;
                    case 12:
                        model.ShowMake(true);
                        break;
                    case 13:
                        model.ShowCondition(true);
                        break;
                    case 14:
                        model.ShowQuantity(true);
                        break;
                    case 15:
                        model.ShowMedia(true);
                        break;
                    case 16:
                        model.ShowStatus(true);
                    default:
                        console.log("What r u doing?");
                        break;
                }
            }
            $.unblockUI();
        });

        testImport.model().SelectedColumn.subscribe(function (item) {
            
            var model = testImport.model();
            var record = _.find(model.RowDetails(), function(item) {
                return item.Header() == model.SelectedColumn();
            });
            if (record) {
                model.CurrentName(record.Header());
                model.CurrentValue(record.Value());                
            }
            else {
                model.CurrentName("");
                model.CurrentValue("");
            }
            model.SelectedMappingOption(null);
           
        });
        ko.applyBindings(testImport.model);
    },
    mapClass() {
        var model = testImport.model();
        var selectedClassId = model.SelectedClass();
        var csvColumn = model.SelectedCsvOption();
        var valueName = $("#class-options option:selected").text();
        var classMap = {
            Id: selectedClassId,
            CsvColumn: csvColumn,
            ReferenceCodeId: selectedClassId,
            Value: valueName
        };
        model.ClassMaps.push(classMap);
    },
    hideViews() {
        var model = testImport.model();
        model.ShowFeature(false);
        model.ShowIdentifiers(false);
        model.ShowSpecification(false);
        model.ShowClass(false);
        model.ShowColor(false);
        model.ShowMarketingDetail(false);
        model.ShowActivity(false);
        model.ShowDesignation(false);
        model.ShowModel(false);
        model.ShowSubModel(false);
        model.ShowPrice(false);
        model.ShowMake(false);
        model.ShowCondition(false);
        model.ShowQuantity(false);
        model.ShowMedia(false);                        
    },
    createCurrentMapOptions(columnName) {
        var model = testImport.model();
        model.CurrentMappingOptions.removeAll();

        // Get unique values for the given column
        var uniques = _.unique(model.Products(), function (item) {
            return item[columnName]();
        });

        // now map those values to a selection list
        _.forEach(uniques, function (item) {
            model.CurrentMappingOptions.push(item[columnName]());
        });

        model.CurrentMappingOptions(model.CurrentMappingOptions().sort());
        console.log(model.CurrentMappingOptions());
    }
});