function AtualizarStatus(id) {
    var opcaoStatus = $("#opcao_" + id).val();
    var processoId = $("#ProcessoId").val();

    $.ajax({
        async: true,
        type: "post",
        data: { "opcaoStatus": opcaoStatus, "processoId": processoId, "convocacaoId": id },
        dataType: "json",
        url: "../AtualizarStatusEstudanteParaContratacao",
        success: function (response) {
            $("#opcao_" + id).val(opcaoStatus);
            if (response !== null) {
                $("#mensagem_sucesso").trigger("click");
            } else {
                $("#mensagem_erro").trigger("click");
            }
        }
    });
}