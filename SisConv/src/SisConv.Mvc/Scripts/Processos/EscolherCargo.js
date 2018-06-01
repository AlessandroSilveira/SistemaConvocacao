$(document).ready(function () {
    $("#enviar").click(function () {
        if ($("#cargo").val() === null || $("#cargo").val() === "") {
            $("#mensagem_erro").trigger("click");

        } else {
            $("#form").submit();
        }
    })
})