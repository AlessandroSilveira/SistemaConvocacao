function AtualizarConvocacao(id) {
    var opcaoConvocacao = $("#opcao_" + id).val(); //("#bkpLoja" + id).html(data);
    var processoId = $("#id").val();

    $.ajax({
        async: true,
        type: "post",
        data: { "opcaoConvocacao": opcaoConvocacao, "processoId": processoId, "ConvocacaoId": id },
        dataType: "json",
        url: "../AtualizarConvocacao",
        success: function (response) {
            if (response !== null) {
                $("#opcao_" + id).val(opcaoConvocacao);
                $("#mensagem_sucesso").trigger("click");
            } else {
                $("#mensagem_erro").trigger("click");
            }
        }
    });
}