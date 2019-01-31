'use strict';
myApp.factory('productsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:1000/';
    var productsServiceFactory = {};

    var _getProducts = function () {

        return $http.get(serviceBase + 'api/products').then(function (results) {
            return results;
        });
    };

    productsServiceFactory.getProducts = _getProducts;

    return productsServiceFactory;

}]);