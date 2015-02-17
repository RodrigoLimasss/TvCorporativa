require(["jquery/jquery-1.11.1.min", "dataTables", "responsive", "dataTables.fixedHeader.min"], 
    function ($, dataTables, responsive, fixedHeader) {
    createDataTables();
});

function createDataTables() {
    
    var table = $('#example').dataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/f2c75b7247b/i18n/Portuguese-Brasil.json"
        },
        //"dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
        "pagingType": "full_numbers",
        stateSave: true,
        "stateDuration": 60 * 60 * 24, //1 Dia
        responsive: true,
        "order": [[1, "asc"]],
        //"processing": true,
        //"serverSide": true,
        //"ajax": {
        //    "url": "scripts/post.php",
        //    "type": "POST"
        //},
        "createdRow": function (row, data, index) {
            $('td', row).eq(0).empty().append($("<a />", { text: data.status, 'href': 'http://www.google.com' }));
        },
        "columns": [
            { "data": "status" },
            { "data": "nome" },
            { "data": "nomeAmigavel" },
            { "data": "dataCriacao" },
            { "data": "endereco" },
            { "data": "telefone" },
            { "data": "cnpj" }
        ]
    });
    new $.fn.dataTable.FixedHeader(table);
    //$.fn.dataTable.KeyTable(table);
}