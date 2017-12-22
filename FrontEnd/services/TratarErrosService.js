'use strict';

define([
        'app',
        'angularAnimate',
        'angularModalService',
        // 'controller/partial/PopupAlterarSenhaController',
        'controller/partial/PopupLoginController',
        'controller/partial/PopupErroController'
    ],
    function(app) {
        app.register.factory('TratarErrosService', ['$http', '$rootScope', 'ModalService', '$localStorage', '$state', '$window',
            function($http, $rootScope, ModalService, $localStorage, $state, $window) {
                var factory = {};

                factory.trataErro = function(dados, origem) {
                    var dadosPopup = {
                        templateUrl: "view/partial/popupErro.html",
                        controller: "PopupErroController",
                        inputs: {}
                    }

                    if (dados == undefined) {
                        if ($localStorage.status == 'F')
                            return;
                        $localStorage.status = 'F';
                        dadosPopup.inputs = {
                            titulo: "Aviso",
                            mensagem: "Servidor OFF-LINE. Tente novamente em alguns instantes. Se o problema persistir, contate o Administrador.",
                            origem: origem,
                            fechar: function() {
                                $localStorage.status = '';
                                $state.go(origem);
                            }
                        }
                    } else if (dados.mensagem.tipo == 'AS') {

                        // $localStorage.token = dados.model.token;
                        // $localStorage.status = '';
                        // dadosPopup.templateUrl = "view/partial/popupAlterarSenha.html";
                        // dadosPopup.controller = "PopupAlterarSenhaController";
                        // dadosPopup.inputs = {
                        //     origem: origem,
                        //     fechar: function() {
                        //         $localStorage.status = 'I';
                        //         $state.go(origem);
                        //     }
                        // };
                    } else if (dados.mensagem.tipo == 'SE') {
                        $window.location.href = 'http://localhost:60318/';
                    } else if (dados.mensagem.tipo == 'T') {

                        $localStorage.status = 'I';
                        dadosPopup.templateUrl = "view/partial/popupLogin.html";
                        dadosPopup.controller = "PopupLoginController";
                        dadosPopup.inputs = {
                            origem: origem,
                            fechar: function() {
                                // $state.go('login');
                                $state.go(origem);
                            }
                        };
                    } else {
                        if (dados.mensagem.codigo == 'E002') {
                            // $localStorage.status = '';
                            // $state.go('login');
                            // return;
                            $state.go(origem);
                        } else {
                            $localStorage.status = '';
                            dadosPopup.inputs = {
                                titulo: dados.mensagem.titulo,
                                mensagem: dados.mensagem.mensagem
                            }
                        }
                    }
                    ModalService.showModal(dadosPopup)
                        .then(function(modal) {
                            $(modal.element).modal();
                        });
                };

                return factory;
            }
        ]);
    });