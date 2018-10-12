(function () {
    "use strict";
    angular
        .module('mainApp')
        .controller('homeController', homeController);
    homeController.$inject = ['$scope', '$rootScope', 'toastr', 'dataService'];

    function homeController($scope, $rootScope, toastr, dataService) {

        var vm = this;
        vm.$onInit = _init;
        vm.toastr = toastr;
        vm.dataService = dataService;

        vm.searchCondition = "";
        vm.searchImagesClick = _searchImagesClick;
        vm.deleteImageClick = _deleteImageClick;
        vm.seperateData = _seperateData;

        vm.userImages = [];

        function _init() {
        }

        function _searchImagesClick(data) {
            if (data.includes(".")) {
                //Fix problem when sending . character
                data = data + "/";
            }
            vm.dataService.getImages(data)
                .then(_getImagesSuccess, _callFail);
        }
        function _getImagesSuccess(data) {
            vm.seperateData(data.Items);
            console.log(data);
        }

        function _deleteImageClick(data) {
            vm.dataService.deleteImage(data)
                .then(_deleteImageSuccess, _callFail);
            $(event.target).closest('.well').addClass('removed');
            vm.toastr.success("Image Removed");
        }
        function _deleteImageSuccess(data) {
            console.log(data);
        }

        function _callFail(error) {
            console.log(error);
        }

        function _seperateData(data) {
         //Sort image data into an object array with users and their images.    
            let userAdded = [];
            let usersInfo = [];
            for (let i = 0; i < data.length; i++) {
                let userInfo = {
                    Id: "",
                    Name: "",
                    Email: "",
                    Images: [],
                };
                if (userAdded.indexOf(data[i].Id) == -1) {

                    userAdded.push(data[i].Id);

                    userInfo["Id"] = data[i].Id;
                    userInfo["Name"] = data[i].Name;
                    userInfo["Email"] = data[i].Email;

                    usersInfo.push(userInfo);
                }
            }
            for (let i = 0; i < data.length; i++) {
                for (let j = 0; j < usersInfo.length; j++) {
                    let imageInfo = {
                        Image: "",
                        Description:""
                    };
                    if (usersInfo[j].Id == data[i].Id) {
                        imageInfo.Image = data[i].Image;
                        imageInfo.Description = data[i].Description;

                        usersInfo[j].Images.push(imageInfo);
                    }
                }
            }
            vm.userImages = usersInfo;
        }

        //When images are added, homeController will call this to reload the search.
        $rootScope.$on("CallHomeSearchFunction", function () {
            vm.searchImagesClick(vm.searchCondition);
        });
    }
})();