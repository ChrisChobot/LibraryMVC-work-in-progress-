(function () {
    'use strict';

    angular
        .module('app')
        .controller('multimediaController', ['$scope', 'dataService', function ($scope, dataService) {
            $scope.multimedia = [];
            $scope.selectedClass;
            $scope.classes = ["All", "AudioBook", "Game", "MusicRecord", "Book", "Magazine"];
          
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

            $scope.createMultimedia = function (multimedia) {
                dataService.addMultimedia(multimedia).then(function () {
                    $location.path('/');
                });
            };
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
