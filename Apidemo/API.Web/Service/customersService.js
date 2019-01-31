'use strict';
myApp.factory('customersService', ['$http', function ($http) {
    
    var serviceBase = 'http://localhost:1000/';
    var customersServiceFactory = {};

    var _getCustomers = function () {

        return $http.get(serviceBase + 'api/customers').then(function (results) {
            return results;
        });
    };

    customersServiceFactory.getCustomers = _getCustomers;

    return customersServiceFactory;

}]);