app.controller('mainIndexController', function ($scope, $http, $state, $window, url) {
    $scope.test = 'this is main index'

    //$http({
    //        method: 'GET',
    //        url: 'http://localhost:3564/api/guest'
    //    }).then(function (data, status, headers, config) {
    //        for (d in data) {
    //            $scope.guests.push(data[d]);
    //        }
    //    }).catch(function onError(response) {
    //        alert('errrrrorrrr');
    //    })

    $scope.gotoCottages = function () {
        $window.open('http://www.oglebay-resort.com/cottagegeneral.html', '_self');
    }

})