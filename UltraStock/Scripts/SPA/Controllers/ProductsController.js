ultraStock.controller("productsController", function ($scope, $http) {
    var productService = new ProductService($scope, $http);
    var categoryService = new CategoryService($scope, $http);

    var showProductList = function () {
        $scope.views = { productList: true };
        $scope.actions.categoryDropListChange();
    };

    var showProductForm = function () {
        $scope.views = { productForm: true };
    };

    var loadProductService = function () {
        productService.init(showProductList);
    };

    categoryService.init(loadProductService);

    $scope.filterParams = {
        category: {}
    };

    $scope.actions = {
        categoryDropListChange: function () {
            $scope.filterParams.category.id = categoryService.getSelectedCategory().id;
        },

        createProduct: function () {
            $scope.productForm = {
                title: "Create New Product",
                isAdding: true,
                selectedCategory: categoryService.getCategoryList()[0],
                reference: "",
                barCodes: []
            };

            showProductForm();
        },

        editProduct: function (selectedProduct) {
            $scope.productForm = {
                title: "Edit Selected Product",
                isAdding: false,
                selectedProduct: selectedProduct,
                id: selectedProduct.id,
                description: selectedProduct.description,
                selectedCategory: categoryService.getCategoryList()[categoryService.findCategoryIndex(selectedProduct.category)],
                reference: selectedProduct.reference,
                barCodes: $.extend(true, [], selectedProduct.barCodes)
            };

            showProductForm();
        },

        submitProductForm: function () {
            var viewModel = {
                description: $scope.productForm.description,
                categoryId: $scope.productForm.selectedCategory.id,
                reference: $scope.productForm.reference,
                barCodes: $scope.productForm.barCodes
            };

            if ($scope.productForm.isAdding === true) {
                productService.createProduct(viewModel, showProductList);
            } else {
                viewModel.id = $scope.productForm.id;
                productService.updateProduct(viewModel, showProductList);
            }
        },

        addNewBarCode: function () {
            var value = {
                id: 0,
                value: $scope.productForm.newBarCode
            };

            $scope.productForm.barCodes.push(value);

            $scope.productForm.newBarCode = "";
        },

        editBarCode: function (barCode) {
            $scope.productForm.selectedBarCode = barCode;
        },

        saveBarCode: function () {
            $scope.productForm.selectedBarCode = null;
        },

        removeBarCode: function (barCode) {
            if (barCode.id === 0) {
                var index = $scope.productForm.barCodes.indexOf(barCode);

                $scope.productForm.barCodes.splice(index, 1);
            } else {
                barCode.temp = barCode.id;
                barCode.id = -1;
            }
        },

        restoreBarCode: function (barCode) {
            barCode.id = barCode.temp;
            barCode.temp = null;
        },

        goBack: function () {
            showProductList();
        }
    };
});