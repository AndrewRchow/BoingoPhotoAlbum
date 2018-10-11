(function () {
    "use strict";
    angular
        .module('mainApp')
        .controller('homeController', homeController);
    homeController.$inject = ['$scope', 'toastr', 'dataService'];

    function homeController($scope, toastr, dataService) {

        var vm = this;
        vm.$onInit = _init;
        vm.toastr = toastr;
        vm.dataService = dataService;

        vm.search = {SearchCondition:""};
        vm.searchImagesClick = _searchImagesClick;


        function _init() {
           
        }

        function _searchImagesClick(search) {
            console.log(search);
            vm.dataService.getImages(search)
                .then(_getImagesSuccess, _callFail);
        }

        function _getImagesSuccess(data) {
            console.log(data);
        }


        function _callFail(error) {
            console.log(error);
        }
       
    }
})();