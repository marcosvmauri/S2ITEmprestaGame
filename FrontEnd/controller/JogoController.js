"use strict";

define([
        'app',
        'services/TratarErrosService',
        'services/JogoService'
    ],
    function(app) {
        app.register.controller('JogoController', ['$scope', '$q', 'TratarErrosService', 'JogoService',
            function($scope, $q, TratarErrosService, JogoService) {

                //Variaveis do busy
                $scope.delay = 0;
                $scope.minDuration = 500;
                $scope.message = 'Aguarde...';
                $scope.backdrop = false;
                $scope.promise = null;

                $scope.telaAtual = 'Lista';
                $scope.tituloDetalharJogo = "Editar jogo";
                $scope.jogoSelecionado = {};

                $scope.novoAlterar = '';

                $scope.paginacao = {
                    limite: 15,
                    pagina: 1
                };

                setTimeout(function() {
                    $('#divConteudo').css('min-height', $(document).height() - 102);
                }, 100);

                //CHAMADAS DA VIEW
                $scope.iniciar = function() {
                    $scope.promise = $scope.servicoBuscarMeusJogos().then(function() {
                        $scope.telaAtual == "Lista";
                    });
                }

                $scope.editarJogoClick = function(jogoSelecionado) {
                    $scope.novoAlterar = 'A';
                    $scope.telaAtual = "Detalhe";
                    $scope.tituloDetalharJogo = "Editar jogo";
                    $scope.jogoSelecionado = jogoSelecionado;
                }

                $scope.btnNovoClick = function() {
                    $scope.novoAlterar = 'N';
                    $scope.jogoSelecionado = {};
                    $scope.telaAtual = "Detalhe";
                    $scope.tituloDetalharJogo = "Novo jogo";

                }

                $scope.btnExcluirClick = function() {
                    $scope.telaAtual = "Excluir";
                }

                $scope.btnVoltarExcluirClick = function() {
                    $scope.telaAtual = "Detalhe";
                }

                $scope.btnExcluirJogoClick = function() {
                    $scope.promise = $scope.servicoExcluirJogo().then(function() {
                        $scope.promise = $scope.servicoBuscarMeusJogos().then(function() {
                            $scope.telaAtual = "Lista";
                        });
                    });
                }

                $scope.formSubmit = function() {
                    if ($scope.form.$invalid) {
                        return;
                    }

                    if ($scope.novoAlterar == 'N') {
                        $scope.promise = $scope.servicoSalvarJogo().then(function(retorno) {
                            $scope.promise = $scope.servicoBuscarMeusJogos().then(function() {
                                $scope.telaAtual = "Lista";
                            });
                        });
                    } else {
                        $scope.promise = $scope.servicoAlterarJogo().then(function(retorno) {
                            $scope.promise = $scope.servicoBuscarMeusJogos().then(function() {
                                $scope.telaAtual = "Lista";
                            });
                        });
                    }
                }

                $scope.btnVoltarClick = function() {
                    $scope.promise = $scope.servicoBuscarMeusJogos().then(function() {
                        $scope.telaAtual = "Lista";
                    });
                }

                $scope.servicoBuscarMeusJogos = function() {
                    var q = $q.defer();
                    JogoService.MeusJogos()
                        .success(function(retorno) {
                            $scope.listaJogo = retorno.model;
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.jogo');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoSalvarJogo = function() {
                    var q = $q.defer();
                    JogoService.salvar($scope.jogoSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.jogo');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoAlterarJogo = function() {
                    var q = $q.defer();
                    JogoService.alterar($scope.jogoSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.jogo');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoExcluirJogo = function() {
                    var q = $q.defer();
                    JogoService.excluir($scope.jogoSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.jogo');
                            q.reject();
                        });
                    return q.promise;
                }
            }
        ]);
    });