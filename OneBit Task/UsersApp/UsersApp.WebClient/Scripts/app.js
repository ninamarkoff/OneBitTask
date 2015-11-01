(function() {
    'use strict';

    angular.module('UsersApp', ['ngRoute'])
        .config(function ($routeProvider) {
            var vm = 'VM';
            $routeProvider.when('/', {
                templateUrl: '../Views/home.html',
                controller: 'HomeCtrl',
                    controllerAs: vm,
                    title: 'Home'
                })
                .when('/getbyid/:id', {
                    templateUrl: '../Views/user-details.html',
                    controller : 'UserDetailsCtrl',
                    controllerAs: vm,
                    title: 'User Details'
                }).
                otherwise({
                    redirectTo: '/'
                });
        })
        .constant('config', {
            apiUrl: 'http://localhost:52350/'
        });
} ())