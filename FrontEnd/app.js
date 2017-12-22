"use strict";

define([
        'RouteResolver',
        'angularModalService'
    ],
    function() {
        var app = angular.module('emprestaGame', ['ui.router', 'RouteResolverServices', 'ngStorage', 'angularModalService', 'cgBusy', 'ngMaterial', 'md.data.table']);

        app.config(['$stateProvider', '$urlRouterProvider', 'RouteResolverProvider', '$controllerProvider', '$compileProvider', '$filterProvider', '$provide', '$httpProvider',
            function($stateProvider, $urlRouterProvider, RouteResolverProvider, $controllerProvider, $compileProvider, $filterProvider, $provide, $httpProvider) {

                app.register = {
                    controller: $controllerProvider.register,
                    directive: $compileProvider.directive,
                    filter: $filterProvider.register,
                    factory: $provide.factory,
                    service: $provide.service
                };

                var route = RouteResolverProvider.route;

                $stateProvider
                    .state('login', route.resolve('Login', ''))
                    .state('home', route.resolve('Home', ''))
                    .state('home.inicio', route.resolve('Inicio', ''))
                    .state('home.jogo', route.resolve('Jogo', ''))
                    .state('home.jogosADevolver', route.resolve('JogosADevolver', ''))
                    .state('home.jogosDisponiveis', route.resolve('JogosDisponiveis', ''))
                    .state('home.jogosEmprestados', route.resolve('JogosEmprestados', ''))
                    .state('home.usuario', route.resolve('Usuario', ''))
                $urlRouterProvider.otherwise('login');

            }
        ]);
        app.value('$emprestaGameUrl', 'http://localhost:52490/api');

        return app;
    });