var EntityFactory = function() {
    var registrations = [];

    this.register = function(name, factoryMethod) {
        registrations[name] = factorMethod;
    };

    this.create = function(name, paper, event) {
        return registrations[name](paper, event);
};