(function() {
    "use stric";
    angular
        .module("booksManagement")
        .controller("BooksListCtrl", ["bookResource","$scope","$location", BooksListCtrl]);

    function BooksListCtrl(bookResource, $scope, $location) {
        var vm = this;
        $scope.counter = 1;
        vm.bookClicked = function(book) {
            console.log("book clicked");
            console.log(book);
            console.log($scope.counter);
            $scope.counter++;
            $location.path('/editBook/').search({id: book.id});
        }

        bookResource.query({$orderby: "Title"},
            function(data) {
                vm.books = data;
            });
    }
}());