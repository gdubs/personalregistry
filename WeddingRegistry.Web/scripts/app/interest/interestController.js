app.controller('interestController', function ($scope, $http, $state) {
    $scope.message = { type: null, message: '' };
    $scope.email = '';
    $scope.notes = '';
    $scope.submitEmail = function () {
        $http({
            method: 'POST',
            url: 'http://api.gabeandmandee.com/api/interest',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            data: $.param({
                Email: $scope.email,
                Notes: $scope.notes
            })
        }).then(function (data, status, headers, config) {
            //if (data) {
                $scope.email = '';
                $scope.notes = '';
                $scope.message.type = 'success';
                $scope.message.message = 'Thank you for your interest!';
            //}
        }).catch(function onError(response) {
            $scope.message.type = 'error';
            $scope.message.message = response.data;
        })
    }
})