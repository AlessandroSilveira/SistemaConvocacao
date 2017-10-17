$(document).ready(function () {
    $("#painel1").fadeIn(2000);
    

    $("#seguir_painel2").click(function () {
        $("#painel1").fadeOut(1000,
            function () {
                $("#painel2").fadeIn(1000);
            });
    });

    $("#seguir_painel3").click(function () {
        $("#mensagem_painel2").html("");
        var nome = $("#Nome").val();
        if (nome === null || nome === "") {
            $("#mensagem_painel2").html("*O campo Nome não pode estar vazio.");
            return false;
        }
        if (nome.length > 100) {
            $("#mensagem_painel2").html("");
            $("#mensagem_painel2").html("*O campo Nome não pode ter mais que 100 caracteres");
            return false;
        }
        $("#painel2").fadeOut(1000,
            function () {
                $("#painel3").fadeIn(1000);
            });
        return false;
    });
    $("#seguir_painel4").click(function () {
        $("#mensagem_painel3").html("");
        var email = $("#Email").val();
        if (email === null || email === "") {
            $("#mensagem_painel3").html("*O campo E-mail não pode estar vazio.");
            return false;
        }

        if (email.length > 100) {
            $("#mensagem_painel3").html("");
            $("#mensagem_painel3").html("*O campo E-mail não pode ter mais que 100 caracteres");
            return false;
        }

        if (!validacaoEmail(email)) {
            $("#mensagem_painel3").html("*O campo E-mail está inválido.");
            return false;
        }

        $("#painel3").fadeOut(1000,
            function () {
                $("#painel4").fadeIn(1000);
            });
        return false;
    });

    $("#seguir_painel5").click(function () {
        $("#mensagem_painel4").html("");
        var empresa = $("#Empresa").val();
        
        if (empresa === null || empresa === "") {
            $("#mensagem_painel4").html("*O campo Empresa não pode estar vazio.");
            return false;
        }

        if (empresa.length > 50) {
            $("#mensagem_painel4").html("");
            $("#mensagem_painel4").html("*O campo Empresa não pode ter mais que 50 caracteres");
            return false;
        }

        $("#painel4").fadeOut(1000,
            function () {
                $("#painel5").fadeIn(1000);
            });
    });
    $("#seguir_painel6").click(function () {
        $("#mensagem_painel5").html("");
        var cnpj = $("#Cnpj").val();

        if (cnpj === null || cnpj === "") {
            $("#mensagem_paine5").html("*O campo Empresa não pode estar vazio.");
            return false;
        }

        if (validarCNPJ(cnpj)) {
            $("#mensagem_paine5").html("*O CNPJ está inválido.");
            return false;
        }

        $("#painel5").fadeOut(1000,
            function () {
                $("#painel6").fadeIn(1000);
            });
    });
    $("#seguir_painel7").click(function () {
        $("#mensagem_paine6").html("");
        var telefone = $("#Telefone").val();

        if (telefone === null || telefone === "") {
            $("#mensagem_paine6").html("*O campo Telefone não pode estar vazio.");
            return false;
        }

        var telefone1 = telefone.replace("(", "");
        var telefone2 = telefone1.replace(")", "");
        var telefone3 = telefone2.replace("-", "");
        var telefone4 = telefone3.replace(" ", "");

        if (telefone4.length < 11) {
            $("#mensagem_paine6").html("*O campo Telefone está inválido.");
            return false;
        } else {
            $("#Telefone").val(telefone4);
        }


        $("#painel6").fadeOut(1000,
            function () {
                $("#painel7").fadeIn(1000);
            });
    });
    $("#seguir_painel8").click(function () {
        $("#mensagem_paine7").html("");
        var arquivo = $("#Imagem").val();

        if (arquivo === null || arquivo === "") {
            $("#mensagem_paine7").html("*O campo Imagem não pode estar vazio.");
            return false;
        }

        $("#painel7").fadeOut(1000,
            function () {
                $("#painel8").fadeIn(1000);
            });
    });
    $("#seguir_painel9").click(function () {
        $("#mensagem_paine8").html("");
        var senha = $("#Senha").val();

        if (senha === null || senha === "") {
            $("#mensagem_paine8").html("*O campo Senha não pode estar vazio.");
            return false;
        }

        if (senha.length === 0 || senha.lengt < 10) {
            $("#mensagem_paine8").html("*O campo Senha deve ter mais de 1 caractere e menor ou igual a 10 caracteres.");
            return false;
        }

        $("#painel8").fadeOut(1000,
            function () {
                $("#painel9").fadeIn(1000);
            });
    });
    $("#seguir_painel10").click(function() {
        $("#form").submit();
    })
});
function validacaoEmail(field) {
    var er = /^[a-zA-Z0-9][a-zA-Z0-9\._-]+@([a-zA-Z0-9\._-]+\.)[a-zA-Z-0-9]{2,3}/;
    if (!er.exec(field)) {
        return false;
    }
    else {
        return true;
    }
}


function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, "");

    if (cnpj === "") return false;

    if (cnpj.length !== 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj === "00000000000000" ||
        cnpj === "11111111111111" ||
        cnpj === "22222222222222" ||
        cnpj === "33333333333333" ||
        cnpj === "44444444444444" ||
        cnpj === "55555555555555" ||
        cnpj === "66666666666666" ||
        cnpj === "77777777777777" ||
        cnpj === "88888888888888" ||
        cnpj === "99999999999999")
        return false;

    // Valida DVs
    var tamanho = cnpj.length - 2;
    var numeros = cnpj.substring(0, tamanho);
    var digitos = cnpj.substring(tamanho);
    var soma = 0;
    var pos = tamanho - 7;
    var i;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado !== digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado !== digitos.charAt(1))
        return false;

    return true;

}
