var ProductService = function ($scope, $http) {
    $scope.productParams = {
        productList: [],
        selectedProduct: {}
    };

    var init = function (finish) {
        $http.get("/Api/Products").then(function (response) {
            $scope.productParams.productList = response.data;
            finish();
        });        
    };

    var getProductsByName = function(value, finish) {
        $http.get("/Api/Products?value=" + value).then(function(response) {
            $scope.productParams.productList = response.data;
            finish();
        });
    };

    var getProductsByReference = function(value, finish) {
        $http.get("/Api/Products?reference=" + value).then(function (response) {
            $scope.productParams.productList = response.data;
            finish();
        });
    };

    var createProduct = function(viewModel, finish) {
        $http.post("/Api/Products", viewModel).then(function (response) {
            response.data.category = $.extend(true, {}, $scope.productForm.selectedCategory);
            $scope.productParams.productList.push(response.data);

            finish();
        });
    };

    var updateProduct = function (viewModel, finish) {        
        $http.put("/Api/Products", viewModel).then(function(response) {
            var index = $scope.productParams.productList.indexOf($scope.productForm.selectedProduct);
            $scope.productParams.productList[index] = $.extend(true, {}, response.data);
            $scope.productParams.productList[index].category = $.extend(true, {}, $scope.productForm.selectedCategory);
            finish();
        });
    };

    return {
        init: init,
        createProduct: createProduct,     
        updateProduct: updateProduct,
        getProductsByName: getProductsByName,
        getProductsByReference: getProductsByReference
    };
};