$(document).ready(function() {
    $("#envia_selecionados").click(function () {
        var convocados = new Array;
       
        $("input[name=Convocado]").each(function () {

            if (this.checked === true) {
                
                convocados.push($(this).val());
            }
            $("#CandidatosSelecionados").val(convocados);
        });
    });
});