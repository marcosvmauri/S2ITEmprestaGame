'use strict';

define([
        'app'
    ],
    function(app) {
        app.register.factory('UsuarioService', ['$http', '$rootScope', '$state', '$localStorage', '$emprestaGameUrl',
            function($http, $rootScope, $state, $localStorage, $emprestaGameUrl) {
                var factory = {};

                var usuario = $localStorage.usuario == undefined ? '' : $localStorage.usuario;
                var token = $localStorage.token == undefined ? '' : $localStorage.token;

                factory.todosUsuario = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Usuario/GetAllUsers',
                            dadosEnvio, {
                                headers: {
                                    Authorization: usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.getUsuario = function() {
                    var dadosEnvio = {
                        login: $localStorage.usuario
                    };

                    return $http.post($emprestaGameUrl + '/Usuario/GetByLogin',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            $localStorage.perfil = data.model.perfil;
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.salvar = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Usuario/Add',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.alterar = function(dadosEnvio) {

                    return $http.put($emprestaGameUrl + '/Usuario/Update',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.excluir = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Usuario/Remove',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.alterarSenha = function(dadosEnvio) {

                    return $http.put($emprestaGameUrl + '/Usuario/AlterarSenha',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                }

                factory.resetarSenha = function(dadosEnvio) {

                    return $http.put($emprestaGameUrl + '/Usuario/ResetarSenha',
                            dadosEnvio, {
                                headers: {
                                    'Authorization': usuario + '|' + token
                                }
                            })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                }
                return factory;
            }
        ]);
    });