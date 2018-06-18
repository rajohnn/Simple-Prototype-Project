Declare("inventory", {
    serverModel: null,
    model: null,

    init: function () {
        if (inventory.serverModel) {
            inventory.model = ko.observable(
                ko.mapping.fromJS(inventory.serverModel));
        };        
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

});

//$(document).on('click', '.panel-heading span.clickable', function (e) {
//    var $this = $(this);
//    if (!$this.hasClass('panel-collapsed')) {
//        $this.parents('.panel').find('.panel-body').slideUp();
//        $this.addClass('panel-collapsed');
//        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
//    } else {
//        $this.parents('.panel').find('.panel-body').slideDown();
//        $this.removeClass('panel-collapsed');
//        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
//    }
//})