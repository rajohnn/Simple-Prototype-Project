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
            console.log(item);
            var model = testImport.model();
            if (item) {
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
        });
        ko.applyBindings(testImport.model);
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
    }
});