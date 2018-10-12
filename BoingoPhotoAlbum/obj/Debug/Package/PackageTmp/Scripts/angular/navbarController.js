(function () {
    "use strict";
    angular
        .module('mainApp')
        .controller('navbarController', navbarController);
    navbarController.$inject = ['$scope', 'dataService'];

    function navbarController($scope, dataService) {

        var vm = this;
        vm.$onInit = _init;

        vm.dataService = dataService;

        vm.homeView = _homeView;
        vm.addView = _addView;

        function _init() {


        }

        function _homeView() {

            dataService.changeView(false);
            console.log(dataService.addingPhotos);
        }

        function _addView() {
            dataService.changeView(true);
            console.log(dataService.addingPhotos);
        }

    }
})();