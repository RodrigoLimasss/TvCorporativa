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
            nomeAmigavel = object.NomeAmigavel;
            var template = object.template;

            if (object.playLists.length == 0) {
                document.write("Ponto sem PlayList");
                return;
            }
            if (object.playLists[0].midias.length == 0) {
                document.write("PlayList sem Mídia");
                return;
            }

            var arrayVideos = object.playLists[0].midias.map(function (e) { return e.Nome + e.Extensao; });
            var index = 0;

            $("body").html(template);

            MontaLogo(object.logo);
            MontaHora();
            MontaFeed();
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
        }
    });
}

function MontaHora() {
    
    var date = new Date();
    $("#hora").text(date.getHours() + ":" + date.getMinutes());

    var intervalHora = setInterval(function () {
        var intervalDate = new Date();
        $("#hora").text(intervalDate.getHours() + ":" + intervalDate.getMinutes());
    }, 60000);
}

function MontaLogo(nameLogo) {
    $("#imgLogo").append($("<img />", { "src": '../../../Files/' + idEmpresa + '/logo/' + nameLogo, "style": "width: 100%;height: 100%;" }));
}

function MontaFeed() {

    var imgFeeds = ["G1_vermelho.png", "G1_vermelho.png", "r7-logo-do-site.jpg", "r7-logo-do-site.jpg"];
    var feeds = ["Prova da Fuvest foi difícil e notas de corte podem cair, dizem professores", "Fuvest divulga gabarito oficial da prova da 1ª fase",
        "R7 e COC fazem correção comentada da Fuvest. Siga!", "Após tropeçar em gato e quebrar a perna, candidata faz Fuvest"];

    $("#imgLogoFeed").append($("<img />", { "src": '../../../../../img/' + imgFeeds[0], "style": "width: 100%;height: 100%;" }));
    $("#noticiaFeed").append($("<label />", { "text": feeds[0] }));

    var index = 0;
    var intervalFeed = setInterval(function () {
        index = index == 3 ? 0 : index+1;
        $("#imgLogoFeed, #noticiaFeed").empty();

        $("#imgLogoFeed").append($("<img />", { "src": '../../../../../img/' + imgFeeds[index], "style": "width: 100%;height: 100%;" }));
        $("#noticiaFeed").append($("<label />", { "text": feeds[index] }));
    }, 10000);
    
}