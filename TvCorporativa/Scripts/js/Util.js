$(function () {
    $(".datepiker").datepicker({
        format: "dd/mm/yyyy",
        language: "pt-BR",
        multidate: false,
        keyboardNavigation: false,
        autoclose: true,
        todayHighlight: true
    });

    $(".maskData").mask("99/99/9999");
    $(".maskHora").mask("99:99");

});
