(function () {
    'use strict';

    angular.module('aiwb').controller('WorkbenchCtrl', ['$scope', controller]);

    function controller($scope) {
        var vm = this;
        var sim = new Simulation();

        $scope.start = function () {
            sim.start($scope.script);
        };

        $scope.restart = function () {

        };

        $scope.pause = function () {

        };
    }
})();