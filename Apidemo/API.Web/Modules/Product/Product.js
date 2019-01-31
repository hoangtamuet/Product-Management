
myApp.controller('productsCtrl', function ($scope, $http) {
    var getData = function () {
        $http({
            method: "GET",
            url: "http://localhost:1000/api/products"
        }).then(function (response) {
            $scope.myData = response.data;
            //if (response.data) $scope.msg = "Post Data Submitted Successfully!";
        }, function (error) {
            });
        $scope.iscreate = false;
        $scope.isedit = false;
        $scope.isshow = true;
    }
    getData();

    $scope.postData = function (id, name, price, quantity) {
        var parameter = JSON.stringify({ id: id, name: name, price: price, quantity: quantity });
        $scope.ND = parameter;
        $http.post("http://localhost:1000/api/products/post", parameter).then(function (response) {
            if (response.data) $scope.msg = "Post Data Submitted Successfully!";
            //alert("ss");
            getData();

        }, function (response) {

            $scope.msg = "Service not Exists";

            $scope.statusval = response.status;

            $scope.statustext = response.statusText;

            $scope.headers = response.headers();

        });
    }  
    $scope.editData = function (id, name, price, quantity) {
        var parameter = JSON.stringify({ id: id, name: name, price: price, quantity: quantity });
        $scope.ND = parameter;
        $http.put("http://localhost:1000/api/products/put", parameter).then(function (response) {
            if (response.data) $scope.msg = "Edit Data Submitted Successfully!";
            alert("Success");
            getData();

        }, function (response) {

            $scope.msg = "Service not Exists";

            $scope.statusval = response.status;

            $scope.statustext = response.statusText;

            $scope.headers = response.headers();

        });
    }
    $scope.deleteData = function (id) {
        var url = "http://localhost:1000/api/products/delete/" + id;
        $http.delete(url).then(function (response) {
            if (response.data) $scope.msg = "Delete Data Submitted Successfully!";
            alert("Success");
            getData();

        }, function (response) {

            $scope.msg = "Service not Exists";

            $scope.statusval = response.status;

            $scope.statustext = response.statusText;

            $scope.headers = response.headers();

        });
    }

    $scope.edit = function (id, name, price, quantity) {
        $scope.isshow = false;
        $scope.isedit = true;
        $scope.ide = id;
        $scope.namee = name;
        $scope.pricee = price;
        $scope.quantitye = quantity;
        $scope.edited = true;
    }
    $scope.create = function () {
        $scope.isshow = false;
        $scope.isedit = false;
        $scope.iscreate = true;
    }

});