'use strict';

define([
        'app'
    ],
    function(app) {
        app.register.factory('JogoService', ['$http', '$rootScope', '$state', '$localStorage', '$emprestaGameUrl',
            function($http, $rootScope, $state, $localStorage, $emprestaGameUrl) {
                var factory = {};

                var usuario = $localStorage.usuario == undefined ? '' : $localStorage.usuario;
                var token = $localStorage.token == undefined ? '' : $localStorage.token;

                factory.todosJogo = function() {

                    return $http.get($emprestaGameUrl + '/Jogo/Get', { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.MeusJogos = function() {

                    return $http.get($emprestaGameUrl + '/Jogo/MeusJogos', { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.JogosDisponiveis = function() {

                    return $http.get($emprestaGameUrl + '/Jogo/JogosDisponiveis', { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.JogosEmprestados = function() {

                    return $http.get($emprestaGameUrl + '/Jogo/JogosEmprestados', { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.JogosADevolver = function() {

                    return $http.get($emprestaGameUrl + '/Jogo/JogosADevolver', { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.salvar = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Jogo/Add',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.alterar = function(dadosEnvio) {

                    return $http.put($emprestaGameUrl + '/Jogo/Update',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.excluir = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Jogo/Remove',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.EmprestarJogo = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Jogo/EmprestarJogo',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.DevolverJogo = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Jogo/DevolverJogo',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };

                factory.DevolverJogo = function(dadosEnvio) {

                    return $http.post($emprestaGameUrl + '/Jogo/DevolverJogo',
                            dadosEnvio, { headers: { 'Authorization': usuario + '|' + token } })
                        .success(function(data) {
                            return;
                        })
                        .error(function(data) {
                            return;
                        });
                };


                return factory;
            }
        ]);
    });