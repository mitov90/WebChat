(function () {
    'use strict';

    define(['appSettings', 'jquery', 'jqueryStorageApi'], function (appSettings, $, jqueryStorageApi) {
        var user = (function () {
            var registerUrl = '/api/Account/Register';
            var loginUrl = '/Token';
            var $storage = $.localStorage;
            var userData = {
                userId: null
            };

            var login = function (email, password, success) {
                var input = {
                    'grant_type': 'password',
                    'username': email,
                    'password': password
                };

                jQuery.support.cors = true;

                $.ajax({
                    type: 'POST',
//                    dataType: 'json',
                    crossDomain: true,
                    url: appSettings.websiteUrl + loginUrl,
                    data: input,
                    success: function (data) {
                        $storage.remove(['isUserLogged', 'sessionToken', 'email', 'expires', 'originalLogInResponse']);
                        $storage.set('isUserLogged', 'true');
                        $storage.set('sessionToken', data.access_token);
                        $storage.set('email', data.userName);
                        $storage.set('expires', data.expires);
                        $storage.set('originalLogInResponse', data);
//                        console.log($storage.get('sessionToken'));
                        success();
                    },
                    async: false
                });
            };

            var isLogged = function () {
                if ($storage.isSet('isUserLogged')) {
                    return true;
                }

                return false;
            };

            var getSessionToken = function () {
                if (isLogged() === true && $storage.isSet('sessionToken')) {
                    return $storage.get('sessionToken');
                }

                throw new Error('User is not logged!');
            };

            var getUserId = function () {
                if (isLogged() === true) {
                    if (userData.userId === null) {
                        userData.userId
                    }
                }

                throw new Error('User is not logged!');
            };

            var register = function (email, password, passwordConfimation, success) {
                var input = {
                    'Email': email,
                    'Password': password,
                    'ConfirmPassword': passwordConfimation
                };

                jQuery.support.cors = true;

                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    crossDomain: true,
                    url: appSettings.websiteUrl + registerUrl,
                    data: input,
                    success: function (data) {
                        success(email, password);
                    },
                    error: function (err) {

                    },
                    async: false
                });
                console.log(email);
                console.log(password);
                console.log(passwordConfimation);
            };

            return{
                register: register,
                login: login,
                getSessionToken: getSessionToken
            };
        }());

        return user;
    });
}());