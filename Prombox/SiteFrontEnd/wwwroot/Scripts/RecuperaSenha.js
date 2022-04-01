jQuery(document).ready(function () {
    //senha validate

    jQuery("#senhaRecuperar").validate({
        rules: {
            senha: {
                required: true,
                rangelength: [6, 12],
                pwcheck: true
            },
            senha2: {
                required: true,
                equalTo: "#senha",
            },
        },
        messages: {
            senha: {
                required: "Campo obrigatório",
                rangelength: "A senha deve conter no mínimo 6 e no máximo 12 caracteres.",
                pwcheck: "A Senha necessita ter de 6 a 12 caracteres, ao menos 1 caracter maiúsculo, ao menos 1 caracter minúsculo e ao menos 1 número!"
            },
            senha2: {
                required: "Campo obrigatório",
                equalTo: "As senhas informadas não coincidem",
            },
        },

        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `invalid-feedback` class to the error element
            error.addClass("invalid-feedback");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.next("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass("is-invalid").removeClass("is-valid");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).addClass("is-valid").removeClass("is-invalid");
        }
    });
    $.validator.addMethod("pwcheck", function (value) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(value) // consists of only these
            && /[a-z]/.test(value) // has a lowercase letter
            && /[A-Z]/.test(value) // has a upper letter
            && /\d/.test(value) // has a digit
    });
    //validação cpf
    jQuery.validator.addMethod("cpf", function (value, element) {
        value = jQuery.trim(value);

        value = value.replace('.', '');
        value = value.replace('.', '');
        cpf = value.replace('-', '');
        while (cpf.length < 11) cpf = "0" + cpf;
        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;
        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }
        if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
        b = 0;
        c = 11;
        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

        var retorno = true;
        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

        return this.optional(element) || retorno;

    }, "Informe um CPF válido");

    var optionsOnlyNumber = {
        'translation': {
            0: {
                pattern: /[0-9]/
            }
        }
    }
    $("#codAuth").mask("000000", optionsOnlyNumber);
    jQuery("#codAutenticar").validate({
        rules: {
            codAuth: {
                required: true,
                maxlength: 6,
                minlength: 6,
            },
        },
        messages: {
            codAuth: {
                required: "Campo Obrigatório",
                maxlength: "O Código deve conter 6 dígitos",
                minlength:  "O Código deve conter 6 dígitos",
            },
        },

        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `invalid-feedback` class to the error element
            error.addClass("invalid-feedback");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.next("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass("is-invalid").removeClass("is-valid");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).addClass("is-valid").removeClass("is-invalid");
        }

    });
    $("#cpf").mask("000.000.000-00", optionsOnlyNumber);

    jQuery("#cpfRecuperarSenha").validate({
        rules: {
            cpf: {
                cpf: true,
                required: true,
                minlength: 14,
            },
        },
        messages: {
            cpf: {
                cpf: "Informe um CPF válido",
                required: "Preencha seu CPF",
                minlength: "O Cpf deve conter 11 dígitos",
            },
        },

        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `invalid-feedback` class to the error element
            error.addClass("invalid-feedback");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.next("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass("is-invalid").removeClass("is-valid");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).addClass("is-valid").removeClass("is-invalid");
        }

    });
});

function recuperar() {
    
    $('#btnEnviar').attr("disabled", "disabled");
    $("#TestSpinner").toggle();

    var recoverModel =
    {
        "cpf": $('#cpf').val()
    };

    var objeto = JSON.stringify(recoverModel);

    $.ajax({

        url: "login/esqueci-minha-senha",
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        data: objeto,
        dataType: "json",
        success: function (xhr, status, response) {
            $("#verificaEmailModal2").modal('show');
            $('#btnEnviar').attr("disabled", "disabled");
            $("#TestSpinner").toggle();
        },
        error: function (err) {
            $("#TestSpinner").toggle();
            //console.log(err);
            $("#cpfInvalid").modal('show');
            $('#btnEnviar').attr("disabled", false);
            let msg = '';
            for (let i = 0; i < err.responseJSON.errors.length; i++) {
                msg += err.responseJSON.errors[i] + '\n';
            }           
        }
    });
}

function codigoAutenticacao() {

    console.log(window.location.href);

    debugger;
    let codeEncrypt = window.location.href.substring(window.location.href.indexOf("codigo-autenticacao") + "codigo-autenticacao?".length);


    var recoverModel =
    {
        "code": parseInt($('#codAuth').val(),10),
        "codeEncrypt" : codeEncrypt
    };

    //console.log(recoverModel);
    var objeto = JSON.stringify(recoverModel);

    $.ajax({

        url: "login/recuperar-senha",
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        data: objeto,
        //dataType: "json",
        success: function (xhr, status, response) {
            $("#verificaEmailModal").modal('show');
            $('#btnEnviar').attr("disabled","disabled");    

        },
        error: function (err) {

            console.log(err);
            let msg = '';
            for (let i = 0; i < err.responseJSON.errors.length; i++) {
                msg += err.responseJSON.errors[i] + '\n';
            }

            $("#loginInvalidModal").modal('show');
        }
    });
}