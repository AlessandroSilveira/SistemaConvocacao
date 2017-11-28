$(document).ready(function ($) {

    $("#DataEntregaDocumentos").mask("00/00/0000");
    $("#HorarioEntregaDocumento").mask("00:00");


    $("#envia_selecionados").click(function () {
        var convocados = new Array;
       
        $("input[name=Convocado]").each(function () {

            if (this.checked === true) {
                
                convocados.push($(this).val());
            }
            $("#CandidatosSelecionados").val(convocados);
        });
    });

    $("#DataEntregaDocumentos").datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });
});