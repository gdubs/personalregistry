"use strict";

app.controller('rsvpController', function ($scope, $http, $state, $stateParams, url) {
    $scope.guests = [];
    $scope.guestSearch = { firstName: '', lastName: '' }
    $scope.selectedGuest = {};
    $scope.message = { type: null, message: ''};
    $scope.rootUrl = url;
    $scope.searched = false;
    $scope.responding = true;

    if (!$stateParams.results) {
        $scope.guests = [];
    }

    $scope.findByCode = function (code) {
       /* $http({
            method: 'GET',
            url: 'http://localhost:3564/api/guest/GetByCode'
        }).then(function (data, status, headers, config) {
            for (d in data) {
                $scope.guests.push(data[d]);
            }
        }).catch(function onError(response) {
            alert('errrrrorrrr');
        })*/

        $scope.guests.push({ id: 1, firstName: 'Test Guest', lastName: 'Guest', rsvp: true })
        $scope.guests.push({ id: 1, firstName: 'Not!!', lastName: 'Guest', rsvp: false })
        //$state.go('main.rsvp.result', { results: $scope.guests })
    }

    $scope.findByName = function (valid) {
        if (!valid)
            return;

        $http({
            method: 'GET',
            url: $scope.rootUrl + '/api/guest/GetByName',
            params: {
                firstName: $scope.guestSearch.firstName,
                lastName: $scope.guestSearch.lastName
            }
        }).then(function (data, status, headers, config) {
            $scope.guests = [];
            for (let d = 0; d < data.data.length; d++) {
                let newGuest = {
                    id: data.data[d].Id,
                    firstName: data.data[d].FirstName,
                    lastName: data.data[d].LastName,
                    additionalGuest: data.data[d].AdditionalGuest,
                    confirmedGuests: data.data[d].ConfirmedGuests,
                    note: data.data[d].Note,
                    rsvp: !data.data[d].RSVPDate ? false : true,
                    attending: data.data[d].Attending
                }
                $scope.guests.push(newGuest);
            }
            $scope.searched = true;
        }).catch(function onError(response) {
            $scope.message.type = 'error';
            $scope.message.message = response.data;
        })
    }

    $scope.selectGuest = function (guest) {
        $scope.guests = [];
        $scope.selectedGuest = guest;
        $scope.searched = false;
    }

    $scope.rsvp = function () {

        $scope.selectedGuest.confirmedGuests = ($scope.selectedGuest.attending) ? $scope.selectedGuest.confirmedGuests : 0;
        $http({
            method: 'POST',
            url: $scope.rootUrl + '/api/guest',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            data: $.param({
                Id: $scope.selectedGuest.id,
                ConfirmedGuests: $scope.selectedGuest.confirmedGuests,
                Attending: $scope.selectedGuest.attending,
                Note: $scope.selectedGuest.note
            })
        }).then(function (data, status, headers, config) {
            if(data){
                // success message
                $scope.resetResults();
                
            }
            $scope.message.type = 'success';
            $scope.message.message = 'Thank you for submitting your RSVP. If you have any questions please send us a message at info@myweddingregistry.com';
        }).catch(function onError(response) {
            $scope.message.type = 'error';
            $scope.message.message = response.data;
        })
    }
    $scope.addPlusOne = function () {
    }

    $scope.resetResults = function () {
        $scope.guests = [];
        $scope.guestSearch = { firstName: '', lastName: '' };
        $scope.selectedGuest = {};
        $scope.searched = false;
    }

    $scope.clearErrorMessage = function () {
        $scope.message.type = null;
        $scope.message.message = '';
    }
})