function sincronizarPonto(id) {
    $("#imgLoad" + id).show();
    $.ajax({
        type: "POST",
        url: 'Home/SincronizarPonto',
        data: { idPonto: id },
        dataType: 'json',
        success: function (data) {
            if (data) {
                $("#spanSuccess" + id).fadeIn('slow').text('ponto sincronizado...');
                setTimeout(function () {
                    $("#spanSuccess" + id).fadeOut('slow');
                }, 3000);
            }

            $("#imgLoad" + id).hide();
            console.log(data);
        }
    });
}

function atualizaDropTemplate() {

    $("#msgLoadTemplates").fadeIn('slow');
    $("#IdTemplate").prop("disabled", true);
    $("#IdTemplate option").eq(0).prop("selected", true);

    $.ajax({
        type: "POST",
        url: '/Ponto/AtualizarDropTemplate',
        data: { idEmpresa: $("#IdEmpresa option:selected").val() },
        dataType: 'json',
        success: function (data) {

            $("#IdTemplate").empty();
            $("#IdTemplate").append("<option selected='selected' value='0'>-- Selecione o Template --</option>");

            $.each(data, function(i, e) {
                $("#IdTemplate").append("<option value='" + e['Value'] + "'>" + e['Text'] + "</option>");
            });

            $("#IdTemplate").prop("disabled", false);
            $("#IdTemplate option").eq(0).prop("selected", false);
            $("#msgLoadTemplates").fadeOut('slow');
        }

    });

}