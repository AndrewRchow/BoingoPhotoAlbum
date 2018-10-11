(function () {
    angular
        .module("mainApp")
        .factory("dataService", dataService);

    dataService.$inject = ['$http', '$q'];

    function dataService($http, q) {
        var dataObj = {
            addingPhotos: false
            ,changeView: _changeView

            ,getImages: _getImages
        };

        return dataObj

        function _changeView(bool) {
            if (bool==true) {
                dataObj.addingPhotos = true;
            } else {
                dataObj.addingPhotos = false;
            }
        }

        function _getImages(search) {
            return $http.get('/api/images', search).then(handleSuccess).catch(handleError('Error update status'));
        }

        function handleSuccess(response) {
            return response.data;
        };
        function handleError(error) {
            return {
                success: false,
                message: error.data
            }
        };

    

    }


})();