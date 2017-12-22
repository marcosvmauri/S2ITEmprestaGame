'use strict';

define(['app'], function(app) {

    app.directive('form', ['ModalService', function(ModalService) {
        return {
            restrict: 'E',
            require: '^form',
            link: function($scope, $element, $attrs, $ctrl) {
                $element.on('submit', function() {
                    $scope.teste = '';

                    if ($scope.form.$invalid) {

                        var dadosPopup = {
                            templateUrl: "view/partial/popupErro.html",
                            controller: "PopupErroController",
                            inputs: {
                                titulo: "Aviso",
                                mensagem: "Existem campos obrigatórios não preenchidos.",
                                fechar: function() {}
                            }
                        }
                        ModalService.showModal(dadosPopup)
                            .then(function(modal) {
                                $(modal.element).modal();
                            });
                    }

                })
            }
        }
    }])

    app.directive('campoObrigatorio', ['$q', function($q) {
        return {
            restrict: 'A',
            require: 'ngModel',
            priority: 2,
            link: function($scope, $element, $attrs, $ctrl) {
                $element.bind('blur', function() {
                    var value = this.value;


                    if (value == '?' || value == '' || value == undefined) {

                        var erros = $element[0].parentNode.getElementsByTagName('small');

                        for (var i = 0; i < erros.length; i++) {
                            $element[0].parentNode.removeChild(erros[0]);
                        }

                        $($element).css('border-color', 'red');
                        $($element).css('background', '#f3b5b5');

                        //Obter texto do label, se houver e adicionar mensagem no small.
                        var msgErro = 'O campo é obrigatório.';
                        if ($($element).parent('.form-group')) {
                            var $lblNomeCampo = $($element).siblings('label');
                            if ($lblNomeCampo) {
                                msgErro = 'O campo ' + $($lblNomeCampo).text() + ' é obrigatório.';
                            }
                        }

                        var $smallMsgErro;
                        if ($($element).siblings('.small-validacao-campo-obrigatorio').length == 0) {
                            $smallMsgErro = $('<small class="small-validacao small-validacao-campo-obrigatorio" style="color: red;"></small>');
                        } else {
                            $smallMsgErro = $($element).siblings('.small-validacao-campo-obrigatorio');
                        }

                        $($smallMsgErro).text(msgErro);
                        $($smallMsgErro).insertAfter($element);

                        $ctrl.$setValidity('campoObrigatorio', false);
                    } else {
                        $($element).css('border-color', '#d2d6de');
                        $($element).css('background', '#fff');

                        //Remover label de validação.
                        if ($($element).parent('.form-group') && $($element).siblings('.small-validacao-campo-obrigatorio').length > 0) {
                            $($element).siblings('.small-validacao-campo-obrigatorio').remove();
                        }

                        $ctrl.$setValidity('campoObrigatorio', true);
                    }
                });
            }
        };
    }]);

    app.directive('cpf', [function() {
        return {
            restrict: 'A',
            require: 'ngModel',
            priority: 1,
            link: function($scope, $element, $attrs, $ctrl) {
                $attrs.$set('maxlength', 14);

                $scope.$watch($attrs['ngModel'], applyMask);

                function applyMask(event) {
                    var value = $element.val().replace(/\D/g, "");
                    value = value.replace(/(\d{3})(\d)/, "$1.$2");
                    value = value.replace(/(\d{3})(\d)/, "$1.$2");
                    value = value.replace(/(\d{3})(\d{1,2})$/, "$1-$2");
                    $element.val(value);
                    if ('asNumber' in $attrs) {
                        $ctrl.$setViewValue(
                            isNaN(parseInt(value.replace(/\D/g, ""), 10)) ?
                            undefined :
                            parseInt(value.replace(/\D/g, ""), 10));
                    } else {
                        $ctrl.$setViewValue(value);
                    }
                }

                $element.bind('blur', function() {
                    var valido;

                    var msgErro = '';

                    var valor = this.value;

                    if (valor.length == 0) {
                        valido = false;
                        msgErro = 'O campo deve ser um CPF é obrigatório.';
                    } else {

                        valor = valor.replace(/\./g, "");
                        valor = valor.replace(/\-/g, "");
                        valor = valor.replace(/\//g, "");

                        valido = CPF(valor);
                        msgErro = 'O campo deve ser um CPF válido.';

                    }
                    //Tratar exibição do campo.
                    if (!valido) {

                        var erros = $element[0].parentNode.getElementsByTagName('small');

                        for (var i = 0; i < erros.length; i++) {
                            $element[0].parentNode.removeChild(erros[0]);
                        }
                        $($element).css('border-color', 'red');
                        $($element).css('background', '#f3b5b5');

                        //Obter texto do label, se houver e adicionar mensagem no small.

                        var $smallMsgErro;
                        if ($($element).siblings('.small-validacao-campo-cnpj').length == 0) {
                            $smallMsgErro = $('<small class="small-validacao small-validacao-campo-cnpj" style="color: red;"></small>');
                        } else {
                            $smallMsgErro = $($element).siblings('.small-validacao-campo-cnpj');
                        }

                        $($smallMsgErro).text(msgErro);
                        $($smallMsgErro).insertAfter($element);

                        $ctrl.$setValidity('cpf', false);
                    } else {
                        $($element).css('border-color', '#d2d6de');
                        $($element).css('background', '#fff');

                        //Remover label de validação.
                        if ($($element).parent('.form-group') && $($element).siblings('.small-validacao-campo-cnpj').length > 0) {
                            $($element).siblings('.small-validacao-campo-cnpj').remove();
                        }

                        $ctrl.$setValidity('cpf', true);
                    }
                });
            }
        };
    }]);

});

function CPF(cpf) {
    var Soma;
    var Resto;
    Soma = 0;
    if (cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;

    for (var i = 1; i <= 9; i++) Soma = Soma + parseInt(cpf.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(cpf.substring(9, 10))) return false;

    Soma = 0;
    for (var i = 1; i <= 10; i++) Soma = Soma + parseInt(cpf.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(cpf.substring(10, 11))) return false;
    return true;
}