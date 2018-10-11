(function () {
    "use strict";
    angular
        .module('mainApp')
        .controller('addController', addController);
    addController.$inject = ['$scope','$timeout', 'toastr', 'dataService'];

    function addController($scope, $timeout, toastr, dataService) {

        var vm = this;
        vm.$onInit = _init;
        vm.toastr = toastr;
        vm.dataService = dataService;


        function _init() {


        }
      

    }
})();