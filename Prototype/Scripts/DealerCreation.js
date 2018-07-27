Declare("dealer", {
    serverModel: null,
    model: null,

    init: function () {
        if (dealer.serverModel) {
            dealer.model = ko.observable(
                ko.mapping.fromJS(dealer.serverModel));
        };        
        ko.applyBindings(dealer.model);
    },

});