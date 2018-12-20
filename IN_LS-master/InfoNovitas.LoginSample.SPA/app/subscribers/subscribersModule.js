angular.module('subscribers', [])
    .service('subscribersSvc', function ($http) {

        this.getSubscribers = function () {
            return $http.get(serviceBase + "api/subscribers");
        }
    })
    .controller('subscribersOverviewCtrl', function ($scope, subscribersSvc, $state) {

        $scope.mainGridOptions = {
            dataSource: {
                transport: {
                    read: function (e) {
                        return subscribersSvc.getSubscribers().success(function (result) {
                            e.success(result.subscribers);
                        });
                    }
                },
                pageSize: 5,
                serverPaging: true,
                serverSorting: true
            },
            dataBound: function () {
          
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
                    field: "fName",
                    title: "Ime",
                    template: "{{dataItem.fName}}",
                    width: "110px"
                },
                {
                    field: "lName",
                    title: "Prezime",
                    template: "{{dataItem.lName}}",
                    width: "110px"
                },
                {
                    field: "booksReserved",
                    title: "Rezervirane knjige",
                    template: "{{dataItem.booksReserved}}",
                    width: "110px"
                }
            ]
        };
    })

    ;