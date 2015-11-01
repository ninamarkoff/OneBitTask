(function () {
    'use strict';

    function usersData($http, $q, $routeParams, config) {
        var users = this;
        var options = {
            headers: {
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Headers": "Cache-Control, Pragma, Origin, Authorization, Content-Type, X-Requested-With",
                "Access-Control-Allow-Methods": "GET, PUT, POST"
            }
        };

        users.getAllUsers = function () {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'user/all')
            .success(function (response) {
                deferred.resolve(response);
            })
            .error(function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
        }

        users.getUserById = function (id) {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'user/getbyid/' + id, options)
            .success(function (response) {
                deferred.resolve(response);
            })
            .error(function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
        }

        users.updateUser = function (id) {
            var deferred = $q.defer();

            $http.put(config.apiUrl + "user/updateuser/" + id)
                .success(function (response) {
                    deferred.resolve(response);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        users.deleteUser = function (id) {
            var deferred = $q.defer();

            $http.delete(config.apiUrl + "user/deleteuser/" + id)
                .success(function (response) {
                    deferred.resolve(response);
                })
                .error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }

        return users;
    }

    angular.module('UsersApp')
        .factory('usersData', ['$http', '$q', '$routeParams', 'config', usersData]);
}())