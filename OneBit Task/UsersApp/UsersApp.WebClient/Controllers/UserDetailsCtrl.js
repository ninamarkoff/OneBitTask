(function () {
    'use strict';

    function userDetailsCtrl($scope, $location, $routeParams, usersData) {
        var vm = this;

        usersData.getUserById($routeParams.id)
        .then(function (data) {
            vm.user = data;
            //console.log($routeParams.id);
        },
            function (error) {
                console.log(error);
            });

        vm.updateUser = function (id) {
            usersData.updateUser(id)
                .then(function (data) {
                    vm.user = data;

                }, function (error) {
                    console.log(error);
                });
        }

        vm.deleteUser = function (id) {
            usersData.deleteUser(id)
                .then(function() {
                    $location.path('/');
                }, function (error) {
                    console.log(error);
                });
        }
    }

    angular.module('UsersApp')
        .controller('UserDetailsCtrl', ['$scope', '$location', '$routeParams', 'usersData', userDetailsCtrl]);
}())