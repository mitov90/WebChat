(function () {
    'use strict';

    define(['appSettings', 'jquery', 'User'], function (appSettings, $, user) {
        var files = (function () {
            var fileUpload = '/api/chat/uploadfile';

            var uploadFile = function (file, success) {
                var data = new FormData();
                data.append('fileAttachment', file.get(0).files[0]);

                $.ajax({
                    type: "POST",
                    contentType: false,
                    crossDomain: true,
                    processData: false,
                    url: appSettings.websiteUrl + fileUpload,
                    data: data,
                    success: function (result) {
                        success(result);
                    }});
            };

            return{
                uploadFile: uploadFile
            };
        }());

        return files;
    });
}());