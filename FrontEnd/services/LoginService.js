'use strict';

define([
        'app'
    ],
    function(app) {
        app.register.factory('LoginService', ['$http', '$rootScope', '$state', '$localStorage', '$emprestaGameUrl',
            function($http, $rootScope, $state, $localStorage, $emprestaGameUrl) {
                var factory = {};

                var usuario = $localStorage.usuario == undefined ? '' : $localStorage.usuario;
                var token = $localStorage.token == undefined ? '' : $localStorage.token;

                factory.login = function(usuario, senha) {
                    var dadosEnvio = { login: usuario };
                    $localStorage.usuario = usuario;
                    return $http.post($emprestaGameUrl + '/login/logar',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + senha } })
                        .success(function(response) {
                            if (response.mensagem.tipo == 'S') {
                                if ($localStorage.token == undefined) {
                                    $rootScope.$storage = $localStorage.$default({
                                        usuario: usuario,
                                        token: response.model.token,
                                        status: 'A',
                                        perfil: ''
                                    });
                                } else {
                                    $localStorage.usuario = usuario;
                                    $localStorage.token = response.model.token;
                                    $localStorage.status = 'A';
                                }
                            }
                            return response;
                        })
                        .error(function(response) {
                            $localStorage.usuario;
                            return response;
                        });
                };

                factory.verificarLogin = function() {
                    var dadosEnvio = { usuario: $localStorage.usuario == undefined ? '' : $localStorage.usuario };

                    return $http.post($emprestaGameUrl + '/login/verificarLogin',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(response) {
                            return response;
                        })
                        .error(function(response) {
                            return response;
                        });

                };

                factory.verificarSessao = function() {
                    var dadosEnvio = { usuario: $localStorage.usuario == undefined ? '' : $localStorage.usuario };

                    return $http.post($emprestaGameUrl + '/login/verificarSessao',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(response) {
                            return response;
                        })
                        .error(function(response) {
                            return response;
                        });

                };

                factory.logout = function() {
                    var dadosEnvio = { login: $localStorage.usuario };

                    return $http.post($emprestaGameUrl + '/login/logoff',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(response) {
                            delete $localStorage.usuario;
                            delete $localStorage.token;
                            delete $localStorage.status;
                            $state.go('login');
                            return response;
                        })
                        .error(function(response) {
                            return response;
                        });
                };

                return factory;
            }
        ]);
    });