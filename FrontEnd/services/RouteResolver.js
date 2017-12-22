'use strict';

define([], function () {

    var RouteResolver = function () {

        this.$get = function () {
            return this;
        };

        this.routeConfig = function () {
            var viewsDirectory = './view/',
                controllersDirectory = 'controller/',

                setBaseDirectories = function (viewsDir, controllersDir) {
                    viewsDirectory = viewsDir;
                    controllersDirectory = controllersDir;
                },

                getViewsDirectory = function () {
                    return viewsDirectory;
                },

                getControllersDirectory = function () {
                    return controllersDirectory;
                };

            return {
                setBaseDirectories: setBaseDirectories,
                getControllersDirectory: getControllersDirectory,
                getViewsDirectory: getViewsDirectory
            };
        }();

        this.route = function (routeConfig) {

            var resolve = function (baseName, path, controllerAs, parametrosRota) {
                if (!path) path = '';

                var routeDef = {};
                var baseFileName = baseName.charAt(0).toLowerCase() + baseName.substr(1);
                routeDef.templateUrl = routeConfig.getViewsDirectory() + path + baseFileName + '.html';

                if (controllerAs) {
                    routeDef.controller = controllerAs + 'Controller';
                }
                else {
                    routeDef.controller = baseName + 'Controller';
                }

                routeDef.url = '/' + baseFileName;
                routeDef.resolve = {
                    loadContentCtrl: ['$q', '$rootScope', function ($q, $rootScope) {
                        // var dependencies = [routeConfig.getControllersDirectory() + path + baseName + 'Controller.js'];
                        var dependencies = [routeConfig.getControllersDirectory() + path + routeDef.controller + '.js'];
                        return resolveDependencies($q, $rootScope, dependencies);
                    }]
                };

                //Criada opção para passar parâmetros pro roteamento.
                if (parametrosRota) {
                    routeDef.params = parametrosRota;
                }

                return routeDef;
            },

                resolveDependencies = function ($q, $rootScope, dependencies) {
                    var defer = $q.defer();
                    require(dependencies, function () {
                        defer.resolve();
                        $rootScope.$apply()
                    });

                    return defer.promise;
                };

            return {
                resolve: resolve
            }
        }(this.routeConfig);

    };

    var servicesApp = angular.module('RouteResolverServices', []);

    //Must be a provider since it will be injected into module.config()    
    servicesApp.provider('RouteResolver', RouteResolver);
});
