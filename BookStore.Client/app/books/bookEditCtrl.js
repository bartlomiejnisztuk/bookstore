(function () {
    "use strict";

    angular
        .module("booksManagement")
        .controller("BookEditCtrl", ["bookResource", "$scope", "$routeParams", BookEditCtrl]
            );

    function BookEditCtrl(bookResource,$scope, $routeParams) {
        var vm = this;
        vm.book = {};
        vm.message = '';
        console.log($routeParams);
        $scope.formats = [{ name: "paper", id: 1 }, { name: "ebook", id: 2 }];
        bookResource.get({ id: $routeParams.id },
            function (data) {
                vm.book = data;
                console.log("book to edit");
                console.log(data);
                vm.originalBook = angular.copy(data);
            });

        if (vm.book && vm.book.id) {
            vm.title = "Edit: " + vm.book.bookName;
        }
        else {
            vm.title = "New Book";
        }

        vm.submit = function () {
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.book = angular.copy(vm.originalBook);
            vm.message = "";
        };

    }
}());