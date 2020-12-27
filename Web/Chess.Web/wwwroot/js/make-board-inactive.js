$(document).ready(function () {
    connection.on("MakeChessboardInactive", function () {
        $('td').removeAttr('ondrop').removeAttr('ondragover');
        $('i').removeAttr('draggable').removeAttr('ondragstart');
    });
});