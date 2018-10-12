(function () {
    angular
        .module("mainApp")
        .factory("dataService", dataService);

    dataService.$inject = ['$http', '$q'];

    function dataService($http, q) {
        var dataObj = {
            addingPhotos: false
            ,changeView: _changeView
            , getImages: _getImages
            , deleteImage: _deleteImage
        };

        return dataObj

        function _changeView(bool) {
            if (bool==true) {
                dataObj.addingPhotos = true;
            } else {
                dataObj.addingPhotos = false;
            }
        }

        function _getImages(data) {
            return $http.get('/api/'+ data).then(handleSuccess).catch(handleError('Error update status'));
        }

        function _deleteImage(data) {
            return $http.delete('/api/' + data).then(handleSuccess).catch(handleError('Error update status'));
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