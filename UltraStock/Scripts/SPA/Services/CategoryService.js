var CategoryService = function($scope, $http) {
    $scope.categoryParams = {
        categoryList: [],        
        selectedCategory: {}
    };

    var init = function(finish) {
        $http.get("/Api/Categories").then(function (response) {
            $scope.categoryParams.categoryList = response.data;            
            $scope.categoryParams.selectedCategory = $scope.categoryParams.categoryList[0];
            finish();
        });
    };

    var getSelectedCategory = function() {
        return $scope.categoryParams.selectedCategory;
    };

    var getCategoryList = function() {
        return $scope.categoryParams.categoryList;
    };

    var findCategoryIndex = function (inputCategory) {
        for (var i = 0; i < $scope.categoryParams.categoryList.length; i++) {
            if ($scope.categoryParams.categoryList[i].id === inputCategory.id) {
                return i;
            }
        }

        return null;
    };

    return {
        init: init,
        getSelectedCategory: getSelectedCategory,
        getCategoryList: getCategoryList,
        findCategoryIndex: findCategoryIndex
    };
};