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

            service.getMultimediaById = function (id, className) {                
                var deferred = $q.defer();
                $http.post('/Multimedia/Details', { id: id, className: className }).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addMultimedia = function (multimedia, coverPhoto) {
                var deferred = $q.defer();

                if (coverPhoto == null)
                {
                    $http.post('/Multimedia/Create', { newMultimedia: JSON.stringify(multimedia) })
                        .then(function () {
                            deferred.resolve();
                        }, function () {
                            deferred.reject();
                        })                        
                    return deferred.promise;
                }
                else
                {
                    this.UploadFile(coverPhoto).then(function (returnedData) {
                        if (returnedData.data.Status && returnedData.data.FileName != null) {
                            multimedia.CoverPhoto = returnedData.data.FileName;

                            $http.post('/Multimedia/Create', { newMultimedia: JSON.stringify(multimedia) })
                                .then(function () {
                                    deferred.resolve();
                                }, function () {
                                    deferred.reject();
                                })
                        }
                        else {
                            //write cannot create
                        }
                    })
                    
                    return deferred.promise;
                }
               
            };

            service.editMultimedia = function (multimedia, coverPhoto) {

                var deferred = $q.defer();

                if (coverPhoto == null) {
                    $http.post('/Multimedia/Edit', { updatedMultimedia: JSON.stringify(multimedia) }).then(function () {
                        deferred.resolve();
                    }, function () {
                        deferred.reject();
                    });
                    return deferred.promise;
                }
                else {
                    this.DeleteFile(multimedia.MultimediaID, multimedia.ClassName).then( this.UploadFile(coverPhoto).then(function (returnedData) {
                        if (returnedData.data.Status && returnedData.data.FileName != null) {
                            multimedia.CoverPhoto = returnedData.data.FileName;

                            $http.post('/Multimedia/Edit', { updatedMultimedia: JSON.stringify(multimedia) })
                                .then(function () {
                                    deferred.resolve();
                                }, function () {
                                    deferred.reject();
                                })
                        }
                    }))

                    return deferred.promise;
                }               
            };

            service.deleteUser = function (id, className) {
                var deferred = $q.defer();
                $http.post('/Multimedia/Delete', { id: id, className: className }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.UploadFile = function (file) {
                var formData = new FormData();
                formData.append("file", file);

                var defer = $q.defer();
                $http.post("/Multimedia/UploadFile", formData,
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                    .then(function (returnedData) {
                        defer.resolve(returnedData);
                    },
                    function () {
                        defer.reject("File Upload Failed!");
                    });

                return defer.promise;
            }

            service.DeleteFile = function (id, className) {
                var deferred = $q.defer();
                $http.post('/Multimedia/DeleteCoverPhoto', { id: id, className: className }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            return service;
        }]);
})();