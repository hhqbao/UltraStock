var SuppliersService = function ($scope, $http) {
    $scope.supplierParams = {
        supplierList: [],
        selectedSupplier: {}
    };

    var init = function (finish) {
        $http.get("/Api/Suppliers").then(function (supplierDtos) {
            $scope.supplierParams.supplierList = supplierDtos.data;
            finish();
        });
    };

    var setSelectedSupplier = function(selectedSupplier) {
        $scope.supplierParams.selectedSupplier = selectedSupplier;
    };

    var getSelectedSupplier = function() {
        return $scope.supplierParams.selectedSupplier;
    };

    var createSupplier = function (viewModel, finish) {
        $http.post("/Api/Suppliers", viewModel).then(function (response) {
            $scope.supplierParams.supplierList.push(response.data);
            finish();
        });
    };

    var updateSupplier = function(viewModel, finish) {
        $http.put("/Api/Suppliers", viewModel).then(function(response) {
            var index = $scope.supplierParams.supplierList.indexOf($scope.supplierParams.selectedSupplier);
            $scope.supplierParams.supplierList[index] = response.data;

            finish();
        });
    };

    return {
        init: init,
        createSupplier: createSupplier,
        updateSupplier: updateSupplier,
        setSelectedSupplier: setSelectedSupplier,
        getSelectedSupplier: getSelectedSupplier
    };
};