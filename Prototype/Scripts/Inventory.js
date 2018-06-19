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
        if (model.ProductDetailsModel.Id() == navigationItem.Id()) {
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
    findFeature: function (features, navigationItem) { 
        var list = [];
        getFeatures(features);
        var result = _.find(list, function (item) {
            if (item.Id() == navigationItem.Id()) {
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
    }
});