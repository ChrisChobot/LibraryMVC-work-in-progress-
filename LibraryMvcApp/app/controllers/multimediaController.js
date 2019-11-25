(function () {
    'use strict';

    angular
        .module('app')
        .controller('multimediaController', ['$scope', 'dataService', function ($scope, dataService) {
            $scope.multimedia = [];
            $scope.selectedClass;
            $scope.displayClasses = ["All", "Audio book", "Game", "Music record", "Book", "Magazine"];
            $scope.realClasses = ["All", "AudioBook", "Game", "MusicRecord", "Book", "Magazine"];

            $scope.sortBy = function (column) {
                $scope.sortColumn = column;
                $scope.reverse = !$scope.reverse;
            };

            $scope.deleteUser = function (id, className) {
                dataService.deleteUser(id, className).then(function () {
                    getData();
                });
            };

            getData();

            function getData() {
                //dataService.getAllData().then(function (result) {
                //    $scope.$watch('searchText', function (term) {
                //        $scope.multimedia = $filter('filter')(result, term, { ClassName: 'searchText' });
                //    });
                //});

                dataService.getAllData().then(function (result) {
                    $scope.multimedia = result;
                });
            }
        }])
        .controller('multimediaAddController', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {

            $scope.classes = ["Audio book", "Game", "Music record", "Book", "Magazine"];
            $scope.SelectedFileForUpload = null;

            $scope.createMultimedia = function (multimedia) {
                dataService.addMultimedia(multimedia, $scope.SelectedFileForUpload).then(function () {
                    $location.path('/');
                });
            };

            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
            }
        }])
        .controller('multimediaEditController', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {
            $scope.multimedia = {};
            $scope.SelectedFileForUpload = null;
            $scope.states = {
                showUpdateButton: false
            };

            dataService.getMultimediaById($routeParams.id, $routeParams.className).then(function (result) {
                $scope.multimedia = result;
                $scope.states.showUpdateButton = true;
            });          

            $scope.updateMultimedia = function (multimedia) {
                dataService.editMultimedia(multimedia, $scope.SelectedFileForUpload).then(function () {
                    $location.path('/');
                });
            };

            $scope.selectFileforUpload = function (file) {
                $scope.SelectedFileForUpload = file[0];
            }
        }])

        .filter('filterByClass', function () {
            return function (items, selectedClass) {
                var filtered = [];

                for (var i = 0; i < items.length; i++) {
                    var item = items[i];

                    if (selectedClass == null || selectedClass == undefined || selectedClass == "All") {
                        filtered.push(item);
                    }
                    else if (item.ClassName == selectedClass) {
                        filtered.push(item);
                    }
                }

                return filtered;
            };
        });
})();
