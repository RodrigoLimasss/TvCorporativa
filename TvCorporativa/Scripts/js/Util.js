﻿$(function () {
    $(".maskData").mask("99/99/9999");
    $(".maskHora").mask("99:99");
    $(".maskTelefone").mask("99 9999-9999");
    $(".maskCnpj").mask("99.999.999/9999-99");

    if ($(".connectedSortable").length > 0)
        $(".connectedSortable").sortable({
            connectWith: ".connectedSortable",
            cursor: 'move',
        }).disableSelection();

    $(".datepiker").datepicker({
        format: "dd/mm/yyyy",
        language: "pt-BR",
        multidate: false,
        keyboardNavigation: false,
        autoclose: true,
        todayHighlight: true
    });
});

