(function () {
    "use strict";
    angular
        .module('mainApp')
        .controller('addController', addController);
    addController.$inject = ['$scope', '$rootScope','$timeout', 'toastr', 'dataService'];

    function addController($scope, $rootScope, $timeout, toastr, dataService) {

        var vm = this;
        vm.$scope = $scope;
        vm.$onInit = _init;
        vm.toastr = toastr;
        vm.dataService = dataService;

        vm.inputEmail = "";
        vm.inputName = "";

        function _init() {

        }

        $scope.submitComplete = function () {
            vm.inputEmail = "";
            vm.inputName = "";
            vm.toastr.success("Image Added");
            $rootScope.$emit("CallHomeSearchFunction", {});
        }
    }
})();