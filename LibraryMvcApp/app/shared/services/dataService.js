(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getAllData = function () {
                var deferred = $q.defer();
                $http.get('/Multimedia/Index').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addMultimedia = function (multimedia) {
                var deferred = $q.defer();
                var data = JSON.stringify(multimedia);
                //var obje = 'username=myusername';
                //var config = {
                //    headers: {
                //        'Content-Type': 'application/json'
                //    }
                //}

                console.log(
                    $http.post('/Multimedia/Create', { newMultimedia: JSON.stringify(multimedia) })
                .then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                }));;
                return deferred.promise;
            };


            return service;
        }]);
})();