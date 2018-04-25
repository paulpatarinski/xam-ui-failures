cordova.define("cordova-plugin-calabash-ios.calabashiOS", function(require, exports, module) {
/*global cordova, module*/

module.exports = {
	 start: function (successCallback, errorCallback) {
        cordova.exec(successCallback, errorCallback, "CalabashiOSServer", "start", []);
    }
};

});
