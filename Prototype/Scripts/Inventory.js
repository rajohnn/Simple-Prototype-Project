Declare("inventory", {
    serverModel: null,
    model: null,

    init: function () {
        if (inventory.serverModel) {
            inventory.model = ko.observable(
                ko.mapping.fromJS(inventory.serverModel));
        };
        inventory.model().CurrentProductDetailsModel = new ko.observable(inventory.model().ProductDetailsModel);
        ko.applyBindings(inventory.model);
    },
    toggleFeature: function () {
        var isExpanded = inventory.model().IsFeatureExpanded();
        console.log(isExpanded);
        inventory.model().IsFeatureExpanded(!isExpanded);
    },
    toggleSpecifications: function () {
        var isExpanded = inventory.model().IsSpecificationExpanded();
        console.log(isExpanded);
        inventory.model().IsSpecificationExpanded(!isExpanded);
    },
    togglePrices: function () {
        var isExpanded = inventory.model().IsPricesExpanded();
        console.log(isExpanded);
        inventory.model().IsPricesExpanded(!isExpanded);
    },
    toggleColors: function () {
        var isExpanded = inventory.model().IsColorsExpanded();
        console.log(isExpanded);
        inventory.model().IsColorsExpanded(!isExpanded);
    },
    toggleMarketingDetails: function () {
        var isExpanded = inventory.model().IsMarketingDetailsExpanded();
        console.log(isExpanded);
        inventory.model().IsMarketingDetailsExpanded(!isExpanded);
    },
    toggleActivities: function () {
        var isExpanded = inventory.model().IsActivitiesExpaneded();
        console.log(isExpanded);
        inventory.model().IsActivitiesExpaneded(!isExpanded);
    },
    onAddFeatureClicked: function () {
        inventory.model().IsFeatureExpanded(true);
    },
    onAddSpecificationClicked: function () {
        inventory.model().IsSpecificationExpanded(true);
        $("#spec-category").focus();
    },
    onAddActivityClicked: function () {
        inventory.model().IsActivitiesExpaneded(true);
        $("#activity-category").focus();
    },
    onAddPriceClicked: function () {
        inventory.model().IsPricesExpanded(true);
        $("#price-category").focus();
    },
    onAddColorClicked: function () {
        inventory.model().IsColorsExpanded(true);
        $("#color-category").focus();
    },
    onAddMarketingDetailClicked: function () {
        inventory.model().IsMarketingDetailsExpanded(true);
        $("#marketing-category").focus();
    },
    onNavigationClicked: function (navigationItem) {
        console.log(navigationItem.Id() + " : " + navigationItem.DisplayName());
        var model = inventory.model();
        if (model.ProductDetailsModel.Id() === navigationItem.Id()) {
            model.CurrentProductDetailsModel(model.ProductDetailsModel);
            inventory.updateNavigation(model.ProductDetailsModel);
        }
        else {
            // find the feature we clicked on
            var features = inventory.model().ProductDetailsModel.Features();
            var feature = inventory.findFeature(features, navigationItem);
            model.CurrentProductDetailsModel(feature);
            inventory.updateNavigation(feature);
        }
    },
    onFeatureClicked: function (feature) {
        var model = inventory.model();
        inventory.updateNavigation(feature);
        model.CurrentProductDetailsModel(feature);
    },
    onSpecificationClicked: function (selectedSpec) {
        inventory.model().IsSpecificationExpanded(true);

        $("#save-spec").text("Update Specification");
        var model = inventory.model();
        var spec = model.NewSpecification;
        model.SelectedSpecificationType(selectedSpec.Category.Id());
        model.SelectedUnitType(selectedSpec.UnitType.Id());
        spec.Id(selectedSpec.Id());
        spec.Name(selectedSpec.Name());
        spec.Amount(selectedSpec.Amount());
        spec.Value(selectedSpec.Value());
        $("#spec-category").focus();
    },
    clearSpecification: function () {
        var model = inventory.model();
        model.NewSpecification.Name("");
        model.NewSpecification.Amount("");
        model.NewSpecification.Value("");
        model.NewSpecification.Category(null);
        model.NewSpecification.UnitType(null);
        model.SelectedSpecificationType(null);
        model.SelectedUnitType(null);
        $("#save-spec").text("Save Specification");
        inventory.model().IsSpecificationExpanded(false);
    },
    onClearSpecificationClicked: function () {
        inventory.clearSpecification();
    },
    onSaveSpecificationClicked: function () {
        var model = inventory.model();
        var amount = model.NewSpecification.Amount();

        if ($.isNumeric(amount)) {
            var functionText = $("#save-spec").text();
            var specType = model.SelectedSpecificationType();
            var unitType = model.SelectedUnitType();

            var type = _.find(model.SpecificationTypes(), function (item) {
                return item.Id() === specType;
            });

            var unit = _.find(model.UnitTypes(), function (item) {
                return item.Id() === unitType;
            });

            var name = model.NewSpecification.Name();
            var value = model.NewSpecification.Value();

            var newItem = {
                Category: {
                    Id: type.Id,
                    Name: type.Name
                },
                UnitType: {
                    Id: unit.Id,
                    Name: unit.Name
                },
                Name: new ko.observable(name),
                Amount: new ko.observable(amount),
                Value: new ko.observable(value)
            };

            if (functionText === "Save Specification") {
                // model.ProductDetailsModel.Specifications.unshift(newItem);
                newItem.Id = new ko.observable(inventory.createId());
                model.CurrentProductDetailsModel().Specifications.unshift(newItem);
            }
            else {
                var existingItem = _.find(model.CurrentProductDetailsModel().Specifications(), function (item) {
                    return item.Id() === model.NewSpecification.Id();
                });
                existingItem.Name(newItem.Name());
                existingItem.Amount(newItem.Amount());
                existingItem.Value(newItem.Value());
                existingItem.Category = newItem.Category;
                existingItem.UnitType = newItem.UnitType;
            }
            inventory.clearSpecification();
        }
    },

    onPriceClicked: function (selectedPrice) {
        inventory.model().IsPricesExpanded(true);

        $("#save-price").text("Update Price");
        var model = inventory.model();
        var spec = model.NewPrice;
        model.SelectedPriceType(selectedPrice.Category.Id());
        spec.Id(selectedPrice.Id());
        spec.Amount(selectedPrice.Amount());
        spec.DisplayValue(selectedPrice.DisplayValue());
        $("#price-category").focus();
    },
    clearPrice: function () {
        var model = inventory.model();
        model.NewPrice.Amount("");
        model.NewPrice.DisplayValue("");
        model.NewPrice.Category(null);
        model.SelectedPriceType(null);
        $("#save-price").text("Save Price");
        inventory.model().IsPricesExpanded(false);
    },
    onClearPriceClicked: function () {
        inventory.clearPrice();
    },
    onSavePriceClicked: function () {
        var model = inventory.model();
        var amount = model.NewPrice.Amount();

        if ($.isNumeric(amount)) {
            var functionText = $("#save-price").text();
            var typeId = model.SelectedPriceType();

            var type = _.find(model.PriceTypes(), function (item) {
                return item.Id() === typeId;
            });

            var displayValue = model.NewPrice.DisplayValue();
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'USD',
                minimumFractionDigits: 2
            });

            var formatted = formatter.format(amount);

            var newItem = {
                Category: {
                    Id: type.Id,
                    Name: type.Name
                },
                Amount: new ko.observable(amount),
                DisplayValue: new ko.observable(displayValue),
                FormattedAmount: new ko.observable(formatted)
            };

            if (functionText === "Save Price") {
                newItem.Id = new ko.observable(inventory.createId());
                model.CurrentProductDetailsModel().Prices.unshift(newItem);
            }
            else {
                var existingItem = _.find(model.CurrentProductDetailsModel().Prices(), function (item) {
                    return item.Id() === model.NewPrice.Id();
                });
                existingItem.Amount(newItem.Amount());
                existingItem.DisplayValue(newItem.DisplayValue());
                existingItem.Category = newItem.Category;
                existingItem.FormattedAmount(newItem.FormattedAmount());
            }
            inventory.clearPrice();
        }
    },

    onColorClicked: function (selectedColor) {
        inventory.model().IsColorsExpanded(true);
        $("#save-color").text("Update Color");
        var model = inventory.model();
        var color = model.NewColor;
        model.SelectedColorType(selectedColor.Category.Id());
        color.Id(selectedColor.Id());
        color.Name(selectedColor.Name());
        color.Value(selectedColor.Value());
        $("#color-category").focus();
    },
    clearColor: function () {
        var model = inventory.model();
        model.NewColor.Name("");
        model.NewColor.Value("");
        model.NewPrice.Category(null);
        model.SelectedColorType(null);
        $("#save-color").text("Save Color");
        inventory.model().IsColorsExpanded(false);
    },
    onClearColorClicked: function () {
        inventory.clearColor();
    },
    onSaveColorClicked: function () {
        var model = inventory.model();
        var functionText = $("#save-color").text();
        var typeId = model.SelectedColorType();
        var name = model.NewColor;
        var type = _.find(model.ColorTypes(), function (item) {
            return item.Id() === typeId;
        });

        var value = model.NewPrice.Value;       

        var newItem = {
            Category: {
                Id: type.Id,
                Name: type.Name
            },
            Name: new ko.observable(model.NewColor.Name()),
            Value: new ko.observable(model.NewColor.Value())
        };

        if (functionText === "Save Color") {
            newItem.Id = new ko.observable(inventory.createId());
            model.CurrentProductDetailsModel().Colors.unshift(newItem);
        }
        else {
            var existingItem = _.find(model.CurrentProductDetailsModel().Colors(), function (item) {
                return item.Id() === model.NewColor.Id();
            });            
            existingItem.Name(newItem.Name());
            existingItem.Category = newItem.Category;
            existingItem.Value(newItem.Value());
        }
        inventory.clearColor();
    },

    findFeature: function (features, navigationItem) {
        var list = [];
        getFeatures(features);
        var result = _.find(list, function (item) {
            if (item.Id() === navigationItem.Id()) {
                console.log("found!");
                return item;
            }
        });
        function getFeatures(features) {
            _.forEach(features, function (item) {
                list.push(item);
                if (item.Features().length > 0) {
                    getFeatures(item.Features());
                }
            });
        }
        return result;
    },
    updateNavigation: function (feature) {
        var model = inventory.model();
        model.NavigationItems.removeAll();
        _.forEach(feature.NavigationItems(), function (item) {
            model.NavigationItems.push(item);
        });
    },
    createId: function () {
        return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
        )
    },
});