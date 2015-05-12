var Simulation = function () {
    $.connection.hub.logging = true;

    var hub = $.connection.simulation,
        entities = [],
        paper = Raphael(document.getElementById('left-container'), 500, 500),
        entityFactory = new EntityFactory();

    this.start = function (script) {
        paper.clear();

        $.connection.hub.start().done(function () {
            console.log('SignalR connected.');

            hub.server.run('tank', script).done(function (frames) {
                run(frames);
            });
        });
    };

    this.pause = function () {
        clearInterval(interval);
    };

    this.resume = function () {
        
    };

    function run(frames) {
        interval = setInterval(function () {
            if (frames.length === 0) {
                clearInterval(interval);
                return;
            }

            var frame = frames.shift();

            for (var i = 0; i < frame.ClientEvents.length; i++) {
                var event = frame.ClientEvents[i];

                console.log(event.EventName);

                switch (event.EventName) {
                    case 'log':
                        console.log(event.Message);

                        // TODO: log to visible console
                        break;

                    case 'entity-created':
                        var entity = entityFactory(event.EntityName, paper, event);

                        entities.push(entity)
                        break;

                    case 'entity-moved':
                        paper.forEach(function (el) {
                            if (el.data('id') == event.EntityId) {
                                el.animate({
                                    x: event.Position.X,
                                    y: event.Position.Y,
                                    transform: 'r' + event.Heading.Angle.Degrees
                                });
                            }
                        });
                        break;
                }
            }
        }, 10);
    }
}

var TankFactory = function (paper, event) {
    var tank = paper.rect(event.Position.X, event.Position.Y, 15, 15);

    tank.attr({ fill: "green" });
    tank.data('id', event.EntityId);

    return tank;
};