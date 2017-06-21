app.controller('rsvpResultController', function ($scope, $http, $state, $stateParams) {
    $scope.results = [];

    if ($stateParams.results && $stateParams.results.length > 0) {
        $scope.results = $stateParams.results;
    }

    $scope.addPlusOne = function () {

    }

    $scope.resetResults = function () {
        $state.go('main.rsvp', { results: [] } )
    }
})