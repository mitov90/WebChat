(function () {
    'use strict';

    define(['appSettings', 'jquery', 'User'], function (appSettings, $, user) {
        var files = (function () {
            var fileUpload = '/api/chat';

            var uploadFile = function (file, success) {
                var data = new FormData();
                data.append('fileAttachment', file[0]);

                $.ajax({
                    type: "POST",
                    contentType: false,
                    processData: false,
                    url: appSettings.websiteUrl + fileUpload,
                    data: data,
                    success: function (result) {
                        success();
                    }});
            };

            return{
                uploadFile: uploadFile
            };
        }());

        return files;
    });
}());