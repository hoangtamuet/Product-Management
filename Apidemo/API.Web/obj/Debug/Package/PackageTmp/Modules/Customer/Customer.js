
myApp.controller('customersCtrl', function ($scope, $http) {
   
    var getData = function () {
        $http({
            method: "GET",
            url: "http://localhost:1000/api/customers"
        }).then(function (response) {
            $scope.myData = response.data;
        }, function (error) {
        });
    }
    getData();

    $scope.postData = function (id, name) {
        var parameter = JSON.stringify({ id: id, name: name});
        $scope.ND = parameter;
        $http.post("http://localhost:1000/api/customers/post", parameter).then(function (response) { 
            if (response.data) $scope.msg = "Post Data Submitted Successfully!";
            getData();

        }, function (response) {

            $scope.msg = "Service not Exists";

            $scope.statusval = response.status;

            $scope.statustext = response.statusText;

            $scope.headers = response.headers();

        });
    }  
    $scope.editData = function (id, name) {
        var parameter = JSON.stringify({ id: id, name: name});
        $scope.ND = parameter;
        $http.put("http://localhost:1000/api/customers/put", parameter).then(function (response) {
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
        var url = "http://localhost:1000/api/customers/delete/" + id;
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

    $scope.edit = function (id) {
        $scope.isshow = false;
        $scope.isedit = true;
        $scope.ide = id;
        $scope.namee = name;
        $scope.edited = true;
    }
    $scope.create = function () {
        $scope.isshow = false;
        $scope.isedit = false;
        $scope.iscreate = true;
    }

});