var idPonto;
$(function () {

    idPonto = $("[id$=IdPonto]").val();
    montaPlayer();
    setInterval("VerificaParaSincronizar()", 30000);
});

function montaPlayer() {
    $.ajax({
        type: "GET",
        url: '/api/ApiPlayer/RiWeb/Get/' + idPonto,
        data: '',
        dataType: 'json',
        success: function (data) {
            $("#playList").html(data);

            var object = JSON.parse(data);

            var template = object.template;
            var arrayVideos = object.playLists[0].midias.map(function (e) { return e.Nome + "." + e.Extensao; });
            var index = 0;

            $("body").html(template);

            createPlayerVideo(arrayVideos[0]);
            $("#video1").get(0).play();

            setTimeout(function () {
                setInterval(function () {
                    if ($("#video1").get(0).currentTime == $("#video1").get(0).duration) {
                        index++;
                        if (index == arrayVideos.length)
                            index = 0;

                        createPlayerVideo(arrayVideos[index]);
                        $("#video1").get(0).play();
                    }

                }, 1000);
            }, 2000);

        }
    });
}

function createPlayerVideo(video) {
    $("#video1").remove();
    $("body").find("#playerVideo").append($("<video/>", {
        'id': 'video1',
        'width': '100%',
        'height': '100%',
        'controls': 'true',
        'poster': '<img src="../../../../../img/loading.gif'
    }).append($('<source/>', { 'src': '../../../Files/' + video, 'type': 'video/mp4' })));

}

function VerificaParaSincronizar() {
    $.ajax({
        type: "POST",
        url: '/api/ApiPlayer/RiWeb/VerificaParaSincronizar/' + idPonto,
        data: '',
        dataType: 'json',
        success: function (data) {

            if (data) {
                setInterval(function () {
                    if ($("#video1").get(0).currentTime == $("#video1").get(0).duration) {
                        montaPlayer();
                    }

                }, 1000);
            }

            console.log(data);
        }
    });
}