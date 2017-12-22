'use strict';

define([
        'app'
    ],
    function (app) {
        app.register.controller('PopupErroController', ['$scope', '$element',
            function ($scope, $element ) {
                $scope.titulo = $scope.dados.titulo;
                $scope.mensagem = $scope.dados.mensagem;
                $scope.fechar = $scope.dados.fechar;

                $scope.iniciar = function () {
                    $("#btnFechar").focus();
                }

            }
        ]);
    });