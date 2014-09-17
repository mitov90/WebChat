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
            'File': 'scripts/file'
        },
        shim: {
            jquery: {
                exports: '$'
            },
            'jqueryStorageApi': ['jquery']
//            "jqueryStorageApi": {
//                deps: ["jquery"],
//                exports: "jQuery.fn.localStorage"
//            }
        }
    });

    require(['jquery', 'sammy', 'mustache', 'sammy.mustache', 'User', 'File'], function ($, Sammy, Mustache, SammyMustache, User, File) {
        Sammy('#main-container', function () {
            this.use(SammyMustache, 'mustache');

            $('#popup-container').hide();

            this.get('#/home', function () {
                this.partial('js/templates/main/welcome.mustache');
            });

            this.get('#/chat-home', function () {
                this.partial('js/templates/main/chat-home.mustache');
            });

            this.get('#/upload', function () {
                var sammyObj = this;
                var redirectAction = function(){
//                    sammyObj.redirect('#/login');
                };
                var uploadFormEvents = function () {
                    var $uploadButton = $('#upload-file-button');
                    $uploadButton.off();
                    $uploadButton.click(function () {
                        var file = $('#file').get(0).files;
                        File.uploadFile(file, redirectAction);
                    });
                };
                this.partial('js/templates/main/upload-test.mustache', {}, uploadFormEvents);
            });

            this.get('#/login', function () {
                var sammyObj = this;
                var redirectAction = function(){
                    console.log(sammyObj);
                    sammyObj.redirect('#/chat-home');
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

            this.get('#/chat-home', function () {
                this.partial('js/templates/main/chat-home.mustache');
            });

            this.get('#/register', function () {
                var sammyObj = this;
                var redirectAction = function(){
                    sammyObj.redirect('#/login');
                };
                var registerFormEvents = function () {
                    var $registerButton = $('#register-button');
                    $registerButton.off();
                    $registerButton.click(function () {
                        var email = $('#email').val();
                        var password = $('#password').val();
                        var confimationPassword = $('#password-confirm').val();
                        User.register(email, password, confimationPassword, redirectAction);
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

            this.get('#/chat-home', function () {
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
    });
}());