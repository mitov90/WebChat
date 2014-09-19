(function () {
    'use strict';

    requirejs.config({
        baseUrl: 'js/',
        paths: {
            'jquery': 'libs/jquery',
            'jqueryStorageApi': 'libs/jquery.storageapi',
            'sammy': 'libs/sammy',
            'mustache': 'libs/mustache',
            'sammy.mustache': 'libs/sammy.mustache',
            'appSettings': 'settings',
            'User': 'scripts/user',
            'File': 'scripts/file',
            'Chat': 'scripts/chat-home',
            'PubNub': 'libs/pubnub.min'
        },
        shim: {
            jquery: {
                exports: '$'
            },
            'jqueryStorageApi': ['jquery'],
            'PubNub': {
                exports: "PUBNUB"
            }
//            "jqueryStorageApi": {
//                deps: ["jquery"],
//                exports: "jQuery.fn.localStorage"
//            }
        }
    });

    require(['jquery', 'sammy', 'mustache', 'sammy.mustache', 'User', 'File', 'Chat'], function ($, Sammy, Mustache, SammyMustache, User, File, Chat) {

        Sammy('#main-container', function () {
            this.use(SammyMustache, 'mustache');

            $('#popup-container').hide();


            this.get('#/home', function () {
                this.partial('js/templates/main/welcome.mustache');
            });

            this.get('#/chat-home/:action/', function () {
                var sammyObj = this;
                var events = function () {
                    Chat.init();
                    $('#show-file-upload-popup').click(function () {
                        console.log('aaaaaaaaaaaa');
                        sammyObj.redirect('#/chat-home/:upload/');
                    });
                };

                this.partial('js/templates/main/chat-home.mustache', {}, events);
            });

            this.get('#/login', function () {
                var sammyObj = this;
                var redirectAction = function () {
                    sammyObj.redirect('#/chat-home/:show-chat/');
                };
                var loginFormEvents = function () {
                    var $registerButton = $('#login-button');
                    $registerButton.off();
                    $registerButton.click(function () {
                        var email = $('#email').val();
                        var password = $('#password').val();
                        User.login(email, password, redirectAction);
                    });
                };

                this.partial('js/templates/main/login.mustache', {}, loginFormEvents);
            });

            this.get('#/register', function () {
                var sammyObj = this;
                var redirectAction = function () {
                    sammyObj.redirect('#/chat-home');
                };
                var loginAction = function (email, password) {
                    User.login(email, password, redirectAction);
                };
                var registerFormEvents = function () {
                    var $registerButton = $('#register-button');
                    $registerButton.off();
                    $registerButton.click(function () {
                        var email = $('#email').val();
                        var password = $('#password').val();
                        var confimationPassword = $('#password-confirm').val();
                        User.register(email, password, confimationPassword, loginAction);
                    });
                };

                this.partial('js/templates/main/register.mustache', {}, registerFormEvents);
            });

            this.get('', function () {
                this.partial('js/templates/main/404.mustache');
            });

            this.notFound = function () {
                this.swap('');
            };
        }).run('#/home');


        Sammy('#top-navigation', function () {
            this.use(SammyMustache, 'mustache');

            this.get('#/home', function () {
                this.partial('js/templates/top-bar/nosession-top-navigation.mustache');
            });

            this.get('', function () {
                this.partial('js/templates/top-bar/nosession-top-navigation.mustache');
            });

            this.notFound = function () {
                this.swap('');
            };
        }).run('#/home');

        Sammy('#side-navigation', function () {
            this.use(SammyMustache, 'mustache');

            this.get('#/chat-home/:action/', function () {
                $('#side-navigation').show();
                this.partial('js/templates/sidebar/side-navigation.mustache');
            });

            this.get('', function () {
                $('#side-navigation').hide();
                this.partial('js/templates/sidebar/side-navigation.mustache');
            });

            this.notFound = function () {
                this.swap('');
            };
        }).run('#/home');

        Sammy('#popup-container', function () {
            this.use(SammyMustache, 'mustache');
            var $popUp = $('#popup-container');

            this.get('#/create-chat', function () {
                var users = {users: User.getAllUsers()};

                var displayAction = function () {
                    $popUp.show();
                };

                this.partial('js/templates/popup/chat-room-creation.mustache', users, displayAction);
            });

            this.get('#/chat-home/:action/', function (context) {
                var sammyObj = this;
                var action = context.params['action'];
                if (action == ':upload') {
                    $popUp.show();
                    var callbackAction = function () {
                        $('#upload-file-cancel-button').click(function () {
                            sammyObj.redirect('#/chat-home/:show-chat/')
                        });

                        $('#upload-file-button').click(function () {
                            File.uploadFile($('#file'), function(fileUrl) {
                                console.log(fileUrl);
                            });
                        });
                    };
                    sammyObj.partial('js/templates/popup/file-upload.mustache', {}, callbackAction);
                }
                else {
                    $popUp.hide();
                }
                console.log(context.params['action']);
            });

            this.notFound = function () {
                $popUp.hide();
            };
        }).run('#/home');
    });
}());