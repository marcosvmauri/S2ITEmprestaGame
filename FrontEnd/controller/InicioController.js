'use strict';

define([
    'app'
],
    function (app) {
        app.register.controller('InicioController', ['$scope',
            function ($scope) {

                setTimeout(function () {
                    $('#divConteudo').css('min-height', $(document).height() - 102);
                }, 100);
            }]);
    });