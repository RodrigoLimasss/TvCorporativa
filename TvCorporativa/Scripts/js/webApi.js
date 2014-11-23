var idPonto;
var idEmpresa;
var nomeAmigavel;
var url;

$(function () {

    idPonto = $("[id$=IdPonto]").val();
    nomeAmigavel = $("[id$=NomeAmigavel]").val();
    url = '/api/ApiPlayer/' + nomeAmigavel;

    montaPlayer();
    setInterval("VerificaParaSincronizar()", 30000);
});

function montaPlayer() {
    $.ajax({
        type: "GET",
        url: url + '/Get/' + idPonto,
        data: '',
        dataType: 'json',
        success: function (data) {
            $("#playList").html(data);

            var object = JSON.parse(data);

            idEmpresa = object.idEmpresa;
            nomeAmigavel = object.nomeAmigavel;
            var template = object.template;
            var arrayVideos = object.playLists[0].midias.map(function (e) { return e.Nome + "." + e.Extensao; });
            var index = 0;

            $("body").html(template);

            createPlayerVideo(idEmpresa, arrayVideos[0]);
            $("#video1").get(0).play();

            setTimeout(function () {
                setInterval(function () {
                    if ($("#video1").get(0).currentTime == $("#video1").get(0).duration) {
                        index++;
                        if (index == arrayVideos.length)
                            index = 0;

                        createPlayerVideo(idEmpresa, arrayVideos[index]);
                        $("#video1").get(0).play();
                    }

                }, 1000);
            }, 2000);

        }
    });
}

function createPlayerVideo(idEmpresa, video) {
    $("#video1").remove();
    $("body").find("#playerVideo").append($("<video/>", {
        'id': 'video1',
        'width': '100%',
        'height': '100%',
        'controls': 'true',
        'poster': '<img src="../../../../../img/loading.gif'
    }).append($('<source/>', { 'src': '../../../Files/' + idEmpresa + '/' + video, 'type': 'video/mp4' })));

}

function VerificaParaSincronizar() {
    $.ajax({
        type: "POST",
        url: url + '/VerificaParaSincronizar/' + idPonto,
        data: '',
        dataType: 'json',
        success: function (data) {

            if (data) {
                var intervalVerifica = setInterval(function () {
                    if ($("#video1").get(0).currentTime == $("#video1").get(0).duration) {
                        clearInterval(intervalVerifica);
                        montaPlayer();
                    }

                }, 100);
            }

            console.log(data);
        }
    });
}