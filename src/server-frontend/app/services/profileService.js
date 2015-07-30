'use strict';
app.factory('profileService', ['$http', 'isfeSettings', function ($http, isfeSettings) {

    var serviceBase = isfeSettings.apiServiceBaseUri;
    var profileServiceFactory = {};

    var _getProfile = function () {

        return $http.get(serviceBase + 'api/profile').then(function (results) {
            return results;
        });
    };

    profileServiceFactory.getProfile = _getProfile;

    return profileServiceFactory;

}]);