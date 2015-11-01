(function () {
    'use strict';

    function homeCtrl($scope, usersData) {
        var vm = this;

        usersData.getAllUsers()
        .then(function (data) {
            vm.users = data;
            console.log(vm.users);
        },
            function (error) {
                console.log(error);
            });
    }


    angular.module('UsersApp')
        .controller('HomeCtrl', ['$scope', 'usersData', homeCtrl]);



}())

