$(function () {

    var idPonto = $("[id$=IdPonto]").val();

    $.ajax({
        type: "POST",
        url: '/api/ApiPlayer/RiWeb/Teste/' + idPonto,
        data: '',
        dataType: 'json',
        success: function (data) {
            $("#playList").html(data);
        }
    });
});