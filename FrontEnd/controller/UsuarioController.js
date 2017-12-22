"use strict";

define([
        'app',
        'services/TratarErrosService',
        'services/UsuarioService'
    ],
    function(app) {
        app.register.controller('UsuarioController', ['$scope', '$q', 'TratarErrosService', 'UsuarioService', '$localStorage',
            function($scope, $q, TratarErrosService, UsuarioService, $localStorage) {

                //Variaveis do busy
                $scope.delay = 0;
                $scope.minDuration = 500;
                $scope.message = 'Aguarde...';
                $scope.backdrop = false;
                $scope.promise = null;



                $scope.telaAtual = 'Lista';
                $scope.tituloDetalharUsuario = "Editar usuário";
                $scope.usuarioSelecionado = {};

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

                    $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                        $scope.telaAtual == "Lista";
                    });
                }

                $scope.editarUsuarioClick = function(usuarioSelecionado) {
                    $scope.novoAlterar = 'A';
                    $scope.telaAtual = "Detalhe";
                    $scope.tituloDetalharUsuario = "Editar usuario";
                    $scope.usuarioSelecionado = usuarioSelecionado;
                }

                $scope.btnNovoClick = function() {
                    $scope.novoAlterar = 'N';
                    $scope.usuarioSelecionado = {};
                    $scope.telaAtual = "Detalhe";
                    $scope.tituloDetalharUsuario = "Novo usuario";

                }

                $scope.btnExcluirClick = function() {
                    $scope.telaAtual = "Excluir";
                }

                $scope.btnVoltarExcluirClick = function() {
                    $scope.telaAtual = "Detalhe";
                }

                $scope.btnExcluirUsuarioClick = function() {
                    $scope.promise = $scope.servicoExcluirUsuario().then(function() {
                        $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                            $scope.telaAtual = "Lista";
                        });
                    });
                }

                $scope.btnResetarSenhaClick = function() {
                    $scope.promise = $scope.servicoResetarSenha().then(function() {
                        $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                            $scope.telaAtual = "Lista";
                        });
                    });
                }



                $scope.formSubmit = function() {
                    if ($scope.form.$invalid) {
                        return;
                    }
                    $scope.usuarioSelecionado.senha = Sha256.hash($scope.usuarioSelecionado.senha);

                    if ($scope.novoAlterar == 'N') {
                        $scope.promise = $scope.servicoSalvarUsuario().then(function(retorno) {
                            $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                                $scope.telaAtual = "Lista";
                            });
                        });
                    } else {
                        $scope.promise = $scope.servicoAlterarUsuario().then(function(retorno) {
                            $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                                $scope.telaAtual = "Lista";
                            });
                        });
                    }
                }

                $scope.btnVoltarClick = function() {
                    $scope.promise = $scope.servicoBuscarTodosUsuarios().then(function() {
                        $scope.telaAtual = "Lista";
                    });
                }

                $scope.servicoBuscarTodosUsuarios = function() {
                    var q = $q.defer();
                    UsuarioService.todosUsuario()
                        .success(function(retorno) {
                            $scope.listaUsuario = retorno.model;
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.usuario');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoSalvarUsuario = function() {
                    var q = $q.defer();
                    UsuarioService.salvar($scope.usuarioSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.usuario');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoAlterarUsuario = function() {
                    var q = $q.defer();
                    UsuarioService.alterar($scope.usuarioSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.usuario');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoResetarSenha = function() {
                    var q = $q.defer();
                    UsuarioService.resetarSenha($scope.usuarioSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.usuario');
                            q.reject();
                        });
                    return q.promise;
                }

                $scope.servicoExcluirUsuario = function() {
                    var q = $q.defer();
                    UsuarioService.excluir($scope.usuarioSelecionado)
                        .success(function(retorno) {
                            TratarErrosService.trataErro(retorno, '');
                            q.resolve();
                        })
                        .error(function(retorno) {
                            TratarErrosService.trataErro(retorno, 'home.usuario');
                            q.reject();
                        });
                    return q.promise;
                }
            }
        ]);
    });