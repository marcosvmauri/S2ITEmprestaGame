'use strict';

define([
    'app',
    'services/LoginService',
    'services/TratarErrosService'
],
function (app) {
    app.register.controller('PopupLoginController',
        ['$scope', '$element', '$state', 'LoginService', '$localStorage', '$q', 'TratarErrosService', '$window',
        function ($scope, $element, $state, LoginService, $localStorage, $q, TratarErrosService, $window) {

            $scope.delay = 0;
            $scope.minDuration = 1500;
            $scope.message = 'Aguarde...';
            $scope.backdrop = false;
            $scope.promise = null;

            $scope.fechar = $scope.dados.fechar;
            $scope.origem = $scope.dados.origem;

            setTimeout(function () {
                $scope.verificaLogin();
            }, 10000);

            $scope.verificaLogin = function () {
                if ($localStorage.status == 'A') {
                    $element.css('display', 'none');
                } else {
                    setTimeout(function () {
                        $scope.verificaLogin();
                    }, 10000);
                }
            }

            $scope.formLoginSubmit = function () {
                if ($scope.formLoginSenha.$invalid)
                    return;
                $scope.promise = $scope.chamarServiceLoginLogar().then(function () {
                    $window.location.reload();
                });
            }

            $scope.chamarServiceLoginLogar = function () {
                var q = $q.defer();

                setTimeout(function () {
                    LoginService.login($localStorage.usuario, Sha256.hash($scope.senha))
                        .then(function onSuccess(retorno) {
                            $($element).modal('hide');
                            $state.go($scope.origem);
                            q.resolve();
                        }, function onError(retorno) {
                            TratarErrosService.trataErro(retorno, 'login').then(function () { });
                            q.reject();
                        });
                }, 500);

                return q.promise;
            }

        }]);
});