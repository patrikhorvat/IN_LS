angular.module('genres', [])
    .service('genresSvc', function ($http) {

        this.createGenre = function (genre) {
            return $http.post(serviceBase + "api/genres", genre);
        }

        this.getGenres = function () {
            return $http.get(serviceBase + "api/genres");
        }


    })

    .controller('genresOverviewCtrl', function ($scope, genresSvc, $state) {


        $scope.mainGridOptions = {
            dataSource: {
                transport: {
                    read: function (e) {
                        return genresSvc.getGenres().success(function (result) {
                            e.success(result.genres);
                        });
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            },
            dataBound: function () {
              //var grid = this;
                //grid.tbody.find("tr").dblclick(function (e) {
                //    var dataItem = grid.dataItem(this);
                //    $scope.profile(dataItem.id);
                //});
            },
            pageSize: 5,
            scrollable: true,
            sortable: true,
            pageable: true,
            columns: [
                {
               

                    field: "id",
                    title: "ID",
                    template: "{{dataItem.id}}",
                    width: "56px"
                },
                {
                    field: "name",
                    title: "Naslov",
                    template: "{{dataItem.name}}",
                    width: "110px"
                },
                {
                    field: "description",
                    title: "Opis",
                    template: "{{dataItem.description}}",
                    width: "110px"
                },
           
                {
                    title: "",
                    width: "250px",
                    template: ' <button type="button" class="btn btn-default" ng-click="edit(dataItem.id)">Uredi</button><button type="button" class="btn btn-default ml5" style="margin-left: 5px;" ng-click="delete(dataItem.id)">Obriši</button>'
                }
            ]
        };


    })

    .controller('newGenreCtrl', function ($scope, genresSvc, userInfoService, $state) {

        $scope.genre = {
            id: 0

        };

        $scope.addNewGenre = function () {
            genresSvc.createGenre($scope.genre).then(function () {

            });
        }

        $scope.$watch(function () {
            console.log("Genre", $scope.genre);
        })
    })
    ;