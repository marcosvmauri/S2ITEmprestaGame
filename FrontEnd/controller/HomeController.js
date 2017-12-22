'use strict';

define([
        'app',
        'angularAnimate',
        'angularModalService',
        'services/UsuarioService',
        'services/LoginService',
        'services/TratarErrosService',
        // 'controller/partial/PopupAlterarSenhaController'
    ],
    function(app) {
        app.register.controller('HomeController', ['$scope', '$state', '$q', '$localStorage',
            'UsuarioService', 'ModalService', 'TratarErrosService', 'LoginService',
            function($scope, $state, $q, $localStorage, UsuarioService, ModalService, TratarErrosService, LoginService) {

                //Variaveis do busy
                $scope.delay = 0;
                $scope.minDuration = 500;
                $scope.message = 'Aguarde...';
                $scope.backdrop = false;
                $scope.promise = null;
                $scope.usuarioLogado = {};

                setTimeout(function() {
                    $('#bodyPrincipal').removeClass();
                    $('#bodyPrincipal').addClass('skin-blue');
                    $('#bodyPrincipal').addClass('sidebar-mini');
                    $('#bodyPrincipal').addClass('wysihtml5-supported');
                    $('#divConteudo').css('min-height', $(document).height() - 102);
                }, 100);

                //CHAMADAS DA VIEW
                $scope.iniciar = function() {
                    $scope.promise = $scope.servicoVerificaUsuario().then(function() {
                        $state.go('home.inicio');
                    });
                }


               
                $scope.logoutClick = function() {
                    $scope.promise = $scope.servicoLogout().then(function() {

                    });
                }

                //CHAMADAS DO SERVICO
                $scope.servicoVerificaUsuario = function() {
                    var q = $q.defer();
                    UsuarioService.getUsuario()
                        .success(function(retorno) {
                            $scope.usuarioLogado = retorno.model;
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.inicio');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoLogout = function() {
                    var q = $q.defer();
                    LoginService.logout()
                        .success(function(retorno) {
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'login');
                            q.reject();
                        });
                    return q.promise;
                }

            }
        ]);
    });