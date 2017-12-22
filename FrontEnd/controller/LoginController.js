"use strict";

define([
        'app',
        'services/LoginService',
        'services/TratarErrosService'
    ],
    function(app) {
        app.register.controller('LoginController', ['$scope', 'LoginService', '$q', 'TratarErrosService', '$state',
            function($scope, LoginService, $q, TratarErrosService, $state) {

                //Variaveis do busy
                $scope.delay = 0;
                $scope.minDuration = 1500;
                $scope.message = 'Aguarde...';
                $scope.backdrop = false;
                $scope.promise = null;

                $scope.iniciar = function() {
                    //$scope.promise = $scope.chamarServiceVerificarLogin().then(function () { });
                }

                $scope.chamarServiceVerificarLogin = function() {
                    var q = $q.defer();

                    setTimeout(function() {
                        LoginService.verificarLogin()
                            .success(
                                function onSuccess(retorno) {
                                    if (retorno.mensagem.tipo == 'S') {
                                        $state.go('home');
                                        q.resolve();
                                    } else {
                                        q.reject();
                                    }
                                })
                            .error(function(retorno) {
                                q.reject();
                            });
                    }, 500);

                    return q.promise;
                }

                $scope.formLoginSubmit = function() {
                    if ($scope.formLoginSenha.$invalid)
                        return;
                    $scope.promise = $scope.chamarServiceLoginLogar().then(function() {
                        $state.go('home');
                    });
                }

                $scope.chamarServiceLoginLogar = function() {
                    var q = $q.defer();

                    setTimeout(function() {
                        LoginService.login($scope.usuario, Sha256.hash($scope.senha))
                            .success(function(retorno) {
                                if (retorno.mensagem.tipo == 'S') {
                                    $state.go('home');
                                    q.resolve();
                                } else {
                                    TratarErrosService.trataErro(retorno, 'login');
                                    q.reject();
                                }
                            })
                            .error(function(retorno) {
                                TratarErrosService.trataErro(retorno, 'login');
                                q.reject();
                            });
                    }, 500);

                    return q.promise;
                }
            }
        ])
    });