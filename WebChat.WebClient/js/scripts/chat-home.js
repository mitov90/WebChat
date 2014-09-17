(function () {
    'use strict';

    define(['appSettings', 'jquery', 'PubNub','jqueryStorageApi'], function (appSettings, $,PubNub, jqueryStorageApi) {
        var globalChat = (function () {
            var subscribeKeyUrl = '/api/Notification/GetSubscribeKey';
            var publishKeyUrl = '/api/Notification/GetPublishKey';
            var $storage = $.localStorage;
            var notificationManager;

            var init = function()
            {
                jQuery.support.cors = true;

                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    url: appSettings.websiteUrl + subscribeKeyUrl,
                    success: function (data) {
                        var subscribeKey = data;
                        $.ajax({
                            type: 'GET',
                            crossDomain: true,
                            url: appSettings.websiteUrl + publishKeyUrl,
                            success: function (data) {
                                var publishKey = data;
                                notificationManager = PubNub.init(
                                    {
                                        subscribe_key : subscribeKey,
                                        publish_key : publishKey
                                    }
                                );

                            },
                            async: false
                        });
                    },
                    async: false
                });

                notificationManager.subscribe(
                    {
                        channel : $storage.get('email'),
                        message : function(m){alert(m);},
                        connect : function () {notificationManager.publish({channel: $storage.get('email'), message :"User Notification Test"})}
                    }
                )

                notificationManager.subscribe(
                    {
                        channel : 'global',
                        message : function(m){alert(m);},
                        connect : function () {notificationManager.publish({channel: 'global', message :"Global Channel notification"})}
                    }
                )
            }

            return{
                init: init
            };
        }());

        return globalChat;
    });
}());
