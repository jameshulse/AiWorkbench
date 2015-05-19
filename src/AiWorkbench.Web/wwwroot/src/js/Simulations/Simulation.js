var Simulation = function () {
    $.connection.hub.logging = true;

    var hub = $.connection.simulation,
        entities = [],
        paper = Raphael(document.getElementById('left-container'), 500, 500),
        entityFactory = new EntityFactory(),
        frames = [],
        running = false;

    hub.client.update = function(newFrames) {
        frames = frames.concat(newFrames);
    };

    entityFactory.register('Tank', TankFactory);

    this.start = function (script) {
        paper.clear();

        $.connection.hub.start().done(function () {
            console.log('SignalR connected.');

            hub.server.run('tank', script).done(function () {
                processFrames();
            });
        });
    };

    this.pause = function () {
        clearInterval(interval);
    };

    this.resume = function () {

    };

    function processFrames() {
        var lastTime,
            requiredElapsed = 1000 / 100; // desired interval is 10fps

        function loop(now) {
            if (!lastTime) {
                lastTime = now;
            }

            if (frames.length === 0) {
                window.requestAnimationFrame(loop);
                return;
            }

            var elapsed = now - lastTime;

            if (elapsed > requiredElapsed) {
                var nextFrame = frames.shift();

                if(!processNextFrame(nextFrame))
                    return;
            }

            window.requestAnimationFrame(loop);
        }

        window.requestAnimationFrame(loop);
    }

    function processNextFrame(frame) {
        for (var i = 0; i < frame.ClientEvents.length; i++) {
            var event = frame.ClientEvents[i];

            console.log(event.EventName);

            switch (event.EventName) {
                case 'end':
                    return false;

                case 'log':
                    console.log(event.Message);

                    // TODO: log to visible console
                    break;

                case 'entity-created':
                    var entity = entityFactory.create(event.EntityTypeName, paper, event);

                    entities.push(entity)
                    break;

                case 'entity-moved':
                    paper.forEach(function (el) {
                        if (el.data('id') == event.EntityId) {
                            el.animate({
                                x: event.Position.X,
                                y: event.Position.Y,
                                transform: 'r' + event.Heading.Degrees
                            });
                        }
                    });
                    break;
            }
        }

        return true;
    }
}

var TankFactory = function (paper, event) {
    paper.setStart();

    paper.rect(event.Position.X, event.Position.Y, 30, 30);
    paper.rect(event.Position.X + 30, event.Position.Y + 12, 15, 6);

    tank = paper.setFinish();

    tank.attr({ fill: "green" });
    tank.data('id', event.EntityId);

    return tank;
};