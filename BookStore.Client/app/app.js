(function() {
    "use strict";
    var app = angular.module("booksManagement", ["common.services", "ngRoute","ngMaterial"]);
    app.config(function($routeProvider) {
        $routeProvider
            .when("/",
                {
                    templateUrl: "app/books/booksListView.html"
                })
            .when("/editBook",
                {
                    templateUrl: "app/books/bookEditView.html"
                });

    });
}());