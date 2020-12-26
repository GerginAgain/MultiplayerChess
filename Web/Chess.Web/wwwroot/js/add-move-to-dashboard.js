$(document).ready(function () {
    connection.on("AddNewMoveToDashboard", function (currentMove, color) {
        let moveColor = "";
        if (color == "blue") {
            moveColor = "text-primary"
        }
        else {
            moveColor = "text-danger"
        }

        var currMove = `<div class="ml-1 ${moveColor}">${currentMove}</div>`;
        $("#moveDashboard").append(currMove);
        var moveDashboard = document.getElementById("moveDashboard");
        moveDashboard.scrollTop = moveDashboard.scrollHeight;
    });
});