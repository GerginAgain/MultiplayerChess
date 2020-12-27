$(document).ready(function () {
    document.getElementById("Games").addEventListener("click", addListener);

    function addListener(e) {
        if (e.target !== e.currentTarget) {
            let id = e.target.id;
            window.location.href = `EnterGame/${id}`;
        }

        e.stopPropagation();
    }

    var connection = new signalR.HubConnectionBuilder().withUrl("/chessHub").build();
    connection.start();

    connection.on("AddNewGame", function (gameName, color, gameId) {
        let gamesElement = document.getElementById("Games");

        let newGameElement = document.createElement("div");
        newGameElement.id = gameId;
        newGameElement.className = "getHover container blueborder m-3 p-2 rounded-lg";
        newGameElement.innerHTML = "Game name: " + gameName + "   " + "Figure color: " + color;
        gamesElement.appendChild(newGameElement);

        document.getElementById(`${gameId}`).addEventListener("click", function (e) {
            let id = e.target.id;
            window.location.href = `EnterGame/${id}`;
        });
    });

    connection.on("DeleteGame", function (gameId) {
        let gameToDelete = document.getElementById(gameId);
        gameToDelete.parentNode.removeChild(gameToDelete);
    });
});