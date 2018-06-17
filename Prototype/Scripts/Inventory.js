Declare("inventory", {
    serverModel: null,
    model: null,

    init: function () {
        if (inventory.serverModel) {
            inventory.model = ko.observable(
                ko.mapping.fromJS(inventory.serverModel));
        };
    }
});