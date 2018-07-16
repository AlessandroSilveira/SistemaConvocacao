$(function () {
    $("#Telefone").mask("(00)00000-0000");
    $("#Recados").mask("(00)00000-0000");
    $("#Celular").mask("(00)00000-0000");
    $("#TelefoneIES").mask("(00)00000-0000");
    $("#DataNascimento").mask("00/00/0000");
    $("#PeriodoAtual").mask("00/0000");
    $("#ColacaoGrau").mask("00/0000"); 
    $("#HorarioAulaIes").mask("00:00");

    $("#DataNascimento").datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

    if ($("#modal").val() === "True") {
        $("#mensagem_sucesso").trigger("click");
    }

});

