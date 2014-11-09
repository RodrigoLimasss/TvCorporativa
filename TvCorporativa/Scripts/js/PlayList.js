function getPontosAndMidias() {

    var idsPontos = $("#pontosSelecionados li").map(function (i, e) { return { id: $(e).data('id'), ordem: i } }).get();
    var idsMidias = $("#midiasSelecionadas li").map(function (i, e) { return { id: $(e).data('id'), ordem: i } }).get();

    $("[id$=idsPontos]").val(JSON.stringify(idsPontos));
    $("[id$=idsMidias]").val(JSON.stringify(idsMidias));
}
