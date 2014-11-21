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