var app = angular.module('app', ['ui.router']);

app.config(['$urlRouterProvider', '$stateProvider', '$locationProvider',
    function ($urlRouterProvider, $stateProvider, $locationProvider) {

        var debug = false;
        var rootUrl = debug ? 'http://localhost:3564' : 'http://api.gabeandmandee.com';
        $stateProvider.state('main', {
            abstract: true,
            url: '/',
            templateUrl: 'scripts/app/main/mainTemplate.html',
            controller: 'mainController as mainCtrl',
            resolve: {
                url: function () {
                    return rootUrl;
                }
            }
        }).state('interest', {
            //parent: 'main',
            url: '/interest',
            templateUrl: 'scripts/app/interest/interestTemplate.html',
            controller: 'interestController as interestCtrl',
            resolve: {
                url: function () {
                    return rootUrl;
                }
            }
        }).state('main.index', {
            //parent: 'main',
            url: '',
            templateUrl: 'scripts/app/mainIndex/mainIndexTemplate.html',
            controller: 'mainIndexController as mainIndexCtrl',
            resolve: {
                url: function () {
                    return rootUrl;
                }
            }
        }).state('main.rsvp', {
            //parent: 'main',
            url: 'rsvp',
            templateUrl: 'scripts/app/rsvp/rsvpTemplate.html',
            controller: 'rsvpController as rsvpCtrl',
            resolve: {
                url: function () {
                    return rootUrl;
                }
            }
        }).state('main.rsvp.result', {
            //parent: 'main',
            url: 'result',
            templateUrl: 'scripts/app/rsvpResult/rsvpResultTemplate.html',
            controller: 'rsvpResultController as rsvpResultCtrl',
            params: {
                results: [],
                url: function () {
                    return rootUrl;
                }
            }
        }).state('main.registry', {
            //parent: 'main',
            url: 'registry',
            templateUrl: 'scripts/app/registry/registryTemplate.html',
            controller: 'registryController as registryCtrl',
            resolve: {
                url: function () {
                    return rootUrl;
                }
            }
        })

        
        $urlRouterProvider.otherwise('/');
        $locationProvider.hashPrefix('');
        $locationProvider.html5Mode(true);
}])