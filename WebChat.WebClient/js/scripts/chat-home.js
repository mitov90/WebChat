(function () {
    'use strict';

    define(['appSettings', 'jquery', 'PubNub','jqueryStorageApi', 'User'], function (appSettings, $,PubNub, jqueryStorageApi, User) {
        var globalChat = (function () {
            var subscribeKeyUrl = '/api/Notification/GetSubscribeKey';
            var postMessageUrl = '/api/Chat/PostMessage';
            var getMessagesUrl = '/api/Chat/GetMessages';
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
                        notificationManager = PubNub.init(
                            {
                                subscribe_key : data
                            });
                        $("#send-message-button").on("click",sendMessage);
                    },
                    async: false
                });
/*
                notificationManager.subscribe(
                    {
                        channel : $storage.get('email'),
                        message : function(m){alert(m);},
                        connect : function () {notificationManager.publish({channel: $storage.get('email'), message :"User Notification Test"})}
                    }
                );
*/
                notificationManager.subscribe(
                    {
                        channel : 'global',
                        message : function(m){if(m=='new message'){updateMessages();}}
                        //connect : function () {notificationManager.publish({channel: 'global', message :"Global Channel notification"})}
                    }
                );

                updateMessages();
            };


            function updateMessages()
            {
                var $chatMessages = $("#chat-messages");
                $chatMessages.children().remove();
                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    url: appSettings.websiteUrl + getMessagesUrl,
                    success: function (data) {
                        console.log(data);
                        var isOddRow = true;
                        for(var message in data)
                        {
                            $("<div/>").addClass("alert")
                                .addClass(isOddRow ? "alert-info" : "alert-success").attr("role","alert")
                                .css("text-align",isOddRow ? "left" : "right")
                                .html("("+data[message].PostOn +") : "+data[message].Body)
                                .appendTo($chatMessages);
                            isOddRow = !isOddRow;
                        }
                    },
                    async: false
                });
            }

            function sendMessage()
            {

                var messageContainer = $("#TextArea");
                if(messageContainer.val()== "")
                {
                    alert("Message must not be empty");
                }
                else
                {
                    // to fix user authentication, it must be done via sending the token and comparing it on the server side with current active users
                    var message =
                    {
                        "Body" : messageContainer.val()
                    }

                    $.ajax({
                        type: 'POST',
                        crossDomain: true,
                        url: appSettings.websiteUrl + postMessageUrl,
                        data : message,
                        success: function (data) {
                            console.log("Message: "+messageContainer.val() +" send.")
                        },
                        async: false
                    });
                }
            }

            return{
                init: init
            };
        }());

        return globalChat;
    });
}());
