﻿"use strict";

define([
        'app',
        'services/TratarErrosService',
        'services/JogoService'
    ],
    function(app) {
        app.register.controller('JogosEmprestadosController', ['$scope', '$q', 'TratarErrosService', 'JogoService',
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
                    $scope.promise = $scope.servicoBuscarJogosEmprestados().then(function() {
                        $scope.telaAtual == "Lista";
                    });
                }

                $scope.servicoBuscarJogosEmprestados = function() {
                    var q = $q.defer();
                    JogoService.JogosEmprestados()
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



            }
        ]);
    });