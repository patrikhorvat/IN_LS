angular.module('books', [])
    .service('booksSvc', function ($http) {
   
         this.getBooks = function () {
            return $http.get(serviceBase + "api/books");
        }
    })
    .controller('booksOverviewCtrl', function ($scope, booksSvc, $state) {

        $scope.mainGridOptions = {
            dataSource: {
                transport: {
                    read: function (e) {
                        return booksSvc.getBooks().success(function (result) {
                            e.success(result.books);
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
                    title: "Naziv",
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
                    field: "authorsList",
                    title: "Autori",
                    template: "{{dataItem.AuthorsList}}",
                    width: "110px"
                },
                {
                    title: "",
                    width: "250px",
                    template: ' <button type="button" class="btn btn-primary" ng-click="profile(dataItem.id)">Profil</button> <button type="button" class="btn btn-default" ng-click="edit(dataItem.id)">Uredi</button><button type="button" class="btn btn-default ml5" style="margin-left: 5px;" ng-click="delete(dataItem.id)">Obriši</button>'
                }
            ]
        };
    })
  
    .controller('newBookCtrl', function ($scope, booksSvc, userInfoService, $state) {


        $scope.selectOptions = {
            placeholder: "Select products...",
            dataTextField: "ProductName",
            dataValueField: "ProductID",
            autoBind: false,
            dataSource: {
                type: "odata",
                serverFiltering: true,
                transport: {
                    read: {
                        url: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Products",
                    }
                }
            }
        };
        $scope.selectedIds = [4, 7];
        $scope.addSelectedId = function () {
            $scope.selectedIds.push(parseInt($scope.enteredId));
            console.log($scope.selectedIds);
        };

        //$scope.addNewBook = function () {
        //    booksSvc.createBook($scope.book).then(function () {
                
        //    });
        //}

        //$scope.$watch(function () {
        //    console.log("Book", $scope.book);
        //})
    })
    ;