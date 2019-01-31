var myApp = angular.module('myApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar']); // muCtrl- main module - depend on ui.router module

myApp.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('products', {
            url: '/products',
            templateUrl: 'Modules/Product/Product.html',
            controller: 'productsCtrl'
        });
    $stateProvider
        .state('customers', {
            url: '/customers',
            templateUrl: 'Modules/Customer/Customer.html',
            controller: 'customersCtrl'
        });
    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: 'Modules/Login/Login.html',
            controller: 'loginCtrl'
        });
    $stateProvider
        .state('signup', {
            url: '/signup',
            templateUrl: 'Modules/Signup/Signup.html',
            controller: 'signupCtrl'
        });
});

myApp.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

myApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

//var app = angular.module('AngularAuthApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar']);

//app.config(function ($stateProvider, $urlRouterProvider) {



//    var helloState = {
//        name: 'home',
//        url: '/home',
//        templateUrl: "/app/views/home.html",
//        controller: "homeController"
//    }

//    var orderState = {
//        name: 'orders',
//        url: '/orders',
//        controller: "ordersController",
//        templateUrl: "/app/views/orders.html"
//    }
//    var loginState = {
//        name: 'login',
//        url: '/login',
//        templateUrl: "/app/views/login.html",
//        controller: "loginController"
//    }
//    $urlRouterProvider.otherwise("/home");
//    $stateProvider.state(helloState);
//    //$stateProvider.state(productState);
//    //$stateProvider.state(customerState);
//    $stateProvider.state(orderState);
//    $stateProvider.state(loginState);

//    //$stateProvider.state("/login", {
//    //    controller: "loginController",
//    //    templateUrl: "/app/views/login.html"
//    //});

//    ////$stateProvider.state("/signup", {
//    ////    controller: "signupController",
//    ////    templateUrl: "/app/views/signup.html"
//    ////});

//    //$stateProvider.state("/orders", {
//    //    controller: "ordersController",
//    //    templateUrl: "/app/views/orders.html"
//    //});

//    $urlRouterProvider.otherwise("/home");
//});
////app.config(function ($httpProvider) {
////    $httpProvider.interceptors.push('authInterceptorService');
////});

//app.run(['authService', function (authService) {
//    authService.fillAuthData();
//}]);