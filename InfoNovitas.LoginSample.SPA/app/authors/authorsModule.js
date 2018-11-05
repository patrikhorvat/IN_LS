angular.module('authors', [])
    .service('authorsSvc', function ($http) {
        this.getAuthors = function () {
            return $http.get(serviceBase + "api/authors");
        }
        this.getAuthor = function (id) {
            return $http.get(serviceBase + "api/authors/" + id);
        }
        this.deleteAuthor = function (id) {
            return $http.delete(serviceBase + "api/authors/" + id);
        }
        this.createAuthor = function (author) {
            return $http.post(serviceBase + "api/authors", author);
        }
        this.updateAuthor = function (id, author) {
            return $http.put(serviceBase + "api/authors/" + id, author);
        }
    })
    .controller('authorsOverviewCtrl', function ($scope, authorsSvc, $state) {

        $scope.mainGridOptions = {
            dataSource: {
                transport: {
                    read: function (e) {
                        return authorsSvc.getAuthors().success(function (result) {
                            e.success(result.authors);
                        });
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            },
            dataBound: function () {
                var grid = this;
                grid.tbody.find("tr").dblclick(function (e) {
                    var dataItem = grid.dataItem(this);
                    $scope.profile(dataItem.id);
                });
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
                    field: "firstName",
                    title: "Ime",
                    template: "{{dataItem.firstName}}",
                    width: "110px"
                },
                {
                    field: "lastName",
                    title: "Prezime",
                    template: "{{dataItem.lastName}}",
                    width: "110px"
                },
                {
                    field: "birthDate",
                    title: "Datum rođenja",
                    template: "{{dataItem.birthDate|date:'dd.MM.yyyy.'}}",
                    width: "140px"
                },
                {
                    field: "birthPlace",
                    title: "Mjesto rođenja",
                    template: "{{dataItem.birthPlace}}",
                    width: "140px",
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains"
                        }
                    }
                },
                {
                    field: "deathDate",
                    title: "Datum smrti",
                    template: "{{dataItem.deathDate|date:'dd.MM.yyyy.'}}",
                    width: "110px"
                },
                {
                    field: "deathPlace",
                    title: "Mjesto smrti",
                    template: "{{dataItem.deathPlace}}",
                    width: "110px"
                },
                {
                    title: "",
                    width: "250px",
                    template: ' <button type="button" class="btn btn-primary" ng-click="profile(dataItem.id)">Profil</button> <button type="button" class="btn btn-default" ng-click="edit(dataItem.id)">Uredi</button><button type="button" class="btn btn-default ml5" style="margin-left: 5px;" ng-click="delete(dataItem.id)">Obriši</button>'
                }
            ]
        };

        authorsSvc.getAuthors().then(function (result) {
            $scope.authors = result.data.authors;
        }, function () { });

        $scope.delete = function (id) {
            if (window.confirm('Are you sure you want to delete Author?')) {
                authorsSvc.deleteAuthor(id).then(function () {
                    $state.reload();
                })
            } 
        }

        $scope.profile = function (id) {
            $state.go('authorProfile', { id: id });
        }

        $scope.edit = function (id) {
            $state.go('updateAuthor', { id: id });
        }
    })
    .controller('authorProfileCtrl', function ($scope, authorsSvc, $state, $stateParams) {
        authorsSvc.getAuthor($stateParams.id).then(function (result) {
            $scope.author = result.data;
        })
    })
    .controller('newAuthorCtrl', function ($scope, authorsSvc, userInfoService, $state) {
        $scope.author = {
            id: 0,
            birthDate: new Date(1900,0,1)
        };

        $scope.addNewAuthor = function () {
            authorsSvc.createAuthor($scope.author).then(function () {
                $state.go('authorsOverview');
            });
        }

        $scope.$watch(function () {
            console.log("Author", $scope.author);
        })
    })
    .controller('updateAuthorCtrl', function ($scope, authorsSvc, $state, $stateParams) {
        authorsSvc.getAuthor($stateParams.id).then(function (result) {
            $scope.author = result.data;

            $scope.author.birthDate = new Date($scope.author.birthDate);
            $scope.author.deathDate = new Date($scope.author.deathDate);
         
        })

        $scope.updateAuthor = function () {
            authorsSvc.updateAuthor($stateParams.id, $scope.author).then(function () {
                $state.go("authorsOverview");
            });
        }
    });