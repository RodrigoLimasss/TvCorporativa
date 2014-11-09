function getPontos() {

    var idsPontos = $("#pontosSelecionados li").map(function (i, e) { return { id: $(e).data('id'), ordem: i } }).get();

    $("[id$=idsPontos]").val(JSON.stringify(idsPontos));
}
