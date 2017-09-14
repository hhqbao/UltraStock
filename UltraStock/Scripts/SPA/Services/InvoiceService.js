var InvoiceService = function ($scope, $http) {
    $scope.invoiceParams = {
        invoiceList: [],
        selectedInvoice: {}
    };

    var loadInvoicesBySupplier = function (supplierId, finish) {
        $http.get("/Api/Invoices?supplierId=" + supplierId).then(function (response) {
            $scope.invoiceParams.invoiceList = response.data;

            finish();
        });
    };

    var addNewInvoice = function (viewModel, finish) {
        $http.post("/Api/Invoices", viewModel).then(function () {
            finish();
        });
    };

    var updateInvoice = function(viewModel, finish) {
        $http.put("/Api/Invoices", viewModel).then(function() {
            finish();
        });
    };

    var setSelectedInvoice = function (invoice) {
        $scope.invoiceParams.selectedInvoice = invoice;
    };

    var getSelectedInvoice = function () {
        return $scope.invoiceParams.selectedInvoice;
    };

    return {
        loadInvoicesBySupplier: loadInvoicesBySupplier,
        addNewInvoice: addNewInvoice,
        updateInvoice: updateInvoice,
        setSelectedInvoice: setSelectedInvoice,
        getSelectedInvoice: getSelectedInvoice
    };
}