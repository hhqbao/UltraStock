ultraStock.controller("suppliersController", function ($scope, $http) {
    var suppliersService = new SuppliersService($scope, $http);
    var productService = new ProductService($scope, $http);
    var invoiceService = new InvoiceService($scope, $http);

    var showSupplierList = function () {
        $scope.views = {
            supplierList: true
        };
    };

    var showSupplierForm = function () {
        $scope.views = {
            supplierForm: true
        };
    };

    var showInvoiceForm = function () {
        $scope.views.invoiceForm = true;
    };

    var showInvoicePage = function () {
        $scope.views = {
            invoicePage: true
        };
    };

    var finishGettingProducts = function () {
        $scope.invoiceForm.detailForm.products = $scope.productParams.productList;
        $scope.invoiceForm.detailForm.isLoading = false;
    };

    var calculateDetailTotal = function (quantity, price, gst, discountRate) {
        var total = (quantity * price) + gst;

        total = total - ((total * discountRate) / 100);

        return total;
    };

    var calculateInvoiceTotal = function (subTotal, invoiceDiscountRate) {
        var discountAmount = (subTotal * invoiceDiscountRate) / 100;

        return subTotal - discountAmount;
    };

    var resetDetailForm = function () {
        $scope.invoiceForm.detailForm = {
            productId: 0,
            quantity: 0,
            price: 0,
            gst:0,
            discountRate: 0,
            products: []
        };
    };

    var cancelInvoiceForm = function () {
        $scope.invoiceForm = {};

        $scope.views.invoiceForm = false;
    };

    suppliersService.init(showSupplierList);

    $scope.getDateFormat = function (inputValue, inputFormat) {
        return moment(inputValue).format(inputFormat);
    };

    $scope.getMoneyFormat = function (value) {
        return numeral(value).format("$0,0.00");
    };

    $scope.actions = {
        createSupplier: function () {
            $scope.supplierForm = {
                title: "Create New Supplier",
                isAdding: true
            };

            showSupplierForm();
        },
        editSupplier: function (selectedSupplier) {
            suppliersService.setSelectedSupplier(selectedSupplier);
            $scope.supplierForm = {
                title: "Edit Supplier",
                isAdding: false,
                id: selectedSupplier.id,
                name: selectedSupplier.name,
                abn: selectedSupplier.abn,
                acn: selectedSupplier.acn,
                phone: selectedSupplier.phone,
                fax: selectedSupplier.fax,
                mobile: selectedSupplier.mobile,
                address: selectedSupplier.address,
                postAddress: selectedSupplier.postAddress
            };

            showSupplierForm();
        },
        submitForm: function () {
            var viewModel = {
                Name: $scope.supplierForm.name,
                ABN: $scope.supplierForm.abn,
                ACN: $scope.supplierForm.acn,
                Phone: $scope.supplierForm.phone,
                Fax: $scope.supplierForm.fax,
                Mobile: $scope.supplierForm.mobile,
                Address: $scope.supplierForm.address,
                PostAddress: $scope.supplierForm.postAddress
            };

            if ($scope.supplierForm.isAdding === true) {
                suppliersService.createSupplier(viewModel, showSupplierList);
            } else {
                viewModel.Id = $scope.supplierForm.id;
                suppliersService.updateSupplier(viewModel, showSupplierList);
            }
        },
        backToList: function () {
            showSupplierList();
        },
        createNewInvoice: function (selectedSupplier) {
            $scope.invoiceForm = {
                title: "Adding New Invoice",
                isAdding: true,
                detailForm: {
                    productId: 0,
                    quantity: 0,
                    price: 0,
                    gst: 0,
                    discountRate: 0,
                    products: []
                },
                invoiceDetails: [],
                selectedSupplier: selectedSupplier,
                subTotal: 0,
                discountRate: 0,
                total: 0
            };

            showInvoiceForm();
        },
        editInvoice: function (selectedInvoice) {
            invoiceService.setSelectedInvoice(selectedInvoice);

            $scope.invoiceForm = {
                title: "Updating Invoice",
                isAdding: false,
                detailForm: {
                    productId: 0,
                    quantity: 0,
                    price: 0,
                    gst: 0,
                    discountRate: 0,
                    products: []
                },
                id: selectedInvoice.id,
                number: selectedInvoice.number,
                selectedSupplier: suppliersService.getSelectedSupplier(),
                date: new Date(selectedInvoice.date),
                invoiceDetails: selectedInvoice.invoiceDetails,
                subTotal: selectedInvoice.subTotal,
                discountRate: selectedInvoice.discountRate,
                total: selectedInvoice.total
            };

            showInvoiceForm();
        },
        searchProductByReference: function () {
            $scope.invoiceForm.detailForm.productId = 0;
            $scope.invoiceForm.detailForm.description = "";

            if ($scope.invoiceForm.detailForm.reference.length > 3) {
                var value = $scope.invoiceForm.detailForm.reference;
                $scope.invoiceForm.detailForm.isLoading = true;
                productService.getProductsByReference(value, finishGettingProducts);
            } else {
                $scope.invoiceForm.detailForm.products = [];
                $scope.invoiceForm.detailForm.isLoading = null;
            }
        },
        searchProductsByDescription: function () {
            $scope.invoiceForm.detailForm.productId = 0;
            $scope.invoiceForm.detailForm.reference = "";

            if ($scope.invoiceForm.detailForm.description.length > 3) {
                var value = $scope.invoiceForm.detailForm.description;
                $scope.invoiceForm.detailForm.isLoading = true;
                productService.getProductsByName(value, finishGettingProducts);
            } else {
                $scope.invoiceForm.detailForm.products = [];
                $scope.invoiceForm.detailForm.isLoading = null;
            }
        },
        selectProductFromList: function (product) {
            $scope.invoiceForm.detailForm.productId = product.id;
            $scope.invoiceForm.detailForm.reference = product.reference;
            $scope.invoiceForm.detailForm.description = product.description;
            $scope.invoiceForm.detailForm.products = [];
            $scope.invoiceForm.detailForm.isLoading = null;
        },
        isProductAlreadySelected: function (product) {
            for (var i = 0; i < $scope.invoiceForm.invoiceDetails.length; i++) {
                var detail = $scope.invoiceForm.invoiceDetails[i];

                if (product.id === detail.productId) {
                    return true;
                }
            }

            return false;
        },
        addDetailToInvoice: function () {
            var detail = {
                invoiceId: 0,
                productId: $scope.invoiceForm.detailForm.productId,
                quantity: $scope.invoiceForm.detailForm.quantity,
                price: $scope.invoiceForm.detailForm.price,
                gst: $scope.invoiceForm.detailForm.gst,
                discountRate: $scope.invoiceForm.detailForm.discountRate,
                action: 1, //Add new detail to invoice
                product: {
                    reference: $scope.invoiceForm.detailForm.reference,
                    description: $scope.invoiceForm.detailForm.description
                }
            };

            detail.total = calculateDetailTotal(detail.quantity, detail.price, detail.gst, detail.discountRate);

            $scope.invoiceForm.invoiceDetails.push(detail);
            $scope.invoiceForm.subTotal += detail.total;
            $scope.invoiceForm.total = calculateInvoiceTotal($scope.invoiceForm.subTotal, $scope.invoiceForm.discountRate);
            resetDetailForm();
        },
        updateInvoiceTotal: function () {
            $scope.invoiceForm.total = calculateInvoiceTotal($scope.invoiceForm.subTotal, $scope.invoiceForm.discountRate);
        },
        submitInvoiceForm: function () {
            var viewModel = {
                number: $scope.invoiceForm.number,
                date: moment($scope.invoiceForm.date).format("DD MMM YYYY"),
                supplierId: $scope.invoiceForm.selectedSupplier.id,
                invoiceDetails: $scope.invoiceForm.invoiceDetails,
                subTotal: $scope.invoiceForm.subTotal,
                discountRate: $scope.invoiceForm.discountRate,
                total: $scope.invoiceForm.total
            };

            if ($scope.invoiceForm.isAdding === true) {
                invoiceService.addNewInvoice(viewModel, cancelInvoiceForm);
            } else {
                viewModel.id = $scope.invoiceForm.id;

                invoiceService.updateInvoice(viewModel, function () {
                    console.log("Updated Successfully!");
                });
            }
        },
        cancelInvoiceForm: function () {
            cancelInvoiceForm();
        },
        removeInvoiceDetail: function (invoiceDetail) {
            if (invoiceDetail.action === 1) {
                var index = $scope.invoiceForm.invoiceDetails.indexOf(invoiceDetail);
                $scope.invoiceForm.subTotal -= invoiceDetail.total;
                $scope.invoiceForm
                    .total = calculateInvoiceTotal($scope.invoiceForm.subTotal, $scope.invoiceForm.discountRate);

                $scope.invoiceForm.invoiceDetails.splice(index, 1);
            } else {
                invoiceDetail.action = 3;
                $scope.invoiceForm.subTotal -= invoiceDetail.total;
                $scope.invoiceForm.total = calculateInvoiceTotal($scope.invoiceForm.subTotal, $scope.invoiceForm.discountRate);
            }
        },
        restoreInvoiceDetail: function (invoiceDetail) {
            invoiceDetail.action = null;

            $scope.invoiceForm.subTotal += invoiceDetail.total;
            $scope.invoiceForm.total = calculateInvoiceTotal($scope.invoiceForm.subTotal, $scope.invoiceForm.discountRate);
        },
        displayInvoicesFromSupplier: function (supplier) {
            suppliersService.setSelectedSupplier(supplier);

            invoiceService.loadInvoicesBySupplier(supplier.id, function () {
                console.log("Ok");
            });

            showInvoicePage();
        }
    };
});