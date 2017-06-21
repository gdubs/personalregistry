app.controller('mainController', function ($scope, $http, $state, url) {
    $scope.guests = ['ang test', 'ang test uli'];
    $scope.activeTab = $state.current.url;
    
    $scope.gotoRsvp = function () {
        $state.go('main.rsvp', {})
        $scope.activeTab = 'rsvp';
    }

    $scope.gotoRegistry = function () {
        $state.go('main.registry', {})
        $scope.activeTab = 'registry';
    }

    $scope.gotoMainIndex = function () {
        $state.go('main.index', {})
        $scope.activeTab = '';
    }
    
})