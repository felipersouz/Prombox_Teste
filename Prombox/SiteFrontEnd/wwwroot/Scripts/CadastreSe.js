jQuery(document).ready(function () {
    //cep
    function limpa_formulário_cep() {
        $("#bairro").val("");
        $("#cidade").val("");
        $("#uf").val("");
        $("#logradouro").val("");
        $("#complemento").val("");
        $("#numero").val("");
    }
    $("#btnBuscaCep").click(function () {
        var cep = $("#cep").val().replace(/\D/g, '');
        if (cep != "") {
            var validacep = /^[0-9]{8}$/;
            if (validacep.test(cep)) {
                $("#bairro").val("...");
                $("#cidade").val("...");
                $("#uf").val("...");
                $("#logradouro").val("...");
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                    if (!("erro" in dados)) {
                        $("#bairro").val(dados.bairro);
                        $("#cidade").val(dados.localidade);
                        $("#uf").val(dados.uf);
                        $("#logradouro").val(dados.logradouro);

                        var validator = $("#step3").validate();
                        validator.resetForm();
                        $("#numero").focus();

                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        $("#cepErrorNotFound").modal('show');
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                $("#cepErrorNotFound").modal('show');
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
            $("#cepErrorNotFound").modal('show');
        }
    });
    //valida pagina finalizar
    $(function () {
        $('#finalizar').attr('disabled', true);
        $('#step4').change(function () {
            if ($('#senha').val().length >= 6 && $('#senha2').val().length >= 6 && $('#termo1').prop('checked') == true && $('#termo2').prop('checked') == true) {
                $('#finalizar').attr('disabled', false);
            } else {
                $('#finalizar').attr('disabled', true);
            }
        });
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
    
    // Validação step1
    jQuery("#step1").validate({
        rules: {
            cpf: {
                cpf: true,                
                required: true,
                minlength: 14,
            },
            dataNascimento: {
                required: true,
                minlength: 10,
            },
            nomeCompleto: {
                required: true,
                minlength: 6,
                maxlength: 100,
            },
            rg: {
                minlength: 12,
                maxlength: 13,
            },
        },
        messages: {
            cpf: {
                cpf: "Informe um CPF válido",
                required: "Preencha seu CPF",
                minlength: "O Cpf deve conter 11 dígitos",
            },
            dataNascimento: {
                required: "Preencha sua data de Nascimento",
                minlength: "Insira uma data válida",
            },
            nomeCompleto: {
                required: "Preencha seu nome completo",
                minlength: "Seu nome completo necessita ter pelo menos 6 caracteres"
            },
            rg: {
                minlength: "RG inválido",
                maxlength: "RG inválido",
            },
            submitHandler: function (form) {
                alert('ok');
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

    /// Validação step2:
    jQuery("#step2").validate({
        rules: {
            email: {
                minlength: 8,
                required: true,
                email: true,
            },
            telPrincipal: {
                required: true,
                minlength: 14,
                telcheck: true,
                telcheck2: true,
            },
            telRecado: {
                minlength: 14,
                telcheck: true,
                telcheck2: true,
            },
        },
        messages: {

            email: {
                minlength: "Seu e-mail deve conter no mínimo 8 caracteres",
                required: "preencha seu e-mail",
                email: "Insira um e-mail válido",
            },
            telPrincipal: {
                required: "Preencha o seu telefone de contato",
                minlength: "Telefone inválido",
            },
            telRecado: {
                minlength: "Telefone inválido",
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

    //validação step 3:
    jQuery("#step3").validate({
        rules: {
            cep: {
                required: true,
                cep: true,
            },
            logradouro: {
                required: true,
            },
            bairro: {
                required: true,
            },
            numero: {
                required: true,
            },
            cidade: {
                required: true,
            },
            uf: {
                required: true
                //minlength: 2,
            },
        },

        messages: {
            cep: {
                required: "Preencha seu cep",
                cep: "Cep inválido",
            },
            logradouro: {
                required: "Campo Obrigatório",
            },
            bairro: {
                required: "Campo Obrigatório",
            },
            numero: {
                required: "Campo Obrigatório",
            },
            cidade: {
                required: "Campo Obrigatório",
            },
            uf: {
                required: "Campo Obrigatório"
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

    jQuery.validator.addMethod("telcheck", function (value) {
        if (value == "(00) 00000-0000" || value == "(11) 11111-1111" || value == "(22) 22222-2222" || value == "(33) 33333-3333" || value == "(44) 44444-4444" || value == "(55) 55555-5555" || value == "(66) 66666-6666" || value == "(77) 77777-7777" || value == "(88) 88888-8888" || value == "(99) 99999-9999")
            return false;
        else return true;
    },
        "Número Inválido"
    );
    jQuery.validator.addMethod("telcheck2", function (value) {
        if (value == "(00) 0000-0000" || value == "(11) 1111-1111" || value == "(22) 2222-2222" || value == "(33) 3333-3333" || value == "(44) 4444-4444" || value == "(55) 5555-5555" || value == "(66) 6666-6666" || value == "(77) 7777-7777" || value == "(88) 8888-8888" || value == "(99) 9999-9999")
            return false;
        else return true;
    },
        "Número Inválido"
    );
    // validação step4
    jQuery("#step4").validate({
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
            termo1: {
                required: true,
            },
            termo2: {
                required: true,
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
            termo1: {
                required: "Aceite os termos de uso do site",
            },
            termo2: {
                required: "Aceite os termos de uso do site",
            }
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
    //.datepicker config
    $('#dataNascimento').datepicker({
        format: 'dd/mm/yyyy',
        language: "pt-BR",
        defaultViewDate: "today",
        endDate: "today",
        startDate: "01/01/1910",
    });

    //jquery mask step1
    var optionsOnlyletter = {
        'translation': {
            A: {
                pattern: /[A-Za-z]/
            }
        }
    }

    var optionsOnlyNumber = {
        'translation': {
            0: {
                pattern: /[0-9]/
            }
        }
    }

    $("#cpf").mask("000.000.000-00", optionsOnlyNumber);
    $("#rg").mask("00.000.000-00", optionsOnlyNumber);
    $("#rg").change(function (event) {
        if ($(this).val().length == 13) {
            $("#rg").mask("000.000.000-0");
        } else {
            $("#rg").mask("00.000.000-00");
        }
    });
    

    $("#dataNascimento").mask("00/00/0000", optionsOnlyNumber);

    //jquery mask step2
    $('#telPrincipal').mask('(00) 0000-00009');
    $('#telPrincipal').change(function (event) {
        if ($(this).val().length === 15) { // Celular com 9 dígitos + 2 dígitos DDD e 4 da máscara
            $('#telPrincipal').mask('(00) 00000-0009');
        } else {
            $('#telPrincipal').mask('(00) 0000-00009');
        }
    });
    $('#telRecado').mask('(00) 0000-00009');
    $('#telRecado').change(function (event) {
        if ($(this).val().length === 15) { // Celular com 9 dígitos + 2 dígitos DDD e 4 da máscara
            $('#telRecado').mask('(00) 00000-0009');
        } else {
            $('#telRecado').mask('(00) 0000-00009');
        }
    });
    //jquery mask step3
    $("#cep").mask("00000-000", optionsOnlyNumber);
    $("#numero").mask("000000", optionsOnlyNumber);

    $.validator.addMethod("pwcheck", function (value) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(value) // consists of only these
            && /[a-z]/.test(value) // has a lowercase letter
            && /[A-Z]/.test(value) // has a upper letter
            && /\d/.test(value) // has a digit
    });
    //input cidade
    $("#cidade").keypress(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ".indexOf(chr) < 0)
            return false;
    });

    //input rg
    $("#rg").blur(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ".indexOf(chr) > 0)
            $("#rg").val("");
    });
    $('#cidade').bind('cut copy paste', function (event) {
        event.preventDefault();
    });

    //input cep
    jQuery.validator.addMethod("cep", function (value, element) {
        return this.optional(element) || /^[0-9]{5}-[0-9]{3}$/.test(value);
    }, "Por favor, digite um CEP válido");
    $('#cep').bind('cut copy paste', function (event) {
        event.preventDefault();
    });

    //input bairro
    $("#bairro").keypress(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ".indexOf(chr) < 0)
            return false;
    });

    $("#bairro").blur(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("123456789-".indexOf(chr) > 0)
            $("#bairro").val("");
    });
    $('#bairro').bind('cut copy paste', function (event) {
        event.preventDefault();
    });

    //input logradouro
    $("#logradouro").keypress(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ 1234567890".indexOf(chr) < 0)
            return false;
    });

    $("#logradouro").blur(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("'!#$%¨&*()_+=´`{}?/:;><-^~`´".indexOf(chr) > 0)
            $("#logradouro").val("");
    });

    $('#logradouro').bind('cut copy paste', function (event) {
        event.preventDefault();
    });


    // Input nome
    $("#nomeCompleto").keypress(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("abcdefghijklmnopqrstuvxywzABCDEFGHIJKLMNOPQRSTUVXYWZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ".indexOf(chr) < 0)
            return false;
    });

    $("#nomeCompleto").blur(function (e) {
        var chr = String.fromCharCode(e.which);
        if ("123456789-".indexOf(chr) > 0)
            $("#nomeCompleto").val("");
    });

    $('#nomeCompleto').bind('cut copy paste', function (event) {
        event.preventDefault();
    });

    // Analisar: Alguém pode colar um texto com outros caracteres com CTRL+V. Tratar isso também!

    // Sugestão: colocar evento no onBlur() do input

});

function avancar() {

    var atual = $('#hiddenStep').val();

    // Validação
    var isValido = $('#step' + atual).valid();
    if (!isValido) {
        return;
    }

    if (atual < 4) {
        atual++;
        $('#voltar').show();
        $('#hiddenStep').val(atual);
    }

    clickItem(parseInt(atual));
}

function voltar() {
    var atual = $('#hiddenStep').val();

    if (atual > 1) {
        atual--;
        $('#hiddenStep').val(atual);
    }

    clickItem(atual);
}

function finalizar(fake) {
     //Criação do objeto

    var cadastro = {
        "Nome": $('#nomeCompleto').val(),
        "Cpf": $('#cpf').val(),
        "Rg": $('#rg').val(),
        "DataNascimento": $('#dataNascimento').val(),
        "Email": $('#email').val(),
        "TelPrincipal": $('#telPrincipal').val(),
        "TelSecundario": $('#telRecado').val(),
        "Cep": $('#cep').val(),
        "Logradouro": $('#logradouro').val(),
        "Numero": $('#numero').val(),
        "Complemento": $('#complemento').val(),
        "Bairro": $('#bairro').val(),
        "Cidade": $('#cidade').val(),
        "Uf": $('#uf').val(),
        "Senha": $('#senha').val()
    };

     var cadastroFake = {
         "bairro": "Centro",
         "cep": "99230-123",
         "cidade": "Barbacena",
         "complemento": "12345",
         "cpf": "123.456.789-12",
         "dataNascimento": "1999-01-20",
         "email": "teste@teste.com.br",
         "logradouro": "Av. Central",
         "nome": "Fulano de Tal de Souza",
         "numero": "456",
         "rg": "9876543-2",
         "telPrincipal": "9992345647",
         "telSecundario": "212345678",
         "uf": "MG",
         "senha": "123456"
     };

     if (fake)
         cadastro = cadastroFake;

    var objeto = JSON.stringify(cadastro);

    console.log(objeto);

    $.ajax({

        url: "/cadastre-se",
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        data: objeto,
        dataType: "json",
        success: function (xhr, status, response) {
            // modal finalizar cadastro
            $("#cadastroSucessModal").modal('show');
            nomeSpanmodal = $('#nomeCompleto').val(),
            $("#nomeClientemodal").text('Olá, ' + nomeSpanmodal);
       //     window.location.href = response.responseJSON.urlRedirect;
        },
        error: function (err) {

            console.log(err);

            let msg = '';
            for (let i = 0; i < err.responseJSON.errors.length; i++) {
                msg += err.responseJSON.errors[i] + '\n';
            }
            $("#cpfCadastradoModal2").modal('show');
        },
    });
}

function clickItem(numero) {

    switch (numero) {
        case 1:
            activate(2, false);
            activate(3, false);
            activate(4, false);
            activate(1, true);
            setarFoco('#cpf');
            $('#voltar').css("display", "none");
            $('#finalizar').css("display", "none");
            $('#avancar').css("display", "block");
            break;
        case 2:
            activate(1, false);
            activate(3, false);
            activate(4, false);
            activate(2, true);
            setarFoco('#email');
            $('#finalizar').css("display", "none");
            $('#avancar').css("display", "block");
            $('#voltar').css("display", "block");
            break;
        case 3:
            activate(1, false);
            activate(2, false);
            activate(4, false);
            activate(3, true,);
            setarFoco('#cep');
            $('#finalizar').css("display", "none");
            $('#avancar').css("display", "block");
            $('#voltar').css("display", "block");
            break;
        case 4:
            activate(1, false);
            activate(2, false);
            activate(3, false);
            activate(4, true);
            setarFoco('#senha');
            $('#avancar').css("display", "none");
            $('#finalizar').css("display", "block");
            $('#voltar').css("display", "block");
            break;
        default:
            activate(1, false);
            activate(2, false);
            activate(3, false);
            activate(4, false);
            $('#avancar').css("display", "none");
    }
}

function setarFoco(nomeInput) {
    var ua = navigator.userAgent.toLowerCase();
    var isAndroid = ua.indexOf("android") > -1;
    if (!isAndroid) {
        $(nomeInput).focus()
    }
}

function activate(numero, activate) {
    if (activate) {
        $('#item' + numero).css("display", "flex");
        $('#step' + numero).css("display", "block");
        $('#hiddenStep').val(numero);
    }
    else {
        $('#item' + numero).css("display", "none");
        $('#step' + numero).css("display", "none");
    }
}
function CheckCpfJaCadastrado()
{

    var cpf = $("#cpf").val();

    if (cpf.length < 11)
        return;

    var aaa = {"value": cpf};

    var objeto = JSON.stringify(aaa);  

    $.ajax({

        url: "cadastre-se/check-cpf-cadastrado",
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        data: objeto,
        dataType: "json",
        success: function (xhr, status, response) {

            
            if (xhr == true)
            {
                $("#cpfCadastradoModal").modal('show');
            }
            return !xhr;
        },
        error: function (err) {

            return true;
            // let msg = '';
            // for (let i = 0; i < err.responseJSON.errors.length; i++) {
            //     msg += err.responseJSON.errors[i] + '\n';
            // }
            // alert(msg);
        },
    });

    



    var input = document.getElementById("cep");

    // Execute a function when the user releases a key on the keyboard
    input.addEventListener("keyup", function(event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        // Cancel the default action, if needed
        event.preventDefault();
        
        $("#btnBuscaCep").click();
    }
    });
    }

//function MudouCheckBoxTermo() {
//    if ($('#termo1').prop('checked') == true && $('#termo2').prop('checked') == true) {
//        checkTermo = true;
//        console.log(checkTermo);
//    } else {
//        checkTermo = false;
//    }
//}


//cep automatico
//function BuscarCep() {
//    var numCep = $("#cep").val();
//    var url = "https://viacep.com.br/ws/" + numCep + "/json";

//    $.ajax({
//        url: url,
//        type: "get",
//        dataType: "json",

//        success: function (dados) {
//            $("#uf").val(dados.uf);
//            $("#cidade").val(dados.localidade);
//            $("#logradouro").val(dados.logradouro);
//            $("#bairro").val(dados.bairro);

            //var validator = $("#step3").validate();
            //validator.resetForm();


            //$("#numero").focus();

//        },
//        erro: function (erro) {
//            $("#cepErrorNotFound").modal('show');
//        },
//    });
//}
