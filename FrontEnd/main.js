'use strict';

requirejs.config({
    paths: {
        jquery: 'Scripts/jquery-3.1.1.min',
        jqueryUi: 'Scripts/jquery-ui.min',
        jqueryMask: 'Scripts/jquery.mask.min',
        bootstrap: 'Scripts/bootstrap.min',
        adminlte: 'admin-lte/js/adminlte',
        linq: 'Scripts/linq.min',
        sha256: 'Scripts/Sha256',
        uiBootstrap: 'Scripts/ui-bootstrap-2.2.0.min',
        uiBootstrapTpls: 'Scripts/ui-bootstrap-tpls.min',
        angular: 'Scripts/angular.min',
        angularStorage: 'Scripts/ngStorage.min',
        angularRoute: 'Scripts/angular-route.min',
        angularLocale: 'Scripts/angular-locale_pt-br',
        uiRoute: 'Scripts/angular-ui-router.min',
        angularAnimate: 'Scripts/angular-animate.min',
        angularBusy: 'Scripts/angular-busy.min',
        angularModalService: 'Scripts/angular-modal-service',
        angularAria: 'Scripts/angular-aria.min',
        angularMaterial: 'Scripts/angular-material.min',
        RouteResolver: 'services/RouteResolver',
        mdDataTable: 'Scripts/md-data-table',
        ngTagsInput: 'Scripts/ng-tags-input.min',
        ngSanitize: 'Scripts/angular-sanitize.min'
    },

    shim: {
        jquery: {
            exports: 'jquery'
        },
        jqueryUi: {
            exports: 'jqueryUi'
        },
        jqueryMask: {
            exports: 'jqueryMask'
        },
        angular: {
            exports: 'angular'
        },
        bootstrap: {
            deps: ['jquery', 'angular'],
            exports: 'bootstrap'
        },
        adminlte: {
            deps: ['jquery'],
            exports: 'adminlte'
        },
        angularStorage: {
            deps: ['angular'],
            exports: 'angularStorage'
        },
        angularLocale: {
            deps: ['angular'],
            exports: 'angularLocale'
        },
        linq: {
            deps: ['jquery'],
            exports: 'linq'
        },
        sha256: {
            deps: ['jquery'],
            exports: 'sha256'
        },
        uiBootstrap: {
            deps: ['jquery'],
            exports: 'uiBootstrap'
        },
        uiBootstrapTpls: {
            deps: ['jquery'],
            exports: 'uiBootstrapTpls'
        },
        angularAnimate: {
            deps: ['angular'],
            exports: 'angularAnimate'
        },
        angularModalService: {
            deps: ['angular', 'angularAnimate'],
            exports: 'angularModalService'
        },
        angularBusy: {
            deps: ['angular'],
            exports: 'angularBusy'
        },
        uiRoute: {
            deps: ['angular'],
            exports: 'uiRoute'
        },
        RouteResolver: {
            deps: ['angular'],
            exports: 'RouteResolver'
        },
        angularAria: {
            deps: ['angular'],
            exports: 'angularAria'
        },
        angularMaterial: {
            deps: ['angular', 'angularAria'],
            exports: 'angularMaterial'
        },
        mdDataTable: {
            deps: ['angular', 'angularMaterial', 'angularAria'],
            exports: 'mdDataTable'
        },
        ngTagsInput: {
            deps: ['angular', 'angularMaterial', 'angularAria'],
            exports: 'ngTagsInput'
        },
        ngSanitize: {
            deps: ['angular'],
            exports: 'ngSanitize'
        }
    }
});

require([
    'app',
    'jquery',
    'jqueryUi',
    'jqueryMask',
    'angular',
    'bootstrap',
    'adminlte',
    'linq',
    'sha256',
    'uiBootstrap',
    'uiBootstrapTpls',
    'angularBusy',
    'angularStorage',
    'angularLocale',
    'uiRoute',
    'angularAnimate',
    'angularAria',
    'angularMaterial',
    'angularModalService',
    'mdDataTable',
    'ngTagsInput',
    'ngSanitize',
    'diretive/diretive'
],
    function () {
        angular.bootstrap(document, ['emprestaGame']);
    });